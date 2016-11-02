CS.require("Bridge");

jsb = {
    findObj: function (name) {
        var ns = Bridge.global, arr = name.split('.');
        for (var i = 0; i < arr.length ; i++) {
            ns = ns[arr[i]];
            if (!Bridge.hasValue(ns)) {
                return null;
            }
        }
        return ns;
    },
}

function jsb_CallObjectCtor(name)
{
    var arr = name.split(".");
    var obj = this;
    arr.forEach(function (a) {
        if (obj)
            obj = obj[a];
    });
    if (obj && obj.ctor) {
        return new obj.ctor();
    }
    return undefined;
}

CS.require("Gen");

Bridge.define("Test", {
    inherits: [UnityEngine.MonoBehaviour],
    Start: function () {
        UnityEngine.MonoBehaviour.print("Start!");
    },
    Update: function () {

    }
});

CS.require("ErrorHandler");

