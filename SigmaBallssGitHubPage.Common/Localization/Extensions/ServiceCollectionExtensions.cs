using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Localization;
using SigmaBallssGitHubPage.Common.Localization.Impl;

namespace SigmaBallssGitHubPage.Common.Localization.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAdaptiveLocalization(this IServiceCollection services)
    {
        services.AddOptions();

        services.TryAddSingleton<IStringLocalizerFactory, AdaptiveStringLocalizerFactory>();
        services.TryAddTransient(typeof(IStringLocalizer<>), typeof(AdaptiveStringLocalizer<>));

        return services;
    }
}
