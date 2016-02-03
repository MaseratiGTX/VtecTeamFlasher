ASPxClientGridViewVisibleColumn = _aspxCreateClass(ASPxClientGridViewColumn, {
    constructor: function (column, visibleIndex) {
        this.actualColumn = column;

        this.constructor.prototype.constructor.call(
            this,
            column.name,
            column.index,
            column.parentIndex,
            column.fieldName,
            column.visible,
            column.filterRowTypeKind,
            column.showFilterMenuLikeItem,
            column.allowGroup,
            column.allowSort,
            column.allowDrag,
            column.HFCheckedList,
            column.inCustWindow,
            column.minWidth
        );

        this.visibleIndex = visibleIndex;
    }
});


ASPxClientSmartGridViewErrorHelper = _aspxCreateClass(null, {
    constructor: function (parentGridView) {
        this.parentGridView = parentGridView;
    },


    ParentGridView: function() {
        return this.parentGridView;
    },

    ErrorDescriptors: function () {
        return this.ParentGridView().ErrorDescriptors;
    },

    UniqueID: function() {
        return this.ParentGridView().uniqueID;
    },


    Interpritate: function(errorMessage, errorData) {
        return this.TryToRecoverErrorObject(errorMessage, errorData)
               || this.TryToInterpritateErrorObject(errorMessage, errorData) 
               || this.CreateCommonErrorObject(errorMessage, errorData);
    },

    TryToRecoverErrorObject: function (errorMessage, errorData) {
        var errorObject = _aspxParseJSON(errorMessage);

        if (errorObject != null && errorObject.Descriptor) {

            var descriptor = errorObject.Descriptor;

            delete errorObject.Descriptor;

            var errorDescriptors = this.ErrorDescriptors();

            switch (descriptor) {
                case errorDescriptors.SOURCE_ELEMENT_VALIDATION_ERROR:
                    errorObject.Type = "SOURCE_ELEMENT_VALIDATION_ERROR";
                    break;
                case errorDescriptors.SOURCE_ELEMENT_NOT_FOUND_ERROR:
                    errorObject.Type = "SOURCE_ELEMENT_NOT_FOUND_ERROR";
                    break;
            }
            
            errorObject.Data = errorData;
            
            return errorObject;
        }

        return null;
    },

    TryToInterpritateErrorObject: function (errorMessage, errorData) {
        var errorMessageNormalized = this.Normalize(errorMessage);
        var errorMessagePattern = this.ToPatternView(errorMessageNormalized, this.UniqueID());

        var errorType = null;
        
        switch (errorMessagePattern) {
            //TODO: Найти более эффективный способ определения CALLBACK_TARGET_NOT_FOUND_ERROR - .NET занимается локализацией текста ошибки
            case "The target '{0}' for the callback could not be found or did not implement ICallbackEventHandler.":
            case "Не удалось найти назначение '{0}' для обратного вызова или не был реализован ICallbackEventHandler.": 
                errorType = "CALLBACK_TARGET_NOT_FOUND_ERROR";
                break;
        }

        if (errorType != null) {
            var result = new Object();
                result.Type = errorType;
                result.Message = errorMessageNormalized;
                result.Data = errorData;

            return result;
        }

        return null;
    },

    CreateCommonErrorObject: function (errorMessage, errorData) {
        var result = new Object();
            result.Type = "COMMON_CALLBACK_ERROR";
            result.Message = errorMessage;
            result.Data = errorData;
        
        return result;
    },


    Normalize: function (source) {
        return _aspxReplaceAll(source, "&#39;", "'");
    },

    ToPatternView: function () {
        if (arguments.length == 0) return null;

        var result = arguments[0];

        for (var index = 1; index < arguments.length; index++) {
            result = _aspxReplaceAll(result, arguments[index], "{" + (index - 1) + "}");
        }

        return result;
    }
});


