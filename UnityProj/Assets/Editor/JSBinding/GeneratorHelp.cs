using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;

namespace jsb
{
    /// <summary>
    /// 
    /// </summary>
    public static class GeneratorHelp
    {
        public class ATypeInfo
        {
            public FieldInfo[] fields;
            public int[] fieldsIndex;

            public PropertyInfo[] properties;
            public int[] propertiesIndex;

            public ConstructorInfo[] constructors;
            public int[] constructorsIndex;

            public MethodInfo[] methods;
            public int[] methodsIndex; // 函数在这个数组中的索引：type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static | BindingFlags.DeclaredOnly);

            public int[] methodsOLInfo;     // 0 不重载 >0 重载序号
            public int howmanyConstructors; // 过滤前一共有几个构造函数
        }
        public static List<ATypeInfo> allTypeInfo = new List<ATypeInfo>();

        public static void ClearTypeInfo()
        {
            //         CallbackInfo cbi = new CallbackInfo();
            //         cbi.fields = new List<CSCallbackField>();
            //         cbi.fields.Add(Vector3Generated.Vector3_x);

            allTypeInfo.Clear();
        }
        public static int AddTypeInfo(Type type)
        {
            ATypeInfo tiOut = new ATypeInfo();
            return AddTypeInfo(type, out tiOut);
        }

        public static int AddTypeInfo(Type type, out ATypeInfo tiOut)
        {
            ATypeInfo ti = new ATypeInfo();
            ti.fields = type.GetFields(JSMgr.BindingFlagsField);
            ti.properties = type.GetProperties(JSMgr.BindingFlagsProperty);
            ti.methods = type.GetMethods(JSMgr.BindingFlagsMethod);
            ti.constructors = type.GetConstructors();
            if (JSBindingSettings.NeedGenDefaultConstructor(type))
            {
                // null means it's default constructor
                var l = new List<ConstructorInfo>();
                l.Add(null);
                l.AddRange(ti.constructors);
                ti.constructors = l.ToArray();
            }
            ti.howmanyConstructors = ti.constructors.Length;

            FilterTypeInfo(type, ti);

            int slot = allTypeInfo.Count;
            allTypeInfo.Add(ti);
            tiOut = ti;
            return slot;
        }
        public static bool IsMemberObsolete(MemberInfo mi)
        {
            object[] attrs = mi.GetCustomAttributes(true);
            for (int j = 0; j < attrs.Length; j++)
            {
                if (attrs[j].GetType() == typeof(System.ObsoleteAttribute))
                {
                    return true;
                }
            }
            return false;

        }

        // 与 Bridge 的排序方式保持一致！处理重载函数的后缀才不会有问题
        static string MethodToString(MethodInfo m)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();

            sb.Append(m.ReturnType.ToString()).Append(" ");
            sb.Append(m.Name).Append(" ");
            sb.Append(m.GetGenericArguments().Length).Append(" ");

            foreach (var p in m.GetParameters())
            {
                sb.Append(p.ParameterType.ToString()).Append(" ");
            }
            return sb.ToString();
        }
        public static int MethodInfoComparison(MethodInfoAndIndex mi1, MethodInfoAndIndex mi2)
        {
            MethodInfo m1 = mi1.method;
            MethodInfo m2 = mi2.method;

            // 实例函数在前
            if (!m1.IsStatic && m2.IsStatic)
                return -1;
            if (m1.IsStatic && !m2.IsStatic)
                return 1;

            // 按名字字符串排序
            if (m1.Name != m2.Name)
                return string.Compare(m1.Name, m2.Name);

            return string.Compare(MethodToString(m1), MethodToString(m2));
        }

