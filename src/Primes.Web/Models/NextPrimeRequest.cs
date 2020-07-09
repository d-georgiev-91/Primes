namespace Primes.Web.Models
{
    /// <summary>
    /// Model holding information of next prime number request
    /// </summary>
    public class NextPrimeRequest
    {
        /// <summary>
        /// Gets or sets the number
        /// </summary>
        public ulong Number { get; set; }
    }
}