ASPxClientSmartGridView = _aspxCreateClass(ASPxClientGridView, {
    SBSRSummaryControlIDSuffix: "_SBSRS",

    ErrorDescriptors: {
        SOURCE_ELEMENT_VALIDATION_ERROR: "SOURCE_ELEMENT_VALIDATION_ERROR_OBJECT",
        SOURCE_ELEMENT_NOT_FOUND_ERROR: "SOURCE_ELEMENT_NOT_FOUND_ERROR_OBJECT"
    },

    constructor: function(name) {
        this.constructor.prototype.constructor.call(this, name);

        this.visibleColumns = [];

        this.readOnly = false;

        this.isSearchPerformed = null;
        this.confirmEditFormWindowUnload = "";
        this.sourceElementNotFound = "";
        this.callbackTargetNotFound = "";
        this.boundOnBeforeUnload = false;

        this.CommandId.PerformSearch = "PERFORMSEARCH";
        this.CommandId.CancelSearch = "CANCELSEARCH";

        this.editFormPopUpActionsRepository = null;
        this.editFormCloseUpActionsRepository = null;
        this.errorHelper = null;

        this.EditFormAttached = new ASPxClientEvent();
        this.EditFormDetached = new ASPxClientEvent();
        this.EditFormInit = new ASPxClientEvent();
        this.EditFormPopUp = new ASPxClientEvent();
        this.EditFormCloseUp = new ASPxClientEvent();

        this.ValidationError = new ASPxClientEvent();
        this.SourceElementNotFound = new ASPxClientEvent();
        this.CallbackTargetNotFound = new ASPxClientEvent();
        this.CommonCallbackError = new ASPxClientEvent();

        this.SRSummaryControl = null;
    },


    GetChildControl: function (idPostfix) {
        return aspxGetControlCollection().Get(this.name + idPostfix);
    },


    GetEditFormPopUpActionsRepository: function() {
        return this.editFormPopUpActionsRepository || (this.editFormPopUpActionsRepository = new ASPxActionsRepository());
    },

    GetEditFormCloseUpActionsRepository: function () {
        return this.editFormCloseUpActionsRepository || (this.editFormCloseUpActionsRepository = new ASPxActionsRepository());
    },

    GetErrorHelper: function() {
        return this.errorHelper || (this.errorHelper = new ASPxClientSmartGridViewErrorHelper(this));
    },


    GetSRSummaryControl: function() {
        return this.SRSummaryControl || (this.SRSummaryControl = this.GetChildControl(this.SBSRSummaryControlIDSuffix));
    },


    FindElementColumn: function(element) {
        //We have to use jQuery - there is no other simple way to detect actual parent row of the element:
        var $element = $(element);

        var elementColumn = $element.is("td.dxgv") ? $element : $element.parents("td.dxgv:first");
        if (elementColumn.length == 0) return null;

        var elementRow = elementColumn.parents("tr:first");
        if (elementRow.length == 0) return null;
        
        if (this._isGroupRow(elementRow[0])) return null;

        var columnVisibleIndex = elementRow.children("td:not('.dxgvIndentCell'):not('.dxgvDetailButton')").index(elementColumn);
        if (columnVisibleIndex == -1) return null;

        var visibleColumn = this.GetVisibleColumn(columnVisibleIndex);
        if (visibleColumn == null) return null;

        return visibleColumn.actualColumn;
    },


    getColumnByHtmlEvent: function (evt) {
        return this.FindElementColumn(evt.target || evt.srcElement);
    },

    getRowIndex: function (argument) {
        return ASPxClientGridView.prototype.getRowIndex.call(this,
            typeof argument.id !== "undefined" ? argument.id : argument
        );
    },

    getColumnIndex: function (argument) {
        if (argument == null) return -1;
        if (typeof argument.index !== "undefined") return argument.index;
        
        return ASPxClientGridView.prototype.getColumnIndex.call(this, argument);
    },


    mainTableDblClick: function (evt) {
        var row = this.getRowByHtmlEvent(evt);

        if (row) {
            var column = this.getColumnByHtmlEvent(evt);
            
            this.RaiseRowDblClick(row, column, evt);
        }
    },


    RaiseRowDblClick: function (row, column, htmlEvent) {
        if (!this.RowDblClick.IsEmpty()) {
            _aspxClearSelection();

            var args = new ASPxSmartClientGridViewRowClickEventArgs(
                this.getRowIndex(row),
                this.getColumnIndex(column),
                htmlEvent
            );
            
            this.RowDblClick.FireEvent(this, args);
            
            return args.cancel;
        }
        return false;
    },


    ScheduleUserCommand: function (args, postponed, e) {
        if (!args || args.length == 0) return;
        
        var commandName = args[0];
        var rowCommands = ["CustomButton", "Select", "AddNew", "StartEdit", "Delete", "ExpandAll", "CollapseAll"];
        
        if ((this.useEndlessPaging || this.allowBatchEditing) && _aspxArrayIndexOf(rowCommands, commandName) > -1)
            args[args.length - 1] = this.FindParentRowVisibleIndex(_aspxGetEventSource(e), true);
        
        this.ScheduleCommand(args, postponed);
    },

    UA_StartEdit: function (visibleIndex) {
        this.StartEditRow(visibleIndex, true);
    },

    UA_AddNew: function (visibleIndex) {
        this.AddNewRow(visibleIndex, true);
    },

    UA_Delete: function (visibleIndex) {
        this.DeleteGridRow(visibleIndex, true);
    },

    UA_ExpandAll: function () {
        this.ExpandAll();
    },

    UA_CollapseAll: function () {
        this.CollapseAll();
    },


    GetColumnFieldName: function(index) {
        var column = this.GetColumn(index);
        return column ? column.fieldName : null;
    },


    GetVisibleColumnsCount: function () {
        return this.visibleColumns.length;
    },

    GetVisibleColumn: function (columnVisibleIndex) {
        if (columnVisibleIndex < 0 || columnVisibleIndex >= this.visibleColumns.length) return null;
        return this.visibleColumns[columnVisibleIndex];
    },


    GetEditors: function() {
        return new ASPxControlCollection(
            this._getEditors()
        );
    },

    FocusEditors: function() {
        this.GetEditors().Focus();
    },


    GetEditorValueString: function(editor) {
        return editor.GetEditorValueString ? editor.GetEditorValueString() : editor.GetValueString();
    },

    GetEditorValue: function (editor) {
        var value = this.GetEditorValueString(editor);
        
        var valueLength = -1;
        if (!_aspxIsExists(value)) {
            value = "";
        } else {
            value = value.toString();
            valueLength = value.length;
        }

        return this.GetEditorIndex(editor.name) + "," + valueLength + "," + value + ";";
    },


    IsSearchPerformed: function() {
        return this.isSearchPerformed;
    },

    PerformSearch: function () {
        this.gridCallBack([this.CommandId.PerformSearch]);
    },

    CancelSearch: function () {
        this.gridCallBack([this.CommandId.CancelSearch]);
    },


    IsDetailRow: function(visibleIndex) {
        return this.hasDetailRows && this.IsDataRow(visibleIndex);
    },

    IsDetailRowExpanded: function(visibleIndex) {
        return this.GetDetailRow(visibleIndex) != null;
    },


    AddNewRow: function (visibleIndex, eventMarker) {
        if (this.readOnly) return;
        this.gridCallBack([this.CommandId.AddNewRow, visibleIndex || "undefined", eventMarker || false]);
    },
    
    StartEditRow: function (visibleIndex, eventMarker) {
        var key = this.GetRowKey(visibleIndex);
        
        if (key != null) {
            this.StartEditRowByKey(key, eventMarker);
        }
    },

    StartEditRowByKey: function (key, eventMarker) {
        this.gridCallBack([this.CommandId.StartEdit, key, eventMarker || false]);
    },

    DeleteGridRow: function (visibleIndex, eventMarker) {
        if (this.readOnly) return;
        
        if (this.confirmDelete != "" && !confirm(this.confirmDelete)) return;
        
        this.DeleteRow(visibleIndex, eventMarker);
    },

    DeleteRow: function (visibleIndex, eventMarker) {
        if (this.readOnly) return;
        
        var key = this.GetRowKey(visibleIndex);
        
        if (key != null) {
            this.DeleteRowByKey(key, eventMarker || false);
        }
    },

    UpdateEdit: function () {
        if (this.readOnly) return;

        ASPxClientGridView.prototype.UpdateEdit.call(this);
    },


    ExecuteOnEditFormPopUp: function(action) {
        this.GetEditFormPopUpActionsRepository().AddItem(action);
    },

    ExecuteOnEditFormCloseUp: function(action) {
        this.GetEditFormCloseUpActionsRepository().AddItem(action);
    },


    OnEditFormPopUp: function() {
        this.InitializeEditFormWindowUnloadHandlers();

        this.FocusEditors();
        
        this.GetEditFormPopUpActionsRepository().Execute(this);
    },

    OnEditFormCloseUp: function() {
        this.FinalizeEditFormWindowUnloadHandlers();

        this.GetEditFormCloseUpActionsRepository().Execute(this);
    },


    OnCallbackGeneralError: function (errorMessage) {
        this.OnCallbackError(errorMessage, null);
        this.OnCallbackFinalized();
    },

    OnCallbackError: function (result, data) {
        var errorObject = this.GetErrorHelper().Interpritate(result, data);

        switch(errorObject.Type) {
            case "SOURCE_ELEMENT_VALIDATION_ERROR":
                this.RaiseValidationError(errorObject);
                break;
            case "SOURCE_ELEMENT_NOT_FOUND_ERROR":
                this.RaiseSourceElementNotFound(errorObject);
                break;
            case "CALLBACK_TARGET_NOT_FOUND_ERROR":
                this.RaiseCallbackTargetNotFound(errorObject);
                break;
            default:
                this.RaiseCommonCallbackError(errorObject);
                break;
        }

        if (this.GetGridTD())
            this.afterCallbackRequired = true;
    },

    OnValidationError: function(errorObject) {
        if (errorObject.FieldName) {
            this.ExecuteOnEditFormPopUp(function () {
                this.FocusEditor(errorObject.FieldName);
            });
        }
        
        this.showingError = errorObject.Message;
        this.data = errorObject.Data;
    },

    OnSourceElementNotFound: function (errorObject) {
        this.CancelEdit();


        var errorMessage = null;

        if (this.sourceElementNotFound != "") {
            errorMessage = this.sourceElementNotFound;
        } else if (errorObject.Message && errorObject.Message != "") {
            errorMessage = errorObject.Message;
        }

        if (errorMessage) {
            window.setTimeout(function () {
                alert(errorMessage);
            }, 0);
        }
    },

    OnCallbackTargetNotFound: function (errorObject) {

        var confirmMessage = null;

        if (this.callbackTargetNotFound != "") {
            confirmMessage = this.callbackTargetNotFound;
        } else if (errorObject.Message && errorObject.Message != "") {
            confirmMessage = errorObject.Message;
        }

        if (confirmMessage) {
            if (confirm(confirmMessage)) {
                this.Refresh();
            }
        }
    },

    OnCommonCallbackError: function (errorObject) {
        this.showingError = errorObject.Message;
        this.data = errorObject.Data;
    },


    OnPopupEditForm_Attached: function (s, e) {
        this.RaiseEditFormAttached(s, e);
    },

    OnPopupEditForm_Detached: function (s, e) {
        this.RaiseEditFormDetached(s, e);
    },
    
    OnPopupEditForm_Init: function(s, e) {
        this.RaiseEditFormInit(s, e);
    },

    OnPopupEditForm_PopUp: function (s, e) {
        this.RaiseEditFormPopUp(s, e);
    },

    OnPopupEditForm_CloseUp: function (s, e) {
        this.RaiseEditFormCloseUp(s, e);
    },


    RaiseEditFormAttached: function (sourceEditForm, sourceEventArgs) {
        if (!this.EditFormAttached.IsEmpty()) {
            this.EditFormAttached.FireEvent(
                this, new ASPxSmartClientGridViewEditFormEventArgs(sourceEditForm, sourceEventArgs)
            );
        }
    },

    RaiseEditFormDetached: function (sourceEditForm, sourceEventArgs) {
        if (!this.EditFormDetached.IsEmpty()) {
            this.EditFormDetached.FireEvent(
                this, new ASPxSmartClientGridViewEditFormEventArgs(sourceEditForm, sourceEventArgs)
            );
        }
    },
    
    RaiseEditFormInit: function (sourceEditForm, sourceEventArgs) {
        if (!this.EditFormInit.IsEmpty()) {
            this.EditFormInit.FireEvent(
                this, new ASPxSmartClientGridViewEditFormEventArgs(sourceEditForm, sourceEventArgs)
            );
        }
    },

    RaiseEditFormPopUp: function (sourceEditForm, sourceEventArgs) {
        this.OnEditFormPopUp(sourceEditForm, sourceEventArgs);
        
        if (!this.EditFormPopUp.IsEmpty()) {
            this.EditFormPopUp.FireEvent(
                this, new ASPxSmartClientGridViewEditFormEventArgs(sourceEditForm, sourceEventArgs)
            ); 
        }
    },

    RaiseEditFormCloseUp: function (sourceEditForm, sourceEventArgs) {
        this.OnEditFormCloseUp(sourceEditForm, sourceEventArgs);

        if (!this.EditFormCloseUp.IsEmpty()) {
            this.EditFormCloseUp.FireEvent(
                this, new ASPxSmartClientGridViewEditFormEventArgs(sourceEditForm, sourceEventArgs)
            );
        }
    },


    RaiseValidationError: function (errorObject) {
        var handled = false;
        
        if (!this.ValidationError.IsEmpty()) {
            var e = new ASPxSmartClientGridViewCallbackErrorEventArgs(errorObject);
            
            this.ValidationError.FireEvent(this, e);
            
            handled = e.handled;
        }

        if (!handled) {
            this.OnValidationError(errorObject);
        }
    },

    RaiseSourceElementNotFound: function (errorObject) {
        var handled = false;

        if (!this.SourceElementNotFound.IsEmpty()) {
            var e = new ASPxSmartClientGridViewCallbackErrorEventArgs(errorObject);

            this.SourceElementNotFound.FireEvent(this, e);

            handled = e.handled;
        }

        if (!handled) {
            this.OnSourceElementNotFound(errorObject);
        }
    },

    RaiseCallbackTargetNotFound: function (errorObject) {
        var handled = false;

        if (!this.CallbackTargetNotFound.IsEmpty()) {
            var e = new ASPxSmartClientGridViewCallbackErrorEventArgs(errorObject);

            this.CallbackTargetNotFound.FireEvent(this, e);

            handled = e.handled;
        }

        if (!handled) {
            this.OnCallbackTargetNotFound(errorObject);
        }
    },

    RaiseCommonCallbackError: function (errorObject) {
        var handled = false;

        if (!this.CommonCallbackError.IsEmpty()) {
            var e = new ASPxSmartClientGridViewCallbackErrorEventArgs(errorObject);

            this.CommonCallbackError.FireEvent(this, e);

            handled = e.handled;
        }

        if (!handled) {
            this.OnCommonCallbackError(errorObject);
        }
    },


    InitializeEditFormWindowUnloadHandlers: function () {
        if (this.boundOnBeforeUnload) return;

        if (this.readOnly) return;
        
        if (this.confirmEditFormWindowUnload != "") {
            ASPxWindowHelper.BindOnBeforeUnload(this.confirmEditFormWindowUnload);
            this.boundOnBeforeUnload = true;
        }
    },

    FinalizeEditFormWindowUnloadHandlers: function () {
        if (this.boundOnBeforeUnload) {
            ASPxWindowHelper.UnBindOnBeforeUnload();
            this.boundOnBeforeUnload = false;
        }
    }
});

