// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnCollisionStay2D : MonoBehaviour
    {
        public void OnCollisionStay2D(Collision2D coll)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnCollisionStay2D", coll);
            }
        }
    }
}