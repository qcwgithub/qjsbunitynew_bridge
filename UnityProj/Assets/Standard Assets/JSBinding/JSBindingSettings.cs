using UnityEngine;
//using UnityEditor;
using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;


public class Qcw : ICloneable
{
	public enum QCWEn{
		HELLO,
		APPLE,
		WORLD,
	}
	public QCWEn en;
	public object Clone() { return null; }
	public Qcw() { }
	//		public int y{get;set;}
	//		public int this[int index]
	//		{
	//			get{
	//				return 0;
	//			}
	//			set {
	//				//return
	//			}
	//		}
	public int Get<T>(int a, int b = 0, int c = 0) { return 0; }
	public static int SGet(int a, int b = 0, int c = 0) { return 0; }
	public int V;
	public static string X;
	public string GV { get; set; }
	public static string SGV { get; set; }
	
	public int this[int i]
	{
		get { return 666; }
		set { }
	}
	public int this[int i, int j]
	{
		get { return 777; }
		set { }
	}
}
public class JSBindingSettings
{
    public static Type[] enums = new Type[]
    {
//        typeof(BindingFlags),
//		typeof(Qcw.QCWEn),
    };
    
    //
    // types to export to JavaSciprt
	// only for samples!
	//
	// below there is another classes(commented out) having almost all types in UnityEngine
	//

    

    public static Type[] classes = new Type[]
    {
        typeof(Qcw),
        typeof(ICloneable),
////
       typeof(Debug),
       typeof(Input),
       typeof(GameObject),
        typeof(Transform),
        typeof(Vector2),
        typeof(Vector3),
        typeof(UnityEngine.Object),
        typeof(MonoBehaviour),
        typeof(Behaviour),
        typeof(Component),
        typeof(IDisposable),
        typeof(IConvertible),
        typeof(IComparable),
        typeof(IEnumerable),
        typeof(IFormattable),
//        typeof(YieldInstruction),
//        typeof(WaitForSeconds),
        typeof(WWW),
        typeof(Application),
        typeof(UnityEngine.Time),
        typeof(Resources),
        typeof(TextAsset),
//        
        typeof(IEnumerator),
//        typeof(List<>),
//        typeof(List<>.Enumerator),
//        typeof(Dictionary<,>),
//        typeof(Dictionary<,>.KeyCollection), 
//        typeof(Dictionary<,>.ValueCollection), 
//        typeof(Dictionary<,>.Enumerator), 
//        typeof(KeyValuePair<,>), 
//        
//        typeof(System.Diagnostics.Stopwatch),
//        typeof(UnityEngine.Random),
//        typeof(StringBuilder),
//
//        typeof(System.Xml.XmlNode),
//        typeof(System.Xml.XmlDocument),
//        typeof(System.Xml.XmlNodeList),
//        typeof(System.Xml.XmlElement),
//        typeof(System.Xml.XmlLinkedNode),
//        typeof(System.Xml.XmlAttributeCollection),
//        typeof(System.Xml.XmlNamedNodeMap),
//        typeof(System.Xml.XmlAttribute),
//
//        // for 2d platformer
        typeof(LayerMask),
        typeof(Physics2D),
        typeof(Rigidbody2D),
        typeof(Collision2D),
        typeof(RaycastHit2D),
        typeof(AudioClip),
        typeof(AudioSource),
        typeof(ParticleSystem),
        typeof(Renderer),
        typeof(ParticleSystemRenderer),
        typeof(DateTime),
        typeof(GUIElement),
        typeof(GUIText),
        typeof(GUITexture),
        typeof(SpriteRenderer),
        typeof(Animator),
        typeof(Camera),
        typeof(Mathf),
        typeof(Quaternion),
        typeof(Sprite),
        typeof(Collider2D),
        typeof(BoxCollider2D),
        typeof(CircleCollider2D),
        typeof(Material),
        typeof(Color),
        typeof(PolygonCollider2D),

        typeof(Light),
        typeof(NavMeshAgent),
        typeof(Rect),
        typeof(Physics),
        typeof(Collider),
        typeof(SphereCollider),
        typeof(LineRenderer),
        typeof(MeshCollider),
        typeof(MeshRenderer),
        typeof(Screen),
        typeof(RaycastHit),
        typeof(BoxCollider),
        typeof(CapsuleCollider),
        typeof(AnimatorStateInfo),
        typeof(Rigidbody),
        typeof(NavMeshPath),

	};
	
