ASPxElementHelper = new Object();

ASPxElementHelper.IsDisabled = function(element) {
    return $(element).hasClass("dxeDisabled");
};

ASPxElementHelper.IsEnabled = function(element) {
    return ASPxElementHelper.IsDisabled(element) == false;
};




ASPxControlBaseTemplates = new Object();

ASPxControlBaseTemplates.InitHandler_SelectAllOnFocus = function(source) {
    $(source.GetInputElement()).focus(
        function() { this.select(); }
    );
};



ASPxTextBoxTemplates = new Object();

ASPxTextBoxTemplates.SetInputMask = function(value) {
    var source = this;

    source.InputMask = value;

    return source;
};

ASPxTextBoxTemplates.GetInputMask = function() {
    var source = this;

    return source.InputMask;
};


ASPxTextBoxTemplates.SetInputCase = function(value) {
    var source = this;

    source.InputCase = value;

    return source;
};

ASPxTextBoxTemplates.GetInputCase = function () {
    var source = this;

    return source.InputCase;
};


ASPxTextBoxTemplates.SetIgnoredKeys = function (value) {
    var source = this;

    source.IgnoredKeys = value;

    return source;
};

ASPxTextBoxTemplates.GetIgnoredKeys = function () {
    var source = this;

    return source.IgnoredKeys;
};


ASPxTextBoxTemplates.GetCaretPosition = function() {
    var source = this;

    return _aspxGetSelectionInfo(source.GetInputElement()).startPos;
};


ASPxTextBoxTemplates.ShouldIgnoreEvent = function(htmlEvent) {
    var source = this;

    if (htmlEvent.ctrlKey || htmlEvent.altKey) return true;

    var ignoredKeys = source.GetIgnoredKeys();
    if (ignoredKeys) {
        return ignoredKeys.indexOf(_aspxGetKeyCode(htmlEvent)) != -1;
    }

    return false;
};


ASPxTextBoxTemplates.TransformValue = function(transformationFunction) {
    var source = this;

    if (typeof transformationFunction !== "function") return this;

    var currentValue = source.GetValue();

    if (currentValue != null) {
        
        var currentCarretPosition = source.GetCaretPosition();
        var reversedCarretPosition = currentValue.length - currentCarretPosition;

        var updatedPart = currentValue.substring(0, currentCarretPosition);
        var otherPart = currentValue.substring(currentCarretPosition, currentValue.length);
        
        var possibleNewValue = transformationFunction(updatedPart) + otherPart;
        var newValue = transformationFunction(possibleNewValue);

        source.SetValue(newValue);

        var newCurrentValue = source.GetValue();

        var newCurrentValueLength = newCurrentValue != null ? newCurrentValue.length : 0;

        source.SetCaretPosition(
            possibleNewValue == newValue ? newCurrentValueLength - reversedCarretPosition : currentCarretPosition
        );
    }

    return this;
};


ASPxTextBoxTemplates.TransformValueAccordingToInputMask = function() {
    var source = this;;
    
    var inputMask = source.GetInputMask();
    if (inputMask) {
        source.TransformValue(function(value) {
            var result = "";

            var match = value.match(inputMask);

            if (match != null) {
                for (var index = 0; index < match.length; index++) {
                    result += match[index];
                }
            }

            return result;
        });
    }
}

ASPxTextBoxTemplates.TransformValueAccordingToInputCase = function () {
    var source = this;
    
    var inputCase = source.GetInputCase();
    if (inputCase) {
        switch (inputCase) {
            case ASPxTBInputCase.UPPER_CASE:
                source.TransformValue(function(value) { return value.toUpperCase(); });
                break;
            case ASPxTBInputCase.LOWER_CASE:
                source.TransformValue(function (value) { return value.toLowerCase(); });
                break;
        }
    }
}

ASPxTextBoxTemplates.SmartKeyUpHandler = function (s, e) {
    this.ActualHandlerFunction(s, e);

    if (s.ShouldIgnoreEvent(e.htmlEvent) == false) {
        s.TransformValueAccordingToInputMask();
        s.TransformValueAccordingToInputCase();
    }
}

ASPxTextBoxTemplates.SmartValueChangedHandler = function (s, e) {
    this.ActualHandlerFunction(s, e);

    s.TransformValueAccordingToInputMask();
    s.TransformValueAccordingToInputCase();
}



ASPxDateEditTemplates = new Object();

ASPxDateEditTemplates.SmartButtonClickHandler = function(s, e) {
    var prevSenderValue = s.GetValue();

    this.ActualHandlerFunction(s, e);

    var actualSenderValue = s.GetValue(); 
    
    if(actualSenderValue != prevSenderValue) {
        // ReSharper disable UseOfImplicitGlobalInFunctionScope
        s.ValueChanged.FireEvent(s, new ASPxClientProcessingModeEventArgs());
        // ReSharper restore UseOfImplicitGlobalInFunctionScope
    }
};

ASPxDateEditTemplates.InitHandler_ToggleDropDownOnClick = function(source) {
    source.ShouldCloseOnMCMouseDown = function() { return false; };
    // ReSharper disable UseOfImplicitGlobalInFunctionScope
    ASPxClientUtils.AttachEventToElement(source.GetInputElement(), 'click', function () { source.ToggleDropDown(); });
    // ReSharper restore UseOfImplicitGlobalInFunctionScope
};



