using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace JM.RulesEngine.ConsoleDemo
{
    internal class Program
    {
        static void Main(string[] args)
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
        }
    }
}
