using UnityEngine;
using System.Collections;

// 这个是跑在C#的
public class TestCallJs : MonoBehaviour
{
#if JS
	int getJsObj(string n)
	{
		string[] arr = n.Split('.');
		int id = 0;
		foreach (var a in arr)
		{
			JSApi.getProperty(id, a);
			id = JSApi.getObject((int)JSApi.GetType.SaveAndRemove);
		}
		return id;
	}

	void Start () 
	{
		string n = "jsb.Test.Logic.TestCallFromCs";
		int id = getJsObj(n);

		//1---------------------------------------------------------------
		// 调用全局函数，使用 id 0
		JSMgr.vCall.CallJSFunctionName(id, "CreateJSBindingInfo");
		
		object obj = JSMgr.datax.getObject((int)JSApi.GetType.JSFunRet);
		CSRepresentedObject csObj = (CSRepresentedObject)obj;
		PrintJSBindingInfo(csObj.jsObjID);
	}
	
	void PrintJSBindingInfo(int objID)
	{
		// 获得字符串属性
		JSApi.getProperty(objID, "Version");
		string s = JSApi.getStringS((int)JSApi.GetType.SaveAndRemove);
		print("版本 " + s);
		
		// 获得整数属性
		JSApi.getProperty(objID, "QQGroup");
		int i = JSApi.getInt32((int)JSApi.GetType.SaveAndRemove);
		print("QQ群 " + i);
		
		// 调用这个obj的函数
		JSMgr.vCall.CallJSFunctionName(objID, "getDocumentUrl");
		s = JSApi.getStringS((int)JSApi.GetType.JSFunRet);
		print("文档 " + s);
	}
#else
	void Start()
	{
		print ("此测试只有JS版本有意义");
	}
#endif
}
