using CourtFlow.Domain.Entities;
using CourtFlow.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourtFlow.Infrastructure.Data.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd();
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.Email)
            .HasConversion(
                v => v.Value, v => new EmailAddress(v))
            .IsRequired();
        builder.Property(u => u.PasswordHash)
            .HasConversion(v => v.Value, v => new PasswordHash(v))
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(u => u.Phone)
            .HasConversion(v => v.Value, v => new PhoneNumber(v))
            .IsRequired();
        builder.Property(u => u.Role)
            .IsRequired()
            .HasConversion<string>();
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}