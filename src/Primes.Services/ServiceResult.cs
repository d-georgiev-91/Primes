using System.Collections.Generic;
using System.Linq;

namespace Primes.Services
{
    /// <summary>
    /// Placeholder model of service result
    /// </summary>
    public class ServiceResult
    {
        /// <summary>
        /// Creates instance of <see cref="ServiceResult"/>
        /// </summary>
        public ServiceResult() => Errors = new Dictionary<ErrorType, ServiceResultError>();


        /// <summary>
        /// Errors placeholder
        /// </summary>
        public Dictionary<ErrorType, ServiceResultError> Errors { get; }

        /// <summary>
        /// Adds error to service result
        /// </summary>
        /// <param name="type">The type of error</param>
        /// <param name="message">The message of error</param>
        /// <returns>Current instance</returns>
        public ServiceResult AddError(ErrorType type, string message)
        {
            var error = new ServiceResultError(type, message);
            AddError(error);

            return this;
        }

        /// <summary>
        /// Adds error to service result
        /// </summary>
        /// <param name="error">The error</param>
        /// <returns>Current instance</returns>
        public ServiceResult AddError(ServiceResultError error)
        {
            Errors.Add(error.Error, error);

            return this;
        }

        /// <summary>
        /// Returns if there are any errors
        /// </summary>
        public bool HasErrors => Errors.Any();
    }

    /// <summary>
    /// Placeholder model of service result of <see cref="TData"/>
    /// </summary>
    /// <typeparam name="TData">The type of data</typeparam>
    public class ServiceResult<TData> : ServiceResult
    {
        /// <summary>
        /// Creates a service result
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>Current instance</returns>
        public static ServiceResult<TData> Create(TData data = default)
        {
            var serviceResult = new ServiceResult<TData> { Data = data };

            return serviceResult;
        }

        /// <inheritdoc cref="AddError"/>
        public new ServiceResult<TData> AddError(ErrorType type, string message)
        {
            base.AddError(type, message);

            return this;
        }

        /// <summary>
        /// Gets or sets the TData
        /// </summary>
        public TData Data { get; set; }
    }
}
