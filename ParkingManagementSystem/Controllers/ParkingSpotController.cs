using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystem.DBContext;

namespace ParkingManagementSystem.Controllers;

public class ParkingSpotController : Controller
{
    private readonly ParkingManagementDbContext _context;
    public ParkingSpotController(ParkingManagementDbContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        ViewBag.parkingSpots = _context.ParkingSpots.ToList();
        return View();
    }
}