ASPxClientSmartGridView.Cast = ASPxClientGridView.Cast;

ASPxSmartClientGridViewRowClickEventArgs = _aspxCreateClass(ASPxClientGridViewRowClickEventArgs, {
    constructor: function (rowIndex, columnIndex, htmlEvent) {
        this.constructor.prototype.constructor.call(this, rowIndex, htmlEvent);
        this.columnIndex = columnIndex;
    }
});

ASPxSmartClientGridViewEditFormEventArgs = _aspxCreateClass(ASPxClientEventArgs, {
    constructor: function (sourceEditForm, sourceEventArgs) {
        this.constructor.prototype.constructor.call(this);
        this.sourceEditForm = sourceEditForm;
        this.sourceEventArgs = sourceEventArgs;
    }
});

ASPxSmartClientGridViewCallbackErrorEventArgs = _aspxCreateClass(ASPxClientEventArgs, {
    constructor: function (errorObject) {
        this.constructor.prototype.constructor.call(this);
        this.ErrorObject = errorObject;
        this.handled = false;
    }
});


function ASPxSmartGridViewDefaults_EditDataRow_OnRowDblClick(s, e) {
    if (s.IsDataRow(e.visibleIndex)) {
        var sourceColumnFieldName = s.GetColumnFieldName(e.columnIndex);

        s.ExecuteOnEditFormPopUp(function () {
            this.FocusEditor(sourceColumnFieldName);
        });

        s.StartEditRow(e.visibleIndex);
    }
};

