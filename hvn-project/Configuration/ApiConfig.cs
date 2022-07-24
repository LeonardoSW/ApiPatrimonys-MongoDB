using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace hvn_project.Configuration
{
    public static class ApiConfig
    {

        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityConfiguration(configuration);

            services.AddControllers();
        }

        public static void UseApiConfiguration(this IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthConfiguration();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
