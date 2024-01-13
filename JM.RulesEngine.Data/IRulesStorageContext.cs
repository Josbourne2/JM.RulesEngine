using JM.RulesEngine.Domain;
using Microsoft.EntityFrameworkCore;

namespace JM.RulesEngine.Data
{
    public interface IRulesStorageContext
    {
        DbSet<RulesEngineWorkflow> Workflows { get; set; }
    }
}