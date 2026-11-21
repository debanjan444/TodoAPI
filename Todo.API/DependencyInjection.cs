using Microsoft.EntityFrameworkCore;
using Todo.Application;
using Todo.Application.Contracts;
using Todo.Application.Implementation;
using Todo.Domain.RepositoryInterface;
using Todo.Infrastructure;
using Todo.Infrastructure.Persistence.Entities;
using Todo.Infrastructure.Repository;

namespace Todo.API
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoAppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(InfraAssemblyMarker).Assembly);


            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();

            return services;
        }




        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(ApplicationLayerMarker).Assembly);

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddScoped<ITokenRevocationService, TokenRevokationService>();
            services.AddScoped<IRefreshTokenService, RefreshTokenService>();

            return services;
        }
    }
}
