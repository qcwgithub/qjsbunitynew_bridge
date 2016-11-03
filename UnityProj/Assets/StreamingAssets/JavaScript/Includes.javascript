CS.require("Bridge");

function jsb_CallObjectCtor(name) { return Bridge.callObjCtor(name); }

CS.require("Gen");



Bridge.define("Test", {
    inherits: [UnityEngine.MonoBehaviour],
    Start: function () {
        UnityEngine.MonoBehaviour.print(System.String.concat("my name is ", this.getname()));

        var q = new Qcw();
        UnityEngine.MonoBehaviour.print("q.V = " + q.V);
        UnityEngine.MonoBehaviour.print(System.String.concat("Qcw.X = ", Qcw.X));
    },
    Update: function () {

    }
});

CS.require("ErrorHandler");

