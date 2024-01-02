using JM.RulesEngine.Data;
using JM.RulesEngine.Domain;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Cosmos.Storage.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JM.RulesEngine.Services
{
    public class InitService
    {
        private readonly IDbContextFactory<RulesStorageContext> _contextFactory;

        public InitService(IDbContextFactory<RulesStorageContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task RunSample()
        {
            await RecreateDatabase();
            await AddRules();
        }
        private async Task RecreateDatabase()
        {
            using var context = await _contextFactory.CreateDbContextAsync();

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
        }

        private async Task AddRules()
        {
            var workFlowFile = await File.ReadAllTextAsync("Discount.json");

            var workFlow = JsonConvert.DeserializeObject<WorkflowData>(workFlowFile);

            using var context = await _contextFactory.CreateDbContextAsync();
            //var cosmosClient = context.Database.GetCosmosClient();//.ClientOptions.SerializerOptions.IgnoreNullValues = true;
            //var ser = new JsonCosmosSerializer();
            //ser.

            //var serialzierOptions = new CosmosSerializationOptions()
            //{
            //    IgnoreNullValues = true
            //};
            //cosmosClient.ClientOptions.SerializerOptions = serialzierOptions;
            //cosmosClient.ClientOptions.SerializerOptions.IgnoreNullValues = true;
            if (workFlow != null)
            {
                context.Add(workFlow);
            }

            await context.SaveChangesAsync();
        }
    }
}
