using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NUnit.Framework;
using Primes.Services;
using Primes.Web.Controllers;
using Primes.Web.Models;

namespace Primes.Web.Tests.Controllers
{
    [TestFixture]
    public class PrimeNumbersControllerTests
    {
        private IPrimeNumberService _primeNumberService;
        private PrimeNumbersController _primeNumbersController;


        [SetUp]
        public void SetUp()
        {
            _primeNumberService = Substitute.For<IPrimeNumberService>();
            _primeNumbersController = new PrimeNumbersController(_primeNumberService);
        }

        [Test]
        public void WhenIsPrimeIsCalledWith5TrueShouldBeReturned()
        {
            var request = new IsPrimeRequest
            {
                Number = 5
            };

            _primeNumberService.IsPrimeNumber(Arg.Any<ulong>())
                .Returns(new ServiceResult<bool> { Data = true });
            var result = _primeNumbersController.IsPrime(request) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.True);
        }

        [Test]
        public void WhenIsPrimeIsCalledWith4FalseShouldBeReturned()
        {
            var request = new IsPrimeRequest
            {
                Number = 4
            };

            _primeNumberService.IsPrimeNumber(Arg.Any<ulong>())
                .Returns(new ServiceResult<bool> { Data = false });
            var result = _primeNumbersController.IsPrime(request) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.False);
        }

        [Test]
        public void WhenNextPrimeIsCalledWith4ThenOkObjectResultWith5ShouldBeReturned()
        {
            var request = new NextPrimeRequest()
            {
                Number = 4
            };

            var serviceResult = new ServiceResult<ulong>
            {
                Data = 5
            };

            _primeNumberService.NextPrimeNumber(Arg.Any<ulong>())
                .Returns(serviceResult);


            var result = _primeNumbersController.NextPrime(request) as OkObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.EqualTo(5));
        }

        [Test]
        public void WhenNextPrimeIsCalledWithUlongMaxValueThenBadRequestObjectResultWithMessageShouldBeReturned()
        {
            var request = new NextPrimeRequest()
            {
                Number = ulong.MaxValue
            };

            var error = new ServiceResultError(ErrorType.UnsupportedOperation, "Message");

            var serviceResult = new ServiceResult<ulong>();
            serviceResult.AddError(error);

            _primeNumberService.NextPrimeNumber(Arg.Any<ulong>())
                .Returns(serviceResult);

            var result = _primeNumbersController.NextPrime(request) as BadRequestObjectResult;
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Value, Is.EqualTo(serviceResult.Errors[ErrorType.UnsupportedOperation].Message));
        }
    }
}