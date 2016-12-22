// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnDisconnectedFromServer : MonoBehaviour
    {
        public void OnDisconnectedFromServer(NetworkDisconnection info)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnDisconnectedFromServer", info);
            }
        }
    }
}