using Login.Application.ViewModels;
using Login.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Login.Application.Interfaces
{
    public interface IUserApplication
    {
        void SignUp(vmUser user);
        vmUser Signin(string email, string password);
        vmUser Me(string login);
    }
}