using Login.Domain.Interfaces;
using Login.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Infra.Test.Mockup.Repository
{
    internal class UserRepositoryTest : IUserRepository
    {
        public bool EmailExists(string email)
        {
            throw new NotImplementedException();
        }

        public UserDomain Me(string email, string password)
        {
            throw new NotImplementedException();
        }

        public UserDomain Me(string id)
        {
            throw new NotImplementedException();
        }

        public UserDomain Signin(string email, string password)
        {
            throw new NotImplementedException();
        }

        public void SignUp(UserDomain user)
        {
            throw new NotImplementedException();
        }

        public void UpdateToken(UserDomain user)
        {
            throw new NotImplementedException();
        }
    }
}
