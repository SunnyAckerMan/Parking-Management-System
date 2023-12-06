using Service.Common.Enums;

namespace Service.Services.Rate;

public class VmRate
{
    public long RateId { get; set; }
    public VmVehicleType VehicleType { get; set; }
    public decimal RatePerHour { get; set; }
    public long ParkingSpotIdFk { get; set; }
    public string CompanyName { get; set; }
}
