using CourtFlow.Domain.Entities;
using CourtFlow.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourtFlow.Infrastructure.Data.Configurations;

public class PricingRuleConfiguration: IEntityTypeConfiguration<PricingRule>
{
    public void Configure(EntityTypeBuilder<PricingRule> builder)
    {
        builder.ToTable("PricingRules");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .ValueGeneratedOnAdd();
        builder.Property(p => p.CourtId)
            .IsRequired();
        builder.Property(p => p.DayOfWeek)
            .HasConversion<string>()
            .IsRequired();
        builder.OwnsOne(p => p.HourRange, hour =>
        {
            hour.Property(h => h.Start)
                .HasColumnName("StartHour")
                .IsRequired();
            hour.Property(h => h.End)
                .HasColumnName("EndHour")
                .IsRequired();
        });
        builder.Property(p => p.PricePerHour)
            .HasConversion(
                v => v.Value,
                v => new Money(v))
            .HasColumnType("numeric(18,2)")
            .IsRequired();
        builder.HasOne(p => p.Court)
            .WithMany()
            .HasForeignKey(p => p.CourtId);
        builder.HasIndex(p => new { p.CourtId, p.DayOfWeek });
    }
}