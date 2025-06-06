using Microsoft.Extensions.DependencyInjection;
using SigmaBallssGitHubPage.Common.JsRuntime.Abstractions;
using SigmaBallssGitHubPage.Common.JsRuntime.Impl;

namespace SigmaBallssGitHubPage.Common.JsRuntime.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddJsRuntimeService(this IServiceCollection services)
    {
        services.AddSingleton<IJsRuntimeService, JsRuntimeService>();

        return services;
    }
}
