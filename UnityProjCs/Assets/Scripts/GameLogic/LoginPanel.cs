using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : MonoBehaviour
{
    // 演示序列化支持
    public string Account;

    public void OnLoginClick()
    {
        print("Login! Account = " + Account);

        gameObject.SetActive(false);
        GameObject prefab = (GameObject)EditorEnv.LoadMainAssetAtPath("Assets/Prefabs/Game.prefab");
        GameObject go = (GameObject) Instantiate(prefab);
        go.transform.SetParent(transform.parent, false);
    }
}
