// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_Update : MonoBehaviour
    {
        public void Update()
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("Update");
            }
        }
    }
}