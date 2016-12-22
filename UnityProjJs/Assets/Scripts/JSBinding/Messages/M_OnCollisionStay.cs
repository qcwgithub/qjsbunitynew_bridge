// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnCollisionStay : MonoBehaviour
    {
        public void OnCollisionStay(Collision collisionInfo)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnCollisionStay", collisionInfo);
            }
        }
    }
}