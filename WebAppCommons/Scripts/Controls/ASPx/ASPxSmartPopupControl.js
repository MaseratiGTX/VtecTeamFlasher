ASPxSmartPopupControlKbdHelper = _aspxCreateClass(ASPxSmartKbdHelper, {
    SHORTCUTS: {
        SHIFT_ESC: ASPxClientUtils.StringToShortcutCode("SHIFT+ESC")
    },

    constructor: function (control) {
        this.constructor.prototype.constructor.call(this, control);
    },

    HandleGlobalKeyDown: function (e) {
        if (this.control) {
            var shortcutCode = ASPxClientUtils.GetShortcutCodeByEvent(e);

            switch (shortcutCode) {
                case this.SHORTCUTS.SHIFT_ESC:
                    this.control.OnCloseButtonClick(-1);
                    break;
            }
        }
    }
});


ASPxClientSmartPopupControl = _aspxCreateClass(ASPxClientPopupControl, {
    constructor: function (name) {
        this.constructor.prototype.constructor.call(this, name);

        this.kbdHelper = null;

        this.controls = [];
        this.editors = [];
    },


    Initialize: function () {
        ASPxClientPopupControl.prototype.Initialize.call(this);

        this.InitializeKbdSupport();
        this.InitializeControls();
    },

    InitializeKbdSupport: function () {
        if (this.kbdHelper) return;

        this.kbdHelper = new ASPxSmartPopupControlKbdHelper(this);
        this.kbdHelper.Init();

        ASPxKbdHelper.RegisterAccessKey(this);
    },

    InitializeControls: function () {
        this.controls = ASPxClientControl.GetChildControls(this).RemoveInternals();
        this.editors = this.controls.Editors();
    },


    GetMainElement: function (index) {
        return this.GetWindowElement(index instanceof Number ? index : -1);
    },
    

    Controls: function () {
        return this.controls;
    },

    Editors: function () {
        return this.editors;
    }
});

ASPxClientSmartPopupControl.Cast = ASPxClientPopupControl.Cast;