using System.Globalization;
using R3;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;

namespace SigmaBallssGitHubPage.Blazor.Services.Impl;

public class CultureProvider : ICultureProvider
{
    private readonly ReactiveProperty<string> _currentReactiveProperty = new(CultureInfo.CurrentCulture.Name);

    public ReadOnlyReactiveProperty<string> CurrentCulture => _currentReactiveProperty;

    public void ChangeCurrentCulture(string culture)
    {
        var cultureInfo = CultureInfo.CreateSpecificCulture(culture);

        CultureInfo.CurrentCulture = cultureInfo;
        CultureInfo.CurrentUICulture = cultureInfo;

        _currentReactiveProperty.Value = culture;
    }
}
