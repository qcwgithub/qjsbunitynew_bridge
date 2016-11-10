using System;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TG<T, J>
{
    public TG(){ v = 1; strs = null; }
    public int v;
    public string[] strs;
}

public class TG2
{
    public TG2() { v = 1;strs = null; }
    public int v;
    public string[] strs;
}

public class Test : MonoBehaviour
{
    void Start()
    {
        //        StartCoroutine(Co());
        //        CallAction(funNs.Hellor.CreateHelloAction());
        //
        //        staticTTest.B.v = "v of B";
        //        staticTTest.C.v = "v of C";
        //        print(staticTTest.B.v);
        //        print(staticTTest.C.v);

        //int x = 2;
        //TestRF.Increase_ByRef(false, ref x);
        //print ("x = " + x + "(应等于 2)");

        //TestRF.Increase_ByRef(true, ref x);
        //print ("x = " + x + "(应等于 3)");

        //TestRF.Get_Out(out x);
        //print ("x = " + x + "(应等于 8)");

        //var v = new Vector3(0f, 0f, 3f);
        //transform.position = v;
        //print(transform.position.ToString());

        //v.x = 5f;
        //print("v.x = " + v.x);

        //TestGeneric<GameObject, int, int> tg = new TestGeneric<GameObject, int, int>(new GameObject("BBCCCC"));
        //tg.PrintName();

        //tg.Hello<int, UnityEngine.Collider>();

        TestMisc tm = new TestMisc();
        tm.TestParams("邱少云", "是谁");

        //var tgjs = new TG<GameObject, int>();
        //var ttt = tgjs.GetType().GetGenericArguments()[0].FullName;
        //print("fullname is " + ttt);

        //List<GameObject> lst = new List<GameObject>();
        //for (int i = 0; i < 10; i++)
        //{
        //    GameObject go = new GameObject("go_" + i);
        //    lst.Add(go);
        //}

        //StringBuilder sb = new StringBuilder();
        //sb.AppendLine("before sort --- ");
        //foreach (var go in lst)
        //{
        //    sb.AppendLine(go.name);
        //}

        //sb.AppendLine();
        //sb.AppendLine("after sort --- ");

        //lst.Sort((a, b) =>
        //{
        //    int x = int.Parse(a.name.Substr(a.name.IndexOf('_') + 1));
        //    int y = int.Parse(b.name.Substr(b.name.IndexOf('_') + 1));
        //    if (x % 2 == 0 && y % 2 == 1)
        //        return -1;
        //    else if (x % 2 == 1 && y % 2 == 0)
        //        return 1;
        //    return 0;
        //});
        //foreach (var go in lst)
        //{
        //    sb.AppendLine(go.name);
        //}

        //print(sb.ToString());


        //foreach (var go in lst)
        //{
        //    UnityEngine.Object.Destroy(go);
        //}
        //lst.Clear();

        //print("lst.Count = " + lst.Count);
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
    public class Hellor// : IEnumerable
    {
        //public IEnumerator GetEnumerator() { return null; }
        static Hellor()
        {
            Debug.Log("Js Hellor::static Hellor()");
        }
        public static Action CreateHelloAction()
        {
            return () =>
            {
                Debug.Log("Hello!!!!!!");
            };
        }
    }

}

namespace staticTTest
{
    class A<T>
    {
         public static string v;
    }
    class B : A<B>
    {
    }
    class C : A<C>
    {
    }
}

public class PerformanceTest1 : MonoBehaviour
{

    Transform mTransform;
    void Start()
    {
        mTransform = transform;
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


    public static TestPerformance.RefObject Run(TestPerformance.RefObject refObject)
    {
        TestPerformance.StaticObject.x += refObject.x;
        TestPerformance.StaticObject.y += refObject.y;
        return TestPerformance.StaticObject;
    }

    public void Test7()
    {
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Start();
        var obj = TestPerformance.StaticObject;
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

    float elapsed = 0;
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed > 3f)
        {
            elapsed = 0f;
            Test0();
            Test1();
            Test2();
            Test3();
            Test4();
            Test5();
            Test6();
        }
    }
}
