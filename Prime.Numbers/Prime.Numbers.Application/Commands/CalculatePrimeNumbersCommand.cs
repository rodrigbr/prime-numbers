using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Prime.Numbers.Application.Helpers;
using Prime.Numbers.Domain.Entites;

namespace Prime.Numbers.Application.Commands
{
    public class CalculatePrimeNumbersCommand : BaseCQ, IRequest<OperationResult<PrimeNumbersResult>>
    {
        [CommandRequired]
        public int Number { get; set; }
    }
}
