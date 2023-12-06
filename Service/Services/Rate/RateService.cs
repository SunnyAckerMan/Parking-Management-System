using Microsoft.Extensions.Logging;
using Repository.DBContext;
using Service.Services.Ticket;

namespace Service.Services.Rate;

public class RateService : IRateService
{
    private readonly ParkingManagementDbContext _context;
    private readonly ILogger<RateService> _logger;
    public RateService(ParkingManagementDbContext context, ILogger<RateService> logger)
    {
        _context = context;
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
            

            _context.Rates.Add(data);
            _context.SaveChanges();

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
            var existingData = _context.Rates.FirstOrDefault(p => p.RateId == id);

            if (existingData != null)
            {
                _context.Rates.Remove(existingData);
                _context.SaveChanges();
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
        var rateList = _context.Rates.ToList();
        var modelList = new List<VmRate>();
        foreach (var data in rateList)
        {
            var model = new VmRate();

            model.VehicleType = (Common.Enums.VmVehicleType)data.VehicleType;
            model.RatePerHour = data.RatePerHour;
            model.ParkingSpotIdFk = data.ParkingSpotIdFk;

            modelList.Add(model);
        }
        return modelList;
    }

    public VmRate GetById(long id)
    {
        var existingData = _context.Rates.FirstOrDefault(p => p.RateId == id);
        var model = new VmRate();
        if (existingData != null)
        {
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
            var data = new Entity.Models.Rate();

            data.VehicleType = (Entity.Enums.VehicleType)model.VehicleType;
            data.RatePerHour = model.RatePerHour;
            data.ParkingSpotIdFk = model.ParkingSpotIdFk;

            _context.Rates.Update(data);
            _context.SaveChanges();

            return true;
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            return false;
        }
    }
}
