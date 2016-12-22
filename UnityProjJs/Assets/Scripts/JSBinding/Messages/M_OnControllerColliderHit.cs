// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnControllerColliderHit : MonoBehaviour
    {
        public void OnControllerColliderHit(ControllerColliderHit hit)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnControllerColliderHit", hit);
            }
        }
    }
}