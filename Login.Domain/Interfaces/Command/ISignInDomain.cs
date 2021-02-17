using Login.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Domain.Interfaces
{ 
    public interface ISignInDomain
    {
        UserDomain Execute(string email, string password);
    }
}
