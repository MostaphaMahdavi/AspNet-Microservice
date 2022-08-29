using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);



//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

//builder.Services.AddLogging();
//var serviceCollection = new ServiceCollection();
//serviceCollection.AddLogging();
//var serviceProvider = serviceCollection.BuildServiceProvider();
//serviceProvider.GetService<ILogger<Program>>();



builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());
builder.Configuration.AddJsonFile($"Ocelot.{builder.Environment.EnvironmentName}.json", true, true);
//builder.Configuration.AddJsonFile($"Ocelot.Local.json", true, true);
var app = builder.Build();

await app.UseOcelot();

app.MapGet("/", () => "Hello World!");

app.Run();

