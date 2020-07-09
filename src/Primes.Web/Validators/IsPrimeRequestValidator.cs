using FluentValidation;
using Primes.Web.Models;

namespace Primes.Web.Validators
{
    public class IsPrimeRequestValidator : AbstractValidator<IsPrimeRequest>
    {
        public IsPrimeRequestValidator()
        {
            RuleFor(isPrimeRequest => isPrimeRequest.Number)
                .GreaterThan(0ul);
        }
    }
}
