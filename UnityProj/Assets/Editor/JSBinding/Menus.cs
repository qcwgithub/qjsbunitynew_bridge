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
		if (EditorApplication.isCompiling)
		{
			
			EditorUtility.DisplayDialog("提示",
			                            "等待Unity编译完再点",
			                            "确定"
			                            );
			return; 
		}

        List<Type> lst = JSBindingSettings.CheckClasses();
        if (lst == null)
		{
			return;
		}
		
		JSDataExchangeEditor.reset();
		UnityEngineManual.initManual();
        CSGenerator.GenerateClassBindings(lst);
        JSGenerator.GenerateClassBindings(lst);
        CSWrapGenerator.GenWraps();

        AssetDatabase.Refresh();
    }
}
