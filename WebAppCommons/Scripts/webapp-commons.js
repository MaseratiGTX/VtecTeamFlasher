JSONHelper = new Object();

JSONHelper.Parse = function (json) {
    try { return $.parseJSON(json); } catch (ex) { return null; }
};



RegExpHelper = new Object();

RegExpHelper.EscapeRegExp = function (source) {
    return source.replace(/([.*+?^=!:${}()|\[\]\/\\])/g, "\\$1");
};



StringHelper = new Object();

StringHelper.ReplaceAll = function (source, oldValue, newValue) {
    return source.replace(new RegExp(RegExpHelper.EscapeRegExp(oldValue), 'g'), newValue);
};

StringHelper.Normalize = function (source) {
    return StringHelper.ReplaceAll(source, "&#39;", "'");
};

StringHelper.ToPatternView = function (source) {
    if (arguments.length == 0) return null;
    if (arguments.length == 1) return source;

    var result = source;

    for (var index = 1; index < arguments.length; index++) {
        result = StringHelper.ReplaceAll(result, arguments[index], "{" + (index - 1) + "}");
    }

    return result;
};

StringHelper.Format = function (source) {
    var parameters = null;

    switch (arguments.length) {
        case 0:
            return null;
        case 1:
            return source;
        case 2:
            var parameter = arguments[1];
            parameters = parameter instanceof Array ? parameter : [parameter];
            break;            
        default:
            parameters = Array.prototype.slice.call(arguments, 1); ;
            break;
    }

    var result = source;

    for (var index = 0; index < parameters.length; index++) {
        result = StringHelper.ReplaceAll(result, "{" + (index) + "}", parameters[index]);
    }

    return result;
};

StringHelper.StartsWith = function (source, substr) {
    return source.slice(0, substr.length) == substr;
};

StringHelper.EndsWith = function (source, substr) {
    return source.slice(-substr.length) == substr;
};



DateHelper = new Object();

DateHelper.StartOfTheDate = function (date) {
    return date ? new Date(date.getFullYear(), date.getMonth(), date.getDate(), 00, 00, 00) : null;
};

DateHelper.EndOfTheDate = function (date) {
    return date ? new Date(date.getFullYear(), date.getMonth(), date.getDate(), 23, 59, 59) : null;
};


DateHelper.GetDayOfWeek = function(date) {
    var weekday = new Array(7);
    
    weekday[0] = "Sunday";
    weekday[1] = "Monday";
    weekday[2] = "Tuesday";
    weekday[3] = "Wednesday";
    weekday[4] = "Thursday";
    weekday[5] = "Friday";
    weekday[6] = "Saturday";

    return weekday[date.getDay()];
};



ErrorType = {
    Unknown: 0,
    Validation: 1,
    SourceElementNotFoundException: 2,
    CallbackTargetNotFound: 3
};



HandlerSubstitutionalFunctionInfo = function (actualHandlerInfo, substitutionalFunction) {
    this.ActualHandlerFunction = actualHandlerInfo.handler;
    this.SubstitutionalFunction = substitutionalFunction;

    return this;
};


ReplaceHandlersExecutor = function (eventObject) {
    this.EventObject = eventObject;

    this.HandlersToProcessCount = null;


    this.First = function (count) {
        this.HandlersToProcessCount = count;

        return this;
    };

    this.FirstOnly = function () {
        this.HandlersToProcessCount = 1;

        return this;
    };

    this.With = function (substitutionalFunction) {
        var handlerInfoList = this.EventObject.handlerInfoList;

        if (handlerInfoList.length == 0) {
            this.EventObject.AddHandler(function () { });

            handlerInfoList = this.EventObject.handlerInfoList;
        }


        var handlersToProcessCount = this.HandlersToProcessCount != null ? Math.min(this.HandlersToProcessCount, handlerInfoList.length) : handlerInfoList.length;

        for (var index = 0; index < handlersToProcessCount; index++) {
            var actualHandlerInfo = handlerInfoList[index];

            var handlerSubstitutionalFunctionInfo = new HandlerSubstitutionalFunctionInfo(actualHandlerInfo, substitutionalFunction);

            actualHandlerInfo.handler = function (s, e) {
                return handlerSubstitutionalFunctionInfo.SubstitutionalFunction(s, e);
            };
        }
    };

    return this;
};

