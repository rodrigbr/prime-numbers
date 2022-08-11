using AutoMapper.QueryableExtensions.Impl;
using FluentValidation.Results;
using MediatR;
using Prime.Numbers.Application.Commands;
using Prime.Numbers.Application.Extensions;
using Prime.Numbers.Application.Helpers;
using Prime.Numbers.Domain.Entites;

namespace Prime.Numbers.Application.CommandHandlers
{
    public class CalculatePrimeNumbersCommandHandler : IRequestHandler<CalculatePrimeNumbersCommand, OperationResult<PrimeNumbersResult>>
    {

        public CalculatePrimeNumbersCommandHandler()
        {

        }

        public async Task<OperationResult<PrimeNumbersResult>> Handle(CalculatePrimeNumbersCommand request, CancellationToken cancellationToken)
        {
            var validationErrors = request.Validate();

            if (validationErrors.Any())
                return validationErrors.ToOperationResult<PrimeNumbersResult>();

            List<int> primes = new List<int>();
            List<int> primeDivisors = new List<int>();

            for (var i = 1; i <= Math.Sqrt(request.Number); i++)
            {
                if (request.Number % i == 0)
                {
                    primeDivisors.Add(i);
                    primes.Add(i);

                    var divisorsCalc = (request.Number / i);
                    if (i != divisorsCalc)
                    {
                        primes.Add(divisorsCalc);
                    }
                }
            }

            primes.Sort();
            primeDivisors.Sort();

            PrimeNumbersResult primeNumbers = new PrimeNumbersResult()
            {
                PrimeDivisorsNumbers = primeDivisors,
                PrimeNumbers = primes
            };

            return OperationResult<PrimeNumbersResult>.CreateSuccess(primeNumbers);
        }
    }
}
