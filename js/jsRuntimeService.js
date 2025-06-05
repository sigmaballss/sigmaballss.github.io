window.onscroll = function() {
    if (window.jsRuntimeService != null)
        window.jsRuntimeService.invokeMethodAsync('OnScroll', window.scrollY);
};

window.RegisterJsRuntimeService = (jsRuntimeService) => {
    window.jsRuntimeService = jsRuntimeService;
};

window.MyDOMGetBoundingClientRect = (element) => element.getBoundingClientRect().top;

window.GetElementBoundingClientRect = (element) => element.getBoundingClientRect();
