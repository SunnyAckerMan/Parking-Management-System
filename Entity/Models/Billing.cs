using Entity.Enums;
using System.ComponentModel.DataAnnotations;
namespace Entity.Models;

public class Billing : BaseEntity
{
    [Key]
    public long BillingId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal AmountPaid { get; set; }
    public long TicketIdFk { get; set; }
}
