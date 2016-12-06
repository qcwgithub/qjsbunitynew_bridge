using UnityEngine;
using UnityEditor;
using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace jsb
{
    class CSWrapGenerator
    {
        static void GenDelegate(Type type, TypeStatus ts,
                            Func<Type, TypeStatus> getParent, Action<Type> onNewType)
        {
            TextFile tfFile = null;
            if (type.DeclaringType != null)
            {
                ts.IsInnerType = true;

                TypeStatus tsParent = getParent(type.DeclaringType);
                if (tsParent == null || tsParent.status == TypeStatus.Status.Wait)
                {
                    return;
                }

                if (tsParent.status == TypeStatus.Status.Ignored)
                {
                    ts.status = TypeStatus.Status.Ignored;
                    return;
                }

                tfFile = tsParent.tf.FindByTag("epos");
            }

            if (tfFile == null)
                tfFile = new TextFile();

            ts.tf = tfFile;
            ts.status = TypeStatus.Status.Exported;

            StringBuilder sb = new StringBuilder();
            TextFile tfNs = tfFile;

            if (type.DeclaringType == null && 
                !string.IsNullOrEmpty(type.Namespace))
            {
                tfNs = tfFile.Add("namespace {0}", type.Namespace).BraceIn();
                tfNs.BraceOut();
            }

            if (type.IsPublic || type.IsNestedPublic)
                sb.Append("public ");

            sb.Append("delegate ");

            MethodInfo method = type.GetMethod("Invoke");
            sb.Append(typefn(method.ReturnType, type.Namespace));
            sb.Append(" ");
            onNewType(method.ReturnType);

            ParameterInfo[] ps = method.GetParameters();
            {
                sb.AppendFormat("{0}({1});", 
				                // type.Name, 
				                typefn(type, "no-namespace", CsNameOption.CompilableWithT),
				                Ps2String(type, ps));

                foreach (var p in ps)
                    onNewType(p.ParameterType);
            }

            tfNs.Add(sb.ToString());
        }

		static void GenEnum(Type type, TypeStatus ts, 
		                    Func<Type, TypeStatus> getParent, Action<Type> onNewType)
		{
			TextFile tfFile = null;
			if (type.DeclaringType != null)
			{
				onNewType(type.DeclaringType);
				ts.IsInnerType = true;

				TypeStatus tsParent = getParent(type.DeclaringType);
				if (tsParent == null || tsParent.status == TypeStatus.Status.Wait)
				{
					return;
				}
				
				if (tsParent.status == TypeStatus.Status.Ignored)
				{
					ts.status = TypeStatus.Status.Ignored;
					return;
				}

				tfFile = tsParent.tf.FindByTag("epos");
			}

			if (tfFile == null)
				tfFile = new TextFile();

			ts.tf = tfFile;
			ts.status = TypeStatus.Status.Exported;

            //GeneratorHelp.ATypeInfo ti = GeneratorHelp.CreateTypeInfo(type);

            StringBuilder sb = new StringBuilder();
            TextFile tfNs = tfFile;

			if (type.DeclaringType == null && 
			    !string.IsNullOrEmpty(type.Namespace))
            {
                tfNs = tfFile.Add("namespace {0}", type.Namespace).BraceIn();
                tfNs.BraceOut();
            }

            tfNs.Add("[Bridge.FileName(\"csw\")]");

            Type uType = Enum.GetUnderlyingType(type);
            TextFile tfClass = null;
            sb.Remove(0, sb.Length);
            {
                if (type.IsPublic || type.IsNestedPublic)
                    sb.Append("public ");

                sb.Append("enum ");
                sb.Append(type.Name);
                if (uType != typeof(int))
                    sb.AppendFormat(" : {0}", uType.CsFullName());

                tfClass = tfNs.Add(sb.ToString()).BraceIn();
                tfClass.BraceOut();
            }

			FieldInfo[] fields = type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static);
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo field = fields[i];
                string v = "";
                if (uType == typeof(ulong))
                    v = System.Convert.ToUInt64(field.GetValue(null)).ToString();
                else
                    v = System.Convert.ToInt64(field.GetValue(null)).ToString();

				tfClass.Add("{0} = {1},", field.Name, v);
			}
        }

		static string typefn(Type tType, string eraseNs, CsNameOption opt = CsNameOption.Compilable)
		{
			string fn = JSNameMgr.CsFullName(tType, opt);
			if (eraseNs == "no-namespace")
			{
				int dot = fn.LastIndexOf('.');
				if (dot >= 0)
				{
					fn = fn.Substring(dot + 1);
				}
			}
			else if (!string.IsNullOrEmpty(eraseNs) &&
			    fn.StartsWith(eraseNs + "."))
			{
				fn = fn.Substring(eraseNs.Length + 1);
			}
			return fn;
		}

		static string Ps2String(Type type, ParameterInfo[] ps, bool hasExtensionAttribute = false)
		{
			args f_args = new args();
			for (int j = 0; j < ps.Length; j++)
			{
				ParameterInfo p = ps[j];
				string s = "";
                if (j == 0 && hasExtensionAttribute)
                {
                    s += "this ";
                }
				if (p.ParameterType.IsByRef)
				{
					if (p.IsOut)
						s += "out ";
					else
						s += "ref ";
				}
				if (ParameterIsParams(p))
					s += "params ";
				s += typefn(p.ParameterType, p.ParameterType.DeclaringType == type ? "no-namespace" : type.Namespace) + " ";
				s += p.Name;
				f_args.Add(s);
			};
			return f_args.ToString();
		}

		static string MethodNameString(Type type, MethodInfo method)
		{
			if (method.IsSpecialName)
			{
				switch (method.Name)
				{
				case "op_Addition": return "operator +";
				case "op_Subtraction": return "operator -";
				case "op_UnaryNegation": return "operator -";
				case "op_Multiply": return "operator *";
				case "op_Division": return "operator /";
				case "op_Equality": return "operator ==";
				case "op_Inequality": return "operator !=";
					
				case "op_LessThan": return "operator <";
                case "op_LessThanOrEqual": return "operator <=";
                case "op_GreaterThan": return "operator >";
				case "op_GreaterThanOrEqual": return "operator >=";
				case "op_Implicit": return "implicit operator " + typefn(method.ReturnType, type.Namespace);
				default: return "operator ???";
				}
            }
			return method.Name;
        }

		static void handlePros(TextFile tfClass, Type type, GeneratorHelp.ATypeInfo ti, Action<Type> OnNewType)
		{
			Action<PropertyInfo> action = (pro) =>
			{
				bool isI = type.IsInterface;

				OnNewType(pro.PropertyType);
				ParameterInfo[] ps = pro.GetIndexParameters();
				
				args iargs = new args();
				bool isIndexer = (ps.Length > 0);
				if (isIndexer)
				{
					for (int j = 0; j < ps.Length; j++)
					{
						iargs.AddFormat("{0} {1}", typefn(ps[j].ParameterType, type.Namespace), ps[j].Name);
						OnNewType(ps[j].ParameterType);
					}
				}

                MethodInfo getm = pro.GetGetMethod();
                MethodInfo setm = pro.GetSetMethod();

                bool canGet = getm != null && getm.IsPublic;
                bool canSet = setm != null && setm.IsPublic;

				string getset = "";

                if (!isI)
                {
                    if (canGet) getset += string.Format("get {{ return default({0}); }}", typefn(pro.PropertyType, type.Namespace));
                    if (canSet) getset += " set {}";
                }
                else
                {
                    if (canGet) getset += "get;";
                    if (canSet) getset += " set;";
                }
				
				string vo = string.Empty;
                if (!isI)
				{
                    vo = "public ";
					
					if ((getm != null && getm.IsStatic) ||
					    (setm != null && setm.IsStatic))
					{
						vo += "static ";
					}

					if ((getm != null && getm.IsVirtual) ||
					    (setm != null && setm.IsVirtual))
					{
						vo += ((getm != null && getm.GetBaseDefinition() != getm) || (setm != null && setm.GetBaseDefinition() != setm))
							? "override " : "virtual ";
                    }
                }
                
                
                if (isIndexer)
                {
                    tfClass.Add("{3}{0} this{1} {{ {2} }}",
					            typefn(pro.PropertyType, type.Namespace), iargs.Format(args.ArgsFormat.Indexer),
					            getset,
                                vo);
                }
                else
                {
                    tfClass.Add("{3}{0} {1} {{ {2} }}",
                                typefn(pro.PropertyType, type.Namespace), pro.Name,
					            getset,
                                vo);
				}
			};
            
			bool hasNoneIndexer = false;
            for (int i = 0; i < ti.Pros.Count; i++)
			{
				MemberInfoEx infoEx = ti.Pros[i];
				PropertyInfo pro = infoEx.member as PropertyInfo;
				if (pro.GetIndexParameters().Length == 0)
				{
					hasNoneIndexer = true;
					action(pro);
				}
			}

			if (hasNoneIndexer)
				tfClass.AddLine();
			
			for (int i = 0; i < ti.Pros.Count; i++)
			{
				MemberInfoEx infoEx = ti.Pros[i];
				PropertyInfo pro = infoEx.member as PropertyInfo;
				if (pro.GetIndexParameters().Length > 0)
				{
                    action(pro);
                }
            }
        }

		static bool ParameterIsParams(ParameterInfo pi)
		{
			return (pi.ParameterType.IsArray && pi.GetCustomAttributes(typeof(ParamArrayAttribute), false).Length > 0);
		}

		static void handleInterfaceProblems(TextFile tfClass, Type cType, Action<Type> OnNewType)
		{
			Type[] interfaces = cType.GetValidInterfaces();
			Action<Type, MethodInfo> actionMethod = (iType, method) => 
			{
				StringBuilder sbDef = new StringBuilder();
				
				sbDef.Append("extern ");
				if (!(method.IsSpecialName && method.Name == "op_Implicit"))
				sbDef.Append(typefn(method.ReturnType, cType.Namespace, CsNameOption.CompilableWithT) + " ");
				
				OnNewType(method.ReturnType);

				sbDef.Append(iType.CsFullName(CsNameOption.CompilableWithT) + "."); // 这句是重点
				sbDef.Append(MethodNameString(cType, method));
				
				if (method.IsGenericMethodDefinition)
				{
					Type[] argus = method.GetGenericArguments();
					args t_args = new args();
					foreach (var a in argus)
						t_args.Add(a.Name);
					
					sbDef.Append(t_args.Format(args.ArgsFormat.GenericT));
				}
				
				sbDef.Append("(");
				ParameterInfo[] ps = method.GetParameters();
				{
					sbDef.Append(Ps2String(cType, ps));
					sbDef.Append(");");
					
					foreach (var p in ps)
						OnNewType(p.ParameterType);
				}
				
				tfClass.Add(sbDef.ToString());
			};

			Action<Type, PropertyInfo> actionPro = (iType, pro) =>
			{
				OnNewType(pro.PropertyType);
				ParameterInfo[] ps = pro.GetIndexParameters();
				
				args iargs = new args();
				bool isIndexer = (ps.Length > 0);
				if (isIndexer)
				{
					for (int j = 0; j < ps.Length; j++)
					{
						iargs.AddFormat("{0} {1}", typefn(ps[j].ParameterType, cType.Namespace), ps[j].Name);
						OnNewType(ps[j].ParameterType);
					}
				}
				
				MethodInfo getm = pro.GetGetMethod();
				MethodInfo setm = pro.GetSetMethod();
				
				bool canGet = getm != null && getm.IsPublic;
				bool canSet = setm != null && setm.IsPublic;
				
				string getset = "";
				{
					if (canGet) getset += "get;";
					if (canSet) getset += " set;";
				}
				
				string vo = string.Empty;
				
				if (isIndexer)
				{
//					tfClass.Add("{3}{0} this{1} {{ {2} }}",
//					            typefn(pro.PropertyType, cType.Namespace), iargs.Format(args.ArgsFormat.Indexer),
//					            getset,
//					            vo);
				}
                else
                {
                    tfClass.Add("{3}{0} {1} {{ {2} }}",
					            typefn(pro.PropertyType, cType.Namespace), 
					            iType.CsFullName(CsNameOption.CompilableWithT) + "." + // 这句是重点
                                pro.Name,
                                getset,
                                vo);
                }
            };
            
            foreach (Type iType in interfaces)
            {
                GeneratorHelp.ATypeInfo ti = GeneratorHelp.CreateTypeInfo(iType);
                for (int i = 0; i < ti.Methods.Count; i++)
                {
                    MemberInfoEx infoEx = ti.Methods[i];
                    MethodInfo method = infoEx.member as MethodInfo;
                    actionMethod(iType, method);
				}
				for (int i = 0; i < ti.Pros.Count; i++)
				{
					MemberInfoEx infoEx = ti.Pros[i];
					PropertyInfo pro = infoEx.member as PropertyInfo;
					actionPro(iType, pro);
                }
                // 特殊处理，BridgeProj工程
                if (iType == typeof(ICollection))
                {
                    tfClass.Add("bool System.Collections.ICollection.IsReadOnly { get; }");
                }
            }
        }
        
        static void handleMethods(TextFile tfClass, Type type, GeneratorHelp.ATypeInfo ti, Action<Type> OnNewType)
		{
			Action<MethodInfo> action = (method) => 
			{
				StringBuilder sbDef = new StringBuilder();

				bool isI = type.IsInterface;

				if (!isI)
				{
					if (method.IsPublic)
						sbDef.Append("public ");
					else if (method.IsFamily)
						sbDef.Append("protected ");
                    else if (method.IsAssembly)
						sbDef.Append("internal ");

					if (method.IsStatic)
						sbDef.Append("static ");

					sbDef.Append("extern ");

					if (method.GetBaseDefinition() != method)
						sbDef.Append("override ");
					else if (method.IsVirtual && !type.IsValueType)
                        sbDef.Append("virtual ");
                }
                
                if (!(method.IsSpecialName && method.Name == "op_Implicit"))
					sbDef.Append(typefn(method.ReturnType, type.Namespace, CsNameOption.CompilableWithT) + " ");

				OnNewType(method.ReturnType);

				sbDef.Append(MethodNameString(type, method));
				
				if (method.IsGenericMethodDefinition)
				{
					Type[] argus = method.GetGenericArguments();
					args t_args = new args();
					foreach (var a in argus)
						t_args.Add(a.Name);
					
					sbDef.Append(t_args.Format(args.ArgsFormat.GenericT));
				}
				
				sbDef.Append("(");
                bool hasExtensionAttribute = (method.GetCustomAttributes(typeof(System.Runtime.CompilerServices.ExtensionAttribute), false).Length > 0);
				ParameterInfo[] ps = method.GetParameters();
				{
                    sbDef.Append(Ps2String(type, ps, hasExtensionAttribute));
					sbDef.Append(");");

					foreach (var p in ps)
						OnNewType(p.ParameterType);
				}
				
				tfClass.Add(sbDef.ToString());
			};
			
			bool hasSpecial = false;
			for (int i = 0; i < ti.Methods.Count; i++)
			{
				MemberInfoEx infoEx = ti.Methods[i];
				MethodInfo method = infoEx.member as MethodInfo;
				if (method.IsSpecialName)
				{
					hasSpecial = true;
					action(method);
                }
            }
            
            if (hasSpecial)
                tfClass.AddLine();
            
            for (int i = 0; i < ti.Methods.Count; i++)
            {
                MemberInfoEx infoEx = ti.Methods[i];
                MethodInfo method = infoEx.member as MethodInfo;
                
                if (!method.IsSpecialName)
                {
                    action(method);
                }
            }
        }
        
		static void GenInterfaceOrStructOrClass(Type type, TypeStatus ts, 
		                                            Func<Type, TypeStatus> getParent, Action<Type> onNewType)
		{
			TextFile tfFile = null;
			if (type.DeclaringType != null)
			{
				ts.IsInnerType = true;

				TypeStatus tsParent = getParent(type.DeclaringType);
				if (tsParent == null || tsParent.status == TypeStatus.Status.Wait)
				{
					return;
				}
				
				if (tsParent.status == TypeStatus.Status.Ignored)
				{
					ts.status = TypeStatus.Status.Ignored;
					return;
				}
				
				tfFile = tsParent.tf.FindByTag("epos");
			}
			
			if (tfFile == null)
				tfFile = new TextFile();

			ts.tf = tfFile;
			ts.status = TypeStatus.Status.Exported;

            GeneratorHelp.ATypeInfo ti = GeneratorHelp.CreateTypeInfo(type);

            StringBuilder sb = new StringBuilder();
            TextFile tfNs = tfFile;

            //string dir = Dir;
            if (type.DeclaringType == null &&
                !string.IsNullOrEmpty(type.Namespace))
            {
                tfNs = tfFile.Add("namespace {0}", type.Namespace).BraceIn();
                tfNs.BraceOut();
            }

            tfNs.Add("[Bridge.FileName(\"csw\")]");

            TextFile tfClass = null;
            sb.Remove(0, sb.Length);
            {
				if (type.IsPublic || type.IsNestedPublic)
                    sb.Append("public ");

                if (type.IsClass)
                {
                    if (type.IsAbstract && type.IsSealed)
                        sb.Append("static ");
                    //else if (type.IsAbstract)
                    //    sb.Append("abstract ");
                    //else if (type.IsSealed)
                    //    sb.Append("sealed ");
                }

                if (type.IsInterface)
                    sb.Append("interface ");
                else if (type.IsValueType)
                    sb.Append("struct ");
                else
                    sb.Append("class ");

				string className = type.CsFullName(CsNameOption.CompilableWithT);
				int dot = className.LastIndexOf(".");
				if (dot >= 0)
				{
					className = className.Substring(dot + 1);
				}
				sb.Append(className);

				Type vBaseType = type.ValidBaseType();
				Type[] interfaces = type.GetDeclaringInterfaces();
                if (vBaseType != null || interfaces.Length > 0)
                {
                    sb.Append(" : ");

                    args a = new args();
                    if (vBaseType != null)
					{
						a.Add(typefn(vBaseType, type.Namespace));
						onNewType(vBaseType);
					}
                    foreach (var i in interfaces)
					{
						a.Add(typefn(i, type.Namespace));
						onNewType(i);
					}

					sb.Append(a.ToString());
                }

                tfClass = tfNs.Add(sb.ToString()).BraceIn();
                tfClass.BraceOut();
            }

			tfClass.AddTag("epos");

            for (int i = 0; i < ti.Fields.Count; i++)
            {
                MemberInfoEx infoEx = ti.Fields[i];
                FieldInfo field = infoEx.member as FieldInfo;
                tfClass.Add("public {0}{1} {2};", (field.IsStatic ? "static " : ""), typefn(field.FieldType, type.Namespace), field.Name);
				
				onNewType(field.FieldType);
            }
            if (ti.Fields.Count > 0)
			    tfClass.AddLine();

			for (int i = 0; i < ti.Cons.Count; i++)
			{
				MemberInfoEx infoEx = ti.Cons[i];
				ConstructorInfo con = infoEx.member as ConstructorInfo;

				if (type.IsValueType)
				{
					// 结构体不需要无参数构造函数
					if (con == null || con.GetParameters().Length == 0)
					{
						continue;
					}
				}

				string ctorName = type.Name;
				if (type.IsGenericTypeDefinition)
				{
					int flag = ctorName.LastIndexOf('`');
					if (flag >= 0)
						ctorName = ctorName.Substring(0, flag);
				}
				tfClass.Add("public extern {0}({1});", ctorName, con == null ? "" : Ps2String(type, con.GetParameters()));

				if (con != null)
				{
					foreach (var p in con.GetParameters())
					{
                        onNewType(p.ParameterType);
                    }
				}
			}
            if (ti.Cons.Count > 0)
			    tfClass.AddLine();

            handlePros(tfClass, type, ti, onNewType);

            if (ti.Pros.Count > 0)
                tfClass.AddLine();

			handleMethods(tfClass, type, ti, onNewType);
			if (!type.IsInterface)
				handleInterfaceProblems(tfClass, type, onNewType);
        }

		static bool ShouldIgnoreType(Type type)
		{
			if (type == null || 
			    type == typeof(Decimal) ||
			    (type.IsGenericType && !type.IsGenericTypeDefinition) ||
			    type.IsPointer
			    )
			{
//				Debug.Log("CSW ignore " + type.ToString());
				return true;
			}
			return false;
		}

		class TypeStatus
		{
			public enum Status { Wait, Exported, Ignored, }
			public Status status = Status.Wait;
			public TextFile tf = null;
			public bool IsInnerType = false;
		}

        public static void GenWraps(Type[] arrEnums, Type[] arrClasses, HashSet<string> bridgeTypes)
        {
            GeneratorHelp.ClearTypeInfo();

			Dictionary<Type, TypeStatus> dict = new Dictionary<Type, TypeStatus>();
            Action<Type> onNewType = null;            
            onNewType = (nt) =>
            {
                while (true)
                {
                    if (nt.IsByRef || nt.IsArray)
                    {
                        nt = nt.GetElementType();
                        continue;
                    }
                    if (nt.IsGenericType && !nt.IsGenericTypeDefinition)
                    {
                        foreach (var ga in nt.GetGenericArguments())
                        {
                            onNewType(ga);
                        }

                        nt = nt.GetGenericTypeDefinition();
                        continue;
                    }
					if (nt.IsGenericParameter)
						return;
					break;
				}

				if (!bridgeTypes.Contains(nt.FullName) &&
                    !dict.ContainsKey(nt))
				{
					dict.Add(nt, new TypeStatus());
				}
			};

			Func<Type, TypeStatus> getParent = (type) =>
			{
				if (dict.ContainsKey(type))
					return dict[type];
				return null;
			};

			foreach (var type in arrEnums)
			{
				onNewType(type);
			}

			foreach (var type in arrClasses)
			{
				onNewType(type);
			}

			while (true)
			{
				Type[] keys = new Type[dict.Count];
				dict.Keys.CopyTo(keys, 0);

				foreach (Type type in keys)
				{
					TypeStatus ts = dict[type];
					if (ts.status != TypeStatus.Status.Wait)
					{
						continue;
					}

					if (ShouldIgnoreType(type))
					{
						ts.status = TypeStatus.Status.Ignored;
						continue;
					}

					if (type.IsEnum)
					{
						GenEnum(type, ts, getParent, onNewType);
					}
                    else if (typeof(Delegate).IsAssignableFrom(type))
                    {
                        GenDelegate(type, ts, getParent, onNewType);
                    }
                    else
					{
						GenInterfaceOrStructOrClass(type, ts, getParent, onNewType);
					}
				}

				bool bContinue = false;
				foreach (var kv in dict)
				{
					if (kv.Value.status == TypeStatus.Status.Wait)
					{
						bContinue = true;
						break;
					}
				}

				if (!bContinue)
					break;
            }
			
			TextFile tfAll = new TextFile();
            tfAll.Add("#pragma warning disable 626, 824");
			foreach (var kv in dict)
			{
				if (kv.Value.status == TypeStatus.Status.Exported &&
				    !kv.Value.IsInnerType)
				{
					tfAll.Add(kv.Value.tf.Ch);
                    tfAll.AddLine();
				}
            }
            tfAll.Add("#pragma warning restore 626, 824");
            File.WriteAllText(JSBindingSettings.CswFilePath, tfAll.Format(-1));
        }
    }
}
