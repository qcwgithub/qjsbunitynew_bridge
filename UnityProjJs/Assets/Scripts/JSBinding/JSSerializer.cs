using UnityEngine;
using System;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;

// JSSerializer: serialize something to javascript object
public class JSSerializer : MonoBehaviour
{
    public string jsClassName = string.Empty;
    public string[] arrString = null;
    public UnityEngine.Object[] arrObject = null;

	int toID(char ct, string strValue)
    {
        switch (ct)
        {
            case 'i':
            case 'f':
                {
                    double v;
                    if (double.TryParse(strValue, out v))
                    {
                        JSApi.setDouble((int)JSApi.SetType.SaveAndTempTrace, v);
                        return JSApi.getSaveID();
                    }
                }
                break;
            case 's':
                {
                    JSApi.setStringS((int)JSApi.SetType.SaveAndTempTrace, strValue);
                    return JSApi.getSaveID();
                }
                //break;
            default:
                break;
        }
        return 0;
    }

	public int GetGameObjectMonoBehaviourJSObj(GameObject go, string scriptName, out JSComponent component)
    {
		component = null;

		// go may be null
		// because the serialized MonoBehaviour can be null
		if (go == null)
			return 0;

        JSComponent[] jsComs = go.GetComponents<JSComponent>();
        foreach (var com in jsComs)
        {
			// NOTE: if a script bind to a GameObject twice, it will always return the first one
            if (com.jsClassName == scriptName)
            {
				component = com;
                return com.GetJSObjID(false);
            }
        }
        return 0;
    }

    public class SerializeStruct
    {
        public string name;
		public int id;

        public List<SerializeStruct> children;

        public void AddChild(SerializeStruct ss)
        {
            if (children == null) 
                children = new List<SerializeStruct>();
            children.Add(ss);
        }
        public SerializeStruct(string name)
        {
            this.name = name;
            id = 0;
        }

        public void removeID()
        {
            if (this.id != 0)
            {
                JSApi.removeByID(this.id);
                this.id = 0;
            }
            if (children != null)
            {
                foreach (var child in children)
                {
                    child.removeID();
                }
            }
        }
    }

    public void ParseSerializeData(int jsObjID, SerializeStruct st)
    {
        while (true)
        {
            string s = NextString();
            if (s == null)
                return;

			int i = s.IndexOf('/');
			string varName = s.Substring(0, i);
			string varValue = s.Substring(i + 1);

			char ct = varName[0];
			if (ct == 'o')
			{
				// varName / objIndex

				var objIndex = int.Parse(varValue);
				JSMgr.datax.setObject((int)JSApi.SetType.SaveAndTempTrace, this.arrObject[objIndex]);
				
				var child = new SerializeStruct(varName);
				child.id = JSApi.getSaveID();
				st.AddChild(child);
			}
			else if (ct == 'k')
			{
				// varName / objIndex / scriptName

				var arr = varValue.Split('/');
				var objIndex = int.Parse(arr[0]);
				var scriptName = arr[1];
				
				var child = new SerializeStruct(varName);
				JSComponent component;
				int refJSObjID = this.GetGameObjectMonoBehaviourJSObj((GameObject)this.arrObject[objIndex], scriptName, out component);
				if (refJSObjID == 0)
				{
					child.id = 0;
				}
				else
				{
					if (waitSerialize == null)
						waitSerialize = new List<JSComponent>();
					waitSerialize.Add(component);
					
					JSApi.setObject((int)JSApi.SetType.SaveAndTempTrace, refJSObjID);
					child.id = JSApi.getSaveID();
				}
				
				st.AddChild(child);
			}
			else // 'f', 'i', 's'
			{
				// varName / varValue

				int id = toID(ct, varValue);
				var child = new SerializeStruct(varName);
				//child.val = JSMgr.vCall.valTemp;
				child.id = id;
				st.AddChild(child);
			}
		}
	}
	int arrStringIndex = 0;
	string NextString()
	{
		if (arrString == null) return null;
		if (arrStringIndex >= 0 && arrStringIndex < arrString.Length)
		{
			return arrString[arrStringIndex++];
		}
		return null;
	}
	
	bool dataSerialized = false;
	protected bool DataSerialized { get { return dataSerialized; } }
    protected List<JSComponent> waitSerialize = null;
    /// <summary>
    /// Initializes the serialized data.
    /// </summary>
    /// <param name="jsObjID">The js object identifier.</param>
    public virtual void initSerializedData(int jsObjID)
    {
        if (dataSerialized)
            return;
        
        dataSerialized = true;
        
        if (arrString == null || arrString.Length == 0)
        {
            return;
        }
        
		SerializeStruct root = new SerializeStruct("root");
        ParseSerializeData(jsObjID, root);
        if (root.children != null)
        {
            foreach (var child in root.children)
            {
				SetObjectFieldOrProperty(jsObjID, child.name, child.id);
            }
        }
        root.removeID();
    }

	static void SetObjectFieldOrProperty(int jsObjID, string name, int valueID)
	{
		// Field
		JSApi.setProperty(jsObjID, name, valueID);
	}
}