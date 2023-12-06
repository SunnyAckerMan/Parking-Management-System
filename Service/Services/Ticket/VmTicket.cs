using System.ComponentModel.DataAnnotations;

namespace Service.Services.Ticket;

public class VmTicket
{
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
    public long ParkingSpotIdFk { get; set; }
    public long RateIdFk { get; set; }
}