function ASPxSmartGridViewDefaults_ExpandCollapseGroupRow_OnRowDblClick(s, e) {
    if (s.IsGroupRow(e.visibleIndex)) {
        if (s.IsGroupRowExpanded(e.visibleIndex)) {
            s.CollapseRow(e.visibleIndex);
        } else {
            s.ExpandRow(e.visibleIndex);
        }
    }
};

function ASPxSmartGridViewDefaults_ExpandCollapseDetailRow_OnRowDblClick(s, e) {
    if (s.IsDetailRow(e.visibleIndex)) {
        if (s.IsDetailRowExpanded(e.visibleIndex)) {
            s.CollapseDetailRow(e.visibleIndex);
        } else {
            s.ExpandDetailRow(e.visibleIndex);
        }
    }
};

function ASPxSmartGridViewDefaults_ExpandCollapseRow_OnRowDblClick(s, e) {
    ASPxSmartGridViewDefaults_ExpandCollapseDetailRow_OnRowDblClick(s, e);
    ASPxSmartGridViewDefaults_ExpandCollapseGroupRow_OnRowDblClick(s, e);
}

function ASPxSmartGridViewDefaults_EditOrExpandCollapseRow_OnRowDblClick(s, e) {
    ASPxSmartGridViewDefaults_EditDataRow_OnRowDblClick(s, e);
    ASPxSmartGridViewDefaults_ExpandCollapseGroupRow_OnRowDblClick(s, e);
}