// auto gen
using UnityEngine;
using UnityEngine.UI;
 
namespace jsb
{
    public class M_OnRenderImage : MonoBehaviour
    {
        public void OnRenderImage(RenderTexture src, RenderTexture dest)
        {
            JSComponent[] coms = GetComponents<JSComponent>();
            if (coms == null || coms.Length == 0)
            {
                Destroy(this);
                return;
            }
             
            foreach (var com in coms)
            {
                com.RecvMsg("OnRenderImage", src, dest);
            }
        }
    }
}