using Healthy.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class HealthTelemetryEntityTypeConfiguration : IEntityTypeConfiguration<HealthTelemetry>
{
    public void Configure(EntityTypeBuilder<HealthTelemetry> builder)
    {
        builder.ToTable("health_telemetries");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.UserId)
            .IsRequired();

        builder.Property(p => p.DeviceId)
            .IsRequired();

        builder.Property(p => p.TimestampAtUtc)
            .IsRequired();
        
        builder.Property(p => p.HeartRate)
            .IsRequired(false);
        
        builder.Property(p => p.BloodOxygenLevel)
            .IsRequired(false);

        builder.Property(p => p.BloodPressureSystolic)
            .IsRequired(false);

        builder.Property(p => p.BloodPressureDiastolic)
            .IsRequired(false);

        builder.HasIndex(p => new { p.UserId, p.DeviceId });
    }
}
