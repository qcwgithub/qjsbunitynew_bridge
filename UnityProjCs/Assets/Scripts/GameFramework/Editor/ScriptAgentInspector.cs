using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ScriptAgent))]
public class ScriptAgentInspector : Editor
{
    //static Dictionary<string, bool> dFold;
    //bool isFold(string k)
    //{
    //    return dFold == null || !dFold.ContainsKey(k) || dFold[k];
    //}
    //void setFold(string k, bool b)
    //{
    //    if (dFold == null)
    //        dFold = new Dictionary<string, bool>();
    //    dFold[k] = b;
    //}
    //static GUIStyle dupStyle;
    //static GUIStyle buttonAddStyle, buttonDelStyle;
    //static bool styleInited = false;
    //static void InitStyle()
    //{
    //    if (styleInited)
    //        return;
    //    styleInited = true;

    //    dupStyle = new GUIStyle(EditorStyles.foldout);
    //    dupStyle.normal.textColor = Color.red;
    //    dupStyle.onActive.textColor = Color.red;
    //    dupStyle.onFocused.textColor = Color.red;
    //    dupStyle.onHover.textColor = Color.red;
    //    dupStyle.onNormal.textColor = Color.red;
    //    dupStyle.hover.textColor = Color.red;
    //    dupStyle.focused.textColor = Color.red;
    //    dupStyle.active.textColor = Color.red;

    //    //buttonDelStyle = new GUIStyle(GUI.skin.button);
    //    buttonAddStyle = new GUIStyle(EditorStyles.miniButton);
    //    buttonAddStyle.normal.textColor = Color.blue;
    //    buttonAddStyle.onActive.textColor = Color.blue;
    //    buttonAddStyle.onFocused.textColor = Color.blue;
    //    buttonAddStyle.onHover.textColor = Color.blue;
    //    buttonAddStyle.onNormal.textColor = Color.blue;
    //    buttonAddStyle.hover.textColor = Color.blue;
    //    buttonAddStyle.focused.textColor = Color.blue;
    //    buttonAddStyle.active.textColor = Color.blue;
    //    buttonAddStyle.fontStyle = FontStyle.Bold;

    //    //buttonDelStyle = new GUIStyle(GUI.skin.button);
    //    buttonDelStyle = new GUIStyle(EditorStyles.miniButton);
    //    buttonDelStyle.normal.textColor = Color.red;
    //    buttonDelStyle.onActive.textColor = Color.red;
    //    buttonDelStyle.onFocused.textColor = Color.red;
    //    buttonDelStyle.onHover.textColor = Color.red;
    //    buttonDelStyle.onNormal.textColor = Color.red;
    //    buttonDelStyle.hover.textColor = Color.red;
    //    buttonDelStyle.focused.textColor = Color.red;
    //    buttonDelStyle.active.textColor = Color.red;
    //    buttonDelStyle.fontStyle = FontStyle.Bold;
    //}

    //bool Title(string label, bool dup)
    //{
    //    InitStyle();
    //    //EditorGUILayout.LabelField(label);
    //    bool f = dup
    //        ? EditorGUI.Foldout(EditorGUILayout.GetControlRect(), isFold(label), label, true, dupStyle)
    //        : EditorGUI.Foldout(EditorGUILayout.GetControlRect(), isFold(label), label, true);
    //    setFold(label, f);
    //    return f;
    //}

    //static List<string> lstKeys = new List<string>();
    //static List<object> lstValues = new List<object>();
    //void getKVs<T>(List<T> lst, out bool keyDuplicated)
    //{
    //    lstKeys.Clear();
    //    lstValues.Clear();
    //    keyDuplicated = false;

    //    Type tT = typeof(T);
    //    for (int i = 0; i < lst.Count; i++)
    //    {
    //        T n = lst[i];
    //        FieldInfo f = tT.GetField("name");
    //        string k = (string)f.GetValue(n);
    //        if (lstKeys.Contains(k))
    //            keyDuplicated = true;
    //        lstKeys.Add(k);
    //        lstValues.Add(tT.GetField("v").GetValue(n));
    //    }
    //}
    //void ShowList<T>(string title, List<T> lst)
    //{
    //    bool keyDuplicated = false;
    //    getKVs(lst, out keyDuplicated);

    //    if (keyDuplicated)
    //        title += " (Duplicated)";
    //    if (!Title(title, keyDuplicated))
    //        return;

