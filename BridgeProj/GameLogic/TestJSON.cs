using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Bridge;
using Bridge.Html5;

namespace jsb.Test.Logic
{
    public class Request10019
    {
        public class Opt
        {
            public uint[] selects;
        }

        public uint itemID;
        public uint num;
        public Opt optParams;
    }
    public class TestJSON : MonoBehaviour
    {
        void Start()
        {
            Request10019 r = new Request10019()
            {
                itemID = 112,
                num = 2,
                optParams = new Request10019.Opt()
                {
                    selects = new uint[] { 5, 4, 8 }
                }
            };

            string str = JSON.Stringify(r);
            print(str);
        }
    }
}