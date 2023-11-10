using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystem.DBContext;

namespace ParkingManagementSystem.Controllers;

public class RateController : Controller
{
    private readonly ParkingManagementDbContext _context;

    public RateController(ParkingManagementDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        return View();
    }
}
