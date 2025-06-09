using RazorLight;
using RazorLight.Extensions;
using TemplatesBuilder.Models;
using TemplatesExporter.Exporter;
using TemplatesExporter.Exporter.Structs;

var builder = new TemplatesExporterAppBuilder();

builder.Services.AddRazorLight(() => new RazorLightEngineBuilder()
    .UseEmbeddedResourcesProject(
        typeof(Program).Assembly,
        rootNamespace: nameof(TemplatesBuilder))
    .UseMemoryCachingProvider()
    .Build());

builder
    .UseTemplateKeySelector(model => string.Join('.',
        "Templates",
        TemplatesExporterAppBuilder.DefaultTemplateKeySelector(model)))
    .AddExport(new TemplateExportParams
    {
        Model = new LogsModel
        {
            Text = "Text"
        },
        PathToSave = Path.Combine(Directory.GetCurrentDirectory(), "logs.html")
    });

await builder.Build().Run();