ASPxSpinEditSceme = {
    Numeric: 0,
    Percent: 1
};


ASPxSpinEditTemplates = new Object();

ASPxSpinEditTemplates.RefreshState = function() {
    var source = this;

    if(source.GetInputElement() != null) {
        source.SetValue(source.GetValue());
    }
};

ASPxSpinEditTemplates.ApplyScheme = function(spinEditSceme) {
    var source = this;

    switch (spinEditSceme) {
        case ASPxSpinEditSceme.Numeric:
            source.SetMaxValue(2147483647);
            source.largeInc = 1000;
            source.displayFormat = "{0:n2}";
            break;
        case ASPxSpinEditSceme.Percent:
            source.SetMaxValue(100);
            source.largeInc = 10;
            source.displayFormat = "{0:n2}%";
            break;
    }

    source.RefreshState();
};



ASPxSpinEditTemplates.SmartGotFocusHandler = function(s, e) {    
    s.RefreshState();  

    return this.ActualHandlerFunction(s, e);
};

ASPxSpinEditTemplates.SmartLostFocusHandler = function(s, e) {    
    var actualHandlerFunction = this.ActualHandlerFunction;
    
    window.setTimeout(
        function () {
            s.RefreshState();
            actualHandlerFunction(s, e);
        }, 
        200
    );
};



ASPxComboBoxTemplates = new Object();

ASPxComboBoxTemplates.GetListItemElement = function(index) {
    var source = this;
    
    // ReSharper disable UseOfImplicitGlobalInFunctionScope
    if (ASPxClientUtils.webKitFamily || ASPxClientUtils.ie)
    // ReSharper restore UseOfImplicitGlobalInFunctionScope
        return source.listBox.GetItemElement(index);
    else
        return source.listBox.GetItemElement(index).firstElementChild;
};

ASPxComboBoxTemplates.PerformCustomCallback = function() {
    var source = this;
    
    source.InCustomCallback = true;
    source.PerformCallback();
};


// ReSharper disable UseOfImplicitGlobalInFunctionScope
ASPxComboBoxTemplates.InitializeButtonContext = function(index) {
    var source = this;

    var element = source.GetButton(index);
    
    if(element) {
        
        var stateController = aspxGetStateController();

        if (stateController.hoverItems[element.id] 
            || 
            stateController.pressedItems[element.id] 
            || 
            stateController.disabledItems[element.id]) {
            return;
        }

        var mainElemement = source.GetMainElement();
        
        var namePrefix = mainElemement.id;
        var elementName = StringHelper.ReplaceAll(element.id, namePrefix + "_", "");

        aspxAddHoverItems(namePrefix, [[["dxeButtonEditButtonHover"], [""], [elementName]]]);
        stateController.hoverItems[element.id].enabled = false;
        stateController.focusedItems[element.id].enabled = false;
        stateController.ClearCache(element, __aspxHoverItemKind);
        stateController.ClearCache(element, __aspxFocusedItemKind);

        aspxAddPressedItems(namePrefix, [[["dxeButtonEditButtonPressed"], [""], [elementName]]]);
        stateController.pressedItems[element.id].enabled = false;
        stateController.ClearCache(element, __aspxPressedItemKind);
        
        aspxAddDisabledItems(namePrefix, [[["dxeDisabled dxeButtonDisabled"], [""], [elementName]]]);
        
        _aspxSetAttribute(element, "onclick", "aspxBEClick('" + mainElemement.id + "', " + index + ")");
    }
};
// ReSharper restore UseOfImplicitGlobalInFunctionScope

// ReSharper disable UseOfImplicitGlobalInFunctionScope
ASPxComboBoxTemplates.SetButtonEnabledState = function(index, enabled) {
    var source = this;

    var element = source.GetButton(index);

    if (element) {
        if (ASPxElementHelper.IsEnabled(element) == enabled) return;

        aspxGetStateController().SetElementEnabled(element, enabled);
        source.ChangeButtonEnabledAttributes(element, _aspxChangeAttributesMethod(enabled));
    }
};
// ReSharper restore UseOfImplicitGlobalInFunctionScope

ASPxComboBoxTemplates.EnableButton = function(index) {
    var source = this;
    
    source.InitializeButtonContext(index);
    source.SetButtonEnabledState(index, true);
};

ASPxComboBoxTemplates.DisableButton = function(index) {
    var source = this;
    
    source.SetButtonEnabledState(index, false);
};

ASPxComboBoxTemplates.ClearValue = function() {
    var source = this;

    source.SetValue(null);
    
    if(source.isCallbackMode) {
        source.filterStrategy.ClearFilter();
        source.filterStrategy.GetListBoxControl().ClearItems();
        source.SendCallback();
    }
};

ASPxComboBoxTemplates.Simplify = function() {
    var source = this;
                            
    var inputElement = source.GetInputElement();
    var dropdownButton = source.GetButton(-1);
                            
    $(inputElement).attr('unselectable', 'on');
    $(inputElement).on('selectstart', function () { return false; });
    $(inputElement).on('focus', function () { dropdownButton.focus(); });

    $(inputElement).css({
        '-webkit-touch-callout': 'none',
        '-webkit-user-select': 'none',
        '-khtml-user-select': 'none',
        '-moz-user-select': 'none',
        '-ms-user-select': 'none',
        'user-select': 'none'
    });

    try { $.styles.insertRule(["#" + inputElement.id + "::selection"], 'background: transparent'); } catch (e) {}
    try { $.styles.insertRule(["#" + inputElement.id + "::-moz-selection"], 'background: transparent'); } catch (e) { }

    return source;
};

