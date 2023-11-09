using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagementSystem.Models;

public class Rate
{
    [Key]
    public long RateId { get; set; } 
    public VehicleType VehicleType { get; set; } 
    public decimal RatePerHour { get; set; }
    public long ParkingSpotIdFk { get; set; }
}
