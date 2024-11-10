﻿using Microsoft.Extensions.DependencyInjection;
using School.Bussiness.Services.Interfaces;
using School.Bussiness.Services.Logic;
using School.DataBase.Models.BaseModels;

namespace School.Bussiness.Extension;

public static class Extensions
{
    public static IServiceCollection AddBussiness(this IServiceCollection services)
    {

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IDiningRoomService, DiningRoomService>();
        
        
        return services;
    }
}