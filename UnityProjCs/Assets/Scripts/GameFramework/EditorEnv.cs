using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class EditorEnv
{
    public static UnityEngine.Object LoadMainAssetAtPath(string path)
    {
#if UNITY_4
        return Resources.LoadAssetAtPath(path);
#else
        return AssetDatabase.LoadMainAssetAtPath(path);
#endif
    }
}
