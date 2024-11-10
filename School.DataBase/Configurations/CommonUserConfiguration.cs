using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.DataBase.Models.BaseModels;

namespace School.DataBase.Configurations;

public class CommonUserConfiguration : IEntityTypeConfiguration<CommonUser>
{
    public void Configure(EntityTypeBuilder<CommonUser> builder)
    {
        builder
            .HasKey(c => c.Id);

        builder
            .HasOne(c => c.Teacher)
            .WithOne(t => t.CommonUser)
            .HasForeignKey<Teacher>(t => t.CommonUserId);
        
        builder
            .HasOne(c => c.Student)
            .WithOne(s => s.CommonUser)
            .HasForeignKey<Student>(t => t.CommonUserId);

    }
}