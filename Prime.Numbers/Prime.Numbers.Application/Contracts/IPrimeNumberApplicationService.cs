using Prime.Numbers.Application.Commands;
using Prime.Numbers.Application.Helpers;
using Prime.Numbers.Domain.Entites;

namespace Prime.Numbers.Application.Contracts
{
    public interface IPrimeNumberApplicationService
    {
        Task<OperationResult<PrimeNumbersResult>> CalculatePrimeNumbers(CalculatePrimeNumbersCommand dto);     
    }
}
