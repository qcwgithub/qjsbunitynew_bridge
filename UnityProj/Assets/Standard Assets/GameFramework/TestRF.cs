using UnityEngine;
using System.Collections;

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
