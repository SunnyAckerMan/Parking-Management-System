using Microsoft.Extensions.Logging;
using Repository.UnitOfWorks;

namespace Service.Services.Billing;

public class BillingService : IBillingService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<BillingService> _logger;
    public BillingService(IUnitOfWork unitOfWork, ILogger<BillingService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public bool Create(VmBilling model)
    {
        try
        {
            var data = new Entity.Models.Billing();
            data.PaymentStatus = (Entity.Enums.PaymentStatus)model.PaymentStatus;
            data.AmountPaid = model.AmountPaid;
            data.TicketIdFk = model.TicketIdFk;
            _unitOfWork.Billings.Create(data);
            _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return false;
        }
    }

    public bool Delete(long id)
    {
        try
        {
            var existingData = _unitOfWork.Billings.FirstOrDefault(p => p.BillingId == id);

            if (existingData != null)
            {
                _unitOfWork.Billings.Delete(existingData);
                _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return false;
        }
    }

    public List<VmBilling> GetAll()
    {
        var billingList = _unitOfWork.Billings.GetAllEnumerable();
        var modelList = new List<VmBilling>();
        foreach (var data in billingList)
        {
            var model = new VmBilling();
            model.BillingId = data.BillingId;
            model.PaymentStatus = (Common.Enums.VmPaymentStatus)data.PaymentStatus;
            model.AmountPaid = data.AmountPaid;
            model.TicketIdFk = data.TicketIdFk;
            modelList.Add(model);
        }
        return modelList;
    }

    public VmBilling GetById(long id)
    {
        var existingData = _unitOfWork.Billings.FirstOrDefault(p => p.BillingId == id);
        var model = new VmBilling();
        if (existingData != null)
        {
            model.BillingId = existingData.BillingId;
            model.PaymentStatus = (Common.Enums.VmPaymentStatus)existingData.PaymentStatus;
            model.AmountPaid = existingData.AmountPaid;
            model.TicketIdFk= existingData.TicketIdFk;
        }
        return model;
    }

    public bool Update(VmBilling model)
    {
        try
        {
            var data = new Entity.Models.Billing();
            data.PaymentStatus = (Entity.Enums.PaymentStatus)model.PaymentStatus;
            data.AmountPaid = model.AmountPaid;
            data.TicketIdFk = model.TicketIdFk;
            _unitOfWork.Billings.Update(data);
            _unitOfWork.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return false;
        }
    }
}
