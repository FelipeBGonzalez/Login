using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Domain.Models;
using System;

namespace Login.Domain.Service
{
    public class SignUpDomain : ISignUpDomain
    {

        public void Execute(UserDomain user)
        {
            user.create_ate = DateTime.Now;
            this.ValidUser(user);
            DomainBase.provider.GetService<IUserRepository>().SignUp(user);

        }

        public void ValidUser(UserDomain user)
        {
            ErrorDomain ret = new ErrorDomain();

            if (DomainBase.provider.GetService<IUserRepository>().EmailExists(user.email))
            {
                throw new ArgumentException("E-mail already exists", "1");
            }

            if (string.IsNullOrEmpty(user.email) || string.IsNullOrEmpty(user.firstName) ||
                string.IsNullOrEmpty(user.lastName) || string.IsNullOrEmpty(user.password))
            {
                throw new ArgumentException("Missing Filds", "2");
            }
        }
    }
}
