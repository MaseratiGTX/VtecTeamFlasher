
ASPxClientControl.IsASPxClientListBox = function(control) {
    return typeof ASPxClientListBox !== "undefined" && ASPxClientListBox != null && control instanceof ASPxClientListBox;
};

ASPxClientControl.IsASPxClientCalendar = function(control) {
    return typeof ASPxClientCalendar !== "undefined" && ASPxClientCalendar != null && control instanceof ASPxClientCalendar;
};


ASPxClientControl.GetChildControls = function (parentControl) {
    var controls = aspxGetControlCollection().elements;
    
    var parentControlName = parentControl.name;

    var result = new Array();

    for (var controlName in controls) {
        var control = controls[controlName];

        if (control == null) continue;
        if (control.GetMainElement() == null) continue;

        if (!control.isASPxClientControl) continue;

        if (controlName.slice(0, parentControlName.length) != parentControlName) continue;
        if (controlName.length == parentControlName.length) continue;

        result.push(control);
    }

    return new ASPxControlCollection(result);
};


var _aspxAdjustControl = function(control) {
    if (control != null && typeof control.AdjustControl === "function") {
        control.AdjustControl();
    }
};

var _aspxRefreshControlState = function(control) {
    if (control != null && typeof control.RefreshState === "function") {
        control.RefreshState();
    }
};

var _aspxFocusControl = function(control) {
    if (control != null && typeof control.SetFocus === "function") {
        control.SetFocus();
    }
};

var _aspxClearControl = function(control) {
    if (control != null) {
        if (typeof control.ClearValue === "function") {
            control.ClearValue();
            return;
        }

        if (typeof control.SetValue === "function") {
            control.SetValue(null);
            return;
        }
    }
};


var _aspxGetVisible = function(control) {
    if (control != null && typeof control.GetVisible === "function") {
        return control.GetVisible();
    }
    return null;
};

var _aspxGetEnabled = function(control) {
    if (control != null && typeof control.GetEnabled === "function") {
        return control.GetEnabled();
    }
    return null;
};



var ASPxControlCollectionContainer = _aspxCreateClass(null, {

    constructor: function (controlType) {
        this.controlType = controlType;
        this.controls = new Array();
    },


    ControlType: function () {
        return this.controlType;
    },

    Controls: function () {
        return this.controls;
    },


    AddControl: function (control) {
        if (this.HasAppropriateType(control) == false) return this;

        this.controls.push(this.InitializeControl(control));

        return this;
    },


    AdjustControls: function () {
        var _this = this;

        return this.Each(function () {
            _this.AdjustControl(this);
        });
    },

    AdjustControl: function (control) {
        _aspxAdjustControl(control);
    },


    ClearControls: function () {
        var _this = this;

        return this.Each(function () {
            _this.ClearControl(this);
        });
    },

    ClearControl: function (control) {
        _aspxClearControl(control);
    },


    HasAppropriateType: function (control) {
        if (this.controlType) {
            return ASPxClientUtils.IsExists(this.controlType) && control instanceof this.controlType;
        }

        return true;
    },


    InitializeControl: function (control) {
        this.AttachCCContainerReference(control);

        return control;
    },

    AttachCCContainerReference: function (control) {
        control.controlCollectionContainer = this;
        control.ControlCollectionContainer = function () {
            return this.controlCollectionContainer;
        }
    },


    Changed: function () {
        return this;
    },


    IsEmpty: function () {
        return this.controls.length == 0;
    },

    IsNotEmpty: function () {
        return this.IsEmpty() == false;
    },

    FirstOrDefault: function () {
        return this.IsNotEmpty() ? this.controls[0] : null;
    },

    LastOrDefault: function () {
        return this.IsNotEmpty() ? this.controls[this.controls.length - 1] : null;
    },

    Each: function () {
        if (arguments.length == 0 || arguments.length > 3) return this;

        var beginIndex = 0;
        var endIndex = this.controls.length;

        if (arguments.length == 2) {
            beginIndex = arguments[0];
        }
        else if (arguments.length >= 3) {
            beginIndex = arguments[0];
            endIndex = Math.min(arguments[1], this.controls.length);
        }

        var sourceFunction = arguments[arguments.length - 1];

        for (var index = beginIndex; index < endIndex; index++) {
            var currentControl = this.controls[index];

            sourceFunction.call(currentControl);
        }

        return this;
    }
});


var ASPxControlCollection = function() {
    var collection = ASPxCollection.apply(null, arguments);

    ASPxControlCollection.injectClassMethods(collection);

        collection.IsASPxControlCollection = true;

    return (collection);
}

ASPxControlCollection.injectClassMethods = function (controlCollection) {
    for (var method in ASPxControlCollection.prototype) {
        if (ASPxControlCollection.prototype.hasOwnProperty(method)) {
            controlCollection[method] = ASPxControlCollection.prototype[method];
        }
    }
    return (controlCollection);
};

ASPxControlCollection.prototype = {

    CreateInstance: function () {
        return (new ASPxControlCollection());
    },


    AdjustControls: function () {
        return this.Each(function () {
            _aspxAdjustControl(this);
        });
    },

    RefreshState: function() {
        return this.Each(function() {
            _aspxRefreshControlState(this);
        });
    },

    Focus: function () {
        _aspxFocusControl(this.First());
        return (this);
    },

    ClearControls: function () {
        return this.Each(function () {
            _aspxClearControl(this);
        });
    },


    RemoveInternals: function() {
        return this.Evict(function () {
            if (ASPxClientControl.IsASPxClientListBox(this)) { 
                return this.isComboBoxList ? true : false;
            }

            if (ASPxClientControl.IsASPxClientCalendar(this)) {
                return this.isDateEditCalendar ? true : false;
            }
            
            return false;
        });
    },
    
    Editors: function() {
        return this.Select(function() {
            return this.isASPxClientEdit ? true : false;
        }); 
    },

    Visible: function() {
        return this.Select(function() {
            return _aspxGetVisible(this);;
        }); 
    },

    Enabled: function() {
        return this.Select(function() {
            return _aspxGetEnabled(this);;
        }); 
    },

    Active: function() {
        return this.Select(function() {
            return _aspxGetVisible(this) && _aspxGetEnabled(this);
        }); 
    }
}