RebindHandlersExecutor = function (eventObject) {
    this.EventObject = eventObject;

    this.HandlerExecutionTemplate = function (s, e) { return this.ActualHandlerFunction(s, e); };


    this.UsingTemplate = function (handlerExecutionTemplate) {
        this.HandlerExecutionTemplate = handlerExecutionTemplate;

        return this;
    };

    this.To = function (destEventObject) {
        var handlerInfoList = this.EventObject.handlerInfoList;

        for (var index = 0; index < handlerInfoList.length; index++) {
            var actualHandlerInfo = handlerInfoList[index];

            var handlerSubstitutionalFunctionInfo = new HandlerSubstitutionalFunctionInfo(actualHandlerInfo, this.HandlerExecutionTemplate);

            destEventObject.AddHandler(
                function (s, e) {
                    return handlerSubstitutionalFunctionInfo.SubstitutionalFunction(s, e);
                }
            );
        }
    };

    return this;
};


EventHelperActions = {
    ReplaceHandlers: "ReplaceHandlers",
    ReplaceFirstHandler: "ReplaceFirstHandler",
    RebindHandlers: "RebindHandlers"
};

EventHelper = function (eventObject) {
    this.EventObject = eventObject;

    this.GetExecutorFor = function (action) {
        switch (action) {
            case EventHelperActions.ReplaceHandlers:
                return new ReplaceHandlersExecutor(this.EventObject);
            case EventHelperActions.ReplaceFirstHandler:
                return new ReplaceHandlersExecutor(this.EventObject).FirstOnly();
            case EventHelperActions.RebindHandlers:
                return new RebindHandlersExecutor(this.EventObject);
            default:
                return null;
        }
    };

    return this;
};

EventHelper.ReplaceHandlers = function (eventObject) {
    return new EventHelper(eventObject).GetExecutorFor(EventHelperActions.ReplaceHandlers);
};

EventHelper.ReplaceFirstHandler = function (eventObject) {
    return new EventHelper(eventObject).GetExecutorFor(EventHelperActions.ReplaceFirstHandler);
};

EventHelper.RebindHandlers = function (eventObject) {
    return new EventHelper(eventObject).GetExecutorFor(EventHelperActions.RebindHandlers);
};

ButtonType = { Unknown: 0, Left: 1, Middle: 2, Right: 3 };

EventHelper.DetectButton = function (eventObject) {
    var actualEventObject = eventObject || window.event;

    return actualEventObject.which == null
        ? ((actualEventObject.button < 2) ? ButtonType.Left : ((actualEventObject.button == 4) ? ButtonType.Middle : ButtonType.Right))
        : ((actualEventObject.which < 2) ? ButtonType.Left : ((actualEventObject.which == 2) ? ButtonType.Middle : ButtonType.Right));
};

KeyType = { None: 0, Alt: 2, Ctrl: 4, Meta: 8, Shift: 16 };

EventHelper.DetectKey = function (eventObject) {
    var actualEventObject = eventObject || window.event;

    return (actualEventObject.altKey ? KeyType.Alt : KeyType.None) +
            (actualEventObject.ctrlKey ? KeyType.Ctrl : KeyType.None) +
            (actualEventObject.metaKey ? KeyType.Meta : KeyType.None) +
            (actualEventObject.shiftKey ? KeyType.Shift : KeyType.None);
};



EventSimulator = new Object();

EventSimulator.extend = function (destination, source) {
    for (var property in source) {
        destination[property] = source[property];
    }

    return destination;
};

EventSimulator.eventMatchers = {
    'HTMLEvents': /^(?:load|unload|abort|error|select|change|submit|reset|focus|blur|resize|scroll)$/,
    'MouseEvents': /^(?:click|dblclick|mouse(?:down|up|over|move|out))$/
};

EventSimulator.defaultOptions = {
    pointerX: 0,
    pointerY: 0,
    button: 0,
    ctrlKey: false,
    altKey: false,
    shiftKey: false,
    metaKey: false,
    bubbles: true,
    cancelable: true
};

