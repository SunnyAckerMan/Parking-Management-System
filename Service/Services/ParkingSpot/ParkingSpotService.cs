using Microsoft.Extensions.Logging;
using Repository.UnitOfWorks;

namespace Service.Services.ParkingSpot;

public class ParkingSpotService : IParkingSpotService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<ParkingSpotService> _logger;
    public ParkingSpotService(IUnitOfWork unitOfWork, ILogger<ParkingSpotService> logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public bool Create(VmParkingSpot model)
    {
        try
        {
            var data = new Entity.Models.ParkingSpot();
            data.ParkingSpotId = model.ParkingSpotId;
            data.CompanyName = model.CompanyName;
            data.Latitude = model.Latitude;
            data.Longitude = model.Longitude;
            data.Location = model.Location;
            data.TotalSpaceInSquareFeet = model.TotalSpaceInSquareFeet;
            data.AvailableSpaceInSquareFeet = model.AvailableSpaceInSquareFeet;
            _unitOfWork.ParkingSpots.Create(data);
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
            var existingData = _unitOfWork.ParkingSpots.GetById(id);

            if (existingData != null)
            {
                _unitOfWork.ParkingSpots.Delete(existingData);
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

    public List<VmParkingSpot> GetAll()
    {
        var parkingSpotList = _unitOfWork.ParkingSpots.GetAllEnumerable();
        var modelList = new List<VmParkingSpot>();
        foreach (var data in parkingSpotList)
        {
            var model = new VmParkingSpot();
            model.ParkingSpotId = data.ParkingSpotId;
            model.CompanyName = data.CompanyName;
            model.Latitude = data.Latitude;
            model.Longitude = data.Longitude;
            model.Location = data.Location;
            model.TotalSpaceInSquareFeet = data.TotalSpaceInSquareFeet;
            model.AvailableSpaceInSquareFeet = data.AvailableSpaceInSquareFeet;
            modelList.Add(model);
        }
        return modelList;
    }

    public VmParkingSpot GetById(long id)
    {
        var existingData = _unitOfWork.ParkingSpots.FirstOrDefault(p => p.ParkingSpotId == id);
        var model = new VmParkingSpot();
        if (existingData != null)
        {
            model.ParkingSpotId = existingData.ParkingSpotId;
            model.CompanyName = existingData.CompanyName;
            model.Latitude = existingData.Latitude;
            model.Longitude = existingData.Longitude;
            model.Location = existingData.Location;
            model.TotalSpaceInSquareFeet = existingData.TotalSpaceInSquareFeet;
            model.AvailableSpaceInSquareFeet = existingData.AvailableSpaceInSquareFeet;
        }
        return model;
    }

    public bool Update(VmParkingSpot model)
    {
        try
        {
            var data = new Entity.Models.ParkingSpot();
            data.ParkingSpotId = model.ParkingSpotId;
            data.CompanyName = model.CompanyName;
            data.Latitude = model.Latitude;
            data.Longitude = model.Longitude;
            data.Location = model.Location;
            data.TotalSpaceInSquareFeet = model.TotalSpaceInSquareFeet;
            data.AvailableSpaceInSquareFeet = model.AvailableSpaceInSquareFeet;
            _unitOfWork.ParkingSpots.Update(data);
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


