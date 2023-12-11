using Microsoft.Extensions.Logging;
using Repository.UnitOfWorks;

namespace Service.Services.Rate;

public class RateService : IRateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<RateService> _logger;
    public RateService(IUnitOfWork unitOfWork, ILogger<RateService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public bool Create(VmRate model)
    {
        try
        {
            var data = new Entity.Models.Rate();

            data.VehicleType = (Entity.Enums.VehicleType)model.VehicleType;
            data.RatePerHour = model.RatePerHour;
            data.ParkingSpotIdFk = model.ParkingSpotIdFk;
            

            _unitOfWork.Rates.Create(data);
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
            var existingData = _unitOfWork.Rates.FirstOrDefault(p => p.RateId == id);

            if (existingData != null)
            {
                _unitOfWork.Rates.Delete(existingData);
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

    public List<VmRate> GetAll()
    {
        var rateList = _unitOfWork.Rates.GetAllEnumerable();
        var modelList = new List<VmRate>();
        foreach (var data in rateList)
        {
            var model = new VmRate();
            model.RateId = data.RateId;
            model.VehicleType = (Common.Enums.VmVehicleType)data.VehicleType;
            model.RatePerHour = data.RatePerHour;
            model.ParkingSpotIdFk = data.ParkingSpotIdFk;

            modelList.Add(model);
        }
        return modelList;
    }

    public VmRate GetById(long id)
    {
        var existingData = _unitOfWork.Rates.FirstOrDefault(p => p.RateId == id);
        var model = new VmRate();
        if (existingData != null)
        {
            model.RateId = existingData.RateId;
            model.VehicleType = (Common.Enums.VmVehicleType)existingData.VehicleType;
            model.RatePerHour = existingData.RatePerHour;
            model.ParkingSpotIdFk = existingData.ParkingSpotIdFk;
        }
        return model;
    }

    public bool Update(VmRate model)
    {
        try
        {
            var data = _unitOfWork.Rates.FirstOrDefault(p => p.RateId == model.RateId);

            data.VehicleType = (Entity.Enums.VehicleType)model.VehicleType;
            data.RatePerHour = model.RatePerHour;
            data.ParkingSpotIdFk = model.ParkingSpotIdFk;

            _unitOfWork.Rates.Update(data);
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
