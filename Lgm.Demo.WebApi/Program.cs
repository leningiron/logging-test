using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Lgm.Demo.Logger;
namespace Lgm.Demo.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureLogging((hostBuilderContext, logging) =>
            {
                logging.AddFileLogger(options =>
                {
                    hostBuilderContext.Configuration.GetSection("Logging").GetSection("TheFileLogger").GetSection("Options").Bind(options);
                });
            });
    }
}
