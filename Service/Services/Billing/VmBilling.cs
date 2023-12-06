using Service.Common.Enums;

namespace Service.Services.Billing;

public class VmBilling
{
    public long BillingId { get; set; }
    public VmPaymentStatus PaymentStatus { get; set; }
    public decimal AmountPaid { get; set; }
    public long TicketIdFk { get; set; }
    public string VehicleNumber { get; set; }
    public string OwnerName { get; set; }
}