    //    int iAdd = -1, iDel = -1;
    //    Type tT = typeof(T);
    //    for (int i = 0; i < lstKeys.Count; i++)
    //    {
    //        T n = lst[i];
    //        H1();
    //        EditorGUILayout.LabelField("", GUILayout.MaxWidth(5));

    //        FieldInfo f = tT.GetField("name");
    //        f.SetValue(n, EditorGUILayout.TextField(lstKeys[i], GUILayout.MaxWidth(120)));

    //        f = typeof(T).GetField("v");
    //        if (f.FieldType == typeof(GameObject))
    //            f.SetValue(n, (GameObject)EditorGUILayout.ObjectField((GameObject)lstValues[i], typeof(GameObject), true));
    //        else if (f.FieldType == typeof(int))
    //            f.SetValue(n, EditorGUILayout.IntField((int)lstValues[i]));
    //        else if (f.FieldType == typeof(bool))
    //            f.SetValue(n, EditorGUILayout.Toggle((bool)lstValues[i]));
    //        else if (f.FieldType == typeof(string))
    //            f.SetValue(n, EditorGUILayout.TextField((string)lstValues[i]));

    //        if (GUILayout.Button("+", buttonAddStyle)) iAdd = i;
    //        if (GUILayout.Button("－", buttonDelStyle)) iDel = i;
    //        H2();
    //    }
    //    if (iAdd != -1) lst.Insert(iAdd, (T)tT.GetMethod("Copy").Invoke(lst[iAdd], null));
    //    if (iDel != -1) lst.RemoveAt(iDel);
    //}

    bool DoUpdate(ScriptAgent script, string[] lines)
    {
        var oldGos = script.Gos;
        var oldInts = script.Ints;
        var oldStrings = script.Strings;
        var oldBools = script.Bools;

        script.Gos = new List<ScriptAgent.NamedGo>();
        script.Ints = new List<ScriptAgent.NamedInt>();
        script.Strings = new List<ScriptAgent.NamedString>();
        script.Bools = new List<ScriptAgent.NamedBool>();

        foreach (var line in lines)
        {
            string[] arr = line.Split(' ');
            string typeName = arr[0];
            string fieldName = arr[1];
            if (typeName == "UnityEngine.GameObject")
            {
                var n = (oldGos == null || oldGos.Count == 0) ? null : oldGos.First((_n) => _n.name == fieldName);
                script.Gos.Add(n != null ? n
                    : new ScriptAgent.NamedGo { name = fieldName, v = null });
            }
            else if (typeName == "System.Int32")
            {
                var n = (oldInts == null || oldInts.Count == 0) ? null : oldInts.First((_n) => _n.name == fieldName);
                script.Ints.Add(n != null ? n
                    : new ScriptAgent.NamedInt { name = fieldName, v = 0 });
            }
            else if (typeName == "System.Boolean")
            {
                var n = (oldBools == null || oldBools.Count == 0) ? null : oldBools.First((_n) => _n.name == fieldName);
                script.Bools.Add(n != null ? n
                    : new ScriptAgent.NamedBool { name = fieldName, v = false });
            }
            else if (typeName == "System.String")
            {
                var n = (oldStrings == null || oldStrings.Count == 0) ? null : oldStrings.First((_n) => _n.name == fieldName);
                script.Strings.Add(n != null ? n
                    : new ScriptAgent.NamedString { name = fieldName, v = "" });
            }
        }

        // 检查有没有发生变化
        int L1, L2, i;

        L1 = oldGos == null ? 0 : oldGos.Count;
        L2 = script.Gos.Count;
        if (L1 != L2) return true;
        for (i = 0; i < oldGos.Count; i++)
        {
            if (oldGos[i].name != script.Gos[i].name ||
                oldGos[i].v != script.Gos[i].v)
            {
                return true;
            }
        }
        L1 = oldInts == null ? 0 : oldInts.Count;
        L2 = script.Ints.Count;
        if (L1 != L2) return true;
        for (i = 0; i < oldInts.Count; i++)
        {
            if (oldInts[i].name != script.Ints[i].name ||
                oldInts[i].v != script.Ints[i].v)
            {
                return true;
            }
        }
        L1 = oldStrings == null ? 0 : oldStrings.Count;
        L2 = script.Strings.Count;
        if (L1 != L2) return true;
        for (i = 0; i < oldStrings.Count; i++)
        {
            if (oldStrings[i].name != script.Strings[i].name ||
                oldStrings[i].v != script.Strings[i].v)
            {
                return true;
            }
        }
        L1 = oldBools == null ? 0 : oldBools.Count;
        L2 = script.Bools.Count;
        if (L1 != L2) return true;
        for (i = 0; i < oldBools.Count; i++)
        {
            if (oldBools[i].name != script.Bools[i].name ||
                oldBools[i].v != script.Bools[i].v)
            {
                return true;
            }
        }
        return false;
    }