	// some public class members can be used
	// some of them are only in editor mode
	// some are because of unknown reason
	//
	// they can't be distinguished by code, but can be known by checking unity docs
	public static bool IsDiscard(Type type, MemberInfo memberInfo)
	{
		string memberName = memberInfo.Name;
		
		if (typeof(Delegate).IsAssignableFrom(type)/* && (memberInfo is MethodInfo || memberInfo is PropertyInfo || memberInfo is FieldInfo)*/)
		{
			return true;
		}
		
		if (memberName == "networkView" && (type == typeof(GameObject) || typeof(Component).IsAssignableFrom(type)))
		{
			return true;
		}
		
		if ((type == typeof(Application) && memberName == "ExternalEval") ||
		    (type == typeof(Input) && memberName == "IsJoystickPreconfigured"))
		{
			return true;
		}
		
		//
		// Temporarily commented out
		// Uncomment them yourself!!
		//
		if ((type == typeof(Motion)) ||
		    (type == typeof(AnimationClip) && memberInfo.DeclaringType == typeof(Motion)) ||
		    (type == typeof(Application) && memberName == "ExternalEval") ||
		    (type == typeof(Input) && memberName == "IsJoystickPreconfigured") ||
		    (type == typeof(AnimatorOverrideController) && memberName == "PerformOverrideClipListCleanup") ||
		    (type == typeof(Caching) && (memberName == "ResetNoBackupFlag" || memberName == "SetNoBackupFlag")) ||
		    (type == typeof(Light) && (memberName == "areaSize")) ||
		    (type == typeof(Security) && memberName == "GetChainOfTrustValue") ||
		    (type == typeof(Texture2D) && memberName == "alphaIsTransparency") ||
		    (type == typeof(WebCamTexture) && (memberName == "isReadable" || memberName == "MarkNonReadable")) ||
		    (type == typeof(StreamReader) && (memberName == "CreateObjRef" || memberName == "GetLifetimeService" || memberName == "InitializeLifetimeService")) ||
		    (type == typeof(StreamWriter) && (memberName == "CreateObjRef" || memberName == "GetLifetimeService" || memberName == "InitializeLifetimeService")) ||
		    (type == typeof(UnityEngine.Font) && memberName == "textureRebuildCallback")
		    #if UNITY_4_6 || UNITY_4_7
		    || (type == typeof(UnityEngine.EventSystems.PointerEventData) && memberName == "lastPress")
		    || (type == typeof(UnityEngine.UI.InputField) && memberName == "onValidateInput") // property delegate
		    || (type == typeof(UnityEngine.UI.Graphic) && memberName == "OnRebuildRequested")
		    || (type == typeof(UnityEngine.UI.Text) && memberName == "OnRebuildRequested")
		    #endif
		    )
		{
			return true;
		}
		
		#if UNITY_ANDROID || UNITY_IPHONE
		if (type == typeof(WWW) && (memberName == "movie"))
			return true;
		#endif
		return false;
	}
	
	public static bool IsSupportByDotNet2SubSet(string functionName)
	{
		if (functionName == "Directory_CreateDirectory__String__DirectorySecurity" ||
		    functionName == "Directory_GetAccessControl__String__AccessControlSections" ||
		    functionName == "Directory_GetAccessControl__String" ||
		    functionName == "Directory_SetAccessControl__String__DirectorySecurity" ||
		    functionName == "DirectoryInfo_Create__DirectorySecurity" ||
		    functionName == "DirectoryInfo_CreateSubdirectory__String__DirectorySecurity" ||
		    functionName == "DirectoryInfo_GetAccessControl__AccessControlSections" ||
		    functionName == "DirectoryInfo_GetAccessControl" ||
		    functionName == "DirectoryInfo_SetAccessControl__DirectorySecurity" ||
		    functionName == "File_Create__String__Int32__FileOptions__FileSecurity" ||
		    functionName == "File_Create__String__Int32__FileOptions" ||
		    functionName == "File_GetAccessControl__String__AccessControlSections" ||
		    functionName == "File_GetAccessControl__String" ||
		    functionName == "File_SetAccessControl__String__FileSecurity")
		{
			return false;
		}
		return true;
	}
	
	public static bool NeedGenDefaultConstructor(Type type)
	{
		if (typeof(Delegate).IsAssignableFrom(type))
			return false;
		
		if (type.IsInterface)
			return false;
		
		// don't add default constructor
		// if it has non-public constructors
		// (also check parameter count is 0?)
		if (type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).Length != 0)
			return false;
		
