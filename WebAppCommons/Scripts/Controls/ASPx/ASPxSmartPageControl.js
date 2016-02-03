ASPxSmartPageControlKbdHelper = _aspxCreateClass(ASPxSmartKbdHelper, {
    SHORTCUTS: {
        ALT_PAGEUP: ASPxClientUtils.StringToShortcutCode("ALT+PAGEUP"),
        ALT_PAGEDOWN: ASPxClientUtils.StringToShortcutCode("ALT+PAGEDOWN")
    },

    constructor: function (control) {
        this.constructor.prototype.constructor.call(this, control);
    },

    HandleGlobalKeyDown: function (e) {
        if (this.control) {
            var shortcutCode = ASPxClientUtils.GetShortcutCodeByEvent(e);

            switch (shortcutCode) {
                case this.SHORTCUTS.ALT_PAGEUP:
                    this.control.MoveToPrevTab();
                    break;
                case this.SHORTCUTS.ALT_PAGEDOWN:
                    this.control.MoveToNextTab();                    
                    break;
            }
        }
    }
});


ASPxClientSmartPageControl = _aspxCreateClass(ASPxClientPageControl, {
    constructor: function (name) {
        this.constructor.prototype.constructor.call(this, name);
        
        this.kbdHelper = null;
        
        this.controls = [];
        this.editors = [];
    },


    Initialize: function () {
        ASPxClientTabControlBase.prototype.Initialize.call(this);
        this.InitializeKbdSupport();
        this.InitializeControls();
    },

    InitializeKbdSupport: function () {
        if (this.kbdHelper) return;

        this.kbdHelper = new ASPxSmartPageControlKbdHelper(this);
        this.kbdHelper.Init();

        ASPxKbdHelper.RegisterAccessKey(this);
    },

    InitializeControls: function () {
        this.controls = ASPxClientControl.GetChildControls(this).RemoveInternals();
        this.editors = this.controls.Editors();

        var _this = this; 
        this.Editors().Each(function() {
            _this.ReplaceSetFocusHandlerFor(this);
        });
    },

    ReplaceSetFocusHandlerFor: function (control) { 
        var controlTabIndex = this.GetTabIndexOf(control);

        if (controlTabIndex != null) {
            control.SetFocusInternal = control.SetFocus;

            var _this = this;
            control.SetFocus = function () {
                _this.MoveToTabIndex(controlTabIndex);
                this.SetFocusInternal.apply(this, arguments);
            };
        }
    },


    Controls: function () {
        return this.controls;
    },

    Editors: function () {
        return this.editors;
    },


    GetTabIndexOf: function (control) {
        var controlMainElement = control.GetMainElement();

        var tabCount = this.GetTabCount();

        for (var tabIndex = 0; tabIndex < tabCount; tabIndex++) {
            var actualTabContentID = this.name + this.GetContentElementID(tabIndex);

            if ($(controlMainElement).parents('#' + actualTabContentID).length != 0) {
                return tabIndex;
            }
        }

        return null;
    },


    MoveToTabName: function (tabName) {
        var tab = this.GetTabByName(tabName);

        if (tab != null) {
            this.SetActiveTab(tab);
        }
    },

    MoveToTabIndex: function (tabIndex) {
        var tabCount = this.GetTabCount();

        var currentActiveTabIndex = this.GetActiveTabIndex();
        var newActiveTabIndex = tabIndex;

        if (newActiveTabIndex < 0) {
            newActiveTabIndex = tabCount - 1;
        }

        if (newActiveTabIndex >= tabCount) {
            newActiveTabIndex = 0;
        }

        if (newActiveTabIndex != currentActiveTabIndex) {
            if (this.GetMainElement() != null) {
                this.SetActiveTabIndex(newActiveTabIndex);
            }
        }
    },

    MoveToNextTab: function () {
        this.MoveToTabIndex(this.GetActiveTabIndex() + 1);
    },

    MoveToPrevTab: function () {
        this.MoveToTabIndex(this.GetActiveTabIndex() - 1);
    }
});

ASPxClientSmartPageControl.Cast = ASPxClientPageControl.Cast;






