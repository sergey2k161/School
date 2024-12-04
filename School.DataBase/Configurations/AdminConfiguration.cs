using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.DataBase.Models.BaseModels;

namespace School.DataBase.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Admin>
{
    public void Configure(EntityTypeBuilder<Admin> builder)
    {
        builder
            .HasKey(a => a.Id);

        builder
            .HasOne(a => a.CommonUser)
            .WithOne(u => u.Admin)
            .OnDelete(DeleteBehavior.Cascade);

    }
}