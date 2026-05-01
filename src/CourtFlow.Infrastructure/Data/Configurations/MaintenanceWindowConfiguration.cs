using CourtFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourtFlow.Infrastructure.Data.Configurations;

public class MaintenanceWindowConfiguration : IEntityTypeConfiguration<MaintenanceWindow>
{
    public void Configure(EntityTypeBuilder<MaintenanceWindow> builder)
    {
        builder.ToTable("MaintenanceWindows");
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
            .ValueGeneratedOnAdd();
        builder.Property(m => m.Reason)
            .HasMaxLength(100)
            .IsRequired();
        builder.OwnsOne(m => m.Window, window =>
            {
                window.Property(w => w.Start)
                    .HasColumnName("StartTime")
                    .IsRequired();
                window.Property(w=>w.End)
                    .HasColumnName("EndTime")
                    .IsRequired();
            }
        );
        builder.Property(m => m.CourtId)
            .IsRequired();
        builder.HasOne(m => m.Court)
            .WithMany()
            .HasForeignKey(a => a.CourtId);
        builder.HasIndex(m => m.CourtId);
    }
}