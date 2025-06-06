using System.Globalization;
using R3;

namespace SigmaBallssGitHubPage.Blazor.Services.Abstractions;

public interface ICultureProvider
{
    public ReadOnlyReactiveProperty<CultureInfo> CurrentCulture { get; }

    public void ChangeCurrentCulture(CultureInfo culture);
}
