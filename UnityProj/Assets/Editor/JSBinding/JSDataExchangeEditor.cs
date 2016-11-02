using System;
using System.Text;
using UnityEngine;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Reflection;

using jsval = JSApi.jsval;

namespace jsb
{
    public class JSDataExchangeEditor : JSDataExchangeMgr
    {
        //static Dictionary<Type, JSDataExchange> dict;
        static JSDataExchange_Arr arrayExchange;

        // Editor only
        public static void reset()
        {
            //dict = new Dictionary<Type, JSDataExchange>();

            arrayExchange = new JSDataExchange_Arr();
        }

        // Editor only
        public struct ParamHandler
        {
            public string argName; // argN
            public string getter;
            public string updater;
        }

        public static bool IsDelegateSelf(Type type)
        {
            return type == typeof(System.Delegate) || type == typeof(System.MulticastDelegate);
        }
        public static bool IsDelegateDerived(Type type)
        {
            return typeof(System.Delegate).IsAssignableFrom(type) && !IsDelegateSelf(type);
        }

        // Editor only
        public static ParamHandler Get_ParamHandler(Type type, int paramIndex, bool isRef, bool isOut)
        {
            ParamHandler ph = new ParamHandler();
            ph.argName = "arg" + paramIndex.ToString();

            if (IsDelegateDerived(type))
            {
                Debug.LogError("Delegate derived class should not get here");
                return ph;
            }

            bool bTOrContainsT = (type.IsGenericParameter || type.ContainsGenericParameters);

            string typeFullName;
            if (bTOrContainsT)
                typeFullName = "object";
            else
                typeFullName = JSNameMgr.CsFullName(type);

            if (type.IsArray)
            {
                ph.getter = new StringBuilder()
                    .AppendFormat("{0} {1} = {2};", typeFullName, ph.argName, arrayExchange.Get_GetParam(type))
                    .ToString();
            }
            else
            {
                if (isRef || isOut)
                {
                    type = type.GetElementType();
                }
                bool needCast;
                string keyword = GetMetatypeKeyword(type, out needCast);
                if (keyword == string.Empty)
                {
                    Debug.LogError("keyword is empty: " + type.Name);
                    return ph;
                }

                if (isOut)
                {
                    ph.getter = new StringBuilder()
                        .AppendFormat("int r_arg{0} = JSApi.incArgIndex();\n", paramIndex)
                        .AppendFormat("        {0} {1}{2};", typeFullName, ph.argName, bTOrContainsT ? " = null" : "")
                        .ToString();
                }
                else if (isRef)
                {
                    ph.getter = new StringBuilder()
                        .AppendFormat("int r_arg{0} = JSApi.getArgIndex();\n", paramIndex)
                        .AppendFormat("{0} {1} = ({0}){2}((int)JSApi.GetType.ArgRef);", typeFullName, ph.argName, keyword)
                        .ToString();
                }
                else
                {
                    if (needCast)
                    {
                        ph.getter = new StringBuilder()
                            .AppendFormat("{0} {1} = ({0}){2}((int)JSApi.GetType.Arg);", typeFullName, ph.argName, keyword)
                            .ToString();
                    }
                    else
                    {
                        ph.getter = new StringBuilder()
                            .AppendFormat("{0} {1} = {2}((int)JSApi.GetType.Arg);", typeFullName, ph.argName, keyword)
                            .ToString();
                    }
                }

                if (isOut || isRef)
                {
                    var _sb = new StringBuilder();
                    if (bTOrContainsT)
                    {
                        // TODO
                        // sorry, 'arr_t' is written in CSGenerator2.cs
                        _sb.AppendFormat("        {0} = arr_t[{1}];\n", ph.argName, paramIndex);
                    }

                    ph.updater = _sb.AppendFormat("        JSApi.setArgIndex(r_arg{0});\n", paramIndex)
                        .AppendFormat("        {0}((int)JSApi.SetType.ArgRef, {1});\n", keyword.Replace("get", "set"), ph.argName)
                        .ToString();
                }
            }
            return ph;
        }

