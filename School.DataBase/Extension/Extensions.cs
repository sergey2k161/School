using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using School.DataBase.Repositories.DataAccessRepositories;
using School.DataBase.Repositories.Interfaces;

namespace School.DataBase.Extension;

public static class Extensions
{
    public static IServiceCollection AddDataBase(this IServiceCollection services)
    {

        services.AddScoped<IAuthRepository, AuthRepository>();
        services.AddScoped<IClassRepository, ClassRepository>();
        services.AddScoped<IDiningRoomRepository, DiningRoomRepository>();
        services.AddScoped<ITeacherRepository, TeacherRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        // Защита от SQL инъекции "Надо сделать, но впадлу пока что"
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Database=School;Username=sergey;Password=1618");
        });
        return services;
    }
}