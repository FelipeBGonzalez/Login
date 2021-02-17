using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Login.WebAPI
{
    public class Startup
    {
        public Startup()
        {
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json");


            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigin",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    );
            });

            services.AddSwaggerGen(c =>
            {

                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });

            #region Configuracao JWT

            var key = Encoding.ASCII.GetBytes("E9A975E3-F262-4DB2-8D8E-87DD644615BA");//Chave usada no MSCWebAccess para criar Token
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            #endregion

            services.AddMemoryCache();
            services.AddRazorPages();


            #region Data Protection
            services.AddDataProtection();
            #endregion

            #region Localization / Globalization
            services.AddLocalization();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1 docs");
            });

            app.UseCors("AllowOrigin");
            app.UseRouting();

            #region Localization / Globalization
            //App supported cultures
            var supportedCultures = new[] {
                new CultureInfo("en-US"),
                new CultureInfo("pt-BR"),
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US"),
                SupportedCultures = supportedCultures, // Formatting numbers, dates, etc.                
                SupportedUICultures = supportedCultures, // UI strings that we have localized.
                RequestCultureProviders = new List<IRequestCultureProvider> { new QueryStringRequestCultureProvider() }
            });
            #endregion

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(context =>
            {
                var connection = Configuration.GetConnectionString("Medlog");
                return context.Response.WriteAsync("ConnectionString: " + connection);
            });

        }
    }
}
