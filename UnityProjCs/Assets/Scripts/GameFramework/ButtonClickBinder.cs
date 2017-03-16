using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Reflection;

[RequireComponent(typeof(Button))]
public class ButtonClickBinder : MonoBehaviour
{
    public GameObject Go;
    public string ScriptName;
    public string MethodName;

    bool added = false;
    private void Start()
    {
        if (added)
            return;
        added = true;

        GetComponent<Button>().onClick.AddListener(OnClick);
    }

    public void OnClick()
    {
#if JS
        JSComponent[] coms = Go.GetComponents<JSComponent>();
        foreach (var com in coms)
        {
            if (com.jsClassName == ScriptName)
            {
                int jsId = com.GetJSObjID(false);
                if (jsId > 0)
                    JSMgr.vCall.CallJSFunctionName(jsId, MethodName);
                return;
            }
        }
#else
        MonoBehaviour[] coms = Go.GetComponents<MonoBehaviour>();
        foreach (var com in coms)
        {
            if (com.GetType().FullName == ScriptName)
            {
                MethodInfo method = com.GetType().GetMethod(MethodName);
                if (method != null)
                    method.Invoke(com, null);
                return;
            }
        }
#endif
    }
}
