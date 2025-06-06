using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace SigmaBallssGitHubPage.Common.Helpers;

public static class WebAssemblyCultureResourcesHelper
{
    public static async Task LoadResourcesForCultures(CultureInfo[] cultureInfos)
    {
        var cultureToRollback = CultureInfo.DefaultThreadCurrentCulture;

        var type = Assembly.GetAssembly(typeof(WebAssemblyHost))!.GetType(
            "Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyCultureProvider");

        var webAssemblyCultureProvider = type!
            .GetProperty("Instance", BindingFlags.Public | BindingFlags.Static)
            ?.GetValue(null);

        foreach (var cultureInfo in cultureInfos)
        {
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;

            await (ValueTask)webAssemblyCultureProvider!
                .GetType()
                .GetMethod("LoadCurrentCultureResourcesAsync", BindingFlags.Public | BindingFlags.Instance)!
                .Invoke(webAssemblyCultureProvider, [])!;
        }

        CultureInfo.DefaultThreadCurrentCulture = cultureToRollback;
    }
}
