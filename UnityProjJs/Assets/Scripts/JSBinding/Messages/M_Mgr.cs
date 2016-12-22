// auto gen
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using jsb;
 
namespace jsb
{
    public class M_Mgr
    {
        static Dictionary<string, int[]> jID = new Dictionary<string, int[]>();
        static int[] GetJsClassMessages(string jsFullName)
        {
            if (jID.ContainsKey(jsFullName))
                return jID[jsFullName];
         
        	if (!JSMgr.vCall.CallJSFunctionName(JSCache.GetBridgeJsID(), "getLMsgs", jsFullName))
        		throw new Exception("call Bridge.getLMsgs failed!");
         
        	string str = JSApi.getStringS((int)JSApi.GetType.JSFunRet);
            if (string.IsNullOrEmpty(str))
            {
                jID[jsFullName] = null;
                return null;
            }
         
            string[] arr = str.Split(',');
        	int[] r = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
                r[i] = int.Parse(arr[i]);
         
            jID[jsFullName] = r;
            return r;
        }
         
        public static void CreateMessages(string jsFullName, GameObject go)
        {
            int[] ids = GetJsClassMessages(jsFullName);
            if (ids == null)
                return;
         
            for (int i = 0; i < ids.Length; i++)
            {
                Type type = MessageTypes[ids[i]];
                if (go.GetComponent(type) == null)
                    go.AddComponent(type);
            }
        }
         
        static Type[] MessageTypes = new Type[]
        {
            typeof(jsb.M_Update),
            typeof(jsb.M_LateUpdate),
            typeof(jsb.M_FixedUpdate),
            typeof(jsb.M_OnGUI),
            typeof(jsb.M_OnDisable),
            typeof(jsb.M_OnEnable),
            typeof(jsb.M_OnBecameInvisible),
            typeof(jsb.M_OnBecameVisible),
            typeof(jsb.M_OnTransformChildrenChanged),
            typeof(jsb.M_OnTransformParentChanged),
            typeof(jsb.M_OnApplicationFocus),
            typeof(jsb.M_OnApplicationPause),
            typeof(jsb.M_OnApplicationQuit),
            typeof(jsb.M_OnAudioFilterRead),
            typeof(jsb.M_OnLevelWasLoaded),
            typeof(jsb.M_OnAnimatorIK),
            typeof(jsb.M_OnAnimatorMove),
            typeof(jsb.M_OnJointBreak),
            typeof(jsb.M_OnParticleCollision),
            typeof(jsb.M_OnCollisionEnter),
            typeof(jsb.M_OnCollisionEnter2D),
            typeof(jsb.M_OnCollisionExit),
            typeof(jsb.M_OnCollisionExit2D),
            typeof(jsb.M_OnCollisionStay),
            typeof(jsb.M_OnCollisionStay2D),
            typeof(jsb.M_OnTriggerEnter),
            typeof(jsb.M_OnTriggerEnter2D),
            typeof(jsb.M_OnTriggerExit),
            typeof(jsb.M_OnTriggerExit2D),
            typeof(jsb.M_OnTriggerStay),
            typeof(jsb.M_OnTriggerStay2D),
            typeof(jsb.M_OnControllerColliderHit),
            typeof(jsb.M_OnConnectedToServer),
            typeof(jsb.M_OnDisconnectedFromServer),
            typeof(jsb.M_OnFailedToConnect),
            typeof(jsb.M_OnFailedToConnectToMasterServer),
            typeof(jsb.M_OnMasterServerEvent),
            typeof(jsb.M_OnNetworkInstantiate),
            typeof(jsb.M_OnPlayerConnected),
            typeof(jsb.M_OnPlayerDisconnected),
            typeof(jsb.M_OnSerializeNetworkView),
            typeof(jsb.M_OnServerInitialized),
            typeof(jsb.M_OnMouseDown),
            typeof(jsb.M_OnMouseDrag),
            typeof(jsb.M_OnMouseEnter),
            typeof(jsb.M_OnMouseExit),
            typeof(jsb.M_OnMouseOver),
            typeof(jsb.M_OnMouseUp),
            typeof(jsb.M_OnMouseUpAsButton),
            typeof(jsb.M_OnPostRender),
            typeof(jsb.M_OnPreCull),
            typeof(jsb.M_OnPreRender),
            typeof(jsb.M_OnRenderImage),
            typeof(jsb.M_OnRenderObject),
            typeof(jsb.M_OnWillRenderObject),
        };
    }
}