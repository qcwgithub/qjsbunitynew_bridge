// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnTriggerStay2D : MonoBehaviour
    {
        public void OnTriggerStay2D(Collider2D other)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnTriggerStay2D", other);
            }
        }
    }
}