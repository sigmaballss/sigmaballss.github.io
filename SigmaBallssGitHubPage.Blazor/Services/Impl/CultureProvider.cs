using System.Globalization;
using R3;
using SigmaBallssGitHubPage.Blazor.Consts;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;

namespace SigmaBallssGitHubPage.Blazor.Services.Impl;

public class CultureProvider : ICultureProvider
{
    private readonly ReactiveProperty<CultureInfo> _currentCultureProperty = new(CultureInfo.CurrentCulture);

    public ReadOnlyReactiveProperty<CultureInfo> CurrentCulture => _currentCultureProperty;

    public void ChangeCurrentCulture(CultureInfo culture)
    {
        if (BlazorApplication.SupportedCultures.Contains(culture) == false)
        {
            throw new NotSupportedException($"Culture '{culture}' is not supported");
        }

        CultureInfo.CurrentCulture = culture;
        CultureInfo.CurrentUICulture = culture;

        _currentCultureProperty.Value = culture;
    }
}
