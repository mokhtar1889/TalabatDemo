using Microsoft.AspNetCore.Mvc;
using TalabatDemo.Factory;

namespace TalabatDemo.Extensions
{
    public static class ServiceRegisteration
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services) {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        
        }

        public static IServiceCollection AddWebApplicationServices(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>((options) => {

                options.InvalidModelStateResponseFactory = ApiResponseFactory.GenerateApiValidationErrorResponse;
            });

            return services;
        }
    }
}
