using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace jsb.Test.Logic
{
    public class TestEntry : MonoBehaviour
    {
        //Dictionary<string, string>
        string[] testNames = new string[]
        {
            "TestCoroutine",
            "TestPerformance",
            "TestVector3",
        };

        void Start()
        {
            GameObject btnPrefab = transform.Find("ButtonPrefab").gameObject;
            foreach (var n in testNames)
            {
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
            
            switch (n)
            {
                case "TestCoroutine": gameObject.AddComponent<TestCoroutine>(); break;
                case "TestVector3": gameObject.AddComponent<TestVector3>(); break;
                case "TestPerformance": gameObject.AddComponent<TestPerformance>(); break;
            }
        }
    }
}