ASPxClientSmartStaticDataViewControl = _aspxCreateClass(ASPxClientControl, {
    constructor: function (name) {
        this.constructor.prototype.constructor.call(this, name);
    },


    GetControl: function(index, type) {
        var controlName = this.name + '_' + type + index;
        return document.getElementById(controlName);
    },

    GetControls: function (type) {
        var index = 0;
        var collection = [];

        while (true) {
            var control = this.GetControl(index, type);

            if (control == null) {
                break;
            }

            collection.push(control);

            index++;
        }

        return collection;
    },


    GetContentControl: function (index) {
        return this.GetControl(index, 'content');
    },

    GetContentControls: function () {
        return this.GetControls('content');
    },


    GetCaptionControl: function (index) {
        return this.GetControl(index, 'caption');
    },

    GetCaptionControls: function () {
        return this.GetControls('caption');
    },


    SetValues: function (dataArray) {
        for (var i = 0; i < dataArray.length; i++) {
            this.SetValue(i, dataArray[i]);
        }
    },

    SetValue: function (index, value) {
        var control = this.GetContentControl(index);

        if (control) {
            control.innerHTML = value;
        }
    },

    
    IsEmpty: function() {
        var controls = this.GetContentControls();

        for (var i = 0; i < controls.length; i++) {
            if (controls[i].innerHTML) {
                return false;
            }
        }
        
        return true;
    }
});

ASPxClientSmartStaticDataViewControl.Cast = ASPxClientControl.Cast;