// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnTriggerExit2D : MonoBehaviour
    {
        public void OnTriggerExit2D(Collider2D other)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnTriggerExit2D", other);
            }
        }
    }
}