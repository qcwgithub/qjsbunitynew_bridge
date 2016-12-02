(function () {
    var fullname = "UnityEngine.WaitForSeconds",
        mb = Bridge.findObj(fullname),
        pt = mb ? mb.prototype : null;

    if (!pt) {
        return;
    }

    var replace = function (funName, fun, allowNew) {
        if (!allowNew && !pt[funName]) {
            UnityEngine.Debug.LogError("Manual-js: " + fullname + "." + funName + " not found!");
            return;
        }
        pt[funName] = fun;
    };
    

    // 在这里改不行啊
    // 因为 UnityEngine.WaitForSeconds === UnityEngine.WaitForSeconds.ctor
    // 挪到 c# 去做特殊处理...
    //replace("ctor", function(a0) {
    //    this.$totalTime = a0;
    //    this.$elapsedTime = 0;
    //    this.$finished = false;
    //});

    replace("get_finished", function(elapsed) { 

        if (!this.$finished) {
            this.$elapsedTime += elapsed;
            if (this.$elapsedTime >= this.$totalTime) {
                this.$finished = true;
            }        
        }
        return this.$finished;
    }, true);

})();