using Microsoft.JSInterop;
using R3;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;

namespace SigmaBallssGitHubPage.Blazor.Services.Impl;

public class JsRuntimeService : IJsRuntimeService
{
    private readonly ReactiveProperty<int> _scrollYValueProperty = new();

    public JsRuntimeService(IJSRuntime jsRuntime)
    {
        jsRuntime.InvokeVoidAsync("RegisterJsRuntimeService", DotNetObjectReference.Create(this));
    }

    public ReadOnlyReactiveProperty<int> ScrollYValue => _scrollYValueProperty;

    [JSInvokable("OnScroll")]
    public void JsOnScroll(int yValue)
    {
        _scrollYValueProperty.Value = yValue;
    }
}
