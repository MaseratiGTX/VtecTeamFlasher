ASPxWindowHelper = new Object();

ASPxWindowHelper.OnBeforeUnload_HandlersRepository = new ASPxCollection();

ASPxWindowHelper.BindOnBeforeUnload = function (argument) {
    var currentHandler = typeof argument !== "function" ? function() { return argument; } : argument;
    
    var handlersRepository = ASPxWindowHelper.OnBeforeUnload_HandlersRepository;
        handlersRepository.AddItem(currentHandler);
    
    window.onbeforeunload = currentHandler;
};

ASPxWindowHelper.UnBindOnBeforeUnload = function () {
    var handlersRepository = ASPxWindowHelper.OnBeforeUnload_HandlersRepository;
        handlersRepository.Pop();

    window.onbeforeunload = handlersRepository.Last();
};