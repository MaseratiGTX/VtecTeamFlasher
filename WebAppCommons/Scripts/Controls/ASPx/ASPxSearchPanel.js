var ASPxCSPControlButtonsContainer = _aspxCreateClass(ASPxControlCollectionContainer, {

    constructor: function (searchPanel) {
        this.constructor.prototype.constructor.call(this, ASPxClientButton);
        
        this.parentSearchPanel = searchPanel;
        this.minControlWidth = null;
        this.maxControlWidth = null;

        this.adjustControlsOnExpand = false;


        this.ParentSearchPanel().Expanded.AddHandler(
            this.ParentSearchPanel_OnExpandedEventHandler.aspxBind(this)
        );
    },


    ParentSearchPanel: function() {
        return this.parentSearchPanel;
    },

    
    InitializeControl: function (control) {
        ASPxControlCollectionContainer.prototype.InitializeControl.call(this, control);

        control.UpdateWidth = _aspxEmptyFunction;
        control.UpdateHeight = _aspxEmptyFunction;

        control.SetText = this.CreateSmartFunctionWrapper(ASPxClientButton.prototype.SetText);
        control.SetImageUrl = this.CreateSmartFunctionWrapper(ASPxClientButton.prototype.SetImageUrl);

        return control;
    },

    CreateSmartFunctionWrapper: function (sourceFunction) {
        return _aspxCreateFunctionWrapper(
            function() {
                sourceFunction.apply(this, arguments);
                
                return this;
            },
            function () {
                this.UpdateWidth = ASPxClientButton.prototype.UpdateWidth;
                this.UpdateHeight = ASPxClientButton.prototype.UpdateHeight;
                
                _aspxRemoveStyleAttribute(this.GetMainElement(), "width");
            },
            function() {
                this.UpdateWidth = _aspxEmptyFunction;
                this.UpdateHeight = _aspxEmptyFunction;

                this.ControlButtonsContainer().Changed();
            }
        );
    },


    AttachCCContainerReference: function (control) {
        control.controlButtonsContainer = this;
        control.ControlButtonsContainer = function () {
            return this.controlButtonsContainer;
        }
    },


    AdjustControls: function() {
        if (this.ParentSearchPanel().IsExpanded()) {
            ASPxControlCollectionContainer.prototype.AdjustControls.call(this);
            this.adjustControlsOnExpand = false;
        } else {
            this.adjustControlsOnExpand = true;
        }
    },

    AdjustControl: function (control) {
        control.SetWidth(this.MaxControlWidth());

        ASPxControlCollectionContainer.prototype.AdjustControl.call(this, control);
    },

    ParentSearchPanel_OnExpandedEventHandler: function() {
        if (this.adjustControlsOnExpand) {
            ASPxControlCollectionContainer.prototype.AdjustControls.call(this);
            this.adjustControlsOnExpand = false;
        }
    },


    Changed: function () {
        ASPxControlCollectionContainer.prototype.Changed.call(this);

        this.minControlWidth = null;
        this.maxControlWidth = null;

        return this;
    },



    MinControlWidth: function () {
        return this.minControlWidth || (this.minControlWidth = this.FetchMinControlWidth());
    },

    FetchMinControlWidth: function () {
        if (this.IsEmpty()) return null;

        var result = this.FirstOrDefault().GetWidth();

        this.Each(1, function() {
            var controlWidth = this.GetWidth();
            
            if (controlWidth < result) result = controlWidth;
        });

        return result;
    },


    MaxControlWidth: function() {
        return this.maxControlWidth || (this.maxControlWidth = this.FetchMaxControlWidth());
    },

    FetchMaxControlWidth: function() {
        if (this.IsEmpty()) return null;

        var result = this.FirstOrDefault().GetWidth();

        this.Each(1, function() {
            var controlWidth = this.GetWidth();
            
            if (result < controlWidth) result = controlWidth;
        });

        return result;
    }
});



var __aspxRPPerformSearchButtonIDSuffix = "_RPCBPS";
var __aspxRPCancelSearchButtonIDSuffix = "_RPCBCS";

