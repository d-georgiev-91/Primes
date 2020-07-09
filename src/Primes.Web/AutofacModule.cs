using Autofac;
using Primes.Services;

namespace Primes.Web
{
    /// <summary>
    /// Autofac module for application
    /// </summary>
    public class AutofacModule : Module
    {
        /// <inheritdoc cref="Module.Load" />
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PrimeNumberService>()
                .As<IPrimeNumberService>()
                .InstancePerLifetimeScope();
        }
    }
}
