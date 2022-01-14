using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TournamentAdministration.Data;

namespace TournamentAdministration
{
    public class Program
    {
        //private readonly UserManager<IdentityUser> userManager;
        //private readonly TournamentAdminContext database;
        //public Program(TournamentAdminContext database, UserManager<IdentityUser> userManager)
        //{
        //    this.database = database;
        //    this.userManager = userManager;
        //}

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await CreateDbIfNotExists(host);
            host.Run();
        }

        public static async Task CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<TournamentAdminContext>();
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    await Dbinitializer.InitializeAsync(context, userManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
