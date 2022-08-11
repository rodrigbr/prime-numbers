using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prime.Numbers.Application.CommandHandlers;
using Prime.Numbers.Application.Commands;
using Prime.Numbers.Application.Helpers;
using Prime.Numbers.Domain.Entites;
using Shouldly;
using Xunit;

namespace Prime.Numbers.Application.Tests.LeaveTypes.Queries
{
    public class CalculatePrimeNumbersCommandHandlerTest
    {

        [Fact]
        public async Task GetPrimeNumberTypeTest()
        {
            int number = 45;
            var handler = new CalculatePrimeNumbersCommandHandler();

            var result = await handler.Handle(new CalculatePrimeNumbersCommand() { Number = number }, CancellationToken.None);

            result.ShouldBeOfType<OperationResult<PrimeNumbersResult>>();
        }

        [Fact]
        public async Task GetPrimeNumberDivisorsPositiveTest()
        {
            int number = 45;
            var handler = new CalculatePrimeNumbersCommandHandler();

            var result = await handler.Handle(new CalculatePrimeNumbersCommand() { Number = number }, CancellationToken.None);

            foreach (var primeDvsr in result.Object.PrimeDivisorsNumbers)
            {
                primeDvsr.ShouldBePositive();
            }
        }

        [Fact]
        public async Task GetPrimeNumberPositiveTest()
        {
            int number = 45;
            var handler = new CalculatePrimeNumbersCommandHandler();

            var result = await handler.Handle(new CalculatePrimeNumbersCommand() { Number = number }, CancellationToken.None);

            foreach (var primeNmbr in result.Object.PrimeNumbers)
            {
                primeNmbr.ShouldBePositive();
            }
        }

        [Fact]
        public async Task GetPrimeNumberTest()
        {
            int number = 45;
            var handler = new CalculatePrimeNumbersCommandHandler();

            var result = await handler.Handle(new CalculatePrimeNumbersCommand() { Number = number }, CancellationToken.None);

            result.Object.PrimeNumbers.Last().ShouldBe(number);
        }
    }
}
