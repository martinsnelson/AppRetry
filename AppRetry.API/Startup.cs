using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AppRetry.API.Infra.Context;
using AppRetry.API.Interface.IRepositories;
using AppRetry.API.Interfce.IServices;
using AppRetry.API.Repositories;
using AppRetry.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace AppRetry.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppRetryContext>(op => op.UseInMemoryDatabase("Users"));

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddHttpClient<CatalogService>();
            // services.AddTransient<ICatalogService, CatalogService>();
            
            services.AddAutoMapper();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "App Retry",
                    Description = "A simple ASP.NET 2.2 Core Web API"
                });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // Ative o middleware para servir o Swagger gerado como um endpoint JSON.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "api/swagger/{documentname}/swagger.json";
            });

            // Habilitar o middleware para servir swagger-ui (HTML, JS, CSS, etc.)
            // especificando o terminal JSON do Swagger.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/api/swagger/v1/swagger.json", "APP Retry");
                //  Para atender à interface do usuário do Swagger na raiz do aplicativo
                c.RoutePrefix = "api/swagger";
            });

            // app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
