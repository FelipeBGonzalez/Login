using Microsoft.Extensions.DependencyInjection;
using Login.Domain;
using Login.Domain.Interfaces;
using Login.Domain.Service;


namespace Login.Domain
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddDomainServiceCollection(this IServiceCollection services)
        {

            /****************************************************************************************************************
             *** realizar a ligacao da interface com a classe neste container de injeção de dependência ***
             * 
             *  Transient objects are always different; a new instance is provided to every controller and every service.

             *  Scoped objects are the same within a request, but different across different requests.

             *  Singleton objects are the same for every object and every request.
             
            ****************************************************************************************************************/
            services.AddSingleton<IInitializeDomain, InitializeDomain>();
            services.AddScoped<ISignUpDomain, SignUpDomain>();
            services.AddScoped<ISignInDomain, SignInDomain>();
            services.AddScoped<IMeDomain, MeDomain>();            
            return services;
        }
    }
}