		//foreach (var c in type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance))
		//{
		//    if (c.GetParameters().Length == 0)
		//        return false;
		//}
		
		if (type.IsClass && (type.IsAbstract || type.IsInterface))
			return false;
		
		if (type.IsClass)
		{
			return type.GetConstructors().Length == 0;
		}
		else
		{
			foreach (var c in type.GetConstructors())
			{
				if (c.GetParameters().Length == 0)
					return false;
			}
			return true;
		}
	}
	
	// extension (including ".")
	public static string jsExtension = ".javascript";
	public static string jscExtension = ".bytes";
	// directory to save js files
	public static string jsDir = Application.streamingAssetsPath + "/JavaScript";
	public static string jsRelDir = "Assets/StreamingAssets/JavaScript";
	public static string mergedJsDir = Application.dataPath + "/../Temp/JavaScript_js";
	public static string jscDir = Application.dataPath + "/JSC";
	public static string jscRelDir = "Assets/JSC";	
	
	public static string jsGeneratedFiles { get { return jsDir + "/Gen" + jsExtension; } }
	// 
	public static string csDir = Application.dataPath + "/JSBinding/CSharp";
	public static string csGeneratedDir = Application.dataPath + "/Standard Assets/JSBinding/G";
	public static string sharpkitGeneratedFiles = JSBindingSettings.jsDir + "/SharpKitGeneratedFiles.javascript";
	public static string monoBehaviour2JSComponentName = JSBindingSettings.jsDir + "/MonoBehaviour2JSComponentName.javascript";
	public static string sharpKitGenFileDir = "StreamingAssets/JavaScript/SharpKitGenerated/";
	
	public static string sharpKitGenFileFullDir { get { return jsDir + "/SharpKitGenerated"; }}
	
	public static string SharpkitGeneratedFilesAll = JSBindingSettings.jsDir + "/SharpKitGeneratedFilesAll.javascript";
	public static string GeneratedFilesAll = JSBindingSettings.jsDir + "/GeneratedFilesAll.javascript";
	
	
	/*
     * Formula:
     * All C# scripts - PathsNotToJavaScript + PathsToJavaScript = C# scripts to export to javascript
     * see JSAnalyzer.MakeJsTypeAttributeInSrc for more information
     */
	public static string[] PathsNotToJavaScript = new string[]
	{
		"JSBinding/",
		//"Stealth/",
		"DaikonForge Tween (Pro)/",
		"NGUI/",
		"Scripts/Framework/"
	};
	public static string[] PathsToJavaScript = new string[]
	{
		"JSBinding/Samples/",
		"JSBinding/JSImp/", // !!
		"DaikonForge Tween (Pro)/Examples/Scripts",
	};
	/// <summary>
	/// By default, menu
	/// 
	/// JSB | Check All Monos for all Prefabs and Scenes
	/// JSB | Replace All Monos for all Prefabs and Scenes
	/// 
	/// handles all Prefabs and Scenes in whole project
	/// add paths(directory or file name) to this array if you want to skip them
	/// </summary>
	public static string[] PathsNotToCheckOrReplace = new string[]
	{
		"JSBinding/",
		"JSBinding/Prefabs/_JSEngine.prefab",
		"Plugins/",
		"Resources/",
		"Src/",
		"StreamingAssets/",
		"UnityVS/",
		"DaikonForge Tween (Pro)/",
		"NGUI/",
	};
	
	/// <summary>
	/// Gets the type serialized properties.
	/// 如果想要序列化某个类的Property，则得在这里配置，否则不序列化。
	/// </summary>
	/// <returns>The type serialized properties.</returns>
	public static PropertyInfo[] GetTypeSerializedProperties(Type type)
	{
		PropertyInfo[] infos = null;
		if (type == typeof(AnimationCurve))
		{
			infos = new PropertyInfo[]
			{
				type.GetProperty("keys"),
				type.GetProperty("postWrapMode"),
				type.GetProperty("preWrapMode")
			};
		}
		else if (type == typeof(Keyframe))
		{
			infos = new PropertyInfo[]
			{
				type.GetProperty("inTangent"),
				type.GetProperty("outTangent"),
				type.GetProperty("tangentMode"),
				type.GetProperty("time"),
				type.GetProperty("value")
			};
		}
		if (infos == null)
			infos = new PropertyInfo[0];
		return infos;
	}
}
