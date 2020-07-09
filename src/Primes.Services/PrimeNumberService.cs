using System;

namespace Primes.Services
{
    /// <inheritdoc cref="IPrimeNumberService"/>
    public class PrimeNumberService : IPrimeNumberService
    {
        /// <inheritdoc cref="IPrimeNumberService.IsPrimeNumber"/>
        public ServiceResult<bool> IsPrimeNumber(ulong number)
        {
            if (number <= 3)
            {
                return ServiceResult<bool>.Create(number > 1);
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return ServiceResult<bool>.Create(false);
            }

            var limit = (ulong)Math.Floor(Math.Sqrt(number));

            for (ulong i = 5; i <= limit; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return ServiceResult<bool>.Create(false);
                }
            }

            return ServiceResult<bool>.Create(true);
        }

        /// <inheritdoc cref="IPrimeNumberService.NextPrimeNumber"/>
        public ServiceResult<ulong> NextPrimeNumber(ulong number)
        {
            while (true)
            {
                if (number == ulong.MaxValue)
                {
                    return ServiceResult<ulong>.Create()
                        .AddError(ErrorType.UnsupportedOperation, 
                            "No implementation for bigger numbers than 64-bit integer");
                }

                number++;

                var isPrimeNumberResult = IsPrimeNumber(number);

                if (!isPrimeNumberResult.HasErrors && isPrimeNumberResult.Data)
                {
                    return ServiceResult<ulong>.Create(number);
                }
            }
        }
    }
}