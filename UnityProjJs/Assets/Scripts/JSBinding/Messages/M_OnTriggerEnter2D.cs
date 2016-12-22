// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnTriggerEnter2D : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnTriggerEnter2D", other);
            }
        }
    }
}