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
/// A class redirect event functions (Awake, Start, Update, etc.) to JavaScript
/// Support serializations
/// </summary>
public class JSComponent : JSSerializer
{
    [HideInInspector]
    [NonSerialized]
    protected int jsObjID = 0;

    int idAwake = 0;
    int idStart = 0;
    int idOnDestroy = 0;
	int idFixedUpdate = 0;
	int idUpdate = 0;
	int idLateUpdate = 0;
	int idOnEnable = 0;

    /// <summary>
    /// Initializes the member function.
    /// </summary>
    protected virtual void initMemberFunction()
    {
        idAwake = JSApi.getObjFunction(jsObjID, "Awake");
        idStart = JSApi.getObjFunction(jsObjID, "Start");
        idOnDestroy = JSApi.getObjFunction(jsObjID, "OnDestroy");
		idFixedUpdate = JSApi.getObjFunction(jsObjID, "FixedUpdate");
		idUpdate = JSApi.getObjFunction(jsObjID, "Update");
		idLateUpdate = JSApi.getObjFunction(jsObjID, "LateUpdate");
		idOnEnable = JSApi.getObjFunction(jsObjID, "OnEnable");
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
        // ATTENSION
        // same script have same idAwake idStart ... values
        // if these lines are executed in OnDestroy (for example  for gameObject A)
        // other gameObjects (for example B) with the same script
        // will also miss these functions
        // 
        // and if another C (with the same script) is born later   
        // it will re-get these values  but they are new values 
        // 
        // 
        // but if they are not removed in OnDestroy 
        // C valueMap may grow to a very big size
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

        // ATTENSION
        // cannot use createJSClassObject here
        // because we have to call ctor, to run initialization code
        // this object will not have finalizeOp
        jsObjID = JSApi.newJSClassObject(this.jsClassName);
        JSApi.setTraceS(jsObjID, true);
        if (jsObjID == 0)
        {
            Debug.LogError("New MonoBehaviour \"" + this.jsClassName + "\" failed. Did you forget to export that class?");
            jsFail = true;
            return;
        } 
        JSMgr.addJSCSRel(jsObjID, this);
        initMemberFunction();
        jsSuccess = true;
    }

    //
    // things to do:
    // A) initJS()
    // B) initSerializedData(jsObjID)
    // C) callIfExist(idAwake)
    //
    // assume we have 2 classes X and Y
    // case 1) if X is not referenced by other classes, during X.Awake(): A + B + C
	//
	// case 2) if a public variable of Y is found during X.initSerializedData(), Y.A() will be called immediately(see GetJSObjID). 
	//         after that, during Y.Awake(): B + C
	//
	// case 3) what happens during AddComponent<X>()
	//           i  X.Awake() -> jsFail == true because jsClassName is empty
	//           ii manually set jsFail = false -> call init(true) and callAwake() (equals to A + B + C)
	//
	//        see GameObject_AddComponentT1 in Components.cs
	//
	// case 4) what happends during GetComponent<X>()
	//         if X.Awake() is not called yet, we manually call X.init(true) (equals to A + B)
	//         after that, during X.Awake(): C
	//
	//         see help_searchAndRetCom and help_searchAndRetComs in Components.cs
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
    /// get javascript object id of this JSComponent.
    /// jsObjID may == 0 when this function is called, because other scripts refer to this JSComponent.
    /// in this case, we call initJS() for this JSComponent immediately.
    /// </summary>
    /// <returns></returns>
    /// 
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

            //
            // jsObj doesn't have finalize
            // we must remove it here
            // having a finalize is another approach
            //
            JSApi.removeByID(jsObjID);
            removeMemberFunction();
        }
    }

     void FixedUpdate()
     {
         callIfExist(idFixedUpdate);
     }

     void Update()
     {
         callIfExist(idUpdate);
     }

     void LateUpdate()
     {
         callIfExist(idLateUpdate);
     }
 
     void OnEnable()
     {
         callIfExist(idOnEnable);
     }
}
