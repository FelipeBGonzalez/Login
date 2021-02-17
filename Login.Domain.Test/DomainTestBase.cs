using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Domain;
using Login.Infra.Data.Repository;

namespace Login.Domain.Test
{
    public class DomainTestBase
    {
        public ServiceProvider provider { get; private set; }

        public DomainTestBase()
        {
            var service = new ServiceCollection();
            service.AddDomainServiceCollection();
            //service.AddInfraTestDataServiceCollection(); //MOCK
            service.AddInfraServiceCollection();

            provider = service.BuildServiceProvider();

            provider.GetService<IInitializeDomain>().Initialize(provider);
        }

    }
}
