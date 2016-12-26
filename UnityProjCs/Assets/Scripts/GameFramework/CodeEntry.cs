using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CodeEntry : MonoBehaviour
{
    void Start()
    {
        // 这个函数是一个演示，他是整个应用程序的入口
        // 逻辑代码不能直接在Inspector中挂上去，那么总得有一个入口点，就是这里
        // 
        // 
        GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Login.prefab");
        GameObject go = (GameObject) Instantiate(prefab);
#if JS
        Instantiate(AssetDatabase.LoadMainAssetAtPath("Assets/Scripts/JSBinding/_JSEngine.prefab"));

        JSComponent jsComp = go.AddComponent<JSComponent>();
        jsComp.jsClassName = "Login";
        jsComp.jsFail = false;
        jsComp.init(true);
        jsComp.callAwake(); // 要调用 js 的 Awake
#else
        go.AddComponent<Login>();
#endif
    }
}
