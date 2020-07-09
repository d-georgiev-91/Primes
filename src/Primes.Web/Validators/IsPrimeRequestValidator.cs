using FluentValidation;
using Primes.Web.Models;

namespace Primes.Web.Validators
{
    /// <summary>
    /// Validator class for <see cref="IsPrimeRequestValidator" />
    /// </summary>
    public class IsPrimeRequestValidator : AbstractValidator<IsPrimeRequest>
    {
        /// <summary>
        /// Create instance of of <see cref="IsPrimeRequest"/>
        /// </summary>
        public IsPrimeRequestValidator()
        {
            RuleFor(isPrimeRequest => isPrimeRequest.Number)
                .GreaterThan(0ul);
        }
    }
}
