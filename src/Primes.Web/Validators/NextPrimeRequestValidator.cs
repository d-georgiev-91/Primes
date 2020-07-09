using FluentValidation;
using Primes.Web.Models;

namespace Primes.Web.Validators
{
    /// <summary>
    /// Validator class for <see cref="NextPrimeRequest" />
    /// </summary>
    public class NextPrimeRequestValidator : AbstractValidator<NextPrimeRequest>
    {
        /// <summary>
        /// Create instance of of <see cref="NextPrimeRequestValidator"/>
        /// </summary>
        public NextPrimeRequestValidator()
        {
            RuleFor(nextPrimeRequest => nextPrimeRequest.Number)
                .GreaterThan(0ul);
        }
    }
}