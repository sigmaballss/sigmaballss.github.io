using Microsoft.Extensions.DependencyInjection;
using TemplatesBuilder.Structs;

namespace TemplatesBuilder.Builder;

public class TemplatesExporterAppBuilder
{
    private readonly List<TemplateExportParams> _exportParams = new();
    private readonly ServiceCollection _serviceCollection = new();

    public IServiceCollection Services => _serviceCollection;

    public void AddExport(TemplateExportParams args)
    {
        _exportParams.Add(args);
    }

    public TemplatesExporterApp Build()
    {
        return new TemplatesExporterApp(
            _exportParams.ToArray(),
            Services.BuildServiceProvider());
    }
}
