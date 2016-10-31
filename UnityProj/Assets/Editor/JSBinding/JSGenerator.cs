using UnityEngine;
using UnityEditor;
using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

namespace jsb
{
    public static class JSGenerator
    {
        static StringBuilder sb = null;
        public static Type type = null;

        static StreamWriter W;
        public static void OnBegin()
        {
            GeneratorHelp.ClearTypeInfo();
            // clear generated enum files
            string p = JSBindingSettings.jsGeneratedFiles;
            if (!File.Exists(p))
            {
                int i = p.Replace('\\', '/').LastIndexOf('/');
                Directory.CreateDirectory(p.Substring(0, i));
            }
            W = OpenFile(p, false);
        }
        public static void OnEnd()
        {
            W.Close();
        }

        public static string SharpKitTypeName(Type type)
        {
            if (type == null)
                return "";
            string name = string.Empty;
            if (type.IsByRef)
            {
                name = SharpKitTypeName(type.GetElementType());
            }
            else if (type.IsArray)
            {
                while (type.IsArray)
                {
                    Type subt = type.GetElementType();
                    name += SharpKitTypeName(subt) + '$';
                    type = subt;
                }
                name += "Array";
            }
            else if (type.IsGenericTypeDefinition)
            {
                // never come here
                name = type.Name;
            }
            else if (type.IsGenericType)
            {
                name = type.Name;
                Type[] ts = type.GetGenericArguments();

                bool hasGenericParameter = false;
                for (int i = 0; i < ts.Length; i++)
                {
                    if (ts[i].IsGenericParameter)
                    {
                        hasGenericParameter = true;
                        break;
                    }
                }

                if (!hasGenericParameter)
                {
                    for (int i = 0; i < ts.Length; i++)
                    {
                        name += "$" + SharpKitTypeName(ts[i]);
                    }
                }
            }
            else
            {
                name = type.Name;
            }
            return name;
        }
        public static string Member_AddSuffix(string methodName, int overloadIndex, int TCounts = 0)
        {
            string name = methodName;
            //if (TCounts > 0)
            //    name += "$" + TCounts.ToString();

            if (overloadIndex > 0)
            {
                name += "$" + overloadIndex;
            }
            return name;
        }
        public static string SharpKitClassName(Type type)
        {
            return JSNameMgr.GetJSTypeFullName(type);
        }

