namespace Service.Services.Ticket;

public interface ITicketService
{
    bool Create(VmTicket model);
    bool Update(VmTicket model);
    bool Delete(long id);
    List<VmTicket> GetAll();
    VmTicket GetById(long id);
}
