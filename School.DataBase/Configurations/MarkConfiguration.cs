using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.DataBase.Models.BaseModels;

namespace School.DataBase.Configurations;

public class MarkConfiguration : IEntityTypeConfiguration<Mark>
{
    public void Configure(EntityTypeBuilder<Mark> builder)
    {
        builder
            .HasKey(m => m.Id);

        builder
            .HasOne(m => m.Student)
            .WithMany(s => s.Marks)
            .HasForeignKey(m => m.StudentId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder
            .HasOne(m => m.Teacher)
            .WithMany(s => s.Marks)
            .HasForeignKey(m => m.TeacherId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}