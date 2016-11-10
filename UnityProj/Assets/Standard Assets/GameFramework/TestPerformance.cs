using UnityEngine;

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
