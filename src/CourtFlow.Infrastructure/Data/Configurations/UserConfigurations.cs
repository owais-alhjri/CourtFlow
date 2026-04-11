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
            .IsRequired();
        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);
        builder.Property(u => u.Email)
            .HasConversion(
                e => e.Value,
                v => new EmailAddress(v))
            .IsRequired();
        builder.Property(u => u.Password)
            .HasConversion(p => p.Value, v => new Password(v))
            .IsRequired()
            .HasMaxLength(255);
        builder.Property(u => u.Phone)
            .HasConversion(p => p.Value, v => new PhoneNumber(v))
            .IsRequired();
        builder.Property(u => u.Role)
            .IsRequired()
            .HasConversion<string>();
        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}