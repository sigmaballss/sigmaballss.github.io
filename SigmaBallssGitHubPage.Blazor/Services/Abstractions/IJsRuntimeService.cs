using System.Numerics;
using Microsoft.AspNetCore.Components;
using R3;
using SigmaBallssGitHubPage.Blazor.Structs;

namespace SigmaBallssGitHubPage.Blazor.Services.Abstractions;

public interface IJsRuntimeService
{
    public ReadOnlyReactiveProperty<int> ScrollYValue { get; }

    public ReadOnlyReactiveProperty<Vector2> ScreenSize { get; }

    public ValueTask<BoundingRect> GetBoundingRect(ElementReference target);
}