        public static void BuildFields(TextFile tfStatic, TextFile tfInst,
            Type type, FieldInfo[] fields, int slot, List<string> lstNames)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < fields.Length; i++)
            {
                FieldInfo field = fields[i];

                lstNames.Add((field.IsStatic ? "Static_" : "") + field.Name);

                TextFile tf = field.IsStatic ? tfStatic : tfInst;
                tf.Add("{0}: {{", field.Name).In()
                    .Add("get: function () {{ return CS.Call({0}, {1}, {2}, {3}{4}); }},", (int)JSVCall.Oper.GET_FIELD, slot, i, (field.IsStatic ? "true" : "false"), (field.IsStatic ? "" : ", this"))
                    .Add("set: function (v) {{ return CS.Call({0}, {1}, {2}, {3}{4}, v); }}", (int)JSVCall.Oper.SET_FIELD, slot, i, (field.IsStatic ? "true" : "false"), (field.IsStatic ? "" : ", this"))
                .Out().Add("},");
            }
        }
        public static void BuildProperties(TextFile tfStatic, TextFile tfInst,
            Type type, PropertyInfo[] properties, int[] propertiesIndex, int slot, List<string> lstNames)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                PropertyInfo property = properties[i];

                ParameterInfo[] ps = property.GetIndexParameters();
                string indexerParamA = string.Empty;
                string indexerParamB = string.Empty;
                string indexerParamC = string.Empty;
                for (int j = 0; j < ps.Length; j++)
                {
                    indexerParamA += "ind" + j.ToString();
                    indexerParamB += "ind" + j.ToString() + ", ";
                    if (j < ps.Length - 1) indexerParamA += ", ";
                    indexerParamC += ", ind" + j.ToString();
                }

                MethodInfo[] accessors = property.GetAccessors();
                bool isStatic = accessors[0].IsStatic;

                // 特殊情况，当[]时，property.Name=Item
                string mName = Member_AddSuffix(property.Name, propertiesIndex[i]);
                lstNames.Add((isStatic ? "Static_" : "") + "get" + mName);
                lstNames.Add((isStatic ? "Static_" : "") + "set" + mName);

                TextFile tf = isStatic ? tfStatic : tfInst;
                tf.Add("get{0}: function ({1}) {{ return CS.Call({2}, {3}, {4}, {5}{6}{7}); }},",
                    mName, indexerParamA, (int)JSVCall.Oper.GET_PROPERTY, slot, i, (isStatic ? "true" : "false"), (isStatic ? "" : ", this"), indexerParamC);

                tf.Add("set{0}: function ({1}v) {{ return CS.Call({2}, {3}, {4}, {5}{6}{7}, v); }},",
                    mName, indexerParamB, (int)JSVCall.Oper.GET_PROPERTY, slot, i, (isStatic ? "true" : "false"), (isStatic ? "" : ", this"), indexerParamC);
            }
        }
        public static void BuildConstructors(TextFile tfInst, Type type, ConstructorInfo[] constructors, int[] constructorsIndex, int slot, List<string> lstNames)
        {
            var argActual = new args();
            var argFormal = new args();

            for (int i = 0; i < constructors.Length; i++)
            {
                TextFile tf = new TextFile();
                ConstructorInfo con = constructors[i];
                ParameterInfo[] ps = con == null ? new ParameterInfo[0] : con.GetParameters();

                argActual.Clear().Add(
                    (int)JSVCall.Oper.CONSTRUCTOR, // OP
                    slot,
                    i,  // NOTICE
                    "true", // IsStatics                
                    "this"
                    );

                argFormal.Clear();

                // add T to formal param
                if (type.IsGenericTypeDefinition)
                {
                    // TODO check
                    int TCount = type.GetGenericArguments().Length;
                    for (int j = 0; j < TCount; j++)
                    {
                        argFormal.Add("t" + j + "");
                        argActual.Add("t" + j + ".getNativeType()");
                    }
                }

                //StringBuilder sbFormalParam = new StringBuilder();
                //StringBuilder sbActualParam = new StringBuilder();
                for (int j = 0; j < ps.Length; j++)
                {
                    argFormal.Add("a" + j.ToString());
                    argActual.Add("a" + j.ToString());
                }

                string mName = Member_AddSuffix("ctor", constructorsIndex[i]);
                lstNames.Add(mName);

                tf.Add("{0}: function ({1}) {{", mName, argFormal)
                    .In()
                        .Add("CS.Call({0});", argActual)
                    .Out().Add("},");

                tfInst.Add(tf.Ch);
            }
        }

        // can handle all methods
        public static void BuildMethods(TextFile tfStatic, TextFile tfInst,
            Type type, MethodInfo[] methods, int slot, List<string> lstNames)
        {
            for (int i = 0; i < methods.Length; i++)
            {
                MethodInfo method = methods[i];
                int overloadIndex = 0; // TODO

                StringBuilder sbFormalParam = new StringBuilder();
                StringBuilder sbActualParam = new StringBuilder();
                ParameterInfo[] paramS = method.GetParameters();
                TextFile tfInitT = new TextFile();
                int TCount = 0;

                // add T to formal param
                if (method.IsGenericMethodDefinition)
                {
                    TCount = method.GetGenericArguments().Length;
                    for (int j = 0; j < TCount; j++)
                    {
                        sbFormalParam.AppendFormat("t{0}", j);
                        if (j < TCount - 1 || paramS.Length > 0)
                            sbFormalParam.Append(", ");

                        tfInitT.Add("var $tn{0} = Bridge.Reflection.getTypeFullName(t{0});", j);
                        sbActualParam.AppendFormat(", $tn{0}", j);
                    }
                }

                int L = paramS.Length;
                for (int j = 0; j < L; j++)
                {
                    sbFormalParam.AppendFormat("a{0}{1}", j, (j == L - 1 ? "" : ", "));
                    sbActualParam.AppendFormat(", a{0}", j);
                }

                //int TCount = method.GetGenericArguments().Length;

                string methodName = method.Name;

                // TODO
                // if (methodName == "ToString") { methodName = "toString"; }

                string mName = Member_AddSuffix(methodName, overloadIndex, TCount);
                lstNames.Add((method.IsStatic ? "Static_" : "") + mName);

                TextFile tf = method.IsStatic ? tfStatic : tfInst;
                tf.Add("{0}: function ({1}) {{", mName, sbFormalParam.ToString())
                    .In()
                        .Add(tfInitT.Ch)
                        .Add("return CS.Call({0}, {1}, {2}, {3}{4});", (int)JSVCall.Oper.METHOD, slot, i, (method.IsStatic ? "true" : "false"), (method.IsStatic ? "" : ", this") + sbActualParam.ToString())
                    .Out()
                    .Add("},");
            }
        }

        public static List<string> GenerateClass()
        {
            List<string> memberNames = new List<string>();

            GeneratorHelp.ATypeInfo ti;
            int slot = GeneratorHelp.AddTypeInfo(type, out ti);

            TextFile tfDef = new TextFile();
            tfDef.Add("Bridge.define(\"{0}\", {{", JSNameMgr.GetJSTypeFullName(type));
            TextFile tfClass = tfDef.Add("");

            if (type.IsInterface)
                tfClass.In().Add("$kind: interface,");
            else if (type.IsValueType)
                tfClass.In().Add("$kind: struct,");

            TextFile tfStatic = tfClass.In().Add("static: {").In();
            tfStatic.Out().Add("},");

            TextFile tfInst = tfClass.Add("").In();

            tfDef.Add("});");

            if (type.IsValueType)
            {
                tfStatic.Add("getDefaultValue: function () {{ return new {0}(); }},", JSNameMgr.GetJSTypeFullName(type));

                tfInst.Add("equals: function (o) {")
                    .In()
                        .Add("if (!Bridge.is(o, {0})) {{", JSNameMgr.GetJSTypeFullName(type))
                        .In()
                            .Add("return false;")
                        .BraceOut()
                        .Add(() =>
                        {
                            StringBuilder sb = new StringBuilder();
                            if (ti.fields.Length == 0)
                                sb.Append("return true;");
                            else
                            {
                                for (int f = 0; f < ti.fields.Length; f++)
                                {
                                    sb.AppendFormat("Bridge.equals(this.{0}, o.{0})", ti.fields[f].Name);
                                    if (f < ti.fields.Length - 1)
                                        sb.AppendFormat(" && ");
                                    else
                                        sb.Append(";");
                                }
                            }
                            return new TextFile().Add(sb.ToString()).Ch;
                        })
                    .BraceOutComma();

                tfInst.Add("$clone: function (to) {")
                    .In()
                        .Add("var s = to || new {0}();", JSNameMgr.GetJSTypeFullName(type))
                        .Add(() =>
                        {
                            TextFile tf = new TextFile();
                            for (int f = 0; f < ti.fields.Length; f++)
                            {
                                tf.Add("s.{0} = this.{0};", ti.fields[f].Name);
                            }
                            return tf.Ch;
                        })
                        .Add("return s;")
                    .BraceOutComma();
            }

            BuildConstructors(tfInst, type, ti.constructors, ti.constructorsIndex, slot, memberNames);
            BuildFields(tfStatic, tfInst, type, ti.fields, slot, memberNames);
            BuildProperties(tfStatic, tfInst, type, ti.properties, ti.propertiesIndex, slot, memberNames);
            BuildMethods(tfStatic, tfInst, type, ti.methods, slot, memberNames);

            W.Write(tfDef.Format(-1));

            return memberNames;
        }

        static void GenerateEnum()
        {
            TextFile tf = new TextFile();

            string typeName = type.ToString();
            // tf.AddLine().Add("// {0}", typeName);

            // remove name space
            int lastDot = typeName.LastIndexOf('.');
            if (lastDot >= 0)
            {
                typeName = typeName.Substring(lastDot + 1);
            }

            if (typeName.IndexOf('+') >= 0)
                return;

            TextFile tfDef = tf.Add("Bridge.define(\"{0}\", {{", JSNameMgr.GetJSTypeFullName(type)).In();
            tfDef.Add("$kind: \"enum\",");
            TextFile tfSta = tfDef.Add("statics: {").In();

            FieldInfo[] fields = type.GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static);
            for (int i = 0; i < fields.Length; i++)
            {
                tfSta.Add("{0}: {1}{2}", fields[i].Name, (int)fields[i].GetValue(null), i == fields.Length - 1 ? "" : ",");
            }
            tfSta.BraceOut();
            tfDef.BraceOutSC();

            W.Write(tf.Format(-1));
        }

        public static void Clear()
        {
            type = null;
            sb = new StringBuilder();
        }
        static void GenEnd()
        {
            string fmt = @"
]]
";
            sb.Append(fmt);
        }

        static void WriteUsingSection(StreamWriter writer)
        {
            string fmt = @"using System;
using UnityEngine;
";
            writer.Write(fmt);
        }
        static StreamWriter OpenFile(string fileName, bool bAppend = false)
        {
            // IMPORTANT
            // Bom (byte order mark) is not needed
            Encoding utf8NoBom = new UTF8Encoding(false);
            return new StreamWriter(fileName, bAppend, utf8NoBom);
        }

        static void HandleStringFormat(StringBuilder sb)
        {
            sb.Replace("[[", "{");
            sb.Replace("]]", "}");
            sb.Replace("'", "\"");
        }

        //     [MenuItem("JS for Unity/Generate JS Enum Bindings")]
        //     public static void GenerateEnumBindings()
        //     {
        //         JSGenerator2.OnBegin();
        // 
        //         for (int i = 0; i < JSBindingSettings.enums.Length; i++)
        //         {
        //             JSGenerator2.Clear();
        //             JSGenerator2.type = JSBindingSettings.enums[i];
        //             JSGenerator2.GenerateEnum();
        //         }
        // 
        //         JSGenerator2.OnEnd();
        // 
        //         Debug.Log("Generate JS Enum Bindings finish. total = " + JSBindingSettings.enums.Length.ToString());
        //     }

        /* 
         * Some classes have another name
         * for example: js has 'Object'
         */
        public static Dictionary<Type, string> typeClassName = new Dictionary<Type, string>();
        static string className = string.Empty;

        public static void GenerateClassBindings()
        {
            JSGenerator.OnBegin();

            // enums
            for (int i = 0; i < JSBindingSettings.enums.Length; i++)
            {
                JSGenerator.Clear();
                JSGenerator.type = JSBindingSettings.enums[i];
                JSGenerator.GenerateEnum();
            }

            // typeName -> member list
            Dictionary<string, List<string>> allDefs = new Dictionary<string, List<string>>();

            // classes
            for (int i = 0; i < JSBindingSettings.classes.Length; i++)
            {
                JSGenerator.Clear();
                JSGenerator.type = JSBindingSettings.classes[i];
                if (!typeClassName.TryGetValue(type, out className))
                    className = type.Name;

                List<string> memberNames = JSGenerator.GenerateClass();
                allDefs.Add(SharpKitClassName(type), memberNames);
            }

            JSGenerator.OnEnd();

            Debug.Log("Generate JS Bindings OK. enum " + JSBindingSettings.enums.Length.ToString() + ", class " + JSBindingSettings.classes.Length.ToString());
        }
    }
}