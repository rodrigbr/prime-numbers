using MediatR;
using Prime.Numbers.Application.Commands;
using Prime.Numbers.Application.Contracts;
using Prime.Numbers.Application.Helpers;
using Prime.Numbers.Domain.Entites;

namespace Prime.Numbers.Application.Implementations
{
    public class PrimeNumberApplicationService : IPrimeNumberApplicationService
    {
        private readonly IMediator _mediator;

        public PrimeNumberApplicationService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<OperationResult<PrimeNumbersResult>> CalculatePrimeNumbers(CalculatePrimeNumbersCommand dto)
        {
            return await _mediator.Send(dto);
        }
    }
}