var ASPxClientSearchPanel = _aspxCreateClass(ASPxClientExpandablePanel, {
    HeaderTextValueRepository: {
        SearchUndefined: 0,
        SearchPerformed: 1,
        SearchCancelled: 2,
        Custom: 3
    },

    constructor: function(name) {
        this.constructor.prototype.constructor.call(this, name);

        this.parentGridViewID = null;
        this.parentGridView = null;

        this.headerSearchUndefined = null;
        this.headerSearchPerformed = null;
        this.headerSearchCancelled = null;

        this.editors = [];

        this.controlButtonsContainer = null;
        this.performSearchButton = null;
        this.cancelSearchButton = null;

        this.PerformSearchClick = new ASPxClientEvent();
        this.CancelSearchClick = new ASPxClientEvent();
    },


    InlineInitialize: function() {
        ASPxClientExpandablePanel.prototype.InlineInitialize.call(this);

        this.GetControlButtonsContainer()
            .AddControl(this.GetPerformSearchButton())
            .AddControl(this.GetCancelSearchButton());
    },

    AdjustControlCore: function() {
        ASPxClientExpandablePanel.prototype.AdjustControlCore.call(this);

        this.GetControlButtonsContainer().AdjustControls();
    },

    AfterInitialize: function() {
        this.InitializeParentGridView();

        ASPxClientExpandablePanel.prototype.AfterInitialize.call(this);
    },

    InitializeControls: function() {
        ASPxClientExpandablePanel.prototype.InitializeControls.call(this);
        this.editors = this.controls.Editors();
    },

    InitializeEvents: function() {
        ASPxClientExpandablePanel.prototype.InitializeEvents.call(this);

        this.GetPerformSearchButton().Click.AddHandler(this.PerformSearchButton_OnClickEventHandler.aspxBind(this));
        this.GetCancelSearchButton().Click.AddHandler(this.CancelSearchButton_OnClickEventHandler.aspxBind(this));
    },

    PerformSearchButton_OnClickEventHandler: function() {
        var eventArgs = new ASPxClientCancelEventArgs();

        this.PerformSearchClick.FireEvent(this, eventArgs);

        if (eventArgs.cancel) return;

        this.PerformSearch();
    },

    CancelSearchButton_OnClickEventHandler: function() {
        var eventArgs = new ASPxClientCancelEventArgs();

        this.CancelSearchClick.FireEvent(this, eventArgs);

        if (eventArgs.cancel) return;

        this.CancelSearch();
    },


    SetParentGridView: function(value) {
        this.FinalizeParentGridView();

        if (typeof value === "string") {
            this.parentGridViewID = value != "" ? value : null;
        } else {
            this.parentGridView = value;
        }

        this.InitializeParentGridView();

        return this;
    },

    GetParentGridView: function() {
        return this.parentGridView;
    },


    FinalizeParentGridView: function() {
        this.parentGridView = null;
        this.parentGridViewID = null;
    },

    InitializeParentGridView: function() {
        if (!this.parentGridView) {
            this.parentGridView = this.parentGridViewID ? ASPxClientControl.GetControlCollection().Get(this.parentGridViewID) : null;
        }

        if (!this.parentGridViewID) {
            this.parentGridViewID = this.parentGridView ? this.parentGridView.name : null;
        }
    },


    SetHeaderSearchUndefined: function(value) {
        this.headerSearchUndefined = value;
        return this;
    },

    GetHeaderSearchUndefined: function() {
        return this.headerSearchUndefined;
    },

    SetHeaderSearchPerformed: function(value) {
        this.headerSearchPerformed = value;
        return this;
    },

    GetHeaderSearchPerformed: function() {
        return this.headerSearchPerformed;
    },

    SetHeaderSearchCancelled: function(value) {
        this.headerSearchCancelled = value;
        return this;
    },

    GetHeaderSearchCancelled: function() {
        return this.headerSearchCancelled;
    },


    GetHeaderTextValue: function () {
        return this.GetControlState("HeaderTextValue") || this.HeaderTextValueRepository.SearchUndefined;
    },

    SetHeaderTextValue: function (value) {
        if (typeof value === "number") {
            this.SetControlState("HeaderTextValue", value);
            this.ChangeHeaderTextDisplayed(this.GetHeaderText());
        }
        return this;
    },


    GetHeaderText: function () {
        switch (this.GetHeaderTextValue()) {
            case this.HeaderTextValueRepository.SearchUndefined:
                return this.GetHeaderSearchUndefined();
            case this.HeaderTextValueRepository.SearchPerformed:
                return this.GetHeaderSearchPerformed() || this.GetHeaderSearchUndefined();
            case this.HeaderTextValueRepository.SearchCancelled:
                return this.GetHeaderSearchCancelled() || this.GetHeaderSearchUndefined();
            default:
                return ASPxClientExpandablePanel.prototype.GetHeaderText.call(this);
        }
    },

    SetHeaderText: function (text) {
        this.SetHeaderTextValue(this.HeaderTextValueRepository.Custom);
        return ASPxClientExpandablePanel.prototype.SetHeaderText.call(this, text);
    },


    Editors: function () {
        return this.editors;
    },

    
    GetControlButtonsContainer: function () {
        return this.controlButtonsContainer || (this.controlButtonsContainer = new ASPxCSPControlButtonsContainer(this));
    },

    GetPerformSearchButton: function () {
        return this.performSearchButton || (this.performSearchButton = this.GetChildControl(__aspxRPPerformSearchButtonIDSuffix));
    },

    GetCancelSearchButton: function () {
        return this.cancelSearchButton || (this.cancelSearchButton = this.GetChildControl(__aspxRPCancelSearchButtonIDSuffix));
    },


    Expand: function() {
        ASPxClientExpandablePanel.prototype.Expand.call(this);

        this.FocusFilters();
    },


    PerformSearch: function () {
        var parentGridView = this.GetParentGridView();

        if (parentGridView) {
            if (parentGridView.PerformSearch) {
                parentGridView.PerformSearch();
            } else {
                parentGridView.PerformCallback("PerformSearch");
            }
        }

        this.SetHeaderTextValue(this.HeaderTextValueRepository.SearchPerformed);
    },

    CancelSearch: function () {
        this.Editors().ClearControls();

        var parentGridView = this.GetParentGridView();

        if (parentGridView) {
            if (parentGridView.CancelSearch) {
                parentGridView.CancelSearch();
            } else {
                parentGridView.PerformCallback("CancelSearch");
            }
        }

        this.SetHeaderTextValue(this.HeaderTextValueRepository.SearchCancelled);

        this.FocusFilters();
    },

    FocusFilters: function () {
        
        if (this.IsCollapsed()) return this;

        this.Editors().Active().Focus();

        return this;
    }

});

ASPxClientSearchPanel.Cast = ASPxClientExpandablePanel.Cast;