ASPxComboBoxTemplates.ShowDropDown_Smart = function() {
    var source = this;

    EventSimulator.Simulate(source.GetDropDownButton(), "mousedown", { button: 1 });
};

ASPxComboBoxTemplates.MarkItemsAsDisabled = function() {
    var source = this;

    if (typeof source.cpDisabledItems == "undefined") return;
    
    var items = source.cpDisabledItems;
    
    for (var i = 0; i < source.GetItemCount(); i++) {
        var itemValue = source.GetItem(i).value;

        if (items[itemValue] != null) {
            var row = source.listBox.GetItemRow(i);
                row.disabled = true;

            var rowCells = row.cells;
            for (var x = 0; x < rowCells.length; x++) {
                var cell = row.cells[x];
                    cell.style.color = "#808080";
                    cell.style.textShadow = "1px 1px #ffffff";
            }
        }
    }
}

ASPxComboBoxTemplates.SmartButtonClickHandler = function(s, e) {
    var prevSenderValue = s.GetValue();

    this.ActualHandlerFunction(s, e);

    var actualSenderValue = s.GetValue(); 
    
    if(actualSenderValue != prevSenderValue) {
        // ReSharper disable UseOfImplicitGlobalInFunctionScope
        s.ValueChanged.FireEvent(s, new ASPxClientProcessingModeEventArgs());
        // ReSharper restore UseOfImplicitGlobalInFunctionScope
    }
};

ASPxComboBoxTemplates.SmartEndCallbackHandler = function(s, e) {
    s.MarkItemsAsDisabled();
    this.ActualHandlerFunction(s, e);
};


ASPxCallbackPanelTemplates = new Object();

ASPxCallbackPanelTemplates.SmartBeginCallback = function(s, e) {
    var childControls = ASPxControlsHelper.GetChildControlsOf(s);
    
    for(var control in childControls) {
        if(typeof control.BeginCallback !== "undefined") {
            control.BeginCallback.FireEvent(control, e);
        }
    }

    return this.ActualHandlerFunction(s, e);
};

ASPxCallbackPanelTemplates.SmartEndCallback = function(s, e) {
    var childControls = ASPxControlsHelper.GetChildControlsOf(s);
    
    for(var control in childControls) {
        if(typeof control.EndCallback !== "undefined") {
            control.EndCallback.FireEvent(control, e);
        }
    }

    return this.ActualHandlerFunction(s, e);
};

ASPxCallbackPanelTemplates.SmartCallbackError = function(s, e) {
    var childControls = ASPxControlsHelper.GetChildControlsOf(s);
    
    for(var control in childControls) {
        if(typeof control.CallbackError !== "undefined") {
            control.CallbackError.FireEvent(control, e);
        }
    }

    return this.ActualHandlerFunction(s, e);
};



ASPxLoadingPanelTemplates = new Object();

ASPxLoadingPanelTemplates.ShowPanel = function() {
    var source = this;

    if (source.counter == 0) {
        source.Show();
    }
    
    source.counter++;
};

ASPxLoadingPanelTemplates.HidePanel = function() {
    var source = this;

    source.counter--;

    if (source.counter == 0 ) {
        source.Hide();
    }
};



ASPxPopupMenuTemplates = new Object();

ASPxPopupMenuTemplates.SaveContextMenuContext = function(s, e) {
    var source = this;
        source.SourceContext = s;
        source.SourceObjectType = e.objectType;
        source.SourceRowIndex = e.index;
        source.SourceHtmlEventX = ASPxClientUtils.GetEventX(e.htmlEvent);
        source.SourceHtmlEventY = ASPxClientUtils.GetEventY(e.htmlEvent);

    return source;
};


ASPxPopupMenuTemplates.SetItemTextTemplate = function (itemName, value) {
    var source = this;
    
    var item = source.GetItemByName(itemName);
    if (item) {
        item.TextTemplate = value;
    }

    return source;
};

ASPxPopupMenuTemplates.GetItemTextTemplate = function (itemName) {
    var source = this;
    
    var item = source.GetItemByName(itemName);
    if (item) {
        return typeof item.TextTemplate !== "undefined" ? item.TextTemplate : null;
    }

    return null;
};

ASPxPopupMenuTemplates.FillItemText = function (itemName) {
    var source = this;

    //TODO: проверить

    var item = source.GetItemByName(itemName);
    if (item) {
        item.SetText(
            StringHelper.Format(
                item.TextTemplate,
                Array.prototype.slice.call(arguments, 1)
            )
        );
    }

    return source;
};

ASPxPopupMenuTemplates.SetItemNavigateUrlTemplate = function (itemName, value) {
    var source = this;

    var item = source.GetItemByName(itemName);
    if (item) {
        item.NavigateUrlTemplate = value;
    }

    return source;
};

ASPxPopupMenuTemplates.GetItemNavigateUrlTemplate = function (itemName) {
    var source = this;

    var item = source.GetItemByName(itemName);
    if (item) {
        return typeof item.NavigateUrlTemplate !== "undefined" ? item.NavigateUrlTemplate : null;
    }

    return null;
};

