using UnityEngine;
using System.Collections;

namespace jsb.Test.Framwork
{
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
		
		public void Hello<X, Y>()
		{
			UnityEngine.Debug.Log("Hello<X, Y>()");
		}
	}

	public class TestMisc
	{
		public void TestParams(params string[] strs)
		{
			UnityEngine.Debug.Log("strs.Length = " + strs.Length);
			for (int i = 0; i < strs.Length; i++)
			{
				UnityEngine.MonoBehaviour.print(strs[i]);
			}
		}
	}

	public class TestPerformance
	{
		public class RefObject
		{
			public string String =
				"xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
			
			public int x = 1;
			public int y = 2;
		}
		
		public static RefObject StaticObject = new RefObject();
		
		public static void test123(params object[] ts)
		{
			if (ts != null && ts.Length > 0)
			{
				for (int i = 0; i < ts.Length; i++)
				{
					Debug.LogError("[" + i + "] = " + ts[i]);
				}
			}
			
		}
		
		public static void testString(params string[] ts)
		{
			if (ts != null && ts.Length > 0)
			{
				for (int i = 0; i < ts.Length; i++)
				{
					Debug.LogError("[" + i + "] = " + ts[i]);
				}
			}
			
		}
	}

	public class TestRF
	{
		public static void Increase_ByRef(bool bInc, ref int x)
		{
			if (bInc)
				x++;
		}
		
		public static void Get_Out(out int x)
		{
			x = 8;
		}
	}
}