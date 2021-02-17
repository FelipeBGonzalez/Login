using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace Login.Domain
{
    public class InitializeDomain : IInitializeDomain
    {
        public void Initialize(ServiceProvider _provider)
        {
            if (DomainBase.provider == null)
                DomainBase.provider = _provider;
        }
    }
}
