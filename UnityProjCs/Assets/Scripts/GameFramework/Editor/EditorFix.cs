using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

public static class EditorFix
{
    public static void SetObjectDirty(Object o)
    {
        EditorUtility.SetDirty(o);
    }

    public static void SetObjectDirty(GameObject go)
    {
        EditorUtility.SetDirty(go);
        EditorSceneManager.MarkSceneDirty(go.scene); //This used to happen automatically from SetDirty
    }

    public static void SetObjectDirty(Component comp)
    {
        EditorUtility.SetDirty(comp);
        EditorSceneManager.MarkSceneDirty(comp.gameObject.scene); //This used to happen automatically from SetDirty
    }
}