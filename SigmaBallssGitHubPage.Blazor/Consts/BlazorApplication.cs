using System.Globalization;

namespace SigmaBallssGitHubPage.Blazor.Consts;

public static class BlazorApplication
{
    public static readonly CultureInfo[] SupportedCultures =
    [
        CultureInfo.CreateSpecificCulture("ru"),
        CultureInfo.CreateSpecificCulture("en"),
    ];
}
