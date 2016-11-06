using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using jsb;

public class Menus
{
	[MenuItem("JSB/Gen Bindings", false, 1)]
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
}
