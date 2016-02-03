var __aspxRPHeaderElementIDSuffix = "_RPH";
var __aspxRPHeaderECButtonIDSuffix = "_RPHECB";
var __aspxRPCStateControlIDSuffix = "_RPCSC";

var ASPxClientExpandablePanel = _aspxCreateClass(ASPxClientRoundPanel, {

    constructor: function (name) {
        this.constructor.prototype.constructor.call(this, name);
        
        this.headerElement = null;
        this.headerECButton = null;
        this.CStateElement = null;

        this.controlStateObject = null;

        this.controls = [];

        this.HeaderClick = new ASPxClientEvent();
        this.Expanded = new ASPxClientEvent();
        this.Collapsed = new ASPxClientEvent();
    },


    GetChildControl: function (idPostfix) {
        return aspxGetControlCollection().Get(this.name + idPostfix);
    },


    GetGroupBoxCaptionElement: undefined,

    RemoveGroupBoxCaptionElement: undefined,
    
    RestoreGroupBoxCaptionElement: undefined,

    InlineInitialize: function () {
        ASPxClientRoundPanel.prototype.InlineInitialize.call(this);

        this.InitializeControls();
        this.InitializeEvents();

        this.ChangeHeaderTextDisplayed(this.GetHeaderText());
        this.Toggle(this.IsExpanded());
        
        this.UpdateHeaderECButtonState();
    },

    AdjustControlCore: function () {
        ASPxClientRoundPanel.prototype.AdjustControlCore.call(this);

        //We have to use jQuery - there is no other simple way to detect actual width of the "hidden" content element:
        var $dxrpHeader = $(this.GetHeaderElement());
        var $dxrpContent = $(this.GetContentElement());

        var difference = $dxrpContent.outerWidth(true) - $dxrpHeader.outerWidth(true);

        if (difference > 0) {
            $dxrpHeader.width($dxrpHeader.width() + difference);
        }
    },

    InitializeControls: function() {
        this.controls = ASPxClientControl.GetChildControls(this).RemoveInternals();
    },

    InitializeEvents: function () {
        _aspxAttachEventToElement(this.GetHeaderElement(), "click", this.HeaderElement_OnClickEventHandler.aspxBind(this));
    },

    HeaderElement_OnClickEventHandler: function (evt) {
        if (evt.ctrlKey == true || evt.shiftKey == true || evt.altKey == true) return;

        
        var eventArgs = new ASPxClientCancelEventArgs();

        this.HeaderClick.FireEvent(this, eventArgs);

        if (eventArgs.cancel) return;


        this.Toggle();
    },


    Controls: function() {
        return this.controls;
    },


    GetHeaderElement: function() {
        return this.headerElement || (this.headerElement = this.GetChild(__aspxRPHeaderElementIDSuffix));
    },

    GetHeaderECButton: function () {
        return this.headerECButton || (this.headerECButton = this.GetChildControl(__aspxRPHeaderECButtonIDSuffix));
    },

    
    GetCStateElement: function () {
        return this.CStateElement || (this.CStateElement = this.GetChild(__aspxRPCStateControlIDSuffix));
    },

    GetControlStateObject: function() {
        return this.controlStateObject || (this.controlStateObject = _aspxParseJSON(this.GetCStateElement().value));
    },

    SaveControlStateObject: function() {
        this.GetCStateElement().value = _aspxToJson(this.controlStateObject);
    },

    GetControlState: function(key) { 
        return this.GetControlStateObject()[key];
    },

    SetControlState: function (key, value) {
        this.GetControlStateObject()[key] = value;
        this.SaveControlStateObject();
    },


    GetECStateValue: function () {
        return this.GetControlState("Expanded") || false;
    },

    SetECStateValue: function (value) {
        if (typeof value === "boolean") {
            this.SetControlState("Expanded", value); 
        }
        return this;
    },

    GetHTStateValue: function () {
        return this.GetControlState("HeaderText") || "";
    },

    SetHTStateValue: function (value) {
        if (typeof value === "string") {
            this.SetControlState("HeaderText", value); 
        }
        return this;
    },


    IsExpanded: function () {
        return this.GetECStateValue();
    },

    IsCollapsed: function () {
        return this.IsExpanded() == false;
    },

    Expand: function () {
        _aspxSetElementDisplay(this.GetContentElement(), true);
        
        this.SetECStateValue(true);

        this.AdjustControlCore();

        this.UpdateHeaderECButtonState();

        this.Expanded.FireEvent(this, ASPxClientEventArgs.Empty);

        return this;
    },

    Collapse: function () {
        _aspxSetElementDisplay(this.GetContentElement(), false);

        this.SetECStateValue(false);

        this.AdjustControlCore();

        this.UpdateHeaderECButtonState();

        this.Collapsed.FireEvent(this, ASPxClientEventArgs.Empty);

        return this;
    },

    Toggle: function(expandOrCollapse) {
        var expandOrCollapseActualState = typeof expandOrCollapse === "boolean" ? expandOrCollapse : !this.IsExpanded();
        
        return expandOrCollapseActualState ? this.Expand() : this.Collapse();
    },


    GetHeaderText: function () {
        return this.GetHTStateValue();
    },

    SetHeaderText: function (text) {
        this.SetHTStateValue(text);
        this.ChangeHeaderTextDisplayed(text);
    },


    ChangeHeaderTextDisplayed: function (text) {
        ASPxClientRoundPanel.prototype.SetHeaderText.call(this, text);
    },


    UpdateHeaderECButtonState: function () {
        this.GetHeaderECButton().SetText(this.IsExpanded() ? '-' : '+');

        return this;
    }
});

ASPxClientExpandablePanel.Cast = ASPxClientControl.Cast;
