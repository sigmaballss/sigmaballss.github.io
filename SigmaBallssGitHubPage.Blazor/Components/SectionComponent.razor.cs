using Microsoft.AspNetCore.Components;
using R3;
using SigmaBallssGitHubPage.Common.JsRuntime.Abstractions;
using SigmaBallssGitHubPage.Common.JsRuntime.Structs;

namespace SigmaBallssGitHubPage.Blazor.Components;

public partial class SectionComponent : ComponentBase, IDisposable
{
    private IDisposable? _observers;

    [Inject]
    public required IJsRuntimeService JsRuntimeService { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private ElementReference ComponentReference { get; set; }

    private BoundingRect BoundingRect { get; set; }

    private bool IsFocused { get; set; }

    public void Dispose()
    {
        _observers?.Dispose();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false)
        {
            return;
        }

        BoundingRect = await JsRuntimeService.GetBoundingRect(ComponentReference);

        var disposables = Disposable.CreateBuilder();

        JsRuntimeService.ScrollYValue
            .Select(IsBoundingRectInFocus)
            .Where(isFocused => IsFocused != isFocused)
            .Subscribe(IsFocused_NewValueDetected)
            .AddTo(ref disposables);

        JsRuntimeService.ScreenSize
            .Subscribe(_ => UpdateBoundingRect())
            .AddTo(ref disposables);

        _observers = disposables.Build();
    }

    private bool IsBoundingRectInFocus(int yValue)
    {
        var halfScreenHeight = JsRuntimeService.ScreenSize.CurrentValue.Y / 2;

        return yValue + halfScreenHeight >= BoundingRect.Top;
    }

    private void IsFocused_NewValueDetected(bool isFocused)
    {
        IsFocused = isFocused;
        StateHasChanged();
    }

    private async ValueTask UpdateBoundingRect()
    {
        BoundingRect = await JsRuntimeService.GetBoundingRect(ComponentReference);
    }
}
