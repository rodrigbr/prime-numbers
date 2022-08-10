using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prime.Numbers.Application.CommandHandlers;
using Prime.Numbers.Application.Commands;
using Prime.Numbers.Application.Contracts;
using Prime.Numbers.Application.Helpers;
using Prime.Numbers.Domain.Entites;

namespace Prime.Numbers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class PrimeNumberController : ControllerBase
    {
        private readonly IPrimeNumberApplicationService _primeNumberApplicationService;

        public PrimeNumberController(IPrimeNumberApplicationService primeNumberApplicationService)
        {
            _primeNumberApplicationService = primeNumberApplicationService;
        }

        [HttpPost("CalculatePrimeNumbers")]
        public async Task<OperationResult<PrimeNumbersResult>> CalculatePrimeNumbers([FromBody] CalculatePrimeNumbersCommand dto)
        {
            return await _primeNumberApplicationService.CalculatePrimeNumbers(dto);
        }
    }
}
