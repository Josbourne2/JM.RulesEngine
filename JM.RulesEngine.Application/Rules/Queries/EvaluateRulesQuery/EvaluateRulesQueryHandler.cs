using JM.RulesEngine.Data;
using MediatR;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JM.RulesEngine.Application.Rules.Queries.EvaluateRulesQuery
{
    public class EvaluateRulesQueryHandler : IRequestHandler<EvaluateRulesQuery, EvaluateRulesQueryResponse>
    {
        private readonly RulesStorageContext _context;

        public EvaluateRulesQueryHandler(RulesStorageContext context)
        {
            _context = context;
        }

        public async Task<EvaluateRulesQueryResponse> Handle(EvaluateRulesQuery request, CancellationToken cancellationToken)
        {
            var validator = new EvaluateRulesQueryValidator();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                throw new ValidationException(result.ToString());
            }

            //Get rules
            var rules = await _context.Workflows().ToListAsync(cancellationToken);


            //Filter rules by property

            //Evaluate rules

            //Return result



            throw new NotImplementedException();
        }
    }
}
