using ShapeAccountManagemenSystem.Application.Helpers;
using ShapeAccountManagemenSystem.Application.Repositories;
using ShapeAccountManagemenSystem.Application.Services;
using ShapeAccountManagementSystem.Core.Interfaces;
using ShapeAccountManagementSystem.Helpers;

namespace ShapeAccountManagementSystem.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(MapperProfile));
            services.AddAutoMapper(typeof(ApplicationMapperProfile));
            return services;
        }
        public static void ConfigureCors(this IServiceCollection services, string origins)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("ShapeCorsPolicy",
                    builder => builder.WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
    }
}
