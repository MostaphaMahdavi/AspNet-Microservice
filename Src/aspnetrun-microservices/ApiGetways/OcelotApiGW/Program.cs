using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddLogging();
var serviceCollection = new ServiceCollection();
serviceCollection.AddLogging();
var serviceProvider = serviceCollection.BuildServiceProvider();
serviceProvider.GetService<ILogger<Program>>();
app.Logger.LogInformation("Start Application");

builder.Services.AddOcelot();
builder.Configuration.AddJsonFile($"Ocelot.{builder.Environment.EnvironmentName}.json",true,true);


await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();

