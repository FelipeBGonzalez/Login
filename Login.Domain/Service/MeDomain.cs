using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Domain.Models;


namespace Login.Domain.Service
{
    public class MeDomain : IMeDomain
    {       
        public UserDomain Execute(string id)
        {
            return DomainBase.provider.GetService<IUserRepository>().Me(id);
        }
    }
}
