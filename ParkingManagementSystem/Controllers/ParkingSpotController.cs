using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystem.DBContext;
using ParkingManagementSystem.Models;

namespace ParkingManagementSystem.Controllers;

public class ParkingSpotController : Controller
{
    private readonly ParkingManagementDbContext _context;
    public ParkingSpotController(ParkingManagementDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
       var parkingSpotList = _context.ParkingSpots.ToList();
        return View(parkingSpotList);
    }

    [HttpGet]
    public IActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ParkingSpot model)
    {
        _context.ParkingSpots.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(long id)
    {
        var existingData = _context.ParkingSpots.FirstOrDefault(p => p.ParkingSpotId == id);
        return View(existingData);
    }

    [HttpPost]
    public IActionResult Update(ParkingSpot model)
    {
        _context.ParkingSpots.Update(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(long id)
    {
        var existingData = _context.ParkingSpots.FirstOrDefault(p => p.ParkingSpotId == id);
        _context.ParkingSpots.Remove(existingData);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

}
