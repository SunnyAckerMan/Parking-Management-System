using Entity.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models;

public class Billing : BaseEntity
{
    [Key]
    public long BillingId { get; set; }
    public PaymentStatus PaymentStatus { get; set; }
    public decimal AmountPaid { get; set; }
    [ForeignKey("Ticket")]
    public long TicketIdFk { get; set; }
    public Ticket Ticket { get; set; }
}
