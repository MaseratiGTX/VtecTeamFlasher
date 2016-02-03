var _aspxEmptyFunction = function () { };

var _aspxCreateFunctionWrapper = function(sourceFunction, beforeFunction, afterFunction) {
    return function() {
        beforeFunction.apply(this, arguments);

        var result = sourceFunction.apply(this, arguments);

        afterFunction.apply(this, arguments);

        return result;
    }
};


var ASPxActionsRepository = function() {
    var collection = ASPxCollection.apply(null, arguments);

    ASPxActionsRepository.injectClassMethods(collection);

        collection.IsASPxActionsRepository = true;

    return (collection);
}

ASPxActionsRepository.injectClassMethods = function (controlCollection) {
    for (var method in ASPxActionsRepository.prototype) {
        if (ASPxActionsRepository.prototype.hasOwnProperty(method)) {
            controlCollection[method] = ASPxActionsRepository.prototype[method];
        }
    }
    return (controlCollection);
};

ASPxActionsRepository.prototype = {

    CreateInstance: function () {
        return (new ASPxActionsRepository());
    },


    AddItem: function(item) {
        if (item && typeof item === "function") {
            ASPxCollection.prototype.AddItem.call(this, item);
        }
        return (this);
    },


    Execute: function (actionContext, actionParameters) {
        this.Each(function() {
            try { this.apply(actionContext || null, actionParameters || arguments); } catch (e) { }
        });
        
        return (this.Clear());
    }

}