    void OnUpdate(ScriptAgent script)
    {
        if (string.IsNullOrEmpty(script.ScriptName))
        {
            Debug.LogError("请输入脚本名");
            return;
        }

#if JS
        string dllPath = Application.dataPath + "/../../BridgeProj/bin/Debug/BridgeProj.dll";
        string outputPath = Application.dataPath + "/../../BridgeProj/bin/Debug/LoadTypeOutput.txt";
#else
        string dllPath = Application.dataPath + "/../Library/ScriptAssemblies/Assembly-CSharp.dll";
        string outputPath = Application.dataPath + "/../Library/ScriptAssemblies/LoadTypeOutput.txt";
#endif
        if (File.Exists(outputPath))
            File.Delete(outputPath);

        var pro = System.Diagnostics.Process.Start(Application.dataPath + "/../../BridgeProj/Cecil/CecilLoadType.exe", 
            string.Format("{0} \"{1}\" {2} \"{3}\"", "FindTypePublicVars", dllPath, script.ScriptName, outputPath)
            );
        pro.WaitForExit();

        if (!File.Exists(outputPath))
        {
            Debug.LogError("更新失败，类不存在");
        }
        else
        {
            string output = File.ReadAllText(outputPath);
            string[] lines = output.Split("\r\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            if (DoUpdate(script, lines))
            {
                Debug.Log("更新成功，变了");
                EditorFix.SetObjectDirty(script);
            }
            else
                Debug.Log("更新成功，没变");
        }
    }

    //void OnClear(ScriptAgent script)
    //{
    //    if (script.Gos != null) script.Gos.Clear();
    //    if (script.Ints != null) script.Ints.Clear();
    //    if (script.Strings != null) script.Strings.Clear();
    //    if (script.Bools != null) script.Bools.Clear();
    //}

    void Show2(SerializedProperty list)
    {
        //EditorGUILayout.PropertyField(list, false);
        //Debug.Log("arraySize = " + list.arraySize);
        for (int i = 0; i < list.arraySize; i++)
        {
            //EditorGUI.indentLevel += 1;
            SerializedProperty pro = list.GetArrayElementAtIndex(i);
            //EditorGUILayout.PropertyField(pro, false);
            pro.Next(true);
            // EditorGUILayout.PropertyField(pro, false);
            string name = pro.stringValue;
            pro.Next(false);
            H1();
            EditorGUILayout.LabelField(name, GUILayout.MaxWidth(100));
            EditorGUILayout.PropertyField(pro, GUIContent.none, false);
            H2();
            //EditorGUI.indentLevel -= 1;
            //H1();
            //Debug.Log("arraySize = " + pro.arraySize);

            //H2();
        }
    }

    void H1() { EditorGUILayout.BeginHorizontal(); }
    void H2() { EditorGUILayout.EndHorizontal(); }
    void V1() { EditorGUILayout.BeginVertical(); }
    void V2() { EditorGUILayout.EndVertical(); }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();
        ScriptAgent script = (ScriptAgent)target;

        EditorGUILayout.Space();
        //H1();
        //EditorGUILayout.LabelField("Init Hide", GUILayout.MaxWidth(100));
        //EditorGUILayout.PropertyField(serializedObject.FindProperty("InitHide"), GUIContent.none);
        //H2();

        H1();
        EditorGUILayout.LabelField("Script Name", GUILayout.MaxWidth(100));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("ScriptName"), GUIContent.none);
        if (GUILayout.Button("Update", EditorStyles.miniButton))
            OnUpdate(script);
        H2();
        //EditorGUILayout.Space();
        Show2(serializedObject.FindProperty("Gos"));
        Show2(serializedObject.FindProperty("Ints"));
        Show2(serializedObject.FindProperty("Strings"));
        Show2(serializedObject.FindProperty("Bools"));
//         EditorGUILayout.Space();
//         H1();
        //EditorGUILayout.LabelField("Script Name", GUILayout.MaxWidth(100));
        //script.ScriptName = EditorGUILayout.TextField(script.ScriptName);
//         if (GUILayout.Button("Clear", EditorStyles.miniButton))
//             OnClear(script);
//         H2();
//         EditorGUILayout.Space();
        serializedObject.ApplyModifiedProperties();
        return;


