// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnSerializeNetworkView : MonoBehaviour
    {
        public void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnSerializeNetworkView", stream, info);
            }
        }
    }
}