        // Editor only
        public static ParamHandler Get_ParamHandler(ParameterInfo paramInfo, int paramIndex)
        {
            return Get_ParamHandler(paramInfo.ParameterType, paramIndex, paramInfo.ParameterType.IsByRef, paramInfo.IsOut);
        }
        // Editor only
        public static ParamHandler Get_ParamHandler(FieldInfo fieldInfo)
        {
            return Get_ParamHandler(fieldInfo.FieldType, 0, false, false);//fieldInfo.FieldType.IsByRef);
        }
        public static string Get_GetJSReturn(Type type)
        {
            if (type == typeof(void))
                return string.Empty;

            if (type.IsArray)
            {
                arrayExchange.elementType = type.GetElementType();
                if (arrayExchange.elementType.IsArray)
                {
                    Debug.LogError("Return [][] not supported");
                    return string.Empty;
                }
                else if (arrayExchange.elementType.ContainsGenericParameters)
                {
                    Debug.LogError(" Return T[] not supported");
                    return "/* Return T[] is not supported */";
                }

                return arrayExchange.Get_GetJSReturn();
            }
            else
            {
                var sb = new StringBuilder();
                bool needCast;
                var keyword = GetMetatypeKeyword(type, out needCast);

                sb.AppendFormat("{0}((int)JSApi.GetType.JSFunRet)", keyword);
                return sb.ToString();
            }
        }
        public static string Get_Return(Type type, string expVar)
        {
            if (type == typeof(void))
                return expVar + ";";

            if (type.IsArray)
            {
                arrayExchange.elementType = type.GetElementType();
                if (arrayExchange.elementType.IsArray)
                {
                    Debug.LogError("Return [][] not supported");
                    return string.Empty;
                }
                //            else if (arrayExchange.elementType.ContainsGenericParameters)
                //            {
                //                Debug.LogError(" Return T[] not supported");
                //                return "/* Return T[] is not supported */";
                //            }

                return arrayExchange.Get_Return(expVar);
            }
            else
            {
                var sb = new StringBuilder();
                bool needCast;
                var keyword = GetMetatypeKeyword(type, out needCast).Replace("get", "set");
                if (type.IsPrimitive)
                    sb.AppendFormat("{0}((int)JSApi.SetType.Rval, ({1})({2}));", keyword, JSNameMgr.CsFullName(type), expVar);
                else if (type.IsEnum)
                    sb.AppendFormat("{0}((int)JSApi.SetType.Rval, (int){1});", keyword, expVar);
                else
                    sb.AppendFormat("{0}((int)JSApi.SetType.Rval, {1});", keyword, expVar);

                return sb.ToString();
            }
        }