        //serializedObject.Update();

        //script = (ScriptAgent)target;
        //EditorGUILayout.Space();
        ////EditorGUILayout.PropertyField(serializedObject.FindProperty("ScriptName"));
        //H1();
        //EditorGUILayout.LabelField("Script Name", GUILayout.MaxWidth(100));
        //script.ScriptName = EditorGUILayout.TextField(script.ScriptName);
        //if (GUILayout.Button("Update", EditorStyles.miniButton))
        //    OnUpdate(script);
        //if (GUILayout.Button("Clear", EditorStyles.miniButton))
        //    OnClear(script);
        //H2();
        //EditorGUILayout.Space();
        ////serializedObject.ApplyModifiedProperties();

        //bool[] b = new bool[]
        //{
        //    (script.Gos != null && script.Gos.Count > 0),
        //    (script.Ints != null && script.Ints.Count > 0),
        //    (script.Bools != null && script.Bools.Count > 0),
        //    (script.Strings != null && script.Strings.Count > 0),
        //};
        //int count2 = 0;
        //if (b[0])
        //{
        //    ShowList<ScriptAgent.NamedGo>("GameObject", script.Gos);
        //}
        //else
        //    count2++;
        //if (b[1])
        //{
        //    ShowList<ScriptAgent.NamedInt>("int", script.Ints);
        //}
        //else
        //    count2++;
        //if (b[2])
        //{
        //    ShowList<ScriptAgent.NamedBool>("bool", script.Bools);
        //}
        //else
        //    count2++;
        //if (b[3])
        //{
        //    ShowList<ScriptAgent.NamedString>("string", script.Strings);
        //}
        //else
        //    count2++;

        //if (count2 > 0)
        //{
        //    int Max = 4;
        //    int c = 0;
        //    Action CheckNewLine = () =>
        //    {
        //        c++;
        //        if (c >= Max)
        //        {
        //            H2();
        //            H1();
        //            c = 0;
        //        }
        //    };
        //    Func<int, GUIStyle> selectStyle = (index) =>
        //    {
        //        int preCount = 0;
        //        for (int i = 0; i < index; i++)
        //            if (!b[i]) preCount++;

        //        int folCount = 0;
        //        for (int i = index + 1; i < b.Length; i++)
        //            if (!b[i]) folCount++;

        //        preCount %= Max;
        //        folCount %= Max;

        //        if (preCount == 0)
        //        {
        //            if (folCount == 0)
        //                return EditorStyles.miniButton;
        //            else
        //                return EditorStyles.miniButtonLeft;
        //        }
        //        else
        //        {
        //            if (folCount == 0)
        //                return EditorStyles.miniButtonRight;
        //            else
        //                return EditorStyles.miniButtonMid;
        //        }
        //    };
        //    EditorGUILayout.Space();

        //    H1();
        //    if (!b[0])
        //    {
        //        if (GUILayout.Button("+GameObject"/*, selectStyle(0)*/))
        //            script.Gos.Add(new ScriptAgent.NamedGo());
        //        CheckNewLine();
        //    }
        //    if (!b[1])
        //    {
        //        if (GUILayout.Button("+int"/*, selectStyle(1)*/))
        //            script.Ints.Add(new ScriptAgent.NamedInt());
        //        CheckNewLine();
        //    }
        //    if (!b[2])
        //    {
        //        if (GUILayout.Button("+bool"/*, selectStyle(2)*/))
        //            script.Bools.Add(new ScriptAgent.NamedBool());
        //        CheckNewLine();
        //    }
        //    if (!b[3])
        //    {
        //        if (GUILayout.Button("+string"/*, selectStyle(3)*/))
        //            script.Strings.Add(new ScriptAgent.NamedString());
        //        CheckNewLine();
        //    }
        //    H2();
        //}

        //serializedObject.ApplyModifiedProperties();
    }
}
