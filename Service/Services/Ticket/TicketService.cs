using Microsoft.Extensions.Logging;
using Repository.UnitOfWorks;

namespace Service.Services.Ticket;

public class TicketService : ITicketService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<TicketService> _logger;
    public TicketService(IUnitOfWork unitOfWork, ILogger<TicketService> logger)
    {
        _unitOfWork = unitOfWork;
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

            _unitOfWork.Tickets.Create(data);
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
            var existingData = _unitOfWork.Tickets.FirstOrDefault(p => p.TicketId == id);

            if (existingData != null)
            {
                _unitOfWork.Tickets.Delete(existingData);
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

    public List<VmTicket> GetAll()
    {
        var ticketList = _unitOfWork.Tickets.GetAllEnumerable();
        var modelList = new List<VmTicket>();
        foreach (var data in ticketList)
        {
            var model = new VmTicket();

            model.TicketId = data.TicketId;
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
        var existingData = _unitOfWork.Tickets.FirstOrDefault(p => p.TicketId == id);
        var model = new VmTicket();
        if (existingData != null)
        {
            model.TicketId = existingData.TicketId;
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

            _unitOfWork.Tickets.Update(data);
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
