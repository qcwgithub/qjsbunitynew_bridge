using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using jsb.Test.Framwork;

namespace jsb.Test.Logic
{
    public class TestInt64 : MonoBehaviour
    {
        void Start()
        {
            ulong ul = 18446744073709551615L; // 2^64-1
            Debug.Log("Js 传出 ulong：" + ul);
            TestMisc.SetUL(ul);

            long l = 9223372036854775807L; // 2^63-1
            Debug.Log("Js 传出 long：" + l);
            TestMisc.SetL(l);

            TestMisc.GetL((_l) =>
            {
                Debug.Log("Js 收到 long：" + _l);
            });

            TestMisc.GetUL((_ul) =>
            {
                Debug.Log("Js 收到 ulong：" + _ul);
            });
        }
    }

}