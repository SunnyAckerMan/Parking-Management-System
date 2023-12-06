using Entity.Enums;
using System.ComponentModel.DataAnnotations;
namespace Entity.Models;

public class Rate : BaseEntity
{
    [Key]
    public long RateId { get; set; } 
    public VehicleType VehicleType { get; set; } 
    public decimal RatePerHour { get; set; }
    public long ParkingSpotIdFk { get; set; }
}
