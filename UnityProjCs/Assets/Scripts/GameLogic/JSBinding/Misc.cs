using UnityEngine;

public static class jsbExtension
{
#if JS
    [Bridge.Script(@"var elapsed = UnityEngine.Time.getdeltaTime();
            mb.$UpdateAllCoroutines(elapsed);
            mb.$UpdateAllInvokes(elapsed);")]
#endif
    public static void UpdateCoroutines(this MonoBehaviour mb)
    {

    }
}