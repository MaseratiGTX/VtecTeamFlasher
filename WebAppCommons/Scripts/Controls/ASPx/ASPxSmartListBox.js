ASPxClientSmartListBox = _aspxCreateClass(ASPxClientListBox, {
    constructor: function(name) {
        this.constructor.prototype.constructor.call(this, name);
        this.displayAll = false;
        this.displayItemCount = 0;
    },


    CorrectHeight: function () {
        if (__aspxFirefox && this.heightCorrected) return;

        if (this.displayAll || this.displayItemCount != 0) {
            var scrollElement = this.GetScrollDivElement();
            var mainElement = this.GetMainElement();
            var listTable = this.GetListTable();

            var itemsCount = listTable.rows.length;
            var itemHeight = _aspxGetClearClientHeight(this.GetListTable()) / itemsCount;

            var actualDisplayItemCount = this.displayAll ? Math.max(itemsCount, this.displayItemCount) : this.displayItemCount;

            if (scrollElement && mainElement && actualDisplayItemCount > 0) {
                scrollElement.style.height = mainElement.style.height = Math.round(actualDisplayItemCount * itemHeight) + "px";
                this.heightCorrected = true;
                return;
            }
        }

        ASPxClientListBox.prototype.CorrectHeight.call(this);
    },

    
    GetEditorValueString: function () {
        var selectedValues = this.GetSelectedValues();

        if (selectedValues.length == 0) return null;

        var result = selectedValues[0];

        for (var index = 1; index < selectedValues.length; index++) {
            result = result + "\u0007" + selectedValues[index].toString();
        }

        return result;
    },


    OnItemSelectionChanged: function (index, selected) {
        ASPxClientListBox.prototype.OnItemSelectionChanged.call(this, index, selected);
        
        this.SetFocus(index);
    },

    SetFocus: function(index) {
        var source = this;

        if (typeof index === "undefined") {
            var focusedEditor = ASPxClientEdit.GetFocusedEditor();
            if (focusedEditor && focusedEditor.GetMainElement() && focusedEditor.name == this.name) return;
        }

        var inputControl = source.GetItemCheckBoxInput(index || 0);
        if (inputControl) {
            window.setTimeout(function() { try { inputControl.focus(); } catch (ex) { }; }, 0);
        }
    }
});

ASPxClientSmartListBox.Cast = ASPxClientControl.Cast;