ASPxPopupMenuTemplates.FillItemNavigateUrl = function (itemName) {
    var source = this;

    //TODO: проверить

    var item = source.GetItemByName(itemName);
    if (item) {
        item.SetNavigateUrl(
            StringHelper.Format(
                item.NavigateUrlTemplate,
                Array.prototype.slice.call(arguments, 1)
            )
        );
    }

    return source;
};


ASPxPopupMenuTemplates.OnRowValuesFetched_Internal = function (rowValues) {
    var source = this;

    if (!source.RowDataFetched.IsEmpty()) {
        var eventArgs = new ASPxClientEventArgs();
            eventArgs.RowValues = rowValues;

        source.RowDataFetched.FireEvent(this, eventArgs);
    }

    return source;
};

ASPxPopupMenuTemplates.OnRowDataFetched = function (handler) {
    var source = this;

    source.RowDataFetched.AddHandler(handler);

    return source;
};

ASPxPopupMenuTemplates.FetchSourceRowData = function (fieldNames) {
    var source = this;

    if (source.SourceContext) {
        source.SourceContext.GetRowValues(
            source.SourceRowIndex,
            fieldNames,
            function(rowValues) {
                source.OnRowValuesFetched_Internal(rowValues);
            }
        );
    }

    return source;
};


ASPxPopupMenuTemplates.ShowMenu = function() {
    var source = this;

    if (source.SourceHtmlEventX != null && source.SourceHtmlEventY != null) {
        source.ShowAtPos(source.SourceHtmlEventX, source.SourceHtmlEventY);    
    }

    return source;
};



ASPxClientEditTemplates = new Object();

ASPxClientEditTemplates.Form = function() {
    var source = this;
    
    return $(source.GetInputElement()).form();
};



EditorsCollectionHelper = new Object();

EditorsCollectionHelper.ExpandFunctionality = function(source) {
    if(ASPxControlHelper.HasExpandedFunctionality(source)) return source;
    
    source.First = EditorsCollectionTemplates.First;
    source.Last = EditorsCollectionTemplates.Last;
    source.FocusFirst = EditorsCollectionTemplates.FocusFirst;
    source.RefreshState = EditorsCollectionTemplates.RefreshState;
    source.BlockContextMenu = EditorsCollectionTemplates.BlockContextMenu;
    source.BindMouseEvent = EditorsCollectionTemplates.BindMouseEvent;
    source.OnClick = EditorsCollectionTemplates.OnClick;
    source.OnMouseUp = EditorsCollectionTemplates.OnMouseUp;
    source.OnMouseDown = EditorsCollectionTemplates.OnMouseDown;
    source.Exclude = EditorsCollectionTemplates.Exclude;
    
    source.HasExpandedFunctionality = true;

    return source;
};



ASPxTBInputCase = {
    UPPER_CASE: "UPPER_CASE",
    LOWER_CASE: "LOWER_CASE"
};

ASPxTextBoxHelper = new Object();

ASPxTextBoxHelper.RefreshHandlersReplacement = function(source) {
    EventHelper.ReplaceHandlers(source.KeyUp).With(ASPxTextBoxTemplates.SmartKeyUpHandler);
    EventHelper.ReplaceHandlers(source.ValueChanged).With(ASPxTextBoxTemplates.SmartValueChangedHandler);
};

ASPxTextBoxHelper.ExpandFunctionality = function(source) {
    if(ASPxControlHelper.HasExpandedFunctionality(source)) return source;

    source.InputMask = null;
    source.SetInputMask = ASPxTextBoxTemplates.SetInputMask;
    source.GetInputMask = ASPxTextBoxTemplates.GetInputMask;

    source.InputCase = null;
    source.SetInputCase = ASPxTextBoxTemplates.SetInputCase;
    source.GetInputCase = ASPxTextBoxTemplates.GetInputCase;

    source.IgnoredKeysDefault = [9, 13, 16, 17, 35, 36, 37, 39];
    source.IgnoredKeys = source.IgnoredKeysDefault;
    source.SetIgnoredKeys = ASPxTextBoxTemplates.SetIgnoredKeys;
    source.GetIgnoredKeys = ASPxTextBoxTemplates.GetIgnoredKeys;

    source.GetCaretPosition = ASPxTextBoxTemplates.GetCaretPosition;

    source.ShouldIgnoreEvent = ASPxTextBoxTemplates.ShouldIgnoreEvent;

    source.TransformValue = ASPxTextBoxTemplates.TransformValue;
    source.TransformValueAccordingToInputMask = ASPxTextBoxTemplates.TransformValueAccordingToInputMask;
    source.TransformValueAccordingToInputCase = ASPxTextBoxTemplates.TransformValueAccordingToInputCase;
    

    ASPxClientEditHelper.ExpandFunctionality(source);

    ASPxControlBaseTemplates.InitHandler_SelectAllOnFocus(source);

    ASPxTextBoxHelper.RefreshHandlersReplacement(source);

    source.HasExpandedFunctionality = true;

    return source;
};





ASPxDateEditHelper = new Object();

ASPxDateEditHelper.RefreshHandlersReplacement = function(source) {
    EventHelper.ReplaceHandlers(source.ButtonClick).With(ASPxDateEditTemplates.SmartButtonClickHandler);
};

