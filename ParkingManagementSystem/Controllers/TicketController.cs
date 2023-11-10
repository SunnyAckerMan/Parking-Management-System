using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystem.DBContext;

namespace ParkingManagementSystem.Controllers;

public class TicketController : Controller
{
    private readonly ParkingManagementDbContext _context;
    public TicketController(ParkingManagementDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
}
