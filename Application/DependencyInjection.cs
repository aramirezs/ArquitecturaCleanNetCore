using Application.Interfaces.IServices;
using Application.Services;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
     /*               .AddScoped<IServiceLabService, ServiceLabService>()
                    .AddScoped<ITicketService, TicketService>();*/


            // FluentValidation
            services.AddControllers()
                .AddFluentValidation(opt => {
                    opt.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                }
            );

            return services;
        }
    }
}
