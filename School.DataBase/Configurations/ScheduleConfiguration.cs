using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.DataBase.Models.BaseModels;

namespace School.DataBase.Configurations;

public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
{
    public void Configure(EntityTypeBuilder<Schedule> builder)
    {
        builder
            .HasKey(s => s.Id);
        
        builder
            .HasOne(s => s.Class)
            .WithMany(c => c.Schedules)
            .HasForeignKey(s => s.ClassId);
        
        builder
            .HasOne(s => s.Teacher)
            .WithMany(t => t.Schedules)
            .HasForeignKey(s => s.TeacherId);
        
        builder
            .HasOne(s => s.Cabinet)
            .WithMany(c => c.Schedules)
            .HasForeignKey(s => s.CabinetId);
    }
}