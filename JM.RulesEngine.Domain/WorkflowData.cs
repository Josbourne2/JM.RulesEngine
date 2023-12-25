using Newtonsoft.Json;
using RulesEngine.Models;

namespace JM.RulesEngine.Domain
{
    public class WorkflowData : Workflow
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string References { get; set; }
        public string ReferenceId { get; set; }
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> GlobalParams { get; set; }
        public new string WorkflowName { get; set; }

        [JsonIgnore]
        public int Seq { get; set; }
    }

    public class RuleData : Rule
    {
        public new List<RuleData> Rules { get; set; }
        public new List<ScopedParamData> LocalParams { get; set; }

        [JsonIgnore]
        public bool? IsSuccess { get; set; }

        [JsonIgnore]
        public string ExceptionMessage { get; set; }

        [JsonIgnore]
        public int Seq { get; set; }
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