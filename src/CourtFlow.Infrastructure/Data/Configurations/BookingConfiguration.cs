using CourtFlow.Domain.Entities;
using CourtFlow.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourtFlow.Infrastructure.Data.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings");
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
        builder.Property(b => b.CourtId)
            .IsRequired();
        builder.Property(b => b.UserId)
            .IsRequired();
        builder.OwnsOne(b => b.Time, time =>
        {
            time.Property(t => t.Start)
                .HasColumnName("StartTime")
                .IsRequired();
            time.Property(t => t.End)
                .HasColumnName("EndTime")
                .IsRequired();
        });
            
        builder.Property(b => b.Status)
            .HasConversion<string>()
            .IsRequired();
        builder.Property(b => b.TotalPrice)
            .HasConversion(
                v =>v.Value,
                v=> new Money(v))
            .HasColumnType("decimal(18,2)")
            .IsRequired();
        builder.Property(b => b.IsLateCancellation)
            .IsRequired();
        builder.Property(b => b.CreatedAt)
            .ValueGeneratedNever()
            .IsRequired();
        builder.HasOne(b => b.User)
            .WithMany()
            .HasForeignKey(a => a.UserId);
        builder.HasOne(b => b.Court)
            .WithMany()
            .HasForeignKey(a=>a.CourtId);
        builder.HasIndex(b => b.CourtId);
        builder.HasIndex(b => new { b.CourtId, b.UserId });
    }
}