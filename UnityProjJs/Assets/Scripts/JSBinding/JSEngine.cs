using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using jsval = JSApi.jsval;

// JSEngine：代表 Js 引擎
public class JSEngine : MonoBehaviour
{
    public static JSEngine inst;
    public static int initState = 0;
    public static bool initSuccess { get { return initState == 1; } set { if (value) initState = 1; } }
    public static bool initFail { get { return initState == 2; } set { if (value) initState = 2; else initState = 0; } }
    
    public void OnInitJSEngine(bool bSuccess)
    {
        if (bSuccess)
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            {
                JSMgr.evaluate("Includes");
            }
            sw.Stop();

            print(string.Format("JS: Init OK. Loading js cost {0} ms. Enable printing error stack: {1}.",
                sw.ElapsedMilliseconds,
                (JSApi.initErrorHandler() == 1 ? "Yes" : "No")));

            initSuccess = true;
        }
        else
        {
            initFail = true;
            Debug.LogError("JS: Init failed.");
        }
    }

    // 这个函数可能从 JSComponent 调用过来
    public static void FirstInit(JSEngine jse = null)
    {
        if (!initSuccess && !initFail)
        {
            if (jse == null)
            {
                var goEngine = new GameObject("_JSEngine");
                goEngine.AddComponent<JSEngine>();
                return;
            }

            if (jse != null)
            {
                DontDestroyOnLoad(jse.gameObject);
                inst = jse;

                JSFileLoader jsLoader = jse.gameObject.GetComponent<JSFileLoader>();
                if (jsLoader == null)
                    jsLoader = jse.gameObject.AddComponent<JSFileLoader>();
                JSMgr.InitJSEngine(jsLoader, jse.OnInitJSEngine);
            }
        }
    }

    void Awake()
    {
        if (JSEngine.inst != null && JSEngine.inst != this)
        {
            // destroy self if there is already a JSEngine gameObject
            Destroy(gameObject);
            return;
        }

        JSEngine.FirstInit(this);
    }

    int jsCallCountPerFrame = 0;
    void Update()
    {
        if (this != JSEngine.inst)
            return;

        jsCallCountPerFrame = JSMgr.vCall.jsCallCount;
        JSMgr.vCall.jsCallCount = 0;

        UpdateThreadSafeActions();
    }

    List<Action> lstThreadSafeActions = new List<Action>();
    bool hasThreadSafeActions = false;
    object @lock = new object();

    public void DoThreadSafeAction(Action action)
    {
        lock (@lock)
        {
            hasThreadSafeActions = true;
            lstThreadSafeActions.Add(action);
        }
    }
    public void UpdateThreadSafeActions()
    {
        if (hasThreadSafeActions)
        {
            lock (@lock)
            {
                foreach (Action action in lstThreadSafeActions)
                {
                    action();
                }
                lstThreadSafeActions.Clear();
                hasThreadSafeActions = false;
            }
        }
    }

//     void OnApplicationQuit()
//     {
//         Debug.Log("OnApplicationQuit");
//     }
    void OnDestroy()
    {
        if (this == JSEngine.inst)
        {
            JSMgr.ShutdownJSEngine();
            JSEngine.inst = null;
            JSEngine.initState = 0;
            Debug.Log("JS: JSEngine Destroy");
        }
    }

	public bool showStatistics = true;
    public int guiX = 0;

    void OnGUI()
    {
        if (this != JSEngine.inst)
            return;
		if (!showStatistics)
			return;
        int countDict1, countDict2;

        JSMgr.GetDictCount(out countDict1, out countDict2);

        GUI.TextArea(new Rect(guiX, 10, 500, 20), "JS->CS Count " + this.jsCallCountPerFrame + " Round " + JSMgr.jsEngineRound + " Objs(Total " + countDict1.ToString() + ", Class " + countDict2.ToString() + ") CSR(Obj " + CSRepresentedObject.s_objCount + " Fun " + CSRepresentedObject.s_funCount + ") Del " + JSMgr.getJSFunCSDelegateCount());

        int clsCount = 0;
        var dict1 = JSMgr.GetDict1();
        var Keys = new List<int>(dict1.Keys);

        var class2Count = new Dictionary<string, int>();
        foreach (int K in Keys)
        {
            if (!dict1.ContainsKey(K))
                continue;

            var Rel = dict1[K];
            var typeName = Rel.csObj.GetType().Name;
            if (class2Count.ContainsKey(typeName))
            {
                class2Count[typeName]++;
            }
            else
            {
                class2Count[typeName] = 1;
            }
            if (Rel.csObj != null && Rel.csObj.GetType().IsClass)
            {
                clsCount++;
            }
        }
        float y = 40;

        GUI.TextArea(new Rect(guiX, y, 400, 20), "class count: " + clsCount);
        y += 20;

        GUI.TextArea(new Rect(guiX, y, 400, 20), "valueMapSize: " + JSApi.getValueMapSize());
        y += 20;

        GUI.TextArea(new Rect(guiX, y, 400, 20), "valueMapIndex: " + JSApi.getValueMapIndex());
        y += 20;

        foreach (var v in class2Count)
        {
            GUI.TextArea(new Rect(guiX, y, 400, 20), v.Key + ": " + v.Value);
            y += 20;
        }
    }
}