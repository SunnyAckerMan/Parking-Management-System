using Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models;

public class Rate : BaseEntity
{
    [Key]
    public long RateId { get; set; }
    public VehicleType VehicleType { get; set; }
    public decimal RatePerHour { get; set; }
    [ForeignKey("ParkingSpot")]
    public long ParkingSpotIdFk { get; set; }
    public ParkingSpot ParkingSpot {get; set;}
}
