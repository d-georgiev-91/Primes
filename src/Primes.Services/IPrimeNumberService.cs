namespace Primes.Services
{
    /// <summary>
    /// Prime operation
    /// </summary>
    public interface IPrimeNumberService
    {
        /// <summary>
        /// Verifies if number is prime
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>Returns a service <inheritdoc cref="ServiceResult{bool}"/></returns>
        public ServiceResult<bool> IsPrimeNumber(ulong number);

        /// <summary>
        /// Returns the next prime number
        /// </summary>
        /// <param name="number">The number</param>
        /// <returns>Returns <inheritdoc cref="ServiceResult{ulong}"/>
        /// If number is outside of 64 bit unsigned integer range an error service result with error is returned.
        /// </returns>
        public ServiceResult<ulong> NextPrimeNumber(ulong number);
    }
}
