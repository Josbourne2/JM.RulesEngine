using Newtonsoft.Json;
using RulesEngine.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace JM.RulesEngine.Domain
{
    public class WorkflowData : Workflow
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string References { get; set; }
        public string ReferenceId { get; set; }
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> GlobalParams { get; set; }
        public new string WorkflowName { get; set; }
        [NotMapped]
        public new IEnumerable<string> WorkflowsToInject { get; set; }

        [JsonIgnore]
        public int Seq { get; set; }
    }

    public class RuleData : Rule
    {
        public string References { get; set; }
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> LocalParams { get; set; }

        [JsonIgnore]
        public bool? IsSuccess { get; set; }

        [JsonIgnore]
        public string ExceptionMessage { get; set; }

        [JsonIgnore]
        public int Seq { get; set; }

        [NotMapped]
        public new IEnumerable<string> WorkflowsToInject { get; set; }
    }

    /// <summary>
    /// ScopedParamData - inherited class to continue naming convention / reserve future functionality
    /// </summary>
    public class ScopedParamData : ScopedParam
    {
        /// <summary>
        /// Reserved for Database / Entity Framework implementations
        /// </summary>
        [JsonIgnore]
        public int? Id { get; set; }

        [JsonIgnore]
        public int Seq { get; set; }
    }
}