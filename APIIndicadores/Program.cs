using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace APIIndicadores
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    var settings = config.Build();
                    config.AddAzureKeyVault(
                        settings["AzureKeyVault:DNS"],
                        settings["AzureKeyVault:ClientId"],
                        settings["AzureKeyVault:ClientSecret"]);

                    settings = config.Build();
                    config.AddAzureAppConfiguration(options =>
                    {
                        options.Connect(settings["ConnectionStrings:AppConfiguration"])
                            .ConfigureRefresh(refresh =>
                            {
                                refresh.Register("Indicadores:SalarioMinimo");
                                refresh.Register("Indicadores:SELIC");
                                refresh.Register("Indicadores:IPCA");
                            });
                    });
                })     
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}