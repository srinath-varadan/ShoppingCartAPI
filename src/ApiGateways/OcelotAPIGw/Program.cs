using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile($"ocelot.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true);
});


// Add services to the container.
// Add services to the container.
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;



builder.Services.AddOcelot().Services.AddCacheManager();
builder.Services.AddLogging(configure =>
{
    configure.AddConfiguration(configuration.GetSection("Logging"));
    configure.AddDebug();
    configure.AddConsole();
});

var app = builder.Build();
app.UseRouting();
app.MapGet("/", () => "Hello World!");

app.UseOcelot();

app.Run();
