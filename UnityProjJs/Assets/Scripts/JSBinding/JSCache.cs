using System;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace jsb
{
	
	public class JSCache
	{
		static int bridgeJsID = -1;
		public static int GetBridgeJsID()
		{
			if (bridgeJsID == -1)
			{
				JSApi.getProperty(0, "Bridge");
				bridgeJsID = JSApi.getSaveID();
				if (bridgeJsID != 0)
					JSApi.setTraceS(bridgeJsID, true);

				// bridgeJsID = JSApi.getObject((int)JSApi.GetType.SaveAndRemove);
			}
			
			if (bridgeJsID == 0)
            {
                throw new Exception("bridgeJsID is 0");
            }

			return bridgeJsID;
		}

		#region MonoBehaviour Inheritance Relation
		// 对继承关系做缓存
		
		static Dictionary<string, bool> dictClassInheritanceRel = new Dictionary<string, bool>();
		
		public static bool IsInheritanceRel(string baseClassName, string subClassName)
		{
			string key = baseClassName + "|" + subClassName;
			
			bool ret = false;
			if (dictClassInheritanceRel.TryGetValue (key, out ret)) {
				return ret;
			}

			if (!JSMgr.vCall.CallJSFunctionName(GetBridgeJsID(), "isInheritRel", baseClassName, subClassName))
				throw new Exception("call Bridge.isInheritRel failed!");

			ret = (System.Boolean)JSApi.getBooleanS((int)JSApi.GetType.JSFunRet);
			dictClassInheritanceRel.Add (key, ret);
			return ret;
		}
		
		#endregion MonoBehaviour Inheritance Relation
		
		#region Type -> TypeInfo
		
		public class TypeInfo
		{
			Type type;
			public TypeInfo(Type t) { this.type = t; }
			
			bool? isValueType = null;
			bool? isClass = null;
			bool? isDelegate = null;
			bool? isCSMonoBehaviour = null;
			string jsTypeFullName = null;
			
			// public bool IsNull { get { return type == null; } }
			
			public bool IsValueType
			{
				get
				{
					if (isValueType == null)
						isValueType = type.IsValueType;
					return (bool)isValueType;
				}
			}
			public bool IsClass
			{
				get
				{
					if (isClass == null)
						isClass = type.IsClass;
					return (bool)isClass;
				}
			}
			public bool IsDelegate
			{
				get
				{
					if (isDelegate == null)
						isDelegate = typeof(System.Delegate).IsAssignableFrom(type);
					return (bool)isDelegate;
				}
			}
			public bool IsCSMonoBehaviour
			{
				get
				{
					if (isCSMonoBehaviour == null)
					{
						if (type == null)
							isCSMonoBehaviour = false;
						else if (type.Namespace != null && type.Namespace.IndexOf("UnityEngine") >= 0)
							isCSMonoBehaviour = true;
						// This is useful if source c# file still exists in project
						// TODO
						//                    else if (type.GetCustomAttributes(typeof(SharpKit.JavaScript.JsTypeAttribute), false).Length > 0)
						//                        isCSMonoBehaviour = false;
						else if (!typeof(MonoBehaviour).IsAssignableFrom(type))
							isCSMonoBehaviour = false;
						else
							isCSMonoBehaviour = true;
					}
					return (bool)isCSMonoBehaviour;
				}
			}
			public string JSTypeFullName
			{
				get
				{
					if (jsTypeFullName == null)
						jsTypeFullName = JSNameMgr.JsFullName(type);
					return jsTypeFullName;
				}
			}
			
		}
		static Dictionary<Type, TypeInfo> dictType2TypeInfo = new Dictionary<Type, TypeInfo>();
		static TypeInfo nullTypeInfo = new TypeInfo(null);
		
		public static TypeInfo GetTypeInfo(Type type)
		{
			if (type == null)
				return nullTypeInfo;
			
			TypeInfo ti;
			if (dictType2TypeInfo.TryGetValue(type, out ti))
				return ti;
			
			ti = new TypeInfo(type);
			dictType2TypeInfo.Add(type, ti);
			return ti;
		}
		#endregion
	}

}