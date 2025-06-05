using R3;

namespace SigmaBallssGitHubPage.Blazor.Services.Abstractions;

public interface IJsRuntimeService
{
    public ReadOnlyReactiveProperty<int> ScrollYValue { get; }
}
