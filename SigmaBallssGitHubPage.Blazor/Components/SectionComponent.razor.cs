using Microsoft.AspNetCore.Components;

namespace SigmaBallssGitHubPage.Blazor.Components;

public partial class SectionComponent : ComponentBase
{
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await Task.Delay(1000);
        SectionClass = "focused-section";
    }

    private string SectionClass { get; set; } = string.Empty;
}
