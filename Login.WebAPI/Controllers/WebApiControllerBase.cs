using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using Login.Application.Services;


namespace Login.WebAPI.Controllers
{
    public class WebApiControllerBase : ControllerBase
    {        
        public ServiceProvider Provider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public WebApiControllerBase()
        {
            var service = new ServiceCollection();
            service.AddApplicationServiceCollection();

            Provider = service.BuildServiceProvider();
            ConfigurationBase();
            
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void ConfigurationBase()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }

     
    }
}
