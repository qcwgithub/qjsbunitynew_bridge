using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    void Awake()
    {
        Button btn = transform.FindChild("Canvas/Button").GetComponent<Button>();
        btn.onClick.AddListener(OnLoginClick);
    }

    void OnLoginClick()
    {
        print("Login!");

        gameObject.SetActive(false);
        GameObject prefab = (GameObject)EditorEnv.LoadMainAssetAtPath("Assets/Prefabs/Game.prefab");
        GameObject go = (GameObject) Instantiate(prefab);
        Transform te = go.transform.FindChild("TestEntry");
        te.gameObject.AddComponent<jsb.Test.Logic.TestEntry>();
    }
}
