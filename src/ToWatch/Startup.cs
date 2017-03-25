using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using ToWatch.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ToWatch.Database;
using AutoMapper;
using ToWatch.ViewModels;

namespace ToWatch
{
    public class Startup
    {
        private IConfigurationRoot configRoot;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("config.json");

            configRoot = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddSingleton(configRoot);
            services.AddDbContext<WatchContext>();
            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            });
            services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;
                config.Cookies.ApplicationCookie.LoginPath = "/Auth/Login";
            })
            .AddEntityFrameworkStores<WatchContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            Mapper.Initialize(config =>
            {
                config.CreateMap<RegisterViewModel, AppUser>().ReverseMap();
            });

            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(config =>
            {
                config.MapRoute(
                    name: "Any",
                    template: "{*catchall}",
                    defaults: new { controller = "App", action = "Index" }
                    );
            });
        }
    }
}
