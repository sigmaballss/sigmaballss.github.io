using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SigmaBallssGitHubPage.Blazor;
using SigmaBallssGitHubPage.Blazor.Services.Abstractions;
using SigmaBallssGitHubPage.Blazor.Services.Impl;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<IJsRuntimeService, JsRuntimeService>();

builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});

await builder.Build().RunAsync();
