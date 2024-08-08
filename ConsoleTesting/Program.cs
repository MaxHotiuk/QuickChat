using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuickChat.Shared.Controllers;
using QuickChat.Shared.Data;
using QuickChat.Shared.Data.InitDataFactory;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;


namespace QuickChat.ConsoleTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            // Setup DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IConfiguration>(configuration)
                .AddDbContext<QuickChatDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")))
                .AddScoped<DBLoadController>()  // Add DBLoadController with its dependencies
                .BuildServiceProvider();

            // Resolve the controller and use it
            var dbLoadController = serviceProvider.GetRequiredService<DBLoadController>();

            // Call methods on dbLoadController as needed
            // e.g., dbLoadController.LoadData();

            // For example, we'll just write to console
            Console.WriteLine("DBLoadController has been resolved successfully.");
        }
    }
}