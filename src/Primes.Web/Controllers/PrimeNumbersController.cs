using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Primes.Services;
using Primes.Web.Models;

namespace Primes.Web.Controllers
{
    /// <summary>
    /// Controller for Prime numbers discovery and verification
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class PrimeNumbersController : ControllerBase
    {
        private readonly IPrimeNumberService _primeNumberService;

        /// <summary>
        /// Creates an instance of <inheritdoc cref="PrimeNumbersController"/>
        /// </summary>
        /// <param name="primeNumberService">Dependency to <inheritdoc cref="IPrimeNumberService"/></param>
        public PrimeNumbersController(IPrimeNumberService primeNumberService) => _primeNumberService = primeNumberService;

        /// <summary>
        /// Returns if a number is a prime or not
        /// </summary>
        /// <param name="isPrimeRequest">Model of type <seealso cref="IsPrimeRequest"/></param>
        /// <returns>
        /// <response code="200">
        /// Returns boolean value showing if number is primer or not
        /// </response>
        /// </returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult IsPrime(IsPrimeRequest isPrimeRequest) =>
            Ok(_primeNumberService.IsPrimeNumber(isPrimeRequest.Number).Data);


        /// <summary>
        /// Find the next prime number greater than the given
        /// </summary>
        /// <param name="nextPrimeRequest">Model of type <seealso cref="NextPrimeRequest"/></param>
        /// <returns>
        /// <response code="400">
        /// Returns error message if next number is out of positive 64 bits integers range
        /// </response>
        /// <response code="200">
        /// Returns ulong value representing the next prime
        /// </response>
        /// </returns>
        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult NextPrime(NextPrimeRequest nextPrimeRequest)
        {

            var result = _primeNumberService.NextPrimeNumber(nextPrimeRequest.Number);

            if (result.Errors.ContainsKey(ErrorType.UnsupportedOperation))
            {
                return BadRequest(result.Errors[ErrorType.UnsupportedOperation].Message);
            }

            return Ok(result.Data);
        }
    }
}
