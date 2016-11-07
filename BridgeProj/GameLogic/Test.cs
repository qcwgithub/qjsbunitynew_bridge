using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Co());
    }

    void Update()
    {
        this.UpdateCoroutines();
    }

    IEnumerator Co()
    {
        int c = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            print("hello " + (++c));
        }
    }
}