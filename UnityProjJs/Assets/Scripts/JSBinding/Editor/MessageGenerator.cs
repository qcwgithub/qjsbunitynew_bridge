using System;
using System.IO;
using UnityEngine;
using System.Collections;

namespace jsb
{
	public class MessageGenerator
    {
        const string CsDir = "Assets/Scripts/JSBinding/Messages";
        const string JsFile = "Assets/StreamingAssets/JavaScript/MessageIDs.javascript";

		class Info
		{
			public string signature;
			public Info(string s)
			{
				signature = s;
			}
			public string methodName
			{
				get
				{
					int i = signature.IndexOf('(');
					return signature.Substring(0, i);
				}
			}
			public string className
			{
				get
				{
					return "M_" + methodName;
				}
			}
			public string argList
			{
				get
				{
					args a = new args();
					a.Add("\"" + this.methodName + "\"");
					
					if (signature.IndexOf("()") >= 0)
						return a.Format(args.ArgsFormat.OnlyList);
					
					int i = signature.IndexOf('(');
					var content = signature.Substring(i + 1, signature.Length - i - 2); // string in ()
					string[] ps = content.Split(',');
					foreach (var p in ps)
					{
						a.Add(p.Substring(p.LastIndexOf(' ') + 1));
					}
					return a.Format(args.ArgsFormat.OnlyList);
				}
			}
		}

		static void ClearFiles()
		{
			if (Directory.Exists(CsDir))
			{
				string[] files = Directory.GetFiles(CsDir, "*.cs");
				foreach (var f in files)
					File.Delete(f);
			}
			else
				Directory.CreateDirectory(CsDir);
		}

		static void GenAMessage(Info info)
		{
			TextFile tf = new TextFile(null, "// auto gen");
			tf.Add("using UnityEngine;");
			tf.Add("using UnityEngine.UI;");
			
			tf.AddLine();

			TextFile tfNs = tf.Add("namespace jsb").BraceIn();
			{
				TextFile tfC = tfNs.Add("public class {0} : MonoBehaviour", info.className).BraceIn();
				{
					TextFile tfM = tfC.Add("public void {0}", info.signature).BraceIn();
					{
						tfM.Add("JSComponent[] coms = GetComponents<JSComponent>();")
							.Add("if (coms == null || coms.Length == 0)")
								.BraceIn()
								.Add("Destroy(this);")
								.Add("return;")
								.BraceOut ()
								.AddLine()
								.Add("foreach (var com in coms)");
						
						TextFile tfF = tfM.BraceIn();
						{
							tfF.Add("com.RecvMsg({0});", info.argList);
						}
						
						tfF.BraceOut();
                    }
                    tfM.BraceOut();
                }
                tfC.BraceOut();
            }
            tfNs.BraceOut();
            
            string s = tf.Format(-1);
            File.WriteAllText(CsDir + "/" + info.className + ".cs", s);
        }

