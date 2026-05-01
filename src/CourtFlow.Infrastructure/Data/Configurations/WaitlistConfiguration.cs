using CourtFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourtFlow.Infrastructure.Data.Configurations;

public class WaitlistConfiguration : IEntityTypeConfiguration<Waitlist>
{
    public void Configure(EntityTypeBuilder<Waitlist> builder)
    {
        builder.ToTable("Waitlists");
        builder.HasKey(w => w.Id);
        builder.Property(w => w.Id)
            .ValueGeneratedOnAdd();
        builder.Property(w => w.CourtId)
            .IsRequired();
        builder.Property(w => w.UserId)
            .IsRequired();
        builder.OwnsOne(w => w.RequestedTime, time =>
        {
            time.Property(t => t.Start)
                .HasColumnName("StartTime")
                .IsRequired();
            time.Property(t => t.End)
                .HasColumnName("EndTime")
                .IsRequired();
        });
        builder.Property(w => w.JoinedAt)
            .ValueGeneratedNever()
            .IsRequired();
        builder.HasOne(w => w.User)
            .WithMany()
            .HasForeignKey(w => w.UserId);
        builder.HasOne(w => w.Court)
            .WithMany()
            .HasForeignKey(w => w.CourtId);
        builder.HasIndex(w => new { w.CourtId, w.UserId });
    }
}