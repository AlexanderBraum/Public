
using Braum.Core.SimpleCqrsMediator.Core;
using Braum.Core.SimpleCqrsMediator.ExampleProject.Example;
using Braum.Core.SimpleCqrsMediator.Interface;

namespace Braum.Core.SimpleCqrsMediator.ExampleProject;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        builder.Services.AddScoped<IQueryProcessor, QueryProcessor>();
        builder.Services.AddScoped<IQueryHandler<ExampleQuery, string>, ExampleQueryHandler>();
        builder.Services.AddScoped<ExampleQuery>();

        var app = builder.Build();
        app.MapOpenApi();
        app.UseSwaggerUi();
        app.UseHttpsRedirection();
        app.MapControllers();
        app.Run();
    }
}