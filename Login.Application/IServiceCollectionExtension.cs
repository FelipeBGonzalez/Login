using Microsoft.Extensions.DependencyInjection;
using Login.Application.Interfaces;



namespace Login.Application.Services
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services)
        {
            /****************************************************************************************************************
                *** realizar a ligacao da interface com a classe neste container de injeção de dependência ***
                * 
                *  Transient objects are always different; a new instance is provided to every controller and every service.

                *  Scoped objects are the same within a request, but different across different requests.

                *  Singleton objects are the same for every object and every request.
                
           
               ****************************************************************************************************************
               - A Camada Application é reponsável por conter o de-para, a converão de business models para viewModels. 
               - Enquanto que a business model atende nomenclatura de modelagem de dados e regras, a viewModel possui 
                 nomes mais amigáveis, campos calculados, concatenações e outras que facilitam a apresentação em front-end.
               ****************************************************************************************************************/
            services.AddScoped<IUserApplication, UserApplication>();            

            return services;
        }
    }
}
