using System;
using Microsoft.AspNetCore.Mvc;

namespace Primes.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GatewayController : ControllerBase
    {
        [HttpPost("[action]/{number}")]
        public IActionResult IsPrime(ulong number) => throw new NotImplementedException();

        [HttpPost("[action]/{number}")]
        public IActionResult NextPrime(ulong number) => throw new NotImplementedException();
    }
}
