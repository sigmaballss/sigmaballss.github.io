using R3;

namespace SigmaBallssGitHubPage.Blazor.Services.Abstractions;

public interface ICultureProvider
{
    public ReadOnlyReactiveProperty<string> CurrentCulture { get; }

    public void ChangeCurrentCulture(string culture);
}
