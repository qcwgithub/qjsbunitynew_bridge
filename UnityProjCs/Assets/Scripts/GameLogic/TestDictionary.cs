using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace jsb.Test.Logic
{
    public class TestDictionary : MonoBehaviour
    {
        void Start()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("liudh", 50);
            dict.Add("wuyz", 27);

            int age;
            if (dict.TryGetValue("liudh", out age))
            {
                Debug.Log("age: " + age.ToString());
            }
            else
            {
                Debug.Log("not found");
            }
            foreach (var v in dict)
            {
                Debug.Log(v.Key.ToString() + "->" + v.Value.ToString());
            }
        }
    }
}