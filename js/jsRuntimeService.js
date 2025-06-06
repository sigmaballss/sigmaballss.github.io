window.onscroll = function() {
    if (window.jsRuntimeService != null)
        window.jsRuntimeService.invokeMethodAsync('OnScroll', window.scrollY);
};

window.onresize = function() {
    if (window.jsRuntimeService != null)
        window.jsRuntimeService.invokeMethodAsync('OnResize', window.innerWidth, window.innerHeight);
};

window.RegisterJsRuntimeService = (jsRuntimeService) => {
    window.jsRuntimeService = jsRuntimeService;

    window.jsRuntimeService.invokeMethodAsync('OnScroll', window.scrollY);
    window.jsRuntimeService.invokeMethodAsync('OnResize', window.innerWidth, window.innerHeight);
};

window.GetElementBoundingClientRect = (element) => element.getBoundingClientRect();

