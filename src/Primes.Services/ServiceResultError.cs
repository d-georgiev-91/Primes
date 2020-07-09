namespace Primes.Services
{
    /// <summary>
    /// Placeholder model of service result error
    /// </summary>
    public class ServiceResultError
    {
        /// <summary>
        /// Creates a instance of <see cref="ServiceResultError"/>
        /// </summary>
        /// <param name="error">Error type</param>
        /// <param name="message">Error message</param>
        public ServiceResultError(ErrorType error, string message)
        {
            Error = error;
            Message = message;
        }

        /// <summary>
        /// Gets or sets error type
        /// </summary>
        public ErrorType Error { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        public string Message { get; set; }
    }
}