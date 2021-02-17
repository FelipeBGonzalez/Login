using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Infra.Test.Mockup.Repository;
using Login.Infra.Data.Repository;
using Login.Domain.Service;

namespace Login.Domain.Test
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfraTestDataServiceCollection(this IServiceCollection services)
        {
            /****************************************************************************************************************
              *** realizar a ligacao da interface com a classe neste container de injeção de dependência ***
              * 
              *  Transient objects are always different; a new instance is provided to every controller and every service.

              *  Scoped objects are the same within a request, but different across different requests.

              *  Singleton objects are the same for every object and every request.


             ****************************************************************************************************************
             - A Camada Infra.Test é reponsável por fornecer dados MOCKADOS para testar a aplicação. 
               
               
             - As Interfaces utilizadas nesta camada Infra vêm da camada Domain, que possui um local para armazenar todas as 
               intefaces de repositório. É responsabilidade da camada Domain mantê-las, para que as camadas Infra, Test ou Mock-up
               façam uso da mesma.


             ****************************************************************************************************************/

            services.AddScoped<IUserRepository, UserRepositoryTest>();
            //services.AddScoped<IProcessRepository, ProcessRepository>();
            //services.AddScoped<ISendEmailNotification, SendEmailNotification>();
        

            return services;
        }
    }
}
