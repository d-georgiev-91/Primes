namespace Primes.Services
{
    public interface IPrimeNumberService
    {
        public bool IsPrimeNumber(ulong number);

        public ulong NextPrimeNumber(ulong number);
    }
}
