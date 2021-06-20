using DatingApp.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatingApp
{
    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    CreateHostBuilder(args).Build().Run();
        //}
        public static async Task Main(string[] args)
        {
           var Host = CreateHostBuilder(args).Build();
            using var Scope = Host.Services.CreateScope();
            var Services = Scope.ServiceProvider;

            try
            {
                var Context = Services.GetRequiredService<DataContext>();
                await Context.Database.MigrateAsync();
                await Seed.SeedUser(Context);
            }
            catch (Exception ex)
            {

                var logger = Services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex,"An Errror Ocuured During Migration");
            }
            await Host.RunAsync();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
