using Login.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Login.Infra.Data
{
    public class ApiContext3 : DbContext
    {
        public ApiContext3(DbContextOptions<ApiContext3> options)
         : base(options)
        { }

       
        public DbSet<UserDomain> User { get; set; }
        public DbSet<PhoneDomain> Phone { get; set; }

    }
}
