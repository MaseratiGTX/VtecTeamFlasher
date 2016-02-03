ASPxSmartKbdHelper = _aspxCreateClass(ASPxKbdHelper, {
    constructor: function (control) {
        this.constructor.prototype.constructor.call(this, control);
    },

    Init: function() {
        ASPxSmartKbdHelper.GlobalInit();
        ASPxSmartKbdHelper.RegisterKbdHelper(this);

        ASPxKbdHelper.prototype.Init.call(this);
    },

    HandleGlobalKeyDown: function(e) { },
    HandleGlobalKeyPress: function (e) { },
    HandleGlobalKeyUp: function (e) { }
});

ASPxSmartKbdHelper.swallowGlobalKey = false;
ASPxSmartKbdHelper._instanceRepository = null;

ASPxSmartKbdHelper.InstanceRepository = function() {
    return ASPxSmartKbdHelper._instanceRepository || (ASPxSmartKbdHelper._instanceRepository = new ASPxKbdHelperRepository());
};

ASPxSmartKbdHelper.GlobalInit = function () {
    if (ASPxSmartKbdHelper.ready) return;

    _aspxAttachEventToDocument("keydown", ASPxSmartKbdHelper.OnGlobalKeyDown);
    _aspxAttachEventToDocument("keypress", ASPxSmartKbdHelper.OnGlobalKeyPress);
    _aspxAttachEventToDocument("keyup", ASPxSmartKbdHelper.OnGlobalKeyUp);

    ASPxSmartKbdHelper.ready = true;
};

ASPxSmartKbdHelper.RegisterKbdHelper = function (kbdHelper) {
    ASPxSmartKbdHelper.InstanceRepository().AddItem(kbdHelper);
};

ASPxSmartKbdHelper.ProcessGlobalKey = function (e, actionName) {
    var instanceRepository = ASPxSmartKbdHelper.InstanceRepository().Actualize();

    if (instanceRepository.IsEmpty()) return;

    if (!ASPxSmartKbdHelper.swallowGlobalKey) 
        ASPxSmartKbdHelper.swallowGlobalKey = instanceRepository.Handle(e, actionName);
    if (ASPxSmartKbdHelper.swallowGlobalKey)
        _aspxPreventEvent(e);
};

ASPxSmartKbdHelper.OnGlobalKeyDown = function (e) {
    ASPxSmartKbdHelper.swallowGlobalKey = false;
    ASPxSmartKbdHelper.ProcessGlobalKey(e, "HandleGlobalKeyDown");
};

ASPxSmartKbdHelper.OnGlobalKeyPress = function (e) {
    ASPxSmartKbdHelper.ProcessGlobalKey(e, "HandleGlobalKeyPress");
};

ASPxSmartKbdHelper.OnGlobalKeyUp = function (e) {
    ASPxSmartKbdHelper.ProcessGlobalKey(e, "HandleGlobalKeyUp");
};


function _aspxIsControlAlive(control) {
    if (!_aspxIsExists(control)) return false;
    
    var controlIsNotExist = control !== aspxGetControlCollection().Get(control.name);
    var controlIsTerminated = control.GetMainElement() == null;

    return (controlIsNotExist || controlIsTerminated);
};


var ASPxKbdHelperRepository = function() {
    var collection = ASPxCollection.apply(null, arguments);

    ASPxKbdHelperRepository.injectClassMethods(collection);

        collection.IsASPxKbdHelperRepository = true;

    return (collection);
}

ASPxKbdHelperRepository.injectClassMethods = function (controlCollection) {
    for (var method in ASPxKbdHelperRepository.prototype) {
        if (ASPxKbdHelperRepository.prototype.hasOwnProperty(method)) {
            controlCollection[method] = ASPxKbdHelperRepository.prototype[method];
        }
    }
    return (controlCollection);
};

ASPxKbdHelperRepository.prototype = {
    
    CreateInstance: function () {
        return (new ASPxKbdHelperRepository());
    },

    
    AddItem: function(item) {
        if (item && item instanceof ASPxSmartKbdHelper) {
            ASPxCollection.prototype.AddItem.call(this, item);
        }
        return (this);
    },


    Actualize: function() {
        return this.RemoveRange(
            this.Select(function () {
                return _aspxIsControlAlive(this.control);
            })
        );
    },


    Handle: function (e, actionName) {
        var result = false;
        this.Each(function () {
            var handlerExecutionResult = this[actionName](e);
            result = result || handlerExecutionResult;
        });
        return (result);
    }
};

