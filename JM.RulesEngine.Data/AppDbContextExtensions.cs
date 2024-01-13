using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JM.RulesEngine.Data
{
    public static class AppDbContextExtensions
    {
        public static void AddApplicationDbContext(this IServiceCollection services, string connectionString)
        {
            

            services.AddDbContextFactory<RulesStorageContext>(optionsBuilder =>
  optionsBuilder
    .UseCosmos(
      connectionString: connectionString,
      databaseName: "rules-evaluator",
      cosmosOptionsAction: options =>
      {
          options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
          options.MaxRequestsPerTcpConnection(20);
          options.MaxTcpConnectionsPerEndpoint(32);
      }));
        }
    }
}
