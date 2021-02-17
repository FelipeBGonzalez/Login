using Microsoft.Extensions.DependencyInjection;

namespace Login.Domain.Interfaces
{
    public interface IInitializeDomain
    {
        void Initialize(ServiceProvider _provider);
    }
}
