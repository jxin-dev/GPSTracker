namespace GPSTracker.Contracts.Responses
{
    public record DeviceDto(Guid Id, string SerialNumber, Guid? OwnerId, bool IsActive, DateTime RegisteredAt,
        List<DevicePhoneNumberDto> DevicePhoneNumbers);
    public record DevicePhoneNumberDto(Guid Id, string PhoneNumber, DateTime RegisteredAt);


}
