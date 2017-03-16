using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Reflection;
using System.Linq;
using UnityEditor.SceneManagement;

[CustomEditor(typeof(ButtonClickBinder))]
public class ButtonClickBinderInspector : Editor
{
    bool CheckMethod(string ScriptName, string MethodName)
    {
#if JS
        string dllPath = Application.dataPath + "/../../BridgeProj/bin/Debug/BridgeProj.dll";
        string outputPath = Application.dataPath + "/../../BridgeProj/bin/Debug/CheckMethodOutput.txt";
#else
        string dllPath = Application.dataPath + "/../Library/ScriptAssemblies/Assembly-CSharp.dll";
        string outputPath = Application.dataPath + "/../Library/ScriptAssemblies/CheckMethodOutput.txt";
#endif

        if (File.Exists(outputPath))
            File.Delete(outputPath);
        
        var pro = System.Diagnostics.Process.Start(Application.dataPath + "/../../BridgeProj/Cecil/CecilLoadType.exe",
            string.Format("{0} \"{1}\" {2} {3} \"{4}\"", "CheckTypePublicMethod", dllPath, ScriptName, MethodName, outputPath)
            );
        pro.WaitForExit();

        if (!File.Exists(outputPath))
        {
            return false;
        }
        else if (File.ReadAllText(outputPath) == "1")
        {
            return true;
        }
        return false;
    }

    void Check(GameObject go, string ScriptName, string MethodName)
    {
        if (go == null)
        {
            Debug.LogError("go is null");
            return;
        }
        if (string.IsNullOrEmpty(ScriptName))
        {
            Debug.LogError("ScriptName is empty");
            return;
        }
        if (string.IsNullOrEmpty(MethodName))
        {
            Debug.LogError("MethodName is empty");
            return;
        }
        var agents = go.GetComponents<ScriptAgent>();
        if (agents.Length == 0)
        {
            Debug.LogError("Go has no ScriptAgent");
            return;
        }
        bool found = false;
        foreach (var agent in agents)
        {
            if (agent.ScriptName == ScriptName)
            {
                found = true;

                bool suc = CheckMethod(ScriptName, MethodName);
                if (suc) Debug.Log("Ok");
                else Debug.LogError("Check Failed!");

                break;
            }
        }
        if (!found)
        {
            Debug.LogError("Go has no ScriptAgent named '" + ScriptName + "'");
            return;
        }
    }

    void H1() { EditorGUILayout.BeginHorizontal(); }
    void H2() { EditorGUILayout.EndHorizontal(); }
    void V1() { EditorGUILayout.BeginVertical(); }
    void V2() { EditorGUILayout.EndVertical(); }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        SerializedProperty goPro = serializedObject.FindProperty("Go");
        SerializedProperty scriptPro = serializedObject.FindProperty("ScriptName");
        SerializedProperty methodPro = serializedObject.FindProperty("MethodName");
        UnityEngine.Object obj1 = goPro.objectReferenceValue;

        H1();
        {
            V1();
            H1();
            {
                EditorGUILayout.LabelField("Go", GUILayout.MaxWidth(90));
                EditorGUILayout.PropertyField(goPro, GUIContent.none);
            }
            H2();

            UnityEngine.Object obj2 = goPro.objectReferenceValue;
            if (obj1 == null && obj2 != null &&
                (string.IsNullOrEmpty(scriptPro.stringValue) || string.IsNullOrEmpty(methodPro.stringValue)))
            {
                GameObject go = (GameObject)obj2;
                var agent = go.GetComponent<ScriptAgent>();
                if (agent != null)
                {
                    scriptPro.stringValue = agent.ScriptName;
                }
            }

            H1();
            {
                EditorGUILayout.LabelField("Script Name", GUILayout.MaxWidth(90));
                EditorGUILayout.PropertyField(scriptPro, GUIContent.none);
            }
            H2();

            H1();
            {
                EditorGUILayout.LabelField("Method Name", GUILayout.MaxWidth(90));
                EditorGUILayout.PropertyField(methodPro, GUIContent.none);
            }
            H2();
            V2();

            if (!Application.isPlaying)
            {
                //V1();
                if (GUILayout.Button("Check"/*, EditorStyles.miniButton*/, GUILayout.MaxHeight(52)))
                {
                    Check((GameObject)obj2, scriptPro.stringValue, methodPro.stringValue);
                }
                //V2();
            }
        }

        H2();
        serializedObject.ApplyModifiedProperties();
    }
}
