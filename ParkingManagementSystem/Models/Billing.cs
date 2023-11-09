using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagementSystem.Models;

public class Billing
{
    [Key]
    public long BillingId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal AmountPaid { get; set; }
    public long TicketIdFk { get; set; }
}
