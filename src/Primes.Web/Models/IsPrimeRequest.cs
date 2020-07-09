namespace Primes.Web.Models
{
    /// <summary>
    /// Model holding information of is prime number request
    /// </summary>
    public class IsPrimeRequest
    {
        /// <summary>
        /// Gets or sets the number
        /// </summary>
        public ulong Number { get; set; }
    }
}