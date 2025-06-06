using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using R3;
using SigmaBallssGitHubPage.Blazor.Consts;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;

namespace SigmaBallssGitHubPage.Blazor.Pages;

public partial class Home : IDisposable
{
    private int _cultureIndexCounter;
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
        _cultureIndexCounter = (_cultureIndexCounter + 1) % BlazorApplication.SupportedCultures.Length;

        CultureProvider.ChangeCurrentCulture(BlazorApplication.SupportedCultures[_cultureIndexCounter]);
    }
}
