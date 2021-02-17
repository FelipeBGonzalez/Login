using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Domain.Models;
using System;
using System.Collections.Generic;
using Login.Domain;
using Login.Infra.Data.Repository;
using Login.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Login.Application.Services
{
    public class ApplicationBase
    {
        public ServiceProvider provider { get; private set; }

        public ApplicationBase()
        {
            var service = new ServiceCollection();
            //service.AddDbContext<ApiContext3>()
           service.AddDbContext<ApiContext3>(opt => opt.UseInMemoryDatabase(databaseName: "InMemoryDb"),
           ServiceLifetime.Scoped,
           ServiceLifetime.Scoped);

            //INICIALIZAÇÃO DOS CONTAINERS DE INJEÇÃO DE DEPENDENCIA
            service.AddDomainServiceCollection();



            // ****** Origem dos Dados *******

            // Dinamica (banco de dados, xml, json)
            //---------------------------------------------
            service.AddInfraServiceCollection();
            //---------------------------------------------

            //Mock (Dados Estáticos para teste)
            //---------------------------------------------
            //service.AddInfraTestDataServiceCollection();
            //---------------------------------------------


            // ****** Origem dos Dados *******

            provider = service.BuildServiceProvider();
        }

        public T GetService<T>()
        {
            provider.GetService<IInitializeDomain>().Initialize(provider);
            return provider.GetService<T>();
        }
    }
}
