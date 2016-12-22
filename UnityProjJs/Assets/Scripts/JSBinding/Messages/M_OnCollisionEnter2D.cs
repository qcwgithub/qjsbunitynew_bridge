// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnCollisionEnter2D : MonoBehaviour
    {
        public void OnCollisionEnter2D(Collision2D coll)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnCollisionEnter2D", coll);
            }
        }
    }
}