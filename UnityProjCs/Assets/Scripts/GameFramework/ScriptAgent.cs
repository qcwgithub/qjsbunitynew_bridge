using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// ScriptAgent：表示一个逻辑脚本的“代理”
/// 逻辑脚本不能挂到 gameObject 上，而是挂这个脚本做为“代理”
/// 这个脚本启动后
/// 1) 如果当前是 C# 版本，则把自己替换成对应的 C# 脚本即可
/// 2) 如果当前是 Js 版本，则添加 JSComponent 对象，（会同时创建 Js 对象）
/// 
/// 这个脚本同时还具体“序列化”功能，支持 int string bool GameObject。
/// 
/// 使用步骤：
/// 1) 挂上这个脚本
/// 2) 填写脚本名（要包含名字空间）
/// 3) 点 Update 按钮，如果有需要序列化的变量会自动显示出来
/// 
/// 不是必须使用这个脚本，手动 AddComponent 也是可以的
/// </summary>
/// 
/// 文档：
/// http://www.cnblogs.com/answerwinner/p/6269747.html
/// 

public class ScriptAgent : MonoBehaviour
{
    [Serializable]
    public class NamedInt
    {
        public string name;
        public int v;
        public NamedInt Copy() { return new NamedInt() { name = this.name, v = this.v }; }
    }

    [Serializable]
    public class NamedString
    {
        public string name;
        public string v;
        public NamedString Copy() { return new NamedString() { name = this.name, v = this.v }; }
    }

    [Serializable]
    public class NamedBool
    {
        public string name;
        public bool v;
        public NamedBool Copy() { return new NamedBool() { name = this.name, v = this.v }; }
    }

    [Serializable]
    public class NamedGo
    {
        public string name;
        public GameObject v;
        public NamedGo Copy() { return new NamedGo() { name = this.name, v = this.v }; }
    }
    
    public string ScriptName;
    public List<NamedGo> Gos = null;
    public List<NamedInt> Ints = null;
    public List<NamedString> Strings = null;
    public List<NamedBool> Bools = null;

    void Awake()
    {
        // 子节点的Agent也要处理一下，否则之后GetComponent会取不到子节点的脚本
        // 但是这样也不有处理全面，举一个有问题的例子：
        // A       无ScriptAgent 
        // | - B   有ScriptAgent，active
        // | - C   有ScriptAgent，inactive
        // |
        // 
        // 这个prefab加载后，C的Agent不会被执行。这种情况很少就是了
        // 
        ScriptAgent[] agents = GetComponentsInChildren<ScriptAgent>(true/* 获取非active的对象 */);
        for (int i = 0; i < agents.Length; i++)
        {
            if (agents[i] != null)
                agents[i].InitAndDestroy();
        }
        InitAndDestroy();
    }
    bool inited = false;

#if JS
    void SetField(int jsId, string _name)
    {
        int id = JSApi.getSaveID();
        JSApi.setProperty(jsId, _name, id);
        JSApi.removeByID(id);
    }

    void SerializeData(JSComponent script)
    {
        int jsId = script.GetJSObjID(false);
        if (jsId == 0)
            return;

        if (Gos != null)
        {
            foreach (var n in Gos)
            {
                JSMgr.datax.setObject((int)JSApi.SetType.SaveAndTempTrace, n.v);
                SetField(jsId, n.name);
            }
        }
        if (Ints != null)
        {
            foreach (var n in Ints)
            {
                JSApi.setInt32((int)JSApi.SetType.SaveAndTempTrace, n.v);
                SetField(jsId, n.name);
            }
        }
        if (Strings != null)
        {
            foreach (var n in Strings)
            {
                JSApi.setStringS((int)JSApi.SetType.SaveAndTempTrace, n.v);
                SetField(jsId, n.name);
            }
        }
        if (Bools != null)
        {
            foreach (var n in Bools)
            {
                JSApi.setBooleanS((int)JSApi.SetType.SaveAndTempTrace, n.v);
                SetField(jsId, n.name);
            }
        }
    }

