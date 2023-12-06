using Microsoft.Extensions.Logging;
using Repository.DBContext;

namespace Service.Services.ParkingSpot;

public class ParkingSpotService : IParkingSpotService
{
    private readonly ParkingManagementDbContext _context;
    private readonly ILogger<ParkingSpotService> _logger;
    public ParkingSpotService(ParkingManagementDbContext context, ILogger<ParkingSpotService> logger)
    {
        _context = context;
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
            _context.ParkingSpots.Add(data);
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
            var existingData = _context.ParkingSpots.FirstOrDefault(p => p.ParkingSpotId == id);

            if (existingData != null)
            {
                _context.ParkingSpots.Remove(existingData);
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

    public List<VmParkingSpot> GetAll()
    {
        var parkingSpotList = _context.ParkingSpots.ToList();
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
        var existingData = _context.ParkingSpots.FirstOrDefault(p => p.ParkingSpotId == id);
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
            _context.ParkingSpots.Update(data);
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


