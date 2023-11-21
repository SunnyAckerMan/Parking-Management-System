using Microsoft.AspNetCore.Mvc;
using ParkingManagementSystem.DBContext;
using ParkingManagementSystem.Models;

namespace ParkingManagementSystem.Controllers;

public class TicketController : Controller
{
    private readonly ParkingManagementDbContext _context;
    public TicketController(ParkingManagementDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var ticketList = _context.Tickets.ToList();
        return View(ticketList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Ticket model)
    {
        _context.Tickets.Add(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(long id)
    {
        var existingData = _context.Tickets.FirstOrDefault(p => p.TicketId == id);
        return View(existingData);
    }

    [HttpPost]
    public IActionResult Update(Ticket model)
    {
        _context.Tickets.Update(model);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(long id)
    {
        var existingData = _context.Tickets.FirstOrDefault(p => p.TicketId == id);
        _context.Tickets.Remove(existingData);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
