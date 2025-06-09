using Microsoft.Extensions.DependencyInjection;
using TemplatesExporter.Exporter.Structs;

namespace TemplatesExporter.Exporter;

public class TemplatesExporterAppBuilder
{
    private readonly List<TemplateExportParams> _exportParams = new();
    private readonly ServiceCollection _serviceCollection = new();

    private TemplateKeySelectorDelegate _templateKeySelectorDelegate = DefaultTemplateKeySelector;

    public IServiceCollection Services => _serviceCollection;

    public TemplatesExporterAppBuilder AddExport(TemplateExportParams args)
    {
        _exportParams.Add(args);

        return this;
    }

    public TemplatesExporterAppBuilder UseTemplateKeySelector(TemplateKeySelectorDelegate templateKeySelector)
    {
        _templateKeySelectorDelegate = templateKeySelector;

        return this;
    }

    public TemplatesExporterApp Build()
    {
        return new TemplatesExporterApp(
            _exportParams.ToArray(),
            Services.BuildServiceProvider(),
            _templateKeySelectorDelegate);
    }

    public static string DefaultTemplateKeySelector(object model)
    {
        return model.GetType().Name.Replace("Model", "");
    }
}

public delegate string TemplateKeySelectorDelegate(object model);
