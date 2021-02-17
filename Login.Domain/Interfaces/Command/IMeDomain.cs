using Login.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Domain.Interfaces
{ 
    public interface IMeDomain
    {
        UserDomain Execute(string id);
    }
}