        public struct FieldInfoAndIndex
        {
            public FieldInfo method;
            public int index;
            public FieldInfoAndIndex(FieldInfo _m, int _i) { method = _m; index = _i; }
        }
        public struct MethodInfoAndIndex
        {
            public MethodInfo method;
            public int index;
            public MethodInfoAndIndex(MethodInfo _m, int _i) { method = _m; index = _i; }
        }
        public struct ConstructorInfoAndIndex
        {
            public ConstructorInfo method;
            public int index;
            public ConstructorInfoAndIndex(ConstructorInfo _m, int _i) { method = _m; index = _i; }
        }
        public struct PropertyInfoAndIndex
        {
            public PropertyInfo method;
            public int index;
            public PropertyInfoAndIndex(PropertyInfo _m, int _i) { method = _m; index = _i; }
        }
        public static void FilterTypeInfo(Type type, ATypeInfo ti)
        {
            bool isStaticClass = (type.IsClass && type.IsAbstract && type.IsSealed);
            bool isAbstractClass = (type.IsClass && type.IsAbstract);

            List<ConstructorInfoAndIndex> lstCons = new List<ConstructorInfoAndIndex>();
            List<FieldInfoAndIndex> lstField = new List<FieldInfoAndIndex>();
            List<PropertyInfoAndIndex> lstPro = new List<PropertyInfoAndIndex>();
            Dictionary<string, int> proAccessors = new Dictionary<string, int>();
            List<MethodInfoAndIndex> lstMethod = new List<MethodInfoAndIndex>();

            for (int i = 0; i < ti.constructors.Length; i++)
            {
                if (isAbstractClass)
                    continue;

                if (ti.constructors[i] == null)
                {
                    lstCons.Add(new ConstructorInfoAndIndex(null, i));
                    continue;
                }

                // 不要生成 MonoBehaviour 的构造函数
                if (type == typeof(UnityEngine.MonoBehaviour))
                {
                    continue;
                }

                if (!IsMemberObsolete(ti.constructors[i]) && !JSBindingSettings.IsDiscard(type, ti.constructors[i]))
                {
                    lstCons.Add(new ConstructorInfoAndIndex(ti.constructors[i], i));
                }
            }

            for (int i = 0; i < ti.fields.Length; i++)
            {
                if (typeof(System.Delegate).IsAssignableFrom(ti.fields[i].FieldType.BaseType))
                {
                    //Debug.Log("[field]" + type.ToString() + "." + ti.fields[i].Name + "is delegate!");
                }
                if (ti.fields[i].FieldType.ContainsGenericParameters)
                    continue;

                if (!IsMemberObsolete(ti.fields[i]) && !JSBindingSettings.IsDiscard(type, ti.fields[i]))
                {
                    lstField.Add(new FieldInfoAndIndex(ti.fields[i], i));
                }
            }


            for (int i = 0; i < ti.properties.Length; i++)
            {
                PropertyInfo pro = ti.properties[i];

                if (typeof(System.Delegate).IsAssignableFrom(pro.PropertyType.BaseType))
                {
                    // Debug.Log("[property]" + type.ToString() + "." + pro.Name + "is delegate!");
                }

                MethodInfo[] accessors = pro.GetAccessors();
                foreach (var v in accessors)
                {
                    if (!proAccessors.ContainsKey(v.Name))
                        proAccessors.Add(v.Name, 0);
                }


                //            if (pro.GetIndexParameters().Length > 0)
                //                continue;
                //            if (pro.Name == "Item") //[] not support
                //                continue;

                // Skip Obsolete
                if (IsMemberObsolete(pro))
                    continue;

                if (JSBindingSettings.IsDiscard(type, pro))
                    continue;

                lstPro.Add(new PropertyInfoAndIndex(pro, i));
            }


            for (int i = 0; i < ti.methods.Length; i++)
            {
                MethodInfo method = ti.methods[i];

                // skip non-static method in static class
                if (isStaticClass && !method.IsStatic)
                {
                    // NGUITools
                    //Debug.Log("........."+type.Name+"."+method.Name);
                    continue;
                }

                // skip property accessor
                if (method.IsSpecialName &&
                    proAccessors.ContainsKey(method.Name))
                {
                    continue;
                }

                if (method.IsSpecialName)
                {
                    if (method.Name == "op_Addition" ||
                        method.Name == "op_Subtraction" ||
                        method.Name == "op_UnaryNegation" ||
                        method.Name == "op_Multiply" ||
                        method.Name == "op_Division" ||
                        method.Name == "op_Equality" ||
                        method.Name == "op_Inequality" ||

                        method.Name == "op_LessThan" ||
                        method.Name == "op_LessThanOrEqual" ||
                        method.Name == "op_GreaterThan" ||
                        method.Name == "op_GreaterThanOrEqual" ||

                        method.Name == "op_Implicit")
                    {
                        if (!method.IsStatic)
                        {
                            Debug.Log("忽略非静态特殊名字函数 " + type.Name + "." + method.Name);
                            continue;
                        }
                    }
                    else
                    {
                        Debug.Log("忽略特殊名字函数 " + type.Name + "." + method.Name);
                        continue;
                    }
                }

                // Skip Obsolete
                if (IsMemberObsolete(method))
                    continue;

                ParameterInfo[] ps;
                bool bDiscard = false;

                // 忽略掉类型带 T 的静态方法
                // 因为 SharpKit 调用时没有提供 T
                if (method.IsGenericMethodDefinition /* || method.IsGenericMethod*/
                    && method.IsStatic)
                {
                    ps = method.GetParameters();
                    for (int k = 0; k < ps.Length; k++)
                    {
                        if (ps[k].ParameterType.ContainsGenericParameters)
                        {
                            var Ts = JSDataExchangeMgr.RecursivelyGetGenericParameters(ps[k].ParameterType);
                            foreach (var t in Ts)
                            {
                                if (t.DeclaringMethod == null)
                                {
                                    bDiscard = true;
                                    break;
                                }
                            }
                            if (bDiscard)
                                break;
                        }
                    }
                    if (bDiscard)
                    {
                        Debug.LogWarning("忽略静态函数 " + type.Name + "." + method.Name);
                        continue;
                    }
                }

                // 是否有 unsafe 的参数？
                bDiscard = false;
                ps = method.GetParameters();
                for (var k = 0; k < ps.Length; k++)
                {
                    Type pt = ps[k].ParameterType;
                    while (true)
                    {
                        if (pt.IsPointer)
                        {
                            bDiscard = true;
                            break;
                        }
                        else if (pt.HasElementType)
                            pt = pt.GetElementType();
                        else
                            break;
                    }

                    if (bDiscard)
                        break;
                }
                if (bDiscard)
                {
                    Debug.Log(type.Name + "." + method.Name + " 忽略，因为他有 unsafe 的参数");
                    continue;
                }

                if (JSBindingSettings.IsDiscard(type, method))
                    continue;

                lstMethod.Add(new MethodInfoAndIndex(method, i));
            }

            if (lstMethod.Count == 0)
                ti.methodsOLInfo = null;
            else
            {
                // 函数排序
                lstMethod.Sort(MethodInfoComparison);
                ti.methodsOLInfo = new int[lstMethod.Count];
            }

            int overloadedIndex = 1;
            bool bOL = false;
            for (int i = 0; i < lstMethod.Count; i++)
            {
                ti.methodsOLInfo[i] = 0;
                if (bOL)
                {
                    ti.methodsOLInfo[i] = overloadedIndex;
                }

                if (i < lstMethod.Count - 1 && lstMethod[i].method.Name == lstMethod[i + 1].method.Name &&
                    ((lstMethod[i].method.IsStatic && lstMethod[i + 1].method.IsStatic) ||
                    (!lstMethod[i].method.IsStatic && !lstMethod[i + 1].method.IsStatic)))
                {
                    if (!bOL)
                    {
                        overloadedIndex = 1;
                        bOL = true;
                        ti.methodsOLInfo[i] = overloadedIndex;
                    }
                    overloadedIndex++;
                }
                else
                {
                    bOL = false;
                    overloadedIndex = 1;
                }
            }

            ti.constructors = new ConstructorInfo[lstCons.Count];
            ti.constructorsIndex = new int[lstCons.Count];
            for (var k = 0; k < lstCons.Count; k++)
            {
                ti.constructors[k] = lstCons[k].method;
                ti.constructorsIndex[k] = lstCons[k].index;
            }

            // ti.fields = lstField.ToArray();
            ti.fields = new FieldInfo[lstField.Count];
            ti.fieldsIndex = new int[lstField.Count];
            for (var k = 0; k < lstField.Count; k++)
            {
                ti.fields[k] = lstField[k].method;
                ti.fieldsIndex[k] = lstField[k].index;
            }

            // ti.properties = lstPro.ToArray();
            ti.properties = new PropertyInfo[lstPro.Count];
            ti.propertiesIndex = new int[lstPro.Count];
            for (var k = 0; k < lstPro.Count; k++)
            {
                ti.properties[k] = lstPro[k].method;
                ti.propertiesIndex[k] = lstPro[k].index;
            }

            ti.methods = new MethodInfo[lstMethod.Count];
            ti.methodsIndex = new int[lstMethod.Count];

            for (var k = 0; k < lstMethod.Count; k++)
            {
                ti.methods[k] = lstMethod[k].method;
                ti.methodsIndex[k] = lstMethod[k].index;
            }
        }

        /// <summary>
        /// Method is overloaded or not?
        /// Used in JSGenerator2
        /// No matter it's static or not
        /// including NonPublic methods
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <returns></returns>
        public static bool MethodIsOverloaded(Type type, string methodName)
        {
            bool ret = MethodIsOverloaded2(type, methodName, JSMgr.BindingFlagsMethod2);
            if (!ret)
            {
                if (MethodIsOverloaded2(type, methodName, JSMgr.BindingFlagsMethod3))
                {
                    ret = true;
                    Debug.Log("NEW OVERLOAD " + type.Name + "." + methodName);
                }
            }
            return ret;
        }
        public static bool MethodIsOverloaded2(Type type, string methodName, BindingFlags flag)
        {
            MethodInfo[] methods = type.GetMethods(flag);
            int N = 0;
            foreach (var m in methods)
            {
                if (m.Name == methodName)
                {
                    N++;
                    if (N >= 2)
                        return true;
                }
            }
            return false;
        }

    }
}