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
                sb.AppendFormat("{0}({1});", type.Name, Ps2String(type, ps));

                foreach (var p in ps)
                    onNewType(p.ParameterType);
            }

            tfNs.Add(sb.ToString());
        }

		static void GenEnum(Type type, TypeStatus ts, 
		                    Func<Type, TypeStatus> getParent)
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

            if (!string.IsNullOrEmpty(type.Namespace))
            {
                tfNs = tfFile.Add("namespace {0}", type.Namespace).BraceIn();
                tfNs.BraceOut();
            }

            TextFile tfClass = null;
            sb.Remove(0, sb.Length);
            {
                if (type.IsPublic || type.IsNestedPublic)
                    sb.Append("public ");

                sb.Append("enum ");
                sb.Append(type.Name);

                tfClass = tfNs.Add(sb.ToString()).BraceIn();
                tfClass.BraceOut();
            }

			FieldInfo[] fields = type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static);
			for (int i = 0; i < fields.Length; i++)
			{
				FieldInfo field = fields[i];
				tfClass.Add("{0} = {1},", field.Name, (int)field.GetValue(null));
			}
        }

		static string typefn(Type tType, string eraseNs)
		{
			string fn = JSNameMgr.CsFullName(tType);
			if (!string.IsNullOrEmpty(eraseNs) &&
			    fn.StartsWith(eraseNs + "."))
			{
				fn = fn.Substring(eraseNs.Length + 1);
			}
			return fn;
		}

		static string Ps2String(Type type, ParameterInfo[] ps)
		{
			args f_args = new args();
			for (int j = 0; j < ps.Length; j++)
			{
				ParameterInfo p = ps[j];
				string s = "";
				if (p.ParameterType.IsByRef)
				{
					if (p.IsOut)
						s = "out ";
					else
						s = "ref ";
				}
				s += typefn(p.ParameterType, type.Namespace) + " ";
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
				if (canGet) getset += string.Format("get {{ return default({0}); }}", typefn(pro.PropertyType, type.Namespace));
				if (canSet) getset += " set {}";

                string vo = string.Empty;
                if ((getm != null && getm.IsVirtual) ||
                    (setm != null && setm.IsVirtual))
                {
                    vo = ((getm != null && getm.GetBaseDefinition() != getm) || (setm != null && setm.GetBaseDefinition() != setm))
                        ? "override " : "virtual ";
                }
				
				if (isIndexer)
				{
					tfClass.Add("public {3}{0} this{1} {{ {2} }}",
					            typefn(pro.PropertyType, type.Namespace), iargs.Format(args.ArgsFormat.Indexer),
					            getset,
                                vo);
                }
                else
                {
                    tfClass.Add("public {3}{0} {1} {{ {2} }}",
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

		static void handleMethods(TextFile tfClass, Type type, GeneratorHelp.ATypeInfo ti, Action<Type> OnNewType)
		{
			Action<MethodInfo> action = (method) => 
			{
				StringBuilder sbDef = new StringBuilder();
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
                else if (method.IsVirtual)
                    sbDef.Append("virtual ");

				if (!(method.IsSpecialName && method.Name == "op_Implicit"))
					sbDef.Append(typefn(method.ReturnType, type.Namespace) + " ");

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
				ParameterInfo[] ps = method.GetParameters();
				{
					sbDef.Append(Ps2String(type, ps));
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

            TextFile tfClass = null;
            sb.Remove(0, sb.Length);
            {
				if (type.IsPublic || type.IsNestedPublic)
                    sb.Append("public ");

                if (type.IsInterface)
                    sb.Append("interface ");
                else if (type.IsValueType)
                    sb.Append("struct ");
                else
                    sb.Append("class ");

                sb.Append(type.Name);

                Type vBaseType = type.ValidBaseType();
                Type[] interfaces = type.GetInterfaces();
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
                tfClass.Add("public {0} {1};", typefn(field.FieldType, type.Namespace), field.Name);
				
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

				tfClass.Add("public extern {0}({1});", type.Name, con == null ? "" : Ps2String(type, con.GetParameters()));

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
        }

		static bool ShouldIgnoreType(Type type)
		{
			if (type == null || 
			    type.IsPrimitive ||
			    (type.Namespace != null && (type.Namespace == "System" || type.Namespace.StartsWith("System.")))
			    )
			{
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

        public static void GenWraps()
        {
            GeneratorHelp.ClearTypeInfo();

			Dictionary<Type, TypeStatus> dict = new Dictionary<Type, TypeStatus>();

			Action<Type> onNewType = (nt) =>
			{
				while (true)
				{
					if (nt.IsByRef || nt.IsArray)
					{
						nt = nt.GetElementType();
						continue;
					}
					if (nt.IsGenericParameter)
						return;
					break;
				}

				if (!dict.ContainsKey(nt))
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

			foreach (var type in JSBindingSettings.enums)
			{
				onNewType(type);
			}

			foreach (var type in JSBindingSettings.classes)
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
						GenEnum(type, ts, getParent);
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
            File.WriteAllText("D:\\x.cs", tfAll.Format(-1));
        }
    }
}