    public void InitAndDestroy()
    {
        if (!inited)
        {
            inited = true;

            JSComponent script = gameObject.AddComponent<JSComponent>();
            script.jsClassName = ScriptName;
            script.jsFail = false;
            script.init(true);

            SerializeData(script);

            script.callAwake();
            script.callOnAwake();
            script.callOnEnable();

            Destroy(this);
        }
    }

#else
    void SetField(MonoBehaviour script, Type type, string _name, object v)
    {
        FieldInfo field = type.GetField(_name);
        if (field != null)
            field.SetValue(script, v);
    }

    void SerializeData(MonoBehaviour script, Type type)
    {
        if (Gos != null)
        {
            foreach (var n in Gos)
            {
                SetField(script, type, n.name, n.v);
            }
        }
        if (Ints != null)
        {
            foreach (var n in Ints)
            {
                SetField(script, type, n.name, n.v);
            }
        }
        if (Strings != null)
        {
            foreach (var n in Strings)
            {
                SetField(script, type, n.name, n.v);
            }
        }
        if (Bools != null)
        {
            foreach (var n in Bools)
            {
                SetField(script, type, n.name, n.v);
            }
        }
    }
    static Dictionary<string, Type> typeCache = new Dictionary<string, Type>();
    public static Type GetTypeByName(string typeName, Type defaultType = null)
    {
        Type t = null;
        if (!typeCache.TryGetValue(typeName, out t))
        {
            if (typeName == "String")
            {
                t = typeof(string);
            }
            else
            {
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    t = a.GetType(typeName);
                    if (t != null)
                    {
                        break;
                    }
                }
            }
            typeCache[typeName] = t;
        }
        if (t == null)
        {
            return defaultType;
        }
        return t;
    }

    void InitAndDestroy()
    {
        if (!inited)
        {
            inited = true;

            Type type;
            if (typeCache.ContainsKey(ScriptName))
                type = typeCache[ScriptName];
            else
            {
                type = GetTypeByName(ScriptName);
                typeCache[ScriptName] = type;
            }

            MonoBehaviour script = (MonoBehaviour)gameObject.AddComponent(type);
            SerializeData(script, type);

            MethodInfo method = script.GetType().GetMethod("OnAwake");
            if (method != null)
                method.Invoke(script, null);

            Destroy(this);
        }
    }
#endif

    //public GameObject GetGo(string name)
    //{
    //    if (Gos == null)
    //        return null;
    //    foreach (var n in Gos)
    //    {
    //        if (n.name == name)
    //            return n.v;
    //    }
    //    return null;
    //}
    //T GetCom<T>(string name) where T : Component
    //{
    //    GameObject go = GetGo(name);
    //    if (go == null)
    //        return null;
    //    return go.GetComponent<T>();
    //}
    //public Transform GetTrans(string name) { return GetCom<Transform>(name); }
    //public Button GetButton(string name) { return GetCom<Button>(name); }
    //public Text GetText(string name) { return GetCom<Text>(name); }
    //public InputField GetInputField(string name) { return GetCom<InputField>(name); }
    //public Slider GetSlider(string name) { return GetCom<Slider>(name); }
    //public Toggle GetToggle(string name) { return GetCom<Toggle>(name); }
    //public CanvasGroup GetCanvasGroup(string name) { return GetCom<CanvasGroup>(name); }
    //public ScrollRect GetScrollRect(string name) { return GetCom<ScrollRect>(name); }
    //public Image GetImage(string name) { return GetCom<Image>(name); }
    //public RawImage GetRawImage(string name) { return GetCom<RawImage>(name); }

    //public int GetInt(string name)
    //{
    //    if (Ints == null)
    //        return 0;
    //    foreach (var n in Ints)
    //    {
    //        if (n.name == name)
    //            return n.v;
    //    }
    //    return 0;
    //}
    //public bool GetBool(string name)
    //{
    //    if (Bools == null)
    //        return false;
    //    foreach (var n in Bools)
    //    {
    //        if (n.name == name)
    //            return n.v;
    //    }
    //    return false;
    //}
    //public string GetString(string name)
    //{
    //    if (Bools == null)
    //        return string.Empty;
    //    foreach (var n in Strings)
    //    {
    //        if (n.name == name)
    //            return n.v;
    //    }
    //    return string.Empty;
    //}
}

// 方便使用 DictBehaviour
//public static class MonoBehavioursExt
//{
//    public static ScriptAgent GetDataBehaviour(this MonoBehaviour b)
//    {
//        return b.GetComponent<ScriptAgent>();
//    }
//}
