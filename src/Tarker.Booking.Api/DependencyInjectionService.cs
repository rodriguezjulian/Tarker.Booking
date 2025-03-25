using System.Reflection;

namespace Tarker.Booking.Api
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddWebApi(this IServiceCollection services) 
        {
            services.AddSwaggerGen(options => 
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Tarker Bookin API",
                    Description = "Administracion de endpoints para Booking"
                });
                var fileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory , fileName));
            });
            return services;
        }
    }
}