        public static string GetMethodArg_DelegateFuncionName(Type classType, string methodName, int methodTag, int argIndex)
        {
            // append Method Index if still conflicts
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("{0}_{1}_GetDelegate_member{2}_arg{3}", classType.Name, methodName, methodTag, argIndex);
            return JSNameMgr.HandleFunctionName(sb.ToString());
        }
        public static TextFile Build_GetDelegate(string getDelegateFunctionName, Type delType)
        {
            TextFile tf = new TextFile();
            TextFile tfFun = tf.Add("JSDataExchangeMgr.GetJSArg<{0}>(() => ", JSNameMgr.CsFullName(delType)).BraceIn();
            {
                TextFile tfIf = tfFun.Add("if (JSApi.isFunctionS((int)JSApi.GetType.Arg))").BraceIn();
                {
                    tfIf.Add("return {0}(JSApi.getFunctionS((int)JSApi.GetType.Arg));", getDelegateFunctionName);

                    tfIf.BraceOut();
                }

                TextFile tfElse = tfFun.Add("else").BraceIn();
                {
                    tfElse.Add("return ({0})JSMgr.datax.getObject((int)JSApi.GetType.Arg);", JSNameMgr.CsFullName(delType));

                    tfElse.BraceOut();
                }

                tfFun.BraceOut().Add(");");
            }

            return tf;
        }
        public static TextFile Build_DelegateFunction(Type classType, MemberInfo memberInfo, Type delType, int methodTag, int argIndex)
        {
            // building a closure
            // a function having a up-value: jsFunction

            string getDelFunctionName = GetMethodArg_DelegateFuncionName(classType, memberInfo.Name, methodTag, argIndex);

            TextFile tf = new TextFile();
            MethodInfo delInvoke = delType.GetMethod("Invoke");
            ParameterInfo[] ps = delInvoke.GetParameters();
            Type returnType = delType.GetMethod("Invoke").ReturnType;

            var argsParam = new args();
            for (int i = 0; i < ps.Length; i++)
            {
                argsParam.Add(ps[i].Name);
            }

            // format as <t,u,v>
            string stringTOfMethod = string.Empty;
            if (delType.ContainsGenericParameters)
            {
                var arg = new args();
                foreach (var t in delType.GetGenericArguments())
                {
                    arg.Add(t.Name);
                }
                stringTOfMethod = arg.Format(args.ArgsFormat.GenericT);
            }

            // this function name is used in BuildFields, don't change
            TextFile tfFun = tf.Add("public static {0} {1}{2}(CSRepresentedObject objFunction)",
                JSNameMgr.CsFullName(delType, true),  // [0]
                getDelFunctionName, // [2]
                stringTOfMethod  // [1]
                )
                .BraceIn();
            {
                tfFun.Add("if (objFunction == null || objFunction.jsObjID == 0)")
                    .In()
                        .Add("return null;")
                        .Out()
                        .AddLine();


                tfFun.Add("{0} action = ({0})JSMgr.getJSFunCSDelegateRel(objFunction.jsObjID);", JSNameMgr.CsFullName(delType, true));
                tfFun.Add("if (action != null)")
                    .In()
                        .Add("return action;")
                        .Out()
                        .AddLine();

                TextFile tfAction = tfFun.Add("action = ({0}) => \n", argsParam.Format(args.ArgsFormat.OnlyList))
                    .BraceIn();
                {
                    tfAction.Add("JSMgr.vCall.CallJSFunctionValue(0, objFunction.jsObjID{0}{1});", (argsParam.Count > 0) ? ", " : "", argsParam);

                    if (returnType != typeof(void))
                        tfAction.Add("return (" + JSNameMgr.CsFullName(returnType) + ")" + JSDataExchangeEditor.Get_GetJSReturn(returnType) + ";");

                    tfAction.BraceOutSC();
                }

                tfFun.Add("JSMgr.addJSFunCSDelegateRel(objFunction.jsObjID, action);")
                    .Add("return action;\n");

                tfFun.BraceOut();
            }

            return tf;
        }
        public enum MemberFeature
        {
            Static = 1 << 0,
            Indexer = 1 << 1, // for Property
            Get = 1 << 2,// can be Get or Set, only one of them, for Field Property
            Set = 1 << 3,
        }
        //
        // arg: a,b,c
        //
        public static TextFile BuildCallString(Type classType, MemberInfo memberInfo, string argList, MemberFeature features, object newValue = null /* string »ò TextFile */)
        {
            bool bGenericT = classType.IsGenericTypeDefinition;
            string memberName = memberInfo.Name;
            bool bIndexer = ((features & MemberFeature.Indexer) > 0);
            bool bStatic = ((features & MemberFeature.Static) > 0);
            bool bStruct = classType.IsValueType;
            string typeFullName = JSNameMgr.CsFullName(classType);
            bool bField = (memberInfo is FieldInfo);
            bool bProperty = (memberInfo is PropertyInfo);
            bool bGet = ((features & MemberFeature.Get) > 0);
            bool bSet = ((features & MemberFeature.Set) > 0);
            if ((bGet && bSet) || (!bGet && !bSet)) { return null; }

            TextFile tf = new TextFile();
            if (bField || bProperty)
            {
                if (!bGenericT)
                {
                    var strThis = typeFullName;
                    if (!bStatic)
                    {
                        strThis = "_this";
                        tf.Add("{0} _this = ({0})vc.csObj;", typeFullName);
                    }

                    string access = bIndexer
                         ? string.Format("{0}[{1}]", strThis, argList)
                         : string.Format("{0}.{1}", strThis, memberName);

                    if (bGet)
                    {
                        tf.Add("var result = {0};", access);
                    }
                    else
                    {
                        if (newValue is string)
                            tf.Add("{0} = {1};", access, newValue);
                        else
                            tf.Add("{0} = ").In().Add((newValue as TextFile).Ch).Out().Add(";");

                        if (!bStatic && bStruct)
                        {
                            tf.Add("JSMgr.changeJSObj(vc.jsObjID, _this);");
                        }
                    }
                }
                else
                {
                    // convention: name 'member'
                    if (bIndexer || !bIndexer) // both indexer and not indexer enters
                    {
                        string objs = (bStatic ? "null" : "vc.csObj");
                        if (bProperty)
                        {
                            if (bGet)
                            {
                                tf.Add("var result = member.GetValue({0}, new object[]{{{1}}});",
                                    objs,
                                    argList);
                            }
                            else
                            {
                                if (newValue is string)
                                {
                                    tf.Add("member.SetValue({0}, {1}, new object[]{{{2}}});",
                                       objs,
                                       newValue,
                                       argList);
                                }
                                else
                                {
                                    tf.Add("member.SetValue({0}, ", objs)
                                        .In()
                                            .Add((newValue as TextFile).Ch)
                                        .Out()
                                        .Add(", new object[]{{{0}}});", argList);
                                }
                            }


                            //tf.Add("{4}member.{0}({1}, {2}new object[]{{{3}}});",
                            //    bGet ? "GetValue" : "SetValue",
                            //    bStatic ? "null" : "vc.csObj",
                            //    bSet ? newValue + ", " : "",
                            //    argList,
                            //    bGet ? "var result = " : "");
                        }
                        else
                        {
                            if (bGet)
                            {
                                tf.Add("var result = member.GetValue({0});", objs);
                            }
                            else
                            {
                                if (newValue is string)
                                    tf.Add("member.SetValue({0}, {1});", objs, newValue);
                                else
                                    tf.Add("member.SetValue({0}, ", objs).In().Add((newValue as TextFile).Ch).Out().Add(");");
                            }

                            //tf.Add("{3}member.{0}({1}{2});",
                            //    bGet ? "GetValue" : "SetValue",
                            //    bStatic ? "null" : "vc.csObj",
                            //    bSet ? ", " + newValue : "",
                            //    bGet ? "var result = " : "");
                        }
                    }
                }
            }
            return tf;
        }
    }
}