using System;
using System.Text;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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

        TestGeneric<GameObject> tg = new TestGeneric<GameObject>();
        tg.PrintName();

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