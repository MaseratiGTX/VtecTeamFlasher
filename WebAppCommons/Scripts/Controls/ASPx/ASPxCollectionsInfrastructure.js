var ASPxCollection = function() {
    var initialItems = null;

    switch(arguments.length) {
        case 0:
            initialItems = new Array();
            break;
        case 1:
            var argument = arguments[0];
            initialItems = argument instanceof Array ? argument : [argument];
            break;
        default:
            initialItems = arguments;
            break;
    }


    var collection = Array.apply(null, initialItems);

    ASPxCollection.injectClassMethods(collection);

        collection.IsASPxCollection = true;

    return (collection);
};

ASPxCollection.injectClassMethods = function(collection) {
    for (var method in ASPxCollection.prototype) {
        if (ASPxCollection.prototype.hasOwnProperty(method)) {
            collection[method] = ASPxCollection.prototype[method];
        }
    }
    return (collection);
};

ASPxCollection.prototype = {
    
    CreateInstance: function() {
        return (new ASPxCollection());
    },


    Count: function() {
        return (this.length);
    },


    IndexOfItem: function(item) {
        var itemsCount = this.Count();
        for (var index = 0; index < itemsCount; index++) {
            if (this[index] == item) return (index);
        }
        return (null);
    },


    AddItem: function(item) {
        this.push(item);
        return (this);
    },

    AddRange: function (items) {
        for (var index = 0; index < items.length; index++) {
            this.AddItem(items[index]);
        }
        return (this);
    },

    Add: function() {
        switch (arguments.length) {
            case 0:
                return (this);
            case 1:
                var argument = arguments[0];
                if (argument instanceof Array) {
                    return (this.AddRange(argument));
                } else {
                    return (this.AddItem(argument));
                }
            default:
                return (this.AddRange(arguments));
        }
    },


    RemoveItem: function(item) {
        var itemIndex = this.IndexOfItem(item);
        if (itemIndex != null) {
            this.splice(itemIndex, 1);
        }
        return (this);
    },

    RemoveRange: function(items) {
        for (var index = 0; index < items.length; index++) {
            this.RemoveItem(items[index]);
        }
        return (this);
    },

    Remove: function() {
        switch(arguments.length) {
            case 0:
                return (this);
            case 1:
                var argument = arguments[0];
                if (argument instanceof Array) {
                    return (this.RemoveRange(argument));
                } else {
                    return (this.RemoveItem(argument));
                }
            default:
                return (this.RemoveRange(arguments));
        }
    },


    Pop: function() {
        if (this.IsNotEmpty()) {
            this.pop();
        }
        return (this);
    },


    Clear: function() {
        while (this.IsNotEmpty()) {
            this.pop();
        }
        return (this);
    },


    IsEmpty: function() {
        return (this.Count() == 0);
    },

    IsNotEmpty: function() {
        return (this.IsEmpty() == false);
    },


    First: function () {
        return (this.IsNotEmpty() ? this[0] : null);
    },

    Last: function () {
        return (this.IsNotEmpty() ? this[this.Count() - 1] : null);
    },


    Each: function () {
        var beginIndex = null;
        var endIndex = null;
        var sourceFunction = null;

        switch(arguments.length) {
            case 1:
                beginIndex = 0;
                endIndex = this.Count();
                sourceFunction = arguments[0];
                break;
            case 2:
                beginIndex = arguments[0];
                endIndex = this.Count();
                sourceFunction = arguments[1];
                break;
            case 3:
                beginIndex = arguments[0];
                endIndex = Math.min(arguments[1], this.Count());
                sourceFunction = arguments[2];
                break;
            default:
                return (this);
        }

        for (var index = beginIndex; index < endIndex; index++) {
            sourceFunction.call(this[index], index);
        }

        return (this);
    },


    Select: function(predicate) {
        var result = this.CreateInstance();

        this.Each(function(index) {
            if (predicate.call(this, index) == true) {
                result.AddItem(this);
            }
        });

        return (result);
    },

    Evict: function(predicate) {
        var result = this.CreateInstance();

        this.Each(function (index) {
            if (predicate.call(this, index) == false) {
                result.AddItem(this);
            }
        });

        return (result);
    },


    Any: function (predicate) {
        if (predicate) {
            var itemsCount = this.Count();
            for (var index = 0; index < itemsCount; index++) {
                if (predicate.call(this[index], index) == true) {
                    return (true);
                }
            }
            return (false);
        }
        return this.IsNotEmpty();
    },


    OfType: function (itemType) {
        return this.Select(function() {
            return (this instanceof itemType);
        });
    },

    Except: function (itemType) {
        return this.Evict(function () {
            return (this instanceof itemType);
        });
    },


    Take: function(itemCount) {
        return this.Select(function(index) {
            return (index < itemCount);
        });
    },

    Skip: function (itemCount) {
        return this.Evict(function (index) {
            return (index < itemCount);
        });
    },


    Min: function(selector) {
        if (this.IsEmpty()) return (null);

        var firstItem = this.First();
        var result = selector ? selector.call(firstItem, 0) : firstItem;

        this.Each(1, function (index) {
            var currentResult = selector ? selector.call(this, index) : this;
            if (currentResult < result) result = currentResult;
        });

        return (result);
    },

    Max: function(selector) {
        if (this.IsEmpty()) return (null);

        var firstItem = this.First();
        var result = selector ? selector.call(firstItem, 0) : firstItem;

        this.Each(1, function (index) {
            var currentResult = selector ? selector.call(this, index) : this;
            if (result < currentResult) result = currentResult;
        });

        return (result);
    }

};