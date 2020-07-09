using NUnit.Framework;

namespace Primes.Services.Tests
{
    [TestFixture]
    public class PrimeNumberServiceTests
    {
        private IPrimeNumberService _primeNumberService;

        [SetUp]
        public void SetUp()
        {
            _primeNumberService = new PrimeNumberService();
        }

        [Test]
        public void WhenIsPrimeNumberIsCalledWith1ThenServiceResultWithTrueDataShouldBeReturned()
        {
            var serviceResult = _primeNumberService.IsPrimeNumber(1);
            Assert.That(serviceResult.Data, Is.False);
        }

        [Test]
        public void WhenIsPrimeNumberIsCalledWith2ThenServiceResultWithTrueDataShouldBeReturned()
        {
            var serviceResult = _primeNumberService.IsPrimeNumber(2);
            Assert.That(serviceResult.Data, Is.True);
        }

        [Test]
        public void WhenIsPrimeNumberIsCalledWith4ThenServiceResultWithTrueDataShouldBeReturned()
        {
            var serviceResult = _primeNumberService.IsPrimeNumber(4);
            Assert.That(serviceResult.Data, Is.False);
        }

        [Test]
        public void WhenIsPrimeNumberIsCalledWith8ThenServiceResultWithTrueDataShouldBeReturned()
        {
            var serviceResult = _primeNumberService.IsPrimeNumber(8);
            Assert.That(serviceResult.Data, Is.False);
        }

        [Test]
        public void WhenNextPrimeNumberIsCalledWith1ThenServiceResultWith2DataShouldBeReturned()
        {
            var serviceResult = _primeNumberService.NextPrimeNumber(1);
            Assert.That(serviceResult.Data, Is.EqualTo(2));
        }

        [Test]
        public void WhenNextPrimeNumberIsCalledWith2ThenServiceResultWith3DataShouldBeReturned()
        {
            var serviceResult = _primeNumberService.NextPrimeNumber(2);
            Assert.That(serviceResult.Data, Is.EqualTo(3));
        }

        [Test]
        public void WhenNextPrimeNumberIsCalledWithUlongMaxValueThenServiceResultWithErrorShouldBeReturned()
        {
            var serviceResult = _primeNumberService.NextPrimeNumber(ulong.MaxValue);
            Assert.That(serviceResult.HasErrors, Is.True);
            Assert.That(serviceResult.Errors, Contains.Key(ErrorType.UnsupportedOperation));
        }
    }
}