using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using jsb.Test.Framwork;

namespace jsb.Test.Logic
{
    class TestInherit2 : TestInherit1
    {
        void Start()
        {
            var arr = GetComponents<TestInherit1>();
            print("arr.Length = " + arr.Length);
        }
        void OnGUI()
        {
            //print("ongui");
        }
    }
}
