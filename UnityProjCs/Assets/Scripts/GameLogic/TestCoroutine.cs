using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace jsb.Test.Logic
{
    public class TestCoroutine : MonoBehaviour
    {
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
                print("我 " + (++c));

                if (c >= 4)
                    yield break;
            }

			// JS 会打印这句，这是因为 yield break 不支持
            print("end of Co");
        }
    }
}