ASPxDateEditHelper.ExpandFunctionality = function(source) {
    if(ASPxControlHelper.HasExpandedFunctionality(source)) return source;
    
    
    ASPxClientEditHelper.ExpandFunctionality(source);
    

    ASPxControlBaseTemplates.InitHandler_SelectAllOnFocus(source);
    ASPxDateEditTemplates.InitHandler_ToggleDropDownOnClick(source);

    ASPxDateEditHelper.RefreshHandlersReplacement(source);

    source.HasExpandedFunctionality = true;

    return source;
};



ASPxSpinEditHelper = new Object();

ASPxSpinEditHelper.RefreshHandlersReplacement = function(source) {
    EventHelper.ReplaceHandlers(source.GotFocus).With(ASPxSpinEditTemplates.SmartGotFocusHandler);
    EventHelper.ReplaceHandlers(source.LostFocus).With(ASPxSpinEditTemplates.SmartLostFocusHandler);
};

ASPxSpinEditHelper.ExpandFunctionality = function(source) {
    if(ASPxControlHelper.HasExpandedFunctionality(source)) return source;
    
    
    ASPxClientEditHelper.ExpandFunctionality(source);
    

    ASPxControlBaseTemplates.InitHandler_SelectAllOnFocus(source);
    
    source.RefreshState = ASPxSpinEditTemplates.RefreshState;
    source.ApplyScheme = ASPxSpinEditTemplates.ApplyScheme;

    ASPxSpinEditHelper.RefreshHandlersReplacement(source);

    source.HasExpandedFunctionality = true;

    return source;
};



ASPxComboBoxHelper = new Object();

ASPxComboBoxHelper.RefreshHandlersReplacement = function(source) {
    EventHelper.ReplaceHandlers(source.ButtonClick).With(ASPxComboBoxTemplates.SmartButtonClickHandler);
    EventHelper.ReplaceHandlers(source.EndCallback).With(ASPxComboBoxTemplates.SmartEndCallbackHandler);
};

ASPxComboBoxHelper.FIX_DEVEXPRESS_SMALL_DATASOURCE_PROBLEM = function(source) {
    if (source.isCallbackMode == false) return;

    var listBoxControl = source.GetListBoxControl();
    
    if (listBoxControl.GetItemCount() < listBoxControl.callbackPageSize) {
        listBoxControl.SetScrollSpacerVisibility(true, false);
        listBoxControl.SetScrollSpacerVisibility(false, false);
        listBoxControl.scrollHelper.Reset();;
    }
};

ASPxComboBoxHelper.FIX_DEVEXPRESS_NullText_FILTER_ROLLBACK_PROBLEM = function(source) {
    source.filterStrategy.GetActualValueOf = function(inputElement) {
        var result = inputElement.value;

        var comboBox = this.comboBox;
        if (comboBox) {
            if(result == comboBox.nullText && !comboBox.focused) {
                result = "";
            }
        };

        return result;
    };
    
    source.filterStrategy.Filtering = function() {
        this.FilterStopTimer();
        
        var input = this.GetInputElement();
        if (!input) return;

        var newFilter = this.GetActualValueOf(input);

        if (!this.FilterCompare(newFilter)) {
            this.SetFilter(newFilter);
            if (this.CheckFilterLength())
                return;
            this.EnsureShowDropDownArea();
            if (this.comboBox.isCallbackMode)
                this.FilteringOnServer();
            else {
                this.FilteringOnClient(input);
                this.isApplyAndCloseAfterFiltration = false;
            }
        } else {
            this.isEnterLocked = false;
            this.isApplyAndCloseAfterFiltration = false;
        }
    };

    source.filterStrategy.FilterChanged = function() {
        return !this.FilterCompareLower(this.GetActualValueOf(this.GetInputElement()).toLowerCase());
    };

    source.filterStrategy.OnFilterRollback = function(withoutCallback) {
        if (this.comboBox.InCallback() && this.currentCallbackIsFiltration)
            return;
        
        if (this.comboBox.isCallbackMode && this.FilterApplied()) {
            var shouldClearFilter = true;
            
            if (!withoutCallback) {
                this.isApplyAndCloseAfterFiltration = true;
                
                if (this.comboBox.GetText() != "" && this.isDropDownListStyle) {
                    this.comboBox.GetListBoxControl().ClearItems();
                    this.comboBox.SendSpecialCallback(this.GetCurrentSelectedItemCallbackArguments());
                } else {
                    this.Filtering();
                    shouldClearFilter = false;
                }
            }
            
            if(shouldClearFilter) {
                this.SetFilter(this.comboBox.GetText());
                this.ClearFilterApplied();
            }
        }
    };
};
    
