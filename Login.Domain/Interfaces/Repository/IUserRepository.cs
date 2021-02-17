using Login.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Domain.Interfaces
{
    public interface IUserRepository
    {
        void SignUp(UserDomain user);
        UserDomain Signin(string email, string password);
        void UpdateToken(UserDomain user);
        UserDomain Me(string id);
        bool EmailExists(string email);
    }
}
