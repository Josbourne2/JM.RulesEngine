using JM.RulesEngine.Domain;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using RulesEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JM.RulesEngine.Data
{
    public class RulesStorageContext : DbContext
    {
        public RulesStorageContext(DbContextOptions<RulesStorageContext> options) : base(options)
        {
        }

        public DbSet<WorkflowData> Workflows { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.Entity<WorkflowData>()
                    .HasNoDiscriminator()
                    .ToContainer(nameof(WorkflowData))
                    .HasPartitionKey( x=>x.References)                    
                    .HasKey(x => x.Id);
        }
    }
}