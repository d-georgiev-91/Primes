﻿using System;

namespace Primes.Services
{
    public class PrimeNumberService : IPrimeNumberService
    {
        public bool IsPrimeNumber(ulong number)
        {
            if (number <= 3)
            {
                return number > 1;
            }

            if (number % 2 == 0 || number % 3 == 0)
            {
                return false;
            }

            var limit = (ulong)Math.Floor(Math.Sqrt(number));

            for (ulong i = 5; i <= limit; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }

        public ulong NextPrimeNumber(ulong number) => throw new System.NotImplementedException();
    }
}