ASPxComboBoxHelper.ExpandFunctionality = function(source) {
    if(ASPxControlHelper.HasExpandedFunctionality(source)) return source;


    ASPxClientEditHelper.ExpandFunctionality(source);
    

    ASPxControlBaseTemplates.InitHandler_SelectAllOnFocus(source);

    source.GetListItemElement = ASPxComboBoxTemplates.GetListItemElement;
    source.InCustomCallback = false;
    source.PerformCustomCallback = ASPxComboBoxTemplates.PerformCustomCallback;
    source.InitializeButtonContext = ASPxComboBoxTemplates.InitializeButtonContext;
    source.SetButtonEnabledState = ASPxComboBoxTemplates.SetButtonEnabledState;
    source.EnableButton = ASPxComboBoxTemplates.EnableButton;
    source.DisableButton = ASPxComboBoxTemplates.DisableButton;
    source.ClearValue = ASPxComboBoxTemplates.ClearValue;
    source.Simplify = ASPxComboBoxTemplates.Simplify;
    source.ShowDropDown_Smart = ASPxComboBoxTemplates.ShowDropDown_Smart;
    source.MarkItemsAsDisabled = ASPxComboBoxTemplates.MarkItemsAsDisabled;

    ASPxComboBoxHelper.FIX_DEVEXPRESS_SMALL_DATASOURCE_PROBLEM(source);
    ASPxComboBoxHelper.FIX_DEVEXPRESS_NullText_FILTER_ROLLBACK_PROBLEM(source);

    source.MarkItemsAsDisabled();

    ASPxComboBoxHelper.RefreshHandlersReplacement(source);

    source.HasExpandedFunctionality = true;

    return source;
};



ASPxCallbackPanelHelper = new Object();

ASPxCallbackPanelHelper.RefreshHandlersReplacement = function(source) {
    EventHelper.ReplaceHandlers(source.BeginCallback).With(ASPxCallbackPanelTemplates.SmartBeginCallback);
    EventHelper.ReplaceHandlers(source.EndCallback).With(ASPxCallbackPanelTemplates.SmartEndCallback);
    EventHelper.ReplaceHandlers(source.CallbackError).With(ASPxCallbackPanelTemplates.SmartCallbackError);
};

ASPxCallbackPanelHelper.ExpandFunctionality = function(source) {
    if (ASPxControlHelper.HasExpandedFunctionality(source)) return source;

    ASPxCallbackPanelHelper.RefreshHandlersReplacement(source);

    source.HasExpandedFunctionality = true;

    return source;
};



ASPxLoadingPanelHelper = new Object();

ASPxLoadingPanelHelper.ExpandFunctionality = function(source) {
    if (ASPxControlHelper.HasExpandedFunctionality(source)) return source;

    source.counter = 0;
    source.ShowPanel = ASPxLoadingPanelTemplates.ShowPanel;
    source.HidePanel = ASPxLoadingPanelTemplates.HidePanel;
    
    source.HasExpandedFunctionality = true;

    return source;
};



ASPxPopupMenuHelper = new Object();

ASPxPopupMenuHelper.ExpandFunctionality = function(source) {
    if (ASPxControlHelper.HasExpandedFunctionality(source)) return source;

    source.SourceContext = null;
    source.SourceObjectType = null;
    source.SourceRowIndex = null;
    source.SourceHtmlEventX = null;
    source.SourceHtmlEventY = null;

    source.RowDataFetched = new ASPxClientEvent();

    source.SaveContextMenuContext = ASPxPopupMenuTemplates.SaveContextMenuContext;
    
    source.SetItemTextTemplate = ASPxPopupMenuTemplates.SetItemTextTemplate;
    source.GetItemTextTemplate = ASPxPopupMenuTemplates.GetItemTextTemplate;
    source.FillItemText = ASPxPopupMenuTemplates.FillItemText;
    source.SetItemNavigateUrlTemplate = ASPxPopupMenuTemplates.SetItemNavigateUrlTemplate;
    source.GetItemNavigateUrlTemplate = ASPxPopupMenuTemplates.GetItemNavigateUrlTemplate;
    source.FillItemNavigateUrl = ASPxPopupMenuTemplates.FillItemNavigateUrl;

    source.OnRowValuesFetched_Internal = ASPxPopupMenuTemplates.OnRowValuesFetched_Internal;
    source.OnRowDataFetched = ASPxPopupMenuTemplates.OnRowDataFetched;
    source.FetchSourceRowData = ASPxPopupMenuTemplates.FetchSourceRowData;

    source.ShowMenu = ASPxPopupMenuTemplates.ShowMenu;


    source.HasExpandedFunctionality = true;

    return source;
};



ASPxTimeEditHelper = new Object();

ASPxTimeEditHelper.ExpandFunctionality = function(source) {
    if (ASPxControlHelper.HasExpandedFunctionality(source)) return source;

    
    ASPxClientEditHelper.ExpandFunctionality(source);
    
    ASPxControlBaseTemplates.InitHandler_SelectAllOnFocus(source);


    source.HasExpandedFunctionality = true;

    return source;
};



ASPxClientEditHelper = new Object();

ASPxClientEditHelper.ExpandFunctionality = function(source) {
    source.Form = ASPxClientEditTemplates.Form;

    return source;
};


ASPxControlType = {
    Unknown: 0,
    ASPxGridView: 1,
    ASPxTextBox: 2,
    ASPxDateEdit: 3,
    ASPxButtonEdit: 4,
    ASPxSpinEdit: 5,
    ASPxComboBox: 6,
    ASPxListBox: 7,
    ASPxCheckBox: 8,
    ASPxPopupControl: 9,
    ASPxPageControl : 10,
    ASPxCallbackPanel : 11,
    ASPxLoadingPanel : 12,
    ASPxPopupMenu : 13,
    ASPxTimeEdit : 14,
    ASPxCalendar : 15,
    
    ASPxSmartGridView : 16,
    ASPxSmartPopupEditForm: 17,
    ASPxSmartPageControl: 18,
    ASPxSmartListBox : 19
};


ASPxControlTypeUtils = new Object();

// ReSharper disable UseOfImplicitGlobalInFunctionScope
ASPxControlTypeUtils.GetControlType = function(control) {
    
    if (typeof ASPxClientSmartGridView !== "undefined" && ASPxClientUtils.IsExists(ASPxClientSmartGridView) && control instanceof ASPxClientSmartGridView) {
        return ASPxControlType.ASPxSmartGridView;
    }
    else if (typeof ASPxClientSmartPopupEditForm !== "undefined" && ASPxClientUtils.IsExists(ASPxClientSmartPopupEditForm) && control instanceof ASPxClientSmartPopupEditForm) {
        return ASPxControlType.ASPxSmartPopupEditForm;
    }
    else if (typeof ASPxClientSmartPageControl !== "undefined" && ASPxClientUtils.IsExists(ASPxClientSmartPageControl) && control instanceof ASPxClientSmartPageControl) {
        return ASPxControlType.ASPxSmartPageControl;
    }
    else if (typeof ASPxClientSmartListBox !== "undefined" && ASPxClientUtils.IsExists(ASPxClientSmartListBox) && control instanceof ASPxClientSmartListBox) {
        return ASPxControlType.ASPxSmartListBox;
    }
    
    if (typeof ASPxClientGridView !== "undefined" && ASPxClientUtils.IsExists(ASPxClientGridView) && control instanceof ASPxClientGridView) {
        return ASPxControlType.ASPxGridView;
    } 
    else if (typeof ASPxClientTextBox !== "undefined" && ASPxClientUtils.IsExists(ASPxClientTextBox) && control instanceof ASPxClientTextBox) {
        return ASPxControlType.ASPxTextBox;
    } 
    else if (typeof ASPxClientDateEdit !== "undefined" && ASPxClientUtils.IsExists(ASPxClientDateEdit) && control instanceof ASPxClientDateEdit) {
        return ASPxControlType.ASPxDateEdit;
    } 
    else if (typeof ASPxClientButtonEdit !== "undefined" && ASPxClientUtils.IsExists(ASPxClientButtonEdit) && control instanceof ASPxClientButtonEdit) {
        return ASPxControlType.ASPxButtonEdit;
    } 
    else if (typeof ASPxClientSpinEdit !== "undefined" && ASPxClientUtils.IsExists(ASPxClientSpinEdit) && control instanceof ASPxClientSpinEdit) {
        return ASPxControlType.ASPxSpinEdit;
    } 
    else if (typeof ASPxClientComboBox !== "undefined" && ASPxClientUtils.IsExists(ASPxClientComboBox) && control instanceof ASPxClientComboBox) {
        return ASPxControlType.ASPxComboBox;
    }
    else if (typeof ASPxClientListBox !== "undefined" && ASPxClientUtils.IsExists(ASPxClientListBox) && control instanceof ASPxClientListBox) {
        return ASPxControlType.ASPxListBox;
    }
    else if (typeof ASPxClientCheckBox !== "undefined" && ASPxClientUtils.IsExists(ASPxClientCheckBox) && control instanceof ASPxClientCheckBox) {
        return ASPxControlType.ASPxCheckBox;
    }
    else if (typeof ASPxClientPopupControl !== "undefined" && ASPxClientUtils.IsExists(ASPxClientPopupControl) && control instanceof ASPxClientPopupControl) {
        return ASPxControlType.ASPxPopupControl;
    }
    else if (typeof ASPxClientPageControl !== "undefined" && ASPxClientUtils.IsExists(ASPxClientPageControl) && control instanceof ASPxClientPageControl) {
        return ASPxControlType.ASPxPageControl;
    }
    else if (typeof ASPxClientCallbackPanel !== "undefined" && ASPxClientUtils.IsExists(ASPxClientCallbackPanel) && control instanceof ASPxClientCallbackPanel) {
        return ASPxControlType.ASPxCallbackPanel;
    }
    else if (typeof ASPxClientLoadingPanel !== "undefined" && ASPxClientUtils.IsExists(ASPxClientLoadingPanel) && control instanceof ASPxClientLoadingPanel) {
        return ASPxControlType.ASPxLoadingPanel;
    }
    else if (typeof ASPxClientPopupMenu !== "undefined" && ASPxClientUtils.IsExists(ASPxClientPopupMenu) && control instanceof ASPxClientPopupMenu) {
        return ASPxControlType.ASPxPopupMenu;
    }
    else if (typeof ASPxClientTimeEdit !== "undefined" && ASPxClientUtils.IsExists(ASPxClientTimeEdit) && control instanceof ASPxClientTimeEdit) {
        return ASPxControlType.ASPxTimeEdit;
    }
    else if (typeof ASPxClientCalendar !== "undefined" && ASPxClientUtils.IsExists(ASPxClientCalendar) && control instanceof ASPxClientCalendar) {
        return ASPxControlType.ASPxCalendar;
    }

    return ASPxControlType.Unknown;
};
// ReSharper restore UseOfImplicitGlobalInFunctionScope


ASPxControlHelper = new Object();

ASPxControlHelper.HasExpandedFunctionality = function(control) {
    return typeof control.HasExpandedFunctionality !== "undefined" && control.HasExpandedFunctionality;
};

