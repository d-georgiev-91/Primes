using Autofac;
using Primes.Services;

namespace Primes.Web
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PrimeNumberService>()
                .As<IPrimeNumberService>()
                .InstancePerLifetimeScope();
        }
    }
}
