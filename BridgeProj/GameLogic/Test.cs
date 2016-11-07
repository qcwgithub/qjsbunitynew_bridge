using System;
using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Co());
        CallAction(funNs.Hellor.CreateHelloAction());
    }

    void Update()
    {
        this.UpdateCoroutines();
    }

    void CallAction(Action a)
    {
        a();
    }

    IEnumerator Co()
    {
        int c = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            print("我 " + (++c));

            if (c >= 4)
                yield break;
        }
        print("end of Co");
    }
}

namespace funNs
{
    public class Hellor
    {
        public static Action CreateHelloAction()
        {
            return () =>
            {
                Debug.Log("Hello!!!!!!");
            };
        }
    }

}