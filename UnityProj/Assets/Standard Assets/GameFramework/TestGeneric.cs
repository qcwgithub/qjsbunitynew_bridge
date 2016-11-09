using UnityEngine;
using System.Collections;

public class TestGeneric<T> where T : UnityEngine.Object
{
	T obj;

	public void PrintName()
	{
		UnityEngine.Debug.Log(obj.name);
	}
}
