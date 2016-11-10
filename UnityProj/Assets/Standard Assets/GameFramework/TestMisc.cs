using UnityEngine;
using System.Collections;

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
