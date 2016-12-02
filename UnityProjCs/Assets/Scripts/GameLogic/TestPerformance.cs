using System;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

namespace jsb.Test.Logic
{
    public class TestPerformance : MonoBehaviour
    {
        Transform mTransform;
        void Start()
        {
            mTransform = transform;

            Test0();
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
            Test6();
        }
        void Test0()
        {
            var N = 10000000;

            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var g = 0;
            var f = 0;
            for (var i = 0; i < N; i++)
            {
                g += 1;
                f += 1;
            }
            sw.Stop();
            //         Debug.Log("loop count: " + N.ToString());
            //         Debug.Log("calc result: " + (f + g).ToString());
            Debug.Log("test0 time: " + sw.ElapsedMilliseconds + " ms");
        }

        private void Test1()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Vector3 m;
            for (int i = 0; i < 2000; i++)
            {
                m = mTransform.position;

                mTransform.position = m;
            }
            Debug.Log("test1 time: " + sw.ElapsedMilliseconds + " ms");
        }

        private void Test2()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Vector3 m = mTransform.position;
            for (int i = 0; i < 2000; i++)
            {
                m = Vector3.Normalize(m);
            }
            Debug.Log("test2 time: " + sw.ElapsedMilliseconds + " ms");
        }

        private void Test3()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Vector3 m = mTransform.position;
            for (int i = 0; i < 2000; i++)
            {
                m.Normalize();
            }
            Debug.Log("test3 time: " + sw.ElapsedMilliseconds + " ms");
        }

        private void Test4()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            Vector3 m = mTransform.position;
            for (int i = 0; i < 2000; i++)
            {
                mTransform.position = m;
            }
            Debug.Log("test4 time: " + sw.ElapsedMilliseconds + " ms");
        }

        private void Test5()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (int i = 0; i < 2000; i++)
            {
                new Vector3(i, i, i);
            }
            Debug.Log("test5 time: " + sw.ElapsedMilliseconds + " ms");
        }

        void Test6()
        {
            var sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            for (var i = 0; i < 50000; i++)
            {
                var go = new GameObject("init");
                GameObject.DestroyImmediate(go);
            }

            Debug.Log("test6 time: " + sw.ElapsedMilliseconds + " ms");
        }


        public static jsb.Test.Framwork.TestPerformance.RefObject Run(jsb.Test.Framwork.TestPerformance.RefObject refObject)
        {
            jsb.Test.Framwork.TestPerformance.StaticObject.x += refObject.x;
            jsb.Test.Framwork.TestPerformance.StaticObject.y += refObject.y;
            return jsb.Test.Framwork.TestPerformance.StaticObject;
        }

        public void Test7()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            var obj = jsb.Test.Framwork.TestPerformance.StaticObject;
            for (int i = 0; i < 50000; i++)
            {
                obj = Run(obj);
            }
            sw.Stop();

            Debug.Log("test7 time: " + sw.ElapsedMilliseconds + " ms");
        }
        public void OnChangeEvent()
        {

        }
    }

}