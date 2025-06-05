using Microsoft.AspNetCore.Components;
using R3;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;
using SigmaBallssGitHubPage.Blazor.Structs;

namespace SigmaBallssGitHubPage.Blazor.Components;

public partial class SectionComponent : ComponentBase, IDisposable
{
    private IDisposable? _isFocusedObserver;

    [Inject]
    public required IJsRuntimeService JsRuntimeService { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    private ElementReference ComponentReference { get; set; }

    private BoundingRect BoundingRect { get; set; }

    private bool IsFocused { get; set; }

    public void Dispose()
    {
        _isFocusedObserver?.Dispose();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false)
        {
            return;
        }

        BoundingRect = await JsRuntimeService.GetBoundingRect(ComponentReference);

        _isFocusedObserver = JsRuntimeService.ScrollYValue
            .Select(IsBoundingRectInFocus)
            .Where(isFocused => IsFocused != isFocused)
            .Subscribe(isFocused =>
            {
                IsFocused = isFocused;
                StateHasChanged();
            });
    }

    private bool IsBoundingRectInFocus(int yValue)
    {
        var screenHeight = JsRuntimeService.ScreenSize.CurrentValue.Y;
        var halfScreenHeight = screenHeight / 2;

        Console.WriteLine(halfScreenHeight);

        return yValue + halfScreenHeight >= BoundingRect.Top;
    }
}
