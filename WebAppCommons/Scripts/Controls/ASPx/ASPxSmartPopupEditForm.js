ASPxSmartPopupEditFormKbdHelper = _aspxCreateClass(ASPxSmartKbdHelper, {
    SHORTCUTS: {
        SHIFT_ESC: ASPxClientUtils.StringToShortcutCode("SHIFT+ESC"),
        CTRL_ENTER: ASPxClientUtils.StringToShortcutCode("CTRL+ENTER")
    },


    constructor: function(control) {
        this.constructor.prototype.constructor.call(this, control);
    },


    GetParentGridView: function () {
        if (this.control && this.control.GetParentGridView) {
            return this.control.GetParentGridView();
        }
        return null;
    },


    HandleGlobalKeyDown: function(e) {
        var parentGridView = this.GetParentGridView();
        if (parentGridView) {
            var shortcutCode = ASPxClientUtils.GetShortcutCodeByEvent(e);

            switch (shortcutCode) {
                case this.SHORTCUTS.SHIFT_ESC:
                    parentGridView.CancelEdit();
                    break;
                case this.SHORTCUTS.CTRL_ENTER:
                    if (parentGridView.readOnly) break;
                    document.activeElement.blur();
                    parentGridView.UpdateEdit();
                    break;
            }
        }
    }
});


ASPxClientSmartPopupEditForm = _aspxCreateClass(ASPxClientPopupControl, {
    constructor: function (name) {
        this.constructor.prototype.constructor.call(this, name);

        this.autoUpdatePosition = true;

        this.kbdHelper = null;

        this.parentGridViewID = null;
        this.parentGridView = null;
        this.parentGridViewAttached = false;

        this.controls = [];
        this.editors = [];

        this.ParentGridViewAttached = new ASPxClientEvent();
        this.ParentGridViewDetached = new ASPxClientEvent();
    },


    Initialize: function() {
        ASPxClientPopupControl.prototype.Initialize.call(this);
        this.InitializeKbdSupport();
        this.InitializeControls();
    },

    InitializeKbdSupport: function () {
        if (this.kbdHelper) return;

        this.kbdHelper = new ASPxSmartPopupEditFormKbdHelper(this);
        this.kbdHelper.Init();

        ASPxKbdHelper.RegisterAccessKey(this);
    },

    AfterInitialize: function () {
        this.InitializeParentGridView();

        ASPxClientPopupControl.prototype.AfterInitialize.call(this);
    },


    GetMainElement: function (index) {
        return this.GetWindowElement(index instanceof Number ? index : -1);
    },


    SetParentGridView: function (value) {
        this.FinalizeParentGridView();

        if (typeof value === "string") {
            this.parentGridViewID = value != "" ? value : null;
        } else {
            this.parentGridView = value;
        }

        this.InitializeParentGridView();

        return this;
    },

    GetParentGridView: function () {
        return this.parentGridView;
    },


    FinalizeParentGridView: function() {
        this.FinalizeParentGridViewState();
        this.FinalizeParentGridViewField();
    },

    InitializeParentGridView: function() {
        this.InitializeParentGridViewField();
        this.InitializeParentGridViewState();
    },


    FinalizeParentGridViewField: function () {
        this.parentGridView = null;
        this.parentGridViewID = null;
    },

    InitializeParentGridViewField: function () {
        if (!this.parentGridView) {
            this.parentGridView = this.parentGridViewID ? ASPxClientControl.GetControlCollection().Get(this.parentGridViewID) : null;
        }

        if (!this.parentGridViewID) {
            this.parentGridViewID = this.parentGridView ? this.parentGridView.name : null;
        }
    },


    FinalizeParentGridViewState: function () {
        var parentGridView = this.GetParentGridView();
        if (parentGridView && this.parentGridViewAttached) {
            this.parentGridViewAttached = false;

            this.RaiseParentGridViewDetached();

            this.ParentGridViewAttached.RemoveHandler(parentGridView.OnPopupEditForm_Attached, parentGridView);
            this.ParentGridViewDetached.RemoveHandler(parentGridView.OnPopupEditForm_Detached, parentGridView);
            this.Init.RemoveHandler(parentGridView.OnPopupEditForm_Init, parentGridView);
            this.PopUp.RemoveHandler(parentGridView.OnPopupEditForm_PopUp, parentGridView);
            this.CloseUp.RemoveHandler(parentGridView.OnPopupEditForm_CloseUp, parentGridView);
        }
    },

    InitializeParentGridViewState: function () {
        var parentGridView = this.GetParentGridView();
        if (parentGridView && this.parentGridViewAttached == false) {
            this.ParentGridViewAttached.AddHandler(parentGridView.OnPopupEditForm_Attached, parentGridView);
            this.ParentGridViewDetached.AddHandler(parentGridView.OnPopupEditForm_Detached, parentGridView);
            this.Init.AddHandler(parentGridView.OnPopupEditForm_Init, parentGridView);
            this.PopUp.AddHandler(parentGridView.OnPopupEditForm_PopUp, parentGridView);
            this.CloseUp.AddHandler(parentGridView.OnPopupEditForm_CloseUp, parentGridView);
            
            this.parentGridViewAttached = true;

            this.RaiseParentGridViewAttached();
        }
    },


    InitializeControls: function() {
        this.controls = ASPxClientControl.GetChildControls(this).RemoveInternals();
        this.editors = this.controls.Editors();
    },


    ExecuteAutoUpdatePosition: function() {
        var _this = this;
        window.setTimeout(function () {
            _this.TryAutoUpdatePosition(-1);
        }, 0);
    },


    Controls: function() {
        return this.controls;
    },

    Editors: function() {
        return this.editors;
    },


    RaisePopUp: function (index) {
        this.OnRisePopUp(index);
        ASPxClientPopupControl.prototype.RaisePopUp.call(this, index);
    },

    RaiseParentGridViewAttached: function() {
        if (!this.ParentGridViewAttached.IsEmpty()) {
            this.ParentGridViewAttached.FireEvent(this, ASPxClientEventArgs.Empty);
        }
    },

    RaiseParentGridViewDetached: function() {
        if (!this.ParentGridViewDetached.IsEmpty()) {
            this.ParentGridViewDetached.FireEvent(this, ASPxClientEventArgs.Empty);
        }
    },


    OnRisePopUp: function () {
        this.Controls().RefreshState();
        this.Editors().Active().Focus();
        this.ExecuteAutoUpdatePosition();
    }
});

ASPxClientSmartPopupEditForm.Cast = ASPxClientPopupControl.Cast;