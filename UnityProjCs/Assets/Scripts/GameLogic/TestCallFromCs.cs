using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace jsb.Test.Logic
{
    public class JSBInfo
    {
        public string Version = "1.0";
        public int QQGroup = 189738580;
        public string getDocumentUrl()
        {
            return "http://www.cnblogs.com/answerwinner/p/6037911.html";
        }
    }

    public class TestCallFromCs
    {
        public static JSBInfo CreateJSBindingInfo()
        {
            return new JSBInfo();
        }
    }
}