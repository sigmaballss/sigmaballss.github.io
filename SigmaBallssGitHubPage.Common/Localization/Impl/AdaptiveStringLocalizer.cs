using System.Globalization;
using Microsoft.Extensions.Localization;

namespace SigmaBallssGitHubPage.Common.Localization.Impl;

public class AdaptiveStringLocalizer<T> : IStringLocalizer<T>
{
    private readonly IStringLocalizerFactory _localizerFactory;

    private readonly Dictionary<string, IStringLocalizer> _localizers = new();

    public AdaptiveStringLocalizer(IStringLocalizerFactory localizerFactory)
    {
        _localizerFactory = localizerFactory;
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        return GetLocalizer().GetAllStrings(includeParentCultures);
    }

    public LocalizedString this[string name] => GetLocalizer()[name];

    public LocalizedString this[string name, params object[] arguments] => GetLocalizer()[name, arguments];

    private IStringLocalizer GetLocalizer()
    {
        var currentCultureName = CultureInfo.CurrentCulture.Name;

        if (_localizers.TryGetValue(currentCultureName, out var localizer) == false)
        {
            localizer = _localizerFactory.Create(typeof(T));
            _localizers.Add(currentCultureName, localizer);
        }

        return localizer;
    }
}
