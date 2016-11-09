using UnityEngine;
using System.Collections;

public class TestGeneric<T, J, K> where T : UnityEngine.Object
{
    T obj;
    public TestGeneric(T o)
    {
        obj = o;
    }

	public void PrintName()
	{
		UnityEngine.Debug.Log(obj.name);
	}
}
