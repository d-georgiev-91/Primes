using System;
using Microsoft.AspNetCore.Mvc;
using Primes.Services;
using Primes.Web.Models;

namespace Primes.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrimeNumbersController : ControllerBase
    {
        private readonly IPrimeNumberService _primeNumberService;

        public PrimeNumbersController(IPrimeNumberService primeNumberService) => _primeNumberService = primeNumberService;

        [HttpPost("[action]")]
        public IActionResult IsPrime(IsPrimeRequest isPrimeRequest) =>
            Ok(_primeNumberService.IsPrimeNumber(isPrimeRequest.Number));

        [HttpPost("[action]")]
        public IActionResult NextPrime(NextPrimeRequest nextPrimeRequest) => Ok(_primeNumberService.NextPrimeNumber(nextPrimeRequest.Number));
    }
}
