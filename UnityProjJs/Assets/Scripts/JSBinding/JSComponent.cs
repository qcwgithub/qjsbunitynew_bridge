using System;
using UnityEngine;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Security;

using jsval = JSApi.jsval;

/// <summary>
/// JSComponent
/// 负责把Unity的事件通知到Js
/// </summary>
public class JSComponent : JSSerializer
{
    [HideInInspector]
    [NonSerialized]
    protected int jsObjID = 0;

    int idAwake = 0;
    int idStart = 0;
    int idOnDestroy = 0;

    /// <summary>
    /// Initializes the member function.
    /// </summary>
    protected virtual void initMemberFunction()
    {
        idAwake = JSApi.getObjFunction(jsObjID, "Awake");
        idStart = JSApi.getObjFunction(jsObjID, "Start");
        idOnDestroy = JSApi.getObjFunction(jsObjID, "OnDestroy");
    }
    /// <summary>
    /// Removes if exist.
    /// </summary>
    /// <param name="id">The identifier.</param>
    void removeIfExist(int id)
    {
        if (id != 0)
        {
            JSApi.removeByID(id);
        }
    }
    void removeMemberFunction()
    {
        // 注意
        // 相同脚本的不同对象具有相同的 idAwake idStart ... 
        // 如果下面这些行在 OnDestroy 期间执行,绑定相同脚本的其他 gameObject 也会同时丢失这些函数
        // 如果之后再有一个新的 gameObject 被生成，并且绑定相同脚本，他会再次去取 idAwake idStart，但是会得到和之前不一样的值
        // 但是如果不移除的话，就会一直遗留在 C 的 valueMap 中
        //
        //         removeIfExist(idAwake);
        //         removeIfExist(idStart);
        //         removeIfExist(idFixedUpdate);
        //         removeIfExist(idUpdate);
        //         removeIfExist(idOnDestroy);
        //         removeIfExist(idOnGUI);
        //         removeIfExist(idOnEnable);
        //         removeIfExist(idOnTriggerEnter2D);
        //         removeIfExist(idOnTriggerStay);
        //         removeIfExist(idOnTriggerExit);
        //         removeIfExist(idOnAnimatorMove);
        //         removeIfExist(idOnAnimatorIK);
        //         removeIfExist(idDestroyChildGameObject);
        //         removeIfExist(idDisableChildGameObject);
        //         removeIfExist(idDestroyGameObject);
    }

    int jsState = 0;
    bool jsSuccess { get { return jsState == 1; } set { if (value) jsState = 1; } }
    public bool jsFail { get { return jsState == 2; } set { if (value) jsState = 2; else jsState = 0; } }

    protected void callIfExist(int funID, params object[] args)
    {
        if (funID > 0)
        {
            JSMgr.vCall.CallJSFunctionValue(jsObjID, funID, args);
        }
    }

    public void initJS()
    {
        if (jsFail || jsSuccess) return;

        if (string.IsNullOrEmpty(jsClassName))
        {
            jsFail = true;
            return;
        }

        // 注意
        // 这里不能用 createJSClassObject
        // because we have to call ctor, to run initialization code
        // 这个对象不会有 finalizeOp
        jsObjID = JSApi.newJSClassObject(this.jsClassName);
        if (jsObjID == 0)
        {
            Debug.LogError("New MonoBehaviour \"" + this.jsClassName + "\" failed. Did you forget to export that class?");
            jsFail = true;
            return;
        }

        jsb.M_Mgr.CreateMessages(jsClassName, gameObject);

		JSApi.setTraceS(jsObjID, true);
        JSMgr.addJSCSRel(jsObjID, this);
        initMemberFunction();
        jsSuccess = true;
    }

    //
    // 这里一共有3件事要做
    // A) initJS()
    // B) initSerializedData(jsObjID)
    // C) callIfExist(idAwake)
    //
    // 假设有2个类 X 和 Y
    // 情况 1) 如果 X 没有被其他人引用，在 X.Awake 期间，会执行: A + B + C
    //
    // 情况 2) 如果 X 里有一个 Y 的 public 变量（在 X.B() 期间会发现）, 那么 Y.A() 会立刻被调用(看 GetJSObjID). 
    //         后来，在 Y.Awake() 中，会执行： Y.B + Y.C
    //
    // 情况 3) 如果调用 AddComponent<X>()，会发生什么事情？
    //           i  X.Awake() -> jsFail == true 因为 jsClassName 是空
    //           ii 手动设置 jsFail = false -> 调用 init(true) 和 callAwake() (也就是 A + B + C)
    //
    //        参考：Components.cs 中的 GameObject_AddComponentT1 函数
    //
    // 情况 4) 如果调用 GetComponent<X>()，会发生什么事情？
    //         如果 X.Awake() 还没有被调用, 那么手动调用 X.init(true) (也就是 A + B)
    //         后来，X.Awake() 时: C
    //
    //         参考：Components.cs 中的 help_searchAndRetCom 和 help_searchAndRetComs 函数
    // 
    public void init(bool callSerialize)
    {
        if (!JSEngine.initSuccess && !JSEngine.initFail)
        {
            JSEngine.FirstInit();
        }
        if (!JSEngine.initSuccess)
        {
            return;
        }

        initJS();

        if (jsSuccess && callSerialize && !DataSerialized)
        {
            initSerializedData(jsObjID);
        }
    }

	public override void initSerializedData(int jsObjID)
	{
		if (DataSerialized)
			return;
		base.initSerializedData(jsObjID);
		
		// init child
		for (int i = 0; waitSerialize != null && i < waitSerialize.Count; i++)
		{
			waitSerialize[i].initSerializedData(waitSerialize[i].jsObjID);
		}
		waitSerialize = null;
	}
		
    public void callAwake()
    {
        if (jsSuccess)
        {
            callIfExist(idAwake);
        }
    }
    void Awake()
    {
        init(true);
        callAwake();
    }
    /// <summary>
    /// 获取 JSComponent 对应的 Js 对象 Id.
    /// jsObjID 此时可能为0，当其他脚本引用此对象
    /// 在这种情况下，手动调用 initJS()
    /// </summary>
    public int GetJSObjID(bool callSerialize)
    {
        if (jsObjID == 0)
        {
            init(callSerialize);
        }
        return jsObjID;
    }

    void Start() 
    {
        callIfExist(idStart);
    }

    void OnDestroy()
    {
        if (!JSMgr.IsShutDown)
        {
            callIfExist(idOnDestroy);
        }

        if (jsSuccess)
        {
            // remove this jsObjID even if JSMgr.isShutDown is true
            JSMgr.removeJSCSRel(jsObjID);
        }

        if (JSMgr.IsShutDown)
        {
            return;
        }

        if (jsSuccess)
        {
            // JSMgr.RemoveRootedObject(jsObj);
            JSApi.setTraceS(jsObjID, false);
            // JSMgr.removeJSCSRel(jsObjID); // Move upwards

            // jsObjID 并没有 finalize（Js那边的析构回调）
            // 所以在这里必须手动移除
            JSApi.removeByID(jsObjID);
            removeMemberFunction();
        }
    }

	public void RecvMsg(string msg, params object[] args)
	{
		JSMgr.vCall.CallJSFunctionName(jsObjID, msg, args);
	}

    public static JSComponent s_AddComponent(GameObject go, string jsName)
    {
        JSComponent jsComp = go.AddComponent<JSComponent>();
        jsComp.jsClassName = jsName;
        jsComp.jsFail = false;
        jsComp.init(true);
        jsComp.callAwake(); // 要调用 js 的 Awake
        return jsComp;
    }
}
