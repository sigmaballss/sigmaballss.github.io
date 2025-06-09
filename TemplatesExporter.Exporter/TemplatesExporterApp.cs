using Microsoft.Extensions.DependencyInjection;
using RazorLight;
using TemplatesExporter.Exporter.Structs;

namespace TemplatesExporter.Exporter;

public class TemplatesExporterApp(
    TemplateExportParams[] exportParams,
    IServiceProvider serviceProvider)
{
    public async Task Run()
    {
        await Parallel.ForEachAsync(exportParams, async (exportParam, cancellationToken) =>
        {
            await using var scope = serviceProvider.CreateAsyncScope();

            var engine = scope.ServiceProvider.GetRequiredService<IRazorLightEngine>();

            var resolvedTemplate = await engine.CompileRenderAsync(
                key: GetTemplateKey(exportParam.Model),
                exportParam.Model);

            await File.WriteAllTextAsync(exportParam.PathToSave, resolvedTemplate, cancellationToken);
        });

        Console.WriteLine("Completed successfully");
    }

    private string GetTemplateKey(object model)
    {
        return model.GetType().Name.Replace("Model", "");
    }
}
