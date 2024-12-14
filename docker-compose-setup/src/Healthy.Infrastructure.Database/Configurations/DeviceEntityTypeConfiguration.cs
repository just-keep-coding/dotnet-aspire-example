using Healthy.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Database.Configurations;

public class DeviceEntityTypeConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.ToTable("devices");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.UserId)
            .IsRequired();

        builder.Property(p => p.CreatedAtUtc)
            .IsRequired();

        builder.Property(p => p.UpdatedAtUtc)
            .IsRequired();
        
        builder.Property(p => p.UserAssignedAtUtc)
            .IsRequired(false);

        builder.HasIndex(p => new { p.Id, p.UserId });
    }
}
