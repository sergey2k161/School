using Microsoft.Extensions.DependencyInjection;
using School.Bussiness.Services.Interfaces;
using School.Bussiness.Services.Logic;
using School.DataBase.Models.BaseModels;
using School.DataBase.Repositories.Interfaces;

namespace School.Bussiness.Extension;

public static class Extensions
{
    public static IServiceCollection AddBussiness(this IServiceCollection services)
    {

        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClassService, ClassService>();
        services.AddScoped<IDiningRoomService, DiningRoomService>();
        services.AddScoped<ITeacherService, TeacherService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IScheduleService, ScheduleService>();
        services.AddScoped<ICabinetService, CabinetService>();     
        services.AddScoped<IDisciplineService, DisciplineService>();
        
        return services;
    }
}