ASPxControlHelper.ExpandFunctionality = function(control, initializationAction, initializationFinishedAction) {
    var controlType = ASPxControlTypeUtils.GetControlType(control);

    switch (controlType) {
        case ASPxControlType.ASPxTextBox:
            ASPxTextBoxHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
        case ASPxControlType.ASPxDateEdit:
            ASPxDateEditHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
        case ASPxControlType.ASPxSpinEdit:
            ASPxSpinEditHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
        case ASPxControlType.ASPxComboBox:
            ASPxComboBoxHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
        case ASPxControlType.ASPxCallbackPanel:
            ASPxCallbackPanelHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
        case ASPxControlType.ASPxLoadingPanel:
            ASPxLoadingPanelHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
        case ASPxControlType.ASPxPopupMenu:
            ASPxPopupMenuHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
        case ASPxControlType.ASPxTimeEdit:
            ASPxTimeEditHelper.ExpandFunctionality(control, initializationAction, initializationFinishedAction);
            break;
    }

    return control;
};


ASPxControlsHelper = new Object();

ASPxControlsHelper.GetChildControlsOf = function(parentControl, controlType) {
    var parentControlName = parentControl.name;

    // ReSharper disable UseOfImplicitGlobalInFunctionScope
    var controls = ASPxClientControl.GetControlCollection().elements;
    // ReSharper restore UseOfImplicitGlobalInFunctionScope

    var result = new Array();

    for (var controlName in controls) {

        var control = controls[controlName];
        var shouldUseControl = false;

        if (StringHelper.StartsWith(controlName, parentControlName) && controlName != parentControlName) {
            
            if(typeof controlType !== "undefined") {
                if(ASPxControlTypeUtils.GetControlType(control) == controlType) {
                    shouldUseControl = true;
                }                
            }
            else {
                shouldUseControl = true;
            }
        }
        
        if(shouldUseControl) {
            result.push(control);
        }
    }

    return EditorsCollectionHelper.ExpandFunctionality(result);
};

ASPxControlsHelper.ExpandFunctionality = function(controls) {
    for (var index = 0; index < controls.length; index++) {
        ASPxControlHelper.ExpandFunctionality(controls[index]);
    }
};



function ASPxControlDefaults_OnInit(s)
{
    ASPxControlHelper.ExpandFunctionality(s);    
}

function ASPxControlDefaults_ClearValue(s)
{
    if (s != null) {
        if (typeof s.ClearValue === "function") {
            s.ClearValue();
            return;
        }

        if (typeof s.SetValue === "function") {
            s.SetValue(null);
            return;
        }
    }
}

function ASPxControlDefaults_SetFocus(s)
{
    if (s != null) {
        if (typeof s.SetFocus === "function") {
            s.SetFocus();
            return;
        }
    }
}


function ASPxLoadingPanelDefaults_OnInit(s) {
    ASPxLoadingPanelHelper.ExpandFunctionality(s);
}


function ASPxComboBoxDefaults_OnInit(s) {
    ASPxComboBoxHelper.ExpandFunctionality(s);
}

function ASPxSimpleComboBoxDefaults_OnInit(s) {
    ASPxComboBoxHelper.ExpandFunctionality(s).Simplify();
}


function ASPxTextBoxDefaults_OnInit(s) {
    ASPxTextBoxHelper.ExpandFunctionality(s);
}

function ASPxTextBoxDefaults_SetSingleWordUppercasedMask(s) {
    ASPxTextBoxHelper
        .ExpandFunctionality(s)
        .SetInputMask(/[a-z]*/ig)
        .SetInputCase(ASPxTBInputCase.UPPER_CASE);
}

function ASPxTextBoxDefaults_SetAlphanumericUppercasedMask(s) {
    ASPxTextBoxHelper
        .ExpandFunctionality(s)
        .SetInputMask(/[a-z0-9 _\-]*/ig)
        .SetInputCase(ASPxTBInputCase.UPPER_CASE);
}

function ASPxTextBoxDefaults_SetAlphanumericUppercasedFilterMask(s) {
    ASPxTextBoxHelper
        .ExpandFunctionality(s)
        .SetInputMask(/(^\[exact\][a-z0-9 _\-%]*|^\[exact\]|^\[exact|^\[exac|^\[exa|^\[ex|^\[e|^\[|[a-z0-9 _\-]*)/ig)
        .SetInputCase(ASPxTBInputCase.UPPER_CASE);
}

function ASPxTextBoxDefaults_SetNumericMask(s) {
    ASPxTextBoxHelper
        .ExpandFunctionality(s)
        .SetInputMask(/[0-9]*/ig);
}

function ASPxTextBoxDefaults_SetNumericFilterMask(s) {
    ASPxTextBoxHelper
        .ExpandFunctionality(s)
        .SetInputMask(/(^\[exact\][0-9_%]*|^\[exact\]|^\[exact|^\[exac|^\[exa|^\[ex|^\[e|^\[|[0-9]*)/ig)
        .SetInputCase(ASPxTBInputCase.UPPER_CASE);
}


function ASPxDateEditDefaults_OnInit(s) {
    ASPxDateEditHelper.ExpandFunctionality(s);
}

function ASPxDateEditDefaults_SetCurrentDateTime(s) {
    s.SetValue(new Date());
}


function ASPxPopupMenuDefaults_OnInit(s) {
    ASPxPopupMenuHelper.ExpandFunctionality(s);
}