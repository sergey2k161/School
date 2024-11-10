using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.DataBase.Configurations;
using School.DataBase.Models.BaseModels;

namespace School.DataBase;

public class AppDbContext : IdentityDbContext<CommonUser, IdentityRole<int>, int>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}
    
    public DbSet<Teacher> Teachers { get; set; }
    
    public DbSet<Class> Classes { get; set; }
    
    public DbSet<DiningRoom> Dishes { get; set; }
    
    public DbSet<Equipment> Equipments { get; set; }
    
    public DbSet<Student> Students { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new TeacherConfiguration());
        builder.ApplyConfiguration(new ClassConfiguration());
        builder.ApplyConfiguration(new StudentConfiguration());
        builder.ApplyConfiguration(new CommonUserConfiguration());

        base.OnModelCreating(builder);
    }
}