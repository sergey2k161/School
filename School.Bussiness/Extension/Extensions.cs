using Microsoft.Extensions.DependencyInjection;
using School.Bussiness.Services.Interfaces;
using School.Bussiness.Services.Logic;

namespace School.Bussiness.Extension;

public static class Extensions
{
    public static IServiceCollection AddBussiness(this IServiceCollection services)
    {

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClassService, ClassService>();
        
        return services;
    }
}