namespace GPSTracker.Contracts.Requests
{
    public record DeviceLocationRequest(string SerialNumber, double Latitude, double Longitude);

    
}
