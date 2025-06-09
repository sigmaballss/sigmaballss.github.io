using RazorLight;
using RazorLight.Extensions;
using TemplatesBuilder.Builder;
using TemplatesBuilder.Content;
using TemplatesBuilder.Content.Models;
using TemplatesBuilder.Structs;

var builder = new TemplatesExporterAppBuilder();

builder.Services.AddRazorLight(() => new RazorLightEngineBuilder()
    .UseEmbeddedResourcesProject(
        typeof(TemplatesContentAssemblyPointer).Assembly,
        rootNamespace: "TemplatesBuilder.Content.Templates")
    .UseMemoryCachingProvider()
    .Build());

builder.AddExport(new TemplateExportParams
{
    Model = new LogsModel
    {
        Text = "Text"
    },
    PathToSave = Path.Combine(Directory.GetCurrentDirectory(), "logs.html")
});

await builder.Build().Run();