EventSimulator.Simulate = function (element, eventName) {
    var options = EventSimulator.extend(EventSimulator.defaultOptions, arguments[2] || {});
    var oEvent, eventType = null;

    for (var name in EventSimulator.eventMatchers) {
        if (EventSimulator.eventMatchers[name].test(eventName)) { eventType = name; break; }
    }

    if (!eventType)
        throw new SyntaxError('Only HTMLEvents and MouseEvents interfaces are supported');

    if (document.createEvent) {
        oEvent = document.createEvent(eventType);

        if (eventType == 'HTMLEvents') {
            oEvent.initEvent(eventName, options.bubbles, options.cancelable);
        }
        else {
            oEvent.initMouseEvent(eventName, options.bubbles, options.cancelable, document.defaultView,
            options.button, options.pointerX, options.pointerY, options.pointerX, options.pointerY,
            options.ctrlKey, options.altKey, options.shiftKey, options.metaKey, options.button, element);
        }

        element.dispatchEvent(oEvent);
    }
    else {
        options.clientX = options.pointerX;
        options.clientY = options.pointerY;
        var evt = document.createEventObject();
        oEvent = EventSimulator.extend(evt, options);
        element.fireEvent('on' + eventName, oEvent);
    }

    return element;
};



EditorsCollectionTemplates = new Object();

EditorsCollectionTemplates.First = function () {
    var source = this;

    if (source.length > 0) {
        return source[0];
    }

    return null;
};

EditorsCollectionTemplates.Last = function () {
    var source = this;

    if (source.length > 0) {
        return source[source.length - 1];
    }

    return null;
};

EditorsCollectionTemplates.Exclude = function (controlTypeToExclude) {
    var source = this;

    var controlsToExclude = $.grep(source, function (item) {
        return ASPxControlTypeUtils.GetControlType(item) == controlTypeToExclude;
    });

    var result = $.grep(source, function (item) {
        for (var control in controlsToExclude) {
            if (StringHelper.StartsWith(item.name, controlsToExclude[control].name)) {
                return false;
            }
        }

        return true;
    });

    return EditorsCollectionHelper.ExpandFunctionality(result);
};

EditorsCollectionTemplates.FocusFirst = function () {
    var source = this;

    var first = source.First();

    if (first != null && first.SetFocus) {
        first.SetFocus();
    }
};

EditorsCollectionTemplates.RefreshState = function () {
    var source = this;

    for (var index = 0; index < source.length; index++) {
        var editor = source[index];

        if (typeof editor.RefreshState !== "undefined") {
            editor.RefreshState();
        }
    }
};

EditorsCollectionTemplates.BlockContextMenu = function () {
    var source = this;

    $(source).on("contextmenu", function () {
        window.event.returnValue = false;
    });

    return source;
};

EditorsCollectionTemplates.BindMouseEvent = function (eventType, handler) {
    var source = this;

    $(source).on(eventType, function (eventObject) {
        eventObject.returnValue = true;

        eventObject.buttonType = EventHelper.DetectButton(eventObject);
        eventObject.keyType = EventHelper.DetectKey(eventObject);

        var handlerExecutionResult = handler(this, eventObject);

        if (handlerExecutionResult == null) {
            return eventObject.returnValue;
        }

        return handlerExecutionResult;
    });

    return source;
};

EditorsCollectionTemplates.OnClick = function (handler) {
    var source = this;

    source.BindMouseEvent("click", handler);

    return source;
};

EditorsCollectionTemplates.OnMouseUp = function (handler) {
    var source = this;

    source.BindMouseEvent("mouseup", handler);

    return source;
};

EditorsCollectionTemplates.OnMouseDown = function (handler) {
    var source = this;

    source.BindMouseEvent("mousedown", handler);

    return source;
};



PageRequestManagerHelper = new Object();

PageRequestManagerHelper.Initialize = function () {
    PageRequestManagerHelper.CurrentPostBackElement = null;
    PageRequestManagerHelper.HandlersRepository = new Array();

    // ReSharper disable UseOfImplicitGlobalInFunctionScope
    var pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();
    // ReSharper restore UseOfImplicitGlobalInFunctionScope
    pageRequestManager.add_beginRequest(PageRequestManagerHelper.CommonBeginRequestHandler);
    pageRequestManager.add_endRequest(PageRequestManagerHelper.CommonEndRequestHandler);
};

