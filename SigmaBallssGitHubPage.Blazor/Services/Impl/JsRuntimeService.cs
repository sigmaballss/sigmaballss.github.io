using System.Numerics;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using R3;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;
using SigmaBallssGitHubPage.Blazor.Structs;

namespace SigmaBallssGitHubPage.Blazor.Services.Impl;

public class JsRuntimeService : IJsRuntimeService
{
    private readonly IJSRuntime _jsRuntime;

    private readonly ReactiveProperty<int> _scrollYValueProperty = new();

    private readonly ReactiveProperty<Vector2> _screenSizeProperty = new();

    public JsRuntimeService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;

        _jsRuntime.InvokeVoidAsync("RegisterJsRuntimeService", DotNetObjectReference.Create(this));
    }

    public ReadOnlyReactiveProperty<int> ScrollYValue => _scrollYValueProperty;

    public ReadOnlyReactiveProperty<Vector2> ScreenSize => _screenSizeProperty;

    [JSInvokable("OnScroll")]
    public void JsOnScroll(int yValue)
    {
        _scrollYValueProperty.Value = yValue;
    }

    [JSInvokable("OnResize")]
    public void JsOnResize(float x, float y)
    {
        _screenSizeProperty.Value = new Vector2(x, y);
    }

    public ValueTask<BoundingRect> GetBoundingRect(ElementReference target)
    {
        return _jsRuntime.InvokeAsync<BoundingRect>("GetElementBoundingClientRect", target);
    }
}
