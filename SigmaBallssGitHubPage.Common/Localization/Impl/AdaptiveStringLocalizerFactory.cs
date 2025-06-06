using System.Globalization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace SigmaBallssGitHubPage.Common.Localization.Impl;

public class AdaptiveStringLocalizerFactory : IStringLocalizerFactory
{
    private readonly IOptions<LocalizationOptions> _localizationOptions;
    private readonly ILoggerFactory _loggerFactory;

    private readonly Dictionary<string, IStringLocalizerFactory> _localizerFactories = new();

    public AdaptiveStringLocalizerFactory(
        IOptions<LocalizationOptions> localizationOptions,
        ILoggerFactory loggerFactory)
    {
        _localizationOptions = localizationOptions;
        _loggerFactory = loggerFactory;
    }

    public IStringLocalizer Create(Type resourceSource) => GetLocalizerFactory().Create(resourceSource);

    public IStringLocalizer Create(string baseName, string location) => GetLocalizerFactory().Create(baseName, location);

    private IStringLocalizerFactory GetLocalizerFactory()
    {
        var currentCultureName = CultureInfo.CurrentCulture.Name;

        if (_localizerFactories.TryGetValue(currentCultureName, out var localizerFactory) == false)
        {
            localizerFactory = new ResourceManagerStringLocalizerFactory(_localizationOptions, _loggerFactory);
            _localizerFactories.Add(currentCultureName, localizerFactory);
        }

        return localizerFactory;
    }
}
