// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnLevelWasLoaded : MonoBehaviour
    {
        public void OnLevelWasLoaded(int level)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnLevelWasLoaded", level);
            }
        }
    }
}