using Application.Interfaces;
using Application.Interfaces.IRepositories;
using Infrastructure.Repositories;
using Infrastructure.Securities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
        {
            #region JWT

            services.AddScoped<IJwtGenerator, JwtGenerator>();

            #endregion

            #region Repositories

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
                    /*.AddScoped<IServiceLabRepository, ServiceLabRepository>()
                    .AddScoped<ITicketRepository, TicketRepository>();*/


            #endregion

            return services;
        }
    }
}
