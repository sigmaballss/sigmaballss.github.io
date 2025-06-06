using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SigmaBallssGitHubPage.Blazor;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;
using SigmaBallssGitHubPage.Blazor.Services.Impl;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLocalization();

builder.Services.AddSingleton<IJsRuntimeService, JsRuntimeService>();
builder.Services.AddSingleton<ICultureProvider, CultureProvider>();

#region Localization resources fix

// Get current localization culture
var currentCulture = CultureInfo.DefaultThreadCurrentCulture;

// Get WASM culture provider via reflection
var type = Assembly.GetAssembly(typeof(WebAssemblyHost))!.GetType("Microsoft.AspNetCore.Components.WebAssembly.Hosting.WebAssemblyCultureProvider");
var instance  = type
    !.GetProperty("Instance", BindingFlags.Public | BindingFlags.Static)
    ?.GetValue(null);

var cultureInfo = CultureInfo.CreateSpecificCulture("ru");

// Swap out the "current culture" for the UI (localization) culture
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
// Load the satellite assemblies
await (ValueTask)instance!
    .GetType()
    .GetMethod("LoadCurrentCultureResourcesAsync", BindingFlags.Public | BindingFlags.Instance)!
    .Invoke(instance, [])!;
// Swap the culture back
CultureInfo.DefaultThreadCurrentCulture = currentCulture;

#endregion

await builder.Build().RunAsync();
