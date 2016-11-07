using UnityEngine;

public static class jsbExtension
{
    [Bridge.Script(@"var elapsed = UnityEngine.Time.getdeltaTime();
            mb.$UpdateAllCoroutines(elapsed);
            mb.$UpdateAllInvokes(elapsed);")]
    public static void UpdateCoroutines(this MonoBehaviour mb)
    {

    }
}