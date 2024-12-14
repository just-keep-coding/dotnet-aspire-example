namespace Core.Application.Devices.GetDevices;

public sealed record DeviceResponse(
    Guid Id,
    Guid? UserId,
    DateTimeOffset CreatedAtUtc,
    DateTimeOffset UpdatedAtUtc,
    DateTimeOffset? UserAssignedAtUtc
);
