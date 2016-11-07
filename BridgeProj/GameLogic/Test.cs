using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Co());
    }

    [Bridge.Script(@"var elapsed = UnityEngine.Time.getdeltaTime();
            this.$UpdateAllCoroutines(elapsed);
            this.$UpdateAllInvokes(elapsed);")]
    void Update()
    {
    }

    IEnumerator Co()
    {
        int c = 0;
        while (true)
        {
            yield return new WaitForSeconds(1f);
            print(++c);
        }
    }
}

public class Test2 : MonoBehaviour
{

}