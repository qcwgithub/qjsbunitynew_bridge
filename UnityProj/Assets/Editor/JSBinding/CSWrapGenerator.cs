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
        static TextFile GenEnum(Type type)
        {
            GeneratorHelp.ATypeInfo ti = GeneratorHelp.CreateTypeInfo(type);

            StringBuilder sb = new StringBuilder();
            TextFile tfFile = new TextFile();
            TextFile tfNs = tfFile;

            if (!string.IsNullOrEmpty(type.Namespace))
            {
                tfNs = tfFile.Add("namespace {0}", type.Namespace).BraceIn();
                tfNs.BraceOut();
            }

            TextFile tfClass = null;
            sb.Remove(0, sb.Length);
            {
                if (type.IsPublic)
                    sb.Append("public ");

                sb.Append("enum ");
                sb.Append(type.Name);

                tfClass = tfNs.Add(sb.ToString()).BraceIn();
                tfClass.BraceOut();
            }

            for (int i = 0; i < ti.Fields.Count; i++)
            {
                MemberInfoEx infoEx = ti.Fields[i];
                FieldInfo field = infoEx.member as FieldInfo;
                tfClass.Add("{0}: {1},", field.Name, field.GetValue(null));
            }

            return tfFile;
        }

        static TextFile GenWrap(Type type)
        {
            if (type == null || 
                type.IsPrimitive ||
                (type.Namespace != null && (type.Namespace == "System" || type.Namespace.StartsWith("System.")))
                )
            {
                return null;
            }

            if (type.IsEnum)
                return GenEnum(type);

            GeneratorHelp.ATypeInfo ti = GeneratorHelp.CreateTypeInfo(type);

            StringBuilder sb = new StringBuilder();
            TextFile tfFile = new TextFile();
            TextFile tfNs = tfFile;

            //string dir = Dir;
            if (!string.IsNullOrEmpty(type.Namespace))
            {
                tfNs = tfFile.Add("namespace {0}", type.Namespace).BraceIn();
                tfNs.BraceOut();
            }

            TextFile tfClass = null;
            sb.Remove(0, sb.Length);
            {
                if (type.IsPublic)
                    sb.Append("public ");

                if (type.IsInterface)
                    sb.Append("interface ");
                else if (type.IsValueType)
                    sb.Append("struct ");
                else
                    sb.Append("class ");

                sb.Append(type.Name);

                if (!type.IsEnum)
                {
                    Type baseType = type.BaseType;
                    Type[] interfaces = type.GetInterfaces();
                    if (baseType != null || interfaces.Length > 0)
                    {
                        sb.Append(" : ");

                        args a = new args();
                        if (baseType != null)
                            a.Add(JSNameMgr.GetTypeFullName(baseType));
                        foreach (var i in interfaces)
                            a.Add(JSNameMgr.GetTypeFullName(i));

                        sb.Append(a.ToString());
                    }
                }

                tfClass = tfNs.Add(sb.ToString()).BraceIn();
                tfClass.BraceOut();
            }

            for (int i = 0; i < ti.Fields.Count; i++)
            {
                MemberInfoEx infoEx = ti.Fields[i];
                FieldInfo field = infoEx.member as FieldInfo;
                tfClass.Add("public {0} {1};", JSNameMgr.GetTypeFullName(field.FieldType), field.Name);
            }

            for (int i = 0; i < ti.Pros.Count; i++)
            {
                MemberInfoEx infoEx = ti.Pros[i];
                PropertyInfo pro = infoEx.member as PropertyInfo;
                ParameterInfo[] ps = pro.GetIndexParameters();

                args iargs = new args();
                bool isIndexer = (ps.Length > 0);
                if (isIndexer)
                {
                    for (int j = 0; j < ps.Length; j++)
                    {
                        iargs.AddFormat("{0} {1}", JSNameMgr.GetTypeFullName(ps[j].ParameterType), ps[j].Name);
                    }
                }

                bool canGet = pro.GetGetMethod() != null && pro.GetGetMethod().IsPublic;
                bool canSet = pro.GetSetMethod() != null && pro.GetSetMethod().IsPublic;

                if (isIndexer)
                {
                    tfClass.Add("public extern {0} this{1} {{ {2} }}",
                        JSNameMgr.GetTypeFullName(pro.PropertyType), iargs.Format(args.ArgsFormat.Indexer),
                        canGet && canSet ? "get; set;" : (canGet ? "get;" : "set;"));
                }
                else
                {
                    tfClass.Add("public extern {0} {1} {{ {2} }}",
                        JSNameMgr.GetTypeFullName(pro.PropertyType), pro.Name,
                        canGet && canSet ? "get; set;" : (canGet ? "get;" : "set;"));
                }
            }

            for (int i = 0; i < ti.Methods.Count; i++)
            {
                MemberInfoEx infoEx = ti.Methods[i];
                MethodInfo method = infoEx.member as MethodInfo;

                args aDef = new args();
                if (method.IsPublic)
                    aDef.Add("public");
                if (method.IsStatic)
                    aDef.Add("static");

                aDef.Add(JSNameMgr.GetTypeFullName(method.ReturnType));

                if (method.IsGenericMethod)
                {

                }
            }
            return tfFile;
        }
        public static void GenWrap()
        {
            GeneratorHelp.ClearTypeInfo();
            TextFile tfAll = new TextFile();
            for (int i = 0; i < JSBindingSettings.classes.Length; i++)
            {
                TextFile tfFile = GenWrap(JSBindingSettings.classes[i]);
                if (tfFile != null)
                    tfAll.Add(tfFile.Ch);
            }
            File.WriteAllText("D:\\x.cs", tfAll.Format(-1));
        }
    }
}
