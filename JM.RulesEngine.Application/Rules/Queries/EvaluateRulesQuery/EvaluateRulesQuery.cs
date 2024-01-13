using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JM.RulesEngine.Application.Rules.Queries.EvaluateRulesQuery
{
    public class EvaluateRulesQuery : IRequest<EvaluateRulesQueryResponse>
    {
        public dynamic Input { get; set; }
    }
}
