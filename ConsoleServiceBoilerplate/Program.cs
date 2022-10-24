using ConsoleServiceBoilerplate;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

Log.Information("Starting host");

try
{
    var host = Host.CreateDefaultBuilder(args)
        .UseSerilog((ctx, lc) => lc
          .ReadFrom.Configuration(ctx.Configuration))
        .ConfigureServices(Startup.ConfigureServices)
        .ConfigureServices(services => services.AddSingleton<Runner>())
        .Build();

    var runner = host.Services
        .GetRequiredService<Runner>()
        .RunAsync();

    await runner;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}