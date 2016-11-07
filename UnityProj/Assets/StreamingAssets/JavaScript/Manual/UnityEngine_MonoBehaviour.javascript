(function () {
    var fullname = "UnityEngine.MonoBehaviour",
        mb = Bridge.findObj(fullname),
        pt = mb ? mb.prototype : null;

    if (!pt) {
        return;
    }

    var replace = function (funName, fun) {
        if (!pt[funName]) {
            UnityEngine.Debug.LogError("Manual-js: " + fullname + "." + funName + " not found!");
            return;
        }
        pt[funName] = fun;
    };

    replace("CancelInvoke$1", function(a0/*String*/) {
        this.$RemoveInvokeByName(a0); 
    });

    replace("CancelInvoke", function() {
        this.$RemoveAllInvokes();
    });

    replace("Invoke", function(a0/*String*/, a1/*Single*/) {
        if (this[a0]) {
            var fun = this[a0].bind(this);
            this.$AddInvoke(a0, fun, a1, 0, false);
        }
    });

    replace("InvokeRepeating", function(a0/*String*/, a1/*Single*/, a2/*Single*/) {
        if (this[a0]) {
            var fun = this[a0].bind(this);
            this.$AddInvoke(a0, fun, a1, a2, true);
        }
    });

    replace("IsInvoking$1", function(a0/*String*/) {
        return this.$IsInvoking(a0);
    });

    replace("IsInvoking", function() {
        return this.$IsInvoking(undefined);
    });

    replace("StartCoroutine$2", function(a0/*String*/, a1/*Object*/) {
        if (this[a0]) {
            var fiber = this[a0].call(this, a1);
            return this.$AddCoroutine(fiber, a0);
        }
    });

    replace("StartCoroutine$1", function(a0/*String*/) {
        if (this[a0]) {
            var fiber = this[a0].call(this);
            return this.$AddCoroutine(fiber, a0);
        }
    });

    replace("StartCoroutine", function(a0/*IEnumerator*/) {
        return this.$AddCoroutine(a0);
    });

    replace("StartCoroutine_Auto", function(a0/*IEnumerator*/) {
        return this.$AddCoroutine(a0);
    });

    replace("StopAllCoroutines", function() {
        return this.$RemoveAllCoroutines();
    });

    replace("StopCoroutine", function(a0/*Coroutine*/) {
        return this.$RemoveCoroutineByFiber(a0);
    });

    replace("StopCoroutine$1", function(a0/*String*/) {
        return this.$RemoveCoroutineByName(a0);
    });

    
    pt.$AddInvoke = function (funName, fun, delay, interval, bRepeat) {
        var invokeNode = {
            funName: funName,
            fun: fun,
            delay: delay,
            interval: interval,
            accum: 0,
            bRepeat: bRepeat,

            prev: undefined,
            next: undefined
        };
        if (this.$firstInvoke) {
            invokeNode.next = this.$firstInvoke;
            this.$firstInvoke.prev = invokeNode;
        };
        this.$firstInvoke = invokeNode;
    };
    pt.$UpdateAllInvokes = function (elapsed) {
        var invoke = this.$firstInvoke,
            next,
            bCall;
        while (invoke != undefined) {
            next = invoke.next;
            bCall = false;
            if (invoke.delay > 0) {
                invoke.delay -= elapsed;
                if (invoke.delay <= 0) {
                    bCall = true;
                }
            } else {
                invoke.accum += elapsed;
                if (invoke.accum >= invoke.interval) {
                    invoke.accum -= invoke.interval;
                    bCall = true;
                }
            }
            if (bCall) {
                invoke.fun();
                if (!invoke.bRepeat) {
                    this.$RemoveInvoke(invoke);
                }
            }
            invoke = next;
        }
    };
    pt.$IsInvoking = function (funName) {
        if (funName == undefined) {
            return (this.$firstInvoke != undefined);
        } else {
            var invoke = this.$firstInvoke,
                next,
                bCall;
            while (invoke != undefined) {
                next = invoke.next;
                if (invoke.funName == funName) {
                    return true;
                }
                invoke = next;
            }
            return false;
        }
    };
    pt.$RemoveAllInvokes = function () {
        this.$firstInvoke = undefined;
    };
    pt.$RemoveInvokeByName = function (funName) {
        var invoke = this.$firstInvoke,
            next,
            bCall;
        while (invoke != undefined) {
            next = invoke.next;
            if (invoke.funName == funName) {
                this.$RemoveInvoke(invoke);
            }
            invoke = next;
        }
    };
    pt.$RemoveInvoke = function (invoke) {
        if (this.$firstInvoke == invoke) {
            this.$firstInvoke = invoke.next;
        }
        else {
            if (invoke.next != undefined) {
                invoke.prev.next = invoke.next;
                invoke.next.prev = invoke.prev;
            }
            else if (invoke.prev) {
                invoke.prev.next = undefined;
            }
        }
        invoke.prev = undefined;
        invoke.next = undefined;
    };

    //
    // Coroutine Scheduler
    // 
    // REFERENCE FROM
    // 
    // Coroutine Scheduler:
    // http://wiki.unity3d.com/index.php/CoroutineScheduler
    //
    // JavaScript yield documents:
    // https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Operators/yield
    // 

    // fiber 类似于 C# 的 IEnumerator
    pt.$AddCoroutine = function (fiber, name) {
        var coroutineNode = {
            $__CN: true,  // mark this is a coroutine node
            prev: undefined,
            next: undefined,
            fiber: fiber,
            finished: false,
            name: name,

            waitForFrames: 0,          // yield null
            waitForSeconds: undefined, // WaitForSeconds
            www: undefined,            // WWW
            asyncOp: undefined,         // AsyncOperation
            waitForCoroutine: undefined, // Coroutine
        };

        if (this.$first) {
            coroutineNode.next = this.$first;
            this.$first.prev = coroutineNode;
        };

        this.$first = coroutineNode;
        // NOTE
        // return coroutine node itself!
        return coroutineNode;
    };
    // this method is called from LateUpdate
    pt.$UpdateAllCoroutines = function (elapsed) {
        // cn is short for Coroutine Node
        var cn = this.$first;
        while (cn != undefined) {
            // store next coroutineNode before it is removed from the list
            var next = cn.next;
            var update = false;

            if (cn.waitForFrames > 0) {
                cn.waitForFrames--;
                if (cn.waitForFrames <= 0) {
                    waitForFrames = 0;
                    this.$UpdateCoroutine(cn);
                }
            }
            else if (cn.waitForSeconds) {
                if (cn.waitForSeconds.get_finished(elapsed)) {
                    cn.waitForSeconds = undefined;
                    this.$UpdateCoroutine(cn);
                }
            }
            else if (cn.www) {
                if (cn.www.get_isDone()) {
                    cn.www = undefined;
                    this.$UpdateCoroutine(cn);
                }
            }
            else if (cn.asyncOp) {
                if (cn.asyncOp.get_isDone()) {
                    cn.asyncOp = undefined;
                    this.$UpdateCoroutine(cn);
                }
            }
            else if (cn.waitForCoroutine) {
                if (cn.waitForCoroutine.finished == true) {
                    cn.waitForCoroutine = undefined;
                    this.$UpdateCoroutine(cn);
                }  
            }
            else {
                this.$UpdateCoroutine(cn);
            }
            cn = next;
        }
    };
    pt.$UpdateCoroutine = function (cn) { // cn is short for Coroutine Node
        var fiber = cn.fiber;
        var obj = fiber.next();
        if (!obj.done) {
            var yieldCommand = obj.value;
            // UnityEngine.Debug.Log$$Object(JSON.stringify(yieldCommand));
            if (yieldCommand == null || Bridge.isNumber(yieldCommand)) {
                cn.waitForFrames = 1;
            }
            else {
                if (yieldCommand instanceof UnityEngine.WaitForSeconds) {
                    cn.waitForSeconds = yieldCommand;
                } 
                else if (yieldCommand instanceof UnityEngine.WWW) {
                    cn.www = yieldCommand;
                }
                else if (yieldCommand instanceof UnityEngine.AsyncOperation) {
                    cn.asyncOp = yieldCommand;
                }
                else if (yieldCommand.$__CN === true/*yieldCommand.toString() == "[object Generator]"*/) {
                    cn.waitForCoroutine = yieldCommand;
                }
                else {
                    throw "Unexpected coroutine yield type: " + yieldCommand.GetType();
                }
            }
        } 
        else {
            // UnityEngine.MonoBehaviour.print("cn.finished = true;");
            
            cn.finished = true;
            this.$RemoveCoroutine(cn);
        }
    };
    pt.$RemoveAllCoroutines = function () {
        this.$first = undefined;
    };
    pt.$RemoveCoroutineByFiber = function (fiber) {
        var cn = this.$first;
        while (cn != undefined) {
            // store next coroutineNode before it is removed from the list
            var next = cn.next;
            if (cn.fiber === fiber) {
                this.$RemoveCoroutine(cn);
            }
            cn = next;
        }
    };
    pt.$RemoveCoroutineByName = function (name) {
        var cn = this.$first;
        while (cn != undefined) {
            // store next coroutineNode before it is removed from the list
            var next = cn.next;
            if (cn.name == name) {
                this.$RemoveCoroutine(cn);
            }
            cn = next;
        }
    };
    pt.$RemoveCoroutine = function (cn) { // cn is short for Coroutine Node
        if (this.$first == cn) {
            this.$first = cn.next;
        }
        else {
            if (cn.next != undefined) {
                cn.prev.next = cn.next;
                cn.next.prev = cn.prev;
            }
            else if (cn.prev) {
                cn.prev.next = undefined;
            }
        }
        cn.prev = undefined;
        cn.next = undefined;
    };
})();
