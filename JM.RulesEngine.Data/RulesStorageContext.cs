using JM.RulesEngine.Domain;
using Microsoft.EntityFrameworkCore;

namespace JM.RulesEngine.Data
{
    public class RulesStorageContext : DbContext
    {
        public RulesStorageContext(DbContextOptions<RulesStorageContext> options) : base(options)
        {
        }

        public DbSet<RulesEngineWorkflow> Workflows { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<T>().

            builder.Entity<RulesEngineWorkflow>()
                    .HasNoDiscriminator()
                    .ToContainer(nameof(RulesEngineWorkflow))
                    .HasPartitionKey(x => x.References)
                    .HasKey(x => x.Id);
        }
    }
}