using System;
using UnityEngine;
using System.Collections;

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

		int x = 2;
		TestRF.Increase_ByRef(false, ref x);
		print ("x = " + x + "(应等于 2)");

		TestRF.Increase_ByRef(true, ref x);
		print ("x = " + x + "(应等于 3)");

		TestRF.Get_Out(out x);
		print ("x = " + x + "(应等于 8)");
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