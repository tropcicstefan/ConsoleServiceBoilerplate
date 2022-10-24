using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConsoleServiceBoilerplate;

public static class Startup
{
    public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
    {
        Console.WriteLine(context.Configuration.GetSection("test").Get<string>());
    }
}
