using UnityEngine;
using System.Collections;
using System.IO;

/// <summary>
/// JSFileLoader
/// 一个加载JS文件的加载器，简单版
/// 在正式版的游戏中，需要另外写一个
/// </summary>
public class JSFileLoader : MonoBehaviour 
{
    //public bool Async = true;
    public delegate void OnLoadJS(string shortName, byte[] bytes, string fullName);

//    public void LoadJSAsync(string shortName, bool bGenerated, OnLoadJS onLoadJS)
//    {
//        StartCoroutine(WWWLoad(shortName, bGenerated, onLoadJS));
//    }

//    public void LoadJSSync(string shortName, bool bGenerated, OnLoadJS onLoadJS)
//    {
//        string fullName = JSMgr.getJSFullName(shortName, bGenerated);
//        byte[] bytes = LoadJSSync(fullName);
//        onLoadJS(shortName, bytes, fullName);
//    }
    public virtual byte[] LoadJSSync(string fullName)
    {
        byte[] bytes = null;

        //
        // 在安卓平台，StreamingAssets 文件是在 apk 内部的，从他里面同步加载文件的唯一方式是死循环等待 WWW 完成
        // 
#if UNITY_ANDROID && !UNITY_EDITOR_WIN && !UNITY_EDITOR_OSX
        WWW w = new WWW(fullName);
        while (true)
        {
            if (w.error != null && w.error.Length > 0)
            {
                Debug.Log("ERROR: /// " + w.error);
                break;
            }

            if (w.isDone)
                break;
        }
        bytes = w.bytes;
#else
        try
        {
            bytes = File.ReadAllBytes(fullName);
        }
        catch (System.Exception exp) 
        {
            Debug.LogError(exp.ToString());
        }
#endif
        return bytes;
    }

//    IEnumerator WWWLoad(string shortName, bool bGenerated, OnLoadJS onLoadJS)
//    {
//        string fullName = JSMgr.getJSFullName(shortName, bGenerated);
//
//        WWW www = new WWW(fullName);
//        yield return www;
//
//        if (www.error != null && www.error.Length > 0)
//        {
//            Debug.Log("Error loading JS: " + fullName + " " + www.error);
//            onLoadJS(shortName, null, fullName);
//        }
//        else
//        {
//            onLoadJS(shortName, www.bytes, fullName);
//        }
//    }
}
