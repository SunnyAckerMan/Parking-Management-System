using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystem.DBContext;

namespace ParkingManagementSystem.Controllers;

public class BillingController : Controller
{
    private readonly ParkingManagementDbContext _context;
    public BillingController(ParkingManagementDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
}
