using RulesEngine.Actions;
using RulesEngine.Models;

namespace JM.RulesEngine.Domain
{
    public class RulesEngineWorkflow
    {
        public RulesEngineWorkflow()
        {            
        }
        public int Id { get; set; }
        public Guid UId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Workflow Workflow { get; set; }      
        public int CustomerId { get; set; }
        
        public DateTime Created { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? Updated { get; set; }
        public int? UpdatedBy { get; set; }
        public string CssIcon { get; set; }
        public string EditModel { get; set; }
       
        public bool Enabled { get; set; }
        public ICollection<string> Properties { get; set; }
        public string References { get; set; }
    }

    //public static class RulesEngineActions
    //{
    //    public static Dictionary<string, Func<ActionBase>> Actions = new Dictionary<string, Func<ActionBase>>{
    //                                                                    {"SendEmail", () => new SendEmailAction() },
    //                                                                    {"CreateAlert", () => new CreateAlertAction() }
    //                                                                };
    //}
}