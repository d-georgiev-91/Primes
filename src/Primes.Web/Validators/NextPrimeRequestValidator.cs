using FluentValidation;
using Primes.Web.Models;

namespace Primes.Web.Validators
{
    public class NextPrimeRequestValidator : AbstractValidator<NextPrimeRequest>
    {
        public NextPrimeRequestValidator()
        {
            RuleFor(nextPrimeRequest => nextPrimeRequest.Number)
                .GreaterThan(0ul);
        }
    }
}