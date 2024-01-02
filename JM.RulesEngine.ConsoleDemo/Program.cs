using JM.RulesEngine.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace JM.RulesEngine.ConsoleDemo
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");


            var config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json")
                  .Build();

            var cosmosConnectionString = config["CosmosConnectionString"];

            var services = new ServiceCollection();



            services.AddDbContextFactory<JM.RulesEngine.Data.RulesStorageContext>(optionsBuilder =>
              optionsBuilder
                .UseCosmos(
                  connectionString: cosmosConnectionString,
                  databaseName: "RulesEngineDb",
                  cosmosOptionsAction: options =>
                  {
                      options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
                      options.MaxRequestsPerTcpConnection(20);
                      options.MaxTcpConnectionsPerEndpoint(32);
                  }));

            services.AddTransient<InitService>();
            using var serviceProvider = services.BuildServiceProvider();
            var initService = serviceProvider.GetRequiredService<InitService>();

            await initService.RunSample();
        }
    }
}
