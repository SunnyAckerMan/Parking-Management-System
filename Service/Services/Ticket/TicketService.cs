using Microsoft.Extensions.Logging;
using Repository.DBContext;

namespace Service.Services.Ticket;

public class TicketService : ITicketService
{
    private readonly ParkingManagementDbContext _context;
    private readonly ILogger<TicketService> _logger;
    public TicketService(ParkingManagementDbContext context, ILogger<TicketService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public bool Create(VmTicket model)
    {
        try
        {
            var data = new Entity.Models.Ticket();
            
            data.VehicleNumber = model.VehicleNumber;
            data.OwnerName = model.OwnerName;
            data.OwnerPhoneNo = model.OwnerPhoneNo;
            data.OwnerEmail = model.OwnerEmail;
            data.OwnerNID = model.OwnerNID;
            data.EntryTime = model.EntryTime; 
            data.ExitTime = model.ExitTime; 
            data.ParkingSpotIdFk = model.ParkingSpotIdFk; 

            _context.Tickets.Add(data);
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
            var existingData = _context.Tickets.FirstOrDefault(p => p.TicketId == id);

            if (existingData != null)
            {
                _context.Tickets.Remove(existingData);
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

    public List<VmTicket> GetAll()
    {
        var ticketList = _context.Tickets.ToList();
        var modelList = new List<VmTicket>();
        foreach (var data in ticketList)
        {
            var model = new VmTicket();

            model.VehicleNumber = data.VehicleNumber;
            model.OwnerName = data.OwnerName;
            model.OwnerPhoneNo = data.OwnerPhoneNo;
            model.OwnerEmail = data.OwnerEmail;
            model.OwnerNID = data.OwnerNID;
            model.EntryTime = data.EntryTime;
            model.ExitTime = data.ExitTime;
            model.ParkingSpotIdFk = data.ParkingSpotIdFk;

            modelList.Add(model);
        }
        return modelList;
    }

    public VmTicket GetById(long id)
    {
        var existingData = _context.Tickets.FirstOrDefault(p => p.TicketId == id);
        var model = new VmTicket();
        if (existingData != null)
        {
            model.VehicleNumber = existingData.VehicleNumber;
            model.OwnerName = existingData.OwnerName;
            model.OwnerPhoneNo = existingData.OwnerPhoneNo;
            model.OwnerEmail = existingData.OwnerEmail;
            model.OwnerNID = existingData.OwnerNID;
            model.EntryTime = existingData.EntryTime;
            model.ExitTime = existingData.ExitTime;
            model.ParkingSpotIdFk = existingData.ParkingSpotIdFk;
        }
        return model;
    }

    public bool Update(VmTicket model)
    {
        try
        {
            var data = new Entity.Models.Ticket();

            data.VehicleNumber = model.VehicleNumber;
            data.OwnerName = model.OwnerName;
            data.OwnerPhoneNo = model.OwnerPhoneNo;
            data.OwnerEmail = model.OwnerEmail;
            data.OwnerNID = model.OwnerNID;
            data.EntryTime = model.EntryTime;
            data.ExitTime = model.ExitTime;
            data.ParkingSpotIdFk = model.ParkingSpotIdFk;

            _context.Tickets.Update(data);
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
