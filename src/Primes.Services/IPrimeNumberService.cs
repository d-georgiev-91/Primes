namespace Primes.Services
{
    public interface IPrimeNumberService
    {
        public ServiceResult<bool> IsPrimeNumber(ulong number);

        public ServiceResult<ulong> NextPrimeNumber(ulong number);
    }
}
