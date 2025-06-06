using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using R3;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;

namespace SigmaBallssGitHubPage.Blazor.Pages;

public partial class Home : IDisposable
{
    private const string EnCulture = "en";
    private const string RuCulture = "ru";
    private string _currentCulture = EnCulture;
    private IDisposable? _observers;

    [Inject]
    public required ICultureProvider CultureProvider { get; set; }

    [Inject]
    public required IStringLocalizer<HomeResources> PageLocalizer { get; set; }

    protected override void OnInitialized()
    {
        _observers = CultureProvider.CurrentCulture
            .Subscribe(_ => StateHasChanged());
    }

    public void Dispose()
    {
        _observers?.Dispose();
    }

    private void ChangeLanguage_OnClick()
    {
        _currentCulture = _currentCulture == EnCulture
            ? RuCulture
            : EnCulture;

        CultureProvider.ChangeCurrentCulture(_currentCulture);
    }
}
