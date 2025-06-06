using System.Numerics;
using Microsoft.AspNetCore.Components;
using R3;
using SigmaBallssGitHubPage.Common.JsRuntime.Structs;

namespace SigmaBallssGitHubPage.Common.JsRuntime.Abstractions;

public interface IJsRuntimeService
{
    public ReadOnlyReactiveProperty<int> ScrollYValue { get; }

    public ReadOnlyReactiveProperty<Vector2> ScreenSize { get; }

    public ValueTask<BoundingRect> GetBoundingRect(ElementReference target);
}
