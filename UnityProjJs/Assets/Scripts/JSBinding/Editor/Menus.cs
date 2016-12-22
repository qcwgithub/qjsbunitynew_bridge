using System;
using System.Text;
using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using jsb;

public class Menus
{
	[MenuItem("JSB/Gen Bindings", false, 2)]
	public static void GenBindings()
	{
        //var d = typeof(UnityEngine.MonoBehaviour).GetConstructors();
        //Debug.Log("d.length=" + d.Length);
        //return;

		if (EditorApplication.isCompiling)
		{
			
			EditorUtility.DisplayDialog("提示",
			                            "等待Unity编译完再点",
			                            "确定"
			                            );
			return; 
		}

        Type[] arrEnums, arrClasses;
        HashSet<string> bridgeTypes;
        if (!JSBindingSettings.CheckClasses(out arrEnums, out arrClasses, out bridgeTypes))
		{
			return;
		}
		
		JSDataExchangeEditor.reset();
		UnityEngineManual.initManual();
        CSGenerator.GenBindings(arrEnums, arrClasses);
        JSGenerator.GenBindings(arrEnums, arrClasses);
        CSWrapGenerator.GenWraps(arrEnums, arrClasses, bridgeTypes);

        AssetDatabase.Refresh();
    }

    [MenuItem("JSB/Update JavaScript", false, 1)]
    public static void UpdateJavaScript()
    {
        string dir = JSBindingSettings.BridgeOutputDir;
        string[] files = Directory.GetFiles(dir, "*.js");

        StringBuilder sb = new StringBuilder();
        foreach (var fileFullName in files)
        {
            string fileName = fileFullName
                .Substring(fileFullName.Replace('\\', '/').LastIndexOf('/') + 1)
                .ToLower();

            if (fileName != "bridge.js" &&
                fileName != "csw.js" &&
                !fileName.EndsWith("min.js"))
            {
                sb.Append(File.ReadAllText(fileFullName));
                sb.AppendLine();
            }
        }

        File.WriteAllText(JSMgr.jsGenByBridgeFile, sb.ToString());
        CorrectJavaScriptYieldCode(JSMgr.jsGenByBridgeFile);

        Debug.Log("OK");
        AssetDatabase.Refresh();
    }

    static void CorrectJavaScriptYieldCode(string filePath)
    {
        string YIELD_DEF = "var $yield = [];"; // 删
        string YIELD_PUSH = "$yield.push"; // 替换为 "yield "
        string YIELD_RET = "return System.Array.toEnumerator($yield);"; // 删
        string FUN_DEC = "function ("; // 替换为 "function* ("

        StringBuilder sb = new StringBuilder();
        StringBuilder sbFail = new StringBuilder();

        bool suc = true;
        string str = File.ReadAllText(filePath);
        int lastIndex = 0, yildDefIndex, funStart = 0;
        int count = 0;
        while (true)
        {
            yildDefIndex = str.IndexOf(YIELD_DEF, lastIndex);
            if (yildDefIndex < 0) { break; }

            funStart = str.LastIndexOf(FUN_DEC, yildDefIndex);
            if (funStart < 0) { suc = false; break; }

            sb.Append(str.Substring(lastIndex, funStart - lastIndex));
            sb.Append("function* (");

            funStart += FUN_DEC.Length;
            lastIndex = str.IndexOf(YIELD_RET, yildDefIndex);
            if (lastIndex < 0) { suc = false; break; }
            lastIndex += YIELD_RET.Length;

            sb.Append(str.Substring(funStart, lastIndex - funStart).Replace(YIELD_DEF, "").Replace(YIELD_PUSH, "yield ").Replace(YIELD_RET, ""));
            count++;
        }
        if (suc)
        {
            if (count > 0)
            {
                sb.Append(str.Substring(lastIndex));
                File.WriteAllText(filePath, sb.ToString());
            }
        }
        else
        {
            sbFail.AppendLine();
            sbFail.Append(filePath);
        }

        if (sbFail.Length == 0)
            Debug.Log("成功，共替换" + count + "个函数");
        else
            Debug.LogError("失败");
    }
	
//	[MenuItem("JSB/Gen Messages", false, 3)]
    static void GenMsgs()
	{
		jsb.MessageGenerator.Gen();
		AssetDatabase.Refresh();
	}
}