		static void GenMMgr(string className)
		{
			TextFile tf = new TextFile(null, "// auto gen");
			tf.Add("using UnityEngine;");
			tf.Add("using UnityEngine.UI;");
            tf.Add("using System;");
            tf.Add("using System.Collections;");
            tf.Add("using System.Collections.Generic;");
            tf.Add("using jsb;");
			
			tf.AddLine();
			
			TextFile tfNs = tf.Add("namespace jsb").BraceIn();
			{
				TextFile tfC = tfNs.Add("public class {0}", className).BraceIn();
                {
                    tfC.Add("static Dictionary<string, int[]> jID = new Dictionary<string, int[]>();");

                    {
                        tfC.AddMultiline(@"
static int[] GetJsClassMessages(string jsFullName)
{
    if (jID.ContainsKey(jsFullName))
        return jID[jsFullName];
 
	if (!JSMgr.vCall.CallJSFunctionName(JSCache.GetBridgeJsID(), ""getLMsgs"", jsFullName))
		throw new Exception(""call Bridge.getLMsgs failed!"");
 
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
}");
                    }
                    tfC.AddLine();

                    {
                        tfC.AddMultiline(@"
public static void CreateMessages(string jsFullName, GameObject go)
{
    int[] ids = GetJsClassMessages(jsFullName);
    if (ids == null)
        return;
 
    // ID号 JS和CS保持一致才不会错
    for (int i = 0; i < ids.Length; i++)
    {
        Type type = MessageTypes[ids[i]];
        if (go.GetComponent(type) == null)
            go.AddComponent(type);
    }
}");
                    }
                    tfC.AddLine();

                    {
                        TextFile tfM = tfC.Add("static Type[] MessageTypes = new Type[]").BraceIn();
                        {
                            for (int i = 0; i < infos.Length; i++)
                            {
                                Info info = infos[i];
                                tfM.Add("typeof(jsb.{0}),", info.className);
                            }
                        }
                        tfM.BraceOutSC();
                    }
                }
                tfC.BraceOut();
            }
            tfNs.BraceOut();
            
            string s = tf.Format(-1);
            File.WriteAllText(CsDir + "/" + className + ".cs", s);
        }

        static void GenJsMessageIDs()
        {
            TextFile tf = new TextFile(null, "// auto gen");
            tf.Add("// 记录每个脚本事件对应的ID号");
            TextFile tfK = tf.Add("Bridge.MessageIDs = ").BraceIn();
            for (int i = 0; i < infos.Length; i++)
            {
                Info info = infos[i];
                tfK.Add("\"{0}\": {1},", info.methodName, i);
            }
            tfK.BraceOutSC();

            string s = tf.Format(-1);
            File.WriteAllText(JsFile, s);
        }
        
        public static void Gen()
        {
            ClearFiles();
            
            // 生成事件响应的c#文件
            for (int i = 0; i < infos.Length; i++)
            {
				Info info = infos[i];              
				GenAMessage(info);
			}

            // 生成一个管理器用来添加事件响应
			GenMMgr("M_Mgr");

            // 让JS知道每个事件对应的ID
            GenJsMessageIDs();
        }
        
        static Info[] infos = new Info[]
        {
            // JSComponent 已有
            //      new Info("Awake()"),
            //      new Info("Start()"),
			//      new Info("OnDestroy()"),
			
			new Info("Update()"),
			new Info("LateUpdate()"),
			
			new Info("FixedUpdate()"),
			new Info("OnGUI()"),
			
			new Info("OnDisable()"),
			new Info("OnEnable()"),
			new Info("OnBecameInvisible()"),
			new Info("OnBecameVisible()"),
			
			new Info("OnTransformChildrenChanged()"),
			new Info("OnTransformParentChanged()"),
			
			new Info("OnApplicationFocus(bool focusStatus)"),
			new Info("OnApplicationPause(bool pauseStatus)"),
			new Info("OnApplicationQuit()"),
			new Info("OnAudioFilterRead(float[] data, int channels)"),
			new Info("OnLevelWasLoaded(int level)"),
			
			new Info("OnAnimatorIK(int layerIndex)"),
			new Info("OnAnimatorMove()"),
			new Info("OnJointBreak(float breakForce)"),
			
			new Info("OnParticleCollision(GameObject other)"),
			new Info("OnCollisionEnter(Collision collisionInfo)"),
			new Info("OnCollisionEnter2D(Collision2D coll)"),
			new Info("OnCollisionExit(Collision collisionInfo)"),
			new Info("OnCollisionExit2D(Collision2D coll)"),
			new Info("OnCollisionStay(Collision collisionInfo)"),
			new Info("OnCollisionStay2D(Collision2D coll)"),
			new Info("OnTriggerEnter(Collider other)"),
			new Info("OnTriggerEnter2D(Collider2D other)"),
			new Info("OnTriggerExit(Collider other)"),
			new Info("OnTriggerExit2D(Collider2D other)"),
			new Info("OnTriggerStay(Collider other)"),
			new Info("OnTriggerStay2D(Collider2D other)"),
			new Info("OnControllerColliderHit(ControllerColliderHit hit)"),
			
			new Info("OnConnectedToServer()"),
			new Info("OnDisconnectedFromServer(NetworkDisconnection info)"),
			new Info("OnFailedToConnect(NetworkConnectionError error)"),
			new Info("OnFailedToConnectToMasterServer(NetworkConnectionError info)"),
			new Info("OnMasterServerEvent(MasterServerEvent msEvent)"),
			new Info("OnNetworkInstantiate(NetworkMessageInfo info)"),
			new Info("OnPlayerConnected(NetworkPlayer player)"),
			new Info("OnPlayerDisconnected(NetworkPlayer player)"),
			new Info("OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)"),
			new Info("OnServerInitialized()"),
			
			new Info("OnMouseDown()"),
			new Info("OnMouseDrag()"),
			new Info("OnMouseEnter()"),
			new Info("OnMouseExit()"),
			new Info("OnMouseOver()"),
			new Info("OnMouseUp()"),
			new Info("OnMouseUpAsButton()"),
			
			new Info("OnPostRender()"),
			new Info("OnPreCull()"),
			new Info("OnPreRender()"),
			new Info("OnRenderImage(RenderTexture src, RenderTexture dest)"),
			new Info("OnRenderObject()"),
			new Info("OnWillRenderObject()"),		
			
			// Editor only
			//
			// Reset
			// OnDrawGizmos
			// OnDrawGizmosSelected
			// OnValidate
		};
	}

}