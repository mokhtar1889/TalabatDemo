using DomainLayer.Contracts;
using Microsoft.AspNetCore.Hosting.Builder;
using TalabatDemo.CustomMiddelwares;

namespace TalabatDemo.Extensions
{
    public static class WebApplicationRegisteration
    {
        public static async Task SeedDataBaseAsync(this WebApplication app) {

            using var scope = app.Services.CreateScope();
            var seedObj = scope.ServiceProvider.GetRequiredService<IDataSeeding>();
            await seedObj.DataSeedAsync();

        }

        public static IApplicationBuilder UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {

            app.UseMiddleware<CustomExceptionHandlerMiddelware>();

            return app;
        }





    }
}
