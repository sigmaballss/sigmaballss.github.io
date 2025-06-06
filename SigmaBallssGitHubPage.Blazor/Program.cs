using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SigmaBallssGitHubPage.Blazor;
using SigmaBallssGitHubPage.Blazor.Consts;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;
using SigmaBallssGitHubPage.Blazor.Services.Impl;
using SigmaBallssGitHubPage.Common.Helpers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddLocalization();

builder.Services.AddSingleton<IJsRuntimeService, JsRuntimeService>();
builder.Services.AddSingleton<ICultureProvider, CultureProvider>();

await WebAssemblyCultureResourcesHelper.LoadResourcesForCultures(BlazorApplication.SupportedCultures);

await builder.Build().RunAsync();
