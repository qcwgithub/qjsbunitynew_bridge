using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace jsb.Test.Logic
{
    public class TestEntry : MonoBehaviour
    {
        Dictionary<string, Action> dict = null;

        void Start()
        {
            dict = new Dictionary<string, Action>();
            dict["TestCoroutine"] = () => { gameObject.AddComponent<TestCoroutine>(); };
            dict["TestPerformance"] = () => { gameObject.AddComponent<TestPerformance>(); };
            dict["TestVector3"] = () => { gameObject.AddComponent<TestVector3>(); };
            dict["TestDictionary"] = () => { gameObject.AddComponent(typeof(TestDictionary)); };

			// 注意，如果是 JS ，AddComponent(string) 要传全名（包括命名空间和定义类）
			// 但是 CS 只要类名就可以了
			// 所以最好是用 AddComponent<T>
#if JS
			string scriptName = "jsb.Test.Logic.TestInt64";
#else
			string scriptName = "TestInt64";
#endif

			dict["TestInt64"] = () => { gameObject.AddComponent(scriptName); };
            dict["TestJSON"] = () => { gameObject.AddComponent<TestJSON>(); };
            // 注意 TestCallJs 是 C# 脚本
            dict["TestCallJs"] = () => { gameObject.AddComponent<TestCallJs>(); };
            dict["TestInherit"] = () => 
            {
                gameObject.AddComponent<TestInherit1>();
                gameObject.AddComponent<TestInherit2>();
            };

            GameObject btnPrefab = transform.Find("ButtonPrefab").gameObject;
            foreach (var KV in dict)
            {
                string n = KV.Key;
                GameObject go = (GameObject) Instantiate(btnPrefab);
                Transform trans = go.transform;
                go.name = n;
                trans.FindChild("Text").GetComponent<UnityEngine.UI.Text>().text = n;
                go.SetActive(true);
                go.GetComponent<Button>().onClick.AddListener(() =>
                {
                    OnClick(n);
                });
                trans.SetParent(transform, false);
            }
        }

        void OnClick(string n)
        {
            // 删除除了 TestEntry 之外的 JSComponent
            MonoBehaviour[] mbs = GetComponents<MonoBehaviour>();
            for (int i = 0; i < mbs.Length; i++)
            {
                if (!(mbs[i] is TestEntry))
                    UnityEngine.Object.DestroyImmediate(mbs[i]);
            }

            dict[n]();
        }
    }
}