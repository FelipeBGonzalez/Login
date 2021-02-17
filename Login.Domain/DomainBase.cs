using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Login.Domain.Interfaces;
using Login.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Login.Domain
{
    public class DomainBase
    {
        //lazy -> determina modelos de entidade carregadas sob demanda. i.e. linq (first, find, single, find, ToList, foreach)
        private static readonly Lazy<DomainBase> lazy = new Lazy<DomainBase>(() => new DomainBase());

        public static DomainBase Instance { get { return lazy.Value; } }

        public static IConfiguration config;

        public static ServiceProvider provider { get; set; }

        public DomainBase()
        {
            RepositoryBase();
        }

        public static void RepositoryBase()
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
              .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            config = builder.Build();
        }

      
    }
}
