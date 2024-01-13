using FluentValidation;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JM.RulesEngine.Application.Rules.Queries.EvaluateRulesQuery
{
    public class EvaluateRulesQueryValidator : AbstractValidator<EvaluateRulesQuery>
    {
        public EvaluateRulesQueryValidator()
        {

        }
    }
}
