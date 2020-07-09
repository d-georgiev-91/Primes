using System;
using Microsoft.AspNetCore.Mvc;
using Primes.Web.Models;

namespace Primes.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        [HttpPost("[action]")]
        public IActionResult IsPrime(IsPrimeRequest isPrimeRequest) => throw new NotImplementedException();

        [HttpPost("[action]")]
        public IActionResult NextPrime(NextPrimeRequest nextPrimeRequest) => throw new NotImplementedException();
    }
}