PageRequestManagerHelper.CommonBeginRequestHandler = function (s, e) {
    var control = e.get_postBackElement();

    PageRequestManagerHelper.CurrentPostBackElement = control;

    PageRequestManagerHelper.RaiseEvent("BeginRequest", control, e);
};

PageRequestManagerHelper.CommonEndRequestHandler = function (s, e) {
    var control = PageRequestManagerHelper.CurrentPostBackElement;

    PageRequestManagerHelper.RaiseEvent("EndRequest", control, e);
};

PageRequestManagerHelper.OnBeginRequest = function (control, eventHandler) {
    PageRequestManagerHelper.AddEventHandler("BeginRequest", control, eventHandler);
};

PageRequestManagerHelper.OnEndRequest = function (control, eventHandler) {
    PageRequestManagerHelper.AddEventHandler("EndRequest", control, eventHandler);
};

PageRequestManagerHelper.FindHandler = function (eventType, controlId) {
    var handlersRepository = PageRequestManagerHelper.HandlersRepository;

    for (var index = 0; index < handlersRepository.length; index++) {
        var item = handlersRepository[index];

        if (item[0] == eventType) {
            if (item[1] == controlId) {
                return item;
            }
        }
    }

    return null;
};

PageRequestManagerHelper.AddEventHandler = function (eventType, control, eventHandler) {
    if (ASPxControlTypeUtils.GetControlType(control) == ASPxControlType.Unknown) return;

    var controlId = control.GetMainElement().id;

    var foundHandler = PageRequestManagerHelper.FindHandler(eventType, controlId);

    if (foundHandler == null) {
        var item = new Array();
        item[0] = eventType;
        item[1] = controlId;
        item[2] = control;
        item[3] = eventHandler;

        PageRequestManagerHelper.HandlersRepository[PageRequestManagerHelper.HandlersRepository.length] = item;
    } else {
        foundHandler[3] = eventHandler;
    }
};

PageRequestManagerHelper.RaiseEvent = function (eventType, control, e) {
    if (control.id === "undefined") return;

    var foundHandler = PageRequestManagerHelper.FindHandler(eventType, control.id);

    if (foundHandler != null) {
        var actualControl = foundHandler[2];
        var actualHandler = foundHandler[3];

        actualHandler(actualControl, e);
    }
};



CommonHTMLElementHelper = new Object();

CommonHTMLElementHelper.NormalizeWidth = function (element, etalon) {

    if (typeof etalon.GetMainElement !== "undefined") {
        etalon = etalon.GetMainElement();
    }

    var absoluteElementLeft = $(element).offset().left;
    var absoluteEtalonLeft = $(etalon).offset().left;
    var etalonWidth = $(etalon).width();

    var elementXShift = Math.abs(absoluteElementLeft - absoluteEtalonLeft);

    $(element).width(etalonWidth - 2 * elementXShift);
};



WindowHelper = new Object();

WindowHelper.HandlersRepository = {};

WindowHelper.BindOnBeforeUnload = function (currentHandler) {
    var key = 'OnBeforeUnload';

    if (typeof WindowHelper.HandlersRepository[key] === "undefined") {
        WindowHelper.HandlersRepository[key] = new Array();
    }

    WindowHelper.HandlersRepository[key].push(currentHandler);

    window.onbeforeunload = currentHandler;
};

WindowHelper.UnBindOnBeforeUnload = function () {
    var key = 'OnBeforeUnload';

    if (typeof WindowHelper.HandlersRepository[key] === "undefined") {
        window.onbeforeunload = null;
        return;
    }

    var handlersRepository = WindowHelper.HandlersRepository[key];

    if (handlersRepository.length > 0) {
        handlersRepository.pop();
    }

    if (handlersRepository.length >= 1) {
        window.onbeforeunload = handlersRepository[handlersRepository.length - 1];
        return;
    }

    window.onbeforeunload = null;
};



CookieHelper = new Object();

CookieHelper.IsCookieEnabled = function() {
    return navigator.cookieEnabled == true;
};

CookieHelper.IsCookieDisabled = function () {
    return this.IsCookieEnabled() == false;
};