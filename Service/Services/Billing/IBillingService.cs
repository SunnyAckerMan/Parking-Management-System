namespace Service.Services.Billing;

public interface IBillingService
{
    bool Create(VmBilling model);
    bool Update(VmBilling model);
    bool Delete(long id);
    List<VmBilling> GetAll();
    VmBilling GetById(long id);
}
