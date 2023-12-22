using FastEndpoints;
using FastEndpoints.Swagger;

namespace FE.PoC.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        services.AddFastEndpoints()
            .SwaggerDocument(opt => { opt.DocumentSettings = s => { s.DocumentName = "v1"; }; });
        var app = builder.Build();

        app.UseFastEndpoints()
            .UseSwaggerGen(settings =>
            {
                settings.Path = "/{documentName}/schema.json";
            }, uiSettings =>
            {
                uiSettings.DocumentPath = "/{documentName}/schema.json";
                uiSettings.DocExpansion = "list";
            });

        app.Run();
    }
}