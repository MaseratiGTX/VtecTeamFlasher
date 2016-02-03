var _aspxParseJSON = function (jsonString) {
    return _aspxIsValidJSON(jsonString) ? eval("(" + jsonString + ")") : null;
};

var _aspxParseBool = function (value) {
    if (typeof value === "string") {
        return value === 'true' || value === 'True' || (value === 'false' || value === 'False' ? false : null);
    }
    return Boolean(value);
};

var _aspxEscapeRegExp = function (source) {
    return source.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
};

var _aspxReplaceAll = function (source, oldValue, newValue) {
    return source.replace(new RegExp(_aspxEscapeRegExp(oldValue), 'g'), newValue);
};