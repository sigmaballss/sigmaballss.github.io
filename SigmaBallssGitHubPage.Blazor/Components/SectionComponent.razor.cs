using Microsoft.AspNetCore.Components;
using R3;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;

namespace SigmaBallssGitHubPage.Blazor.Components;

public partial class SectionComponent : ComponentBase
{
    [Inject]
    public required IJsRuntimeService JsRuntimeService { get; set; }

    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    public ElementReference ComponentReference { get; set; }

    private bool IsFocused { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false)
        {
            return;
        }

        var boundingRect = await JsRuntimeService.GetBoundingRect(ComponentReference);

        Console.WriteLine($"{boundingRect.Top}, {boundingRect.Bottom}, {boundingRect.Left}, {boundingRect.Right}");
    }

    protected override void OnInitialized()
    {
        JsRuntimeService.ScrollYValue
            .Select(yValue => yValue < 100)
            .Where(isFocused => IsFocused != isFocused)
            .Subscribe(isFocused =>
            {
                IsFocused = isFocused;
                StateHasChanged();
            });
    }
}
