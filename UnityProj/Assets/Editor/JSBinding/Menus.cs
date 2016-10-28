using UnityEngine;
using System.Collections;
using UnityEditor;

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
				
		if (!CSGenerator.CheckClassBindings())
		{
			return;
		}

		
		JSDataExchangeEditor.reset();
		UnityEngineManual.initManual();
		CSGenerator.GenerateClassBindings();

        AssetDatabase.Refresh();
    }
}
