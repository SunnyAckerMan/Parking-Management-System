using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models;

public class Ticket : BaseEntity
{
    [Key]
    public long TicketId { get; set; }
    public string VehicleNumber { get; set; }
    [Required]
    public string OwnerName { get; set; }
    [Required]
    public string OwnerPhoneNo { get; set; } 
    public string OwnerEmail { get; set; } 
    public string OwnerNID { get; set; } 
    public DateTime EntryTime { get; set; } 
    public DateTime? ExitTime { get; set; }
    [ForeignKey("ParkingSpot")]
    public long ParkingSpotIdFk { get; set; }
    public ParkingSpot ParkingSpot { get; set; }
    [ForeignKey("Rate")]
    public long RateIdFk { get; set; }
    public Rate Rate { get; set; }
}
