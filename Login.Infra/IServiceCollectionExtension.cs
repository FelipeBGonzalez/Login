using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;


namespace Login.Infra.Data.Repository
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddInfraServiceCollection(this IServiceCollection services)
        {
            /****************************************************************************************************************
               *** realizar a ligacao da interface com a classe neste container de injeção de dependência ***
               * 
               *  Transient objects are always different; a new instance is provided to every controller and every service.

               *  Scoped objects are the same within a request, but different across different requests.

               *  Singleton objects are the same for every object and every request.


              ****************************************************************************************************************
              - A Camada Infra é reponsável por fornecer dados para aplicação. Sua origem depende da implementação das interfaces
                e pode ser Banco de Dados, arquivos XML, Json, Mensageria, etc. 

              - As Interfaces utilizadas nesta camada Infra vêm da camada Domain, que possui um local para armazenar todas as 
                intefaces de repositório. É responsabilidade da camada Domain mantê-las, para que as camadas Infra, Test ou Mock-up
                façam uso da mesma.

              - Ao contrario da Camada Model (onde cada service representa uma ação), a camada Infra possui todas as ações do CRUD
                um único Service.
    
              ****************************************************************************************************************/
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
