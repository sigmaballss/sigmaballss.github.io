using System.Globalization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SigmaBallssGitHubPage.Blazor;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;
using SigmaBallssGitHubPage.Blazor.Services.Impl;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var cultureInfo = CultureInfo.CreateSpecificCulture("ru");

builder.Services.AddLocalization();

builder.Services.AddSingleton<IJsRuntimeService, JsRuntimeService>();
builder.Services.AddSingleton<ICultureProvider, CultureProvider>();

await builder.Build().RunAsync();
