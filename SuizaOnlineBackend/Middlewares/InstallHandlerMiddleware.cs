using SuizaOnlineBackend.Middlewares.ErrorMiddlewares;
using Microsoft.AspNetCore.Builder;


namespace SuizaOnlineBackend.Middlewares
{
    public static class InstallHandlerMiddleware
    {
        public static IApplicationBuilder UseHandlerUsers(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
