using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.DataBase.Models.BaseModels;

namespace School.DataBase.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .HasKey(s => s.Id);

        builder
            .HasOne(s => s.Class)
            .WithMany(c => c.Students);
        
    }
}