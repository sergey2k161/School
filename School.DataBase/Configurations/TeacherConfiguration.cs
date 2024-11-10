using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.DataBase.Models.BaseModels;

namespace School.DataBase.Configurations;


public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {
        builder
            .HasKey(t => t.Id);
        builder
            .HasOne(t => t.CommonUser)
            .WithOne(cu => cu.Teacher)
            .HasForeignKey<Teacher>(s => s.CommonUserId);
        
        builder
            .HasMany(t => t.Disciplines)
            .WithMany(d => d.Teachers);
            
        builder
            .HasMany(t => t.Classes)
            .WithMany(c => c.Teachers);
            
        builder
            .HasMany(t => t.Cabinets)
            .WithMany(c => c.Teachers);
        
        builder
            .HasOne(t => t.MainClass)
            .WithOne(c => c.MainTeacher)
            .HasForeignKey<Class>(t => t.MainTeacherId);
    }
}