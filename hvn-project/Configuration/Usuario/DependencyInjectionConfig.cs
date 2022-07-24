using hvn_project.Data;
using hvn_project.Repository;
using hvn_project.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hvn_project.Configuration.Usuario
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMongoRepository, MongoRepository>();
            services.AddScoped<IHandleValidate, HandleValidate>();
            services.AddScoped<IHandlerPatrimony, HandlerPatrimony>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
            services.AddScoped<ApplicationDbContext>();
        }
    }
}
