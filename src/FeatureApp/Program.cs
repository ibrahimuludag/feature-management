using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FeatureApp
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
                    //webBuilder.ConfigureAppConfiguration(config =>
                    //{
                    //    var settings = config.Build();
                    //    var connectionString = settings.GetConnectionString("AzureAppConfig");
                    //    config.AddAzureAppConfiguration(options => options.Connect(connectionString).UseFeatureFlags(
                    //        f => f.CacheExpirationInterval = TimeSpan.FromSeconds(1)
                    //    ));
                    //});
                    webBuilder.UseStartup<Startup>();
                });
    }
}
