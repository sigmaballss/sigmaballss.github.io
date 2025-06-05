using Microsoft.AspNetCore.Components;
using R3;
using SigmaBallssGitHubPage.Blazor.Structs;

namespace SigmaBallssGitHubPage.Blazor.Services.Abstractions;

public interface IJsRuntimeService
{
    public ReadOnlyReactiveProperty<int> ScrollYValue { get; }

    public ValueTask<BoundingRect> GetBoundingRect(ElementReference target);
}
