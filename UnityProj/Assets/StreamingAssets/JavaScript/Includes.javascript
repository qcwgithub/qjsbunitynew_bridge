CS.require("Bridge");

function jsb_CallObjectCtor(name) { return Bridge.callObjCtor(name); }

CS.require("Gen");



Bridge.define("Test", {
        inherits: [UnityEngine.MonoBehaviour],
        Start: function () {
            var $t;
            //print("my name is " + name);

            //var q = new Qcw();
            //print("q.V = " + q.V);
            //print("Qcw.X = " + Qcw.X);

            var a = this.getgameObject().AddComponent(UnityEngine.AudioSource);
            UnityEngine.MonoBehaviour.print(System.String.concat("audio.name = ", a.getname()));

            UnityEngine.MonoBehaviour.print("all behaviours: ");
            var arr = this.GetComponents(UnityEngine.Behaviour);
            $t = Bridge.getEnumerator(arr);
            while ($t.moveNext()) {
                var c = $t.getCurrent();
                UnityEngine.MonoBehaviour.print(Bridge.Reflection.getTypeName(Bridge.getType(c)));
            }
        },
        Update: function () {

        }
    });

CS.require("ErrorHandler");

