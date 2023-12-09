using Microsoft.AspNetCore.Mvc;
using Service.Services.Ticket;

namespace ParkingManagementSystem.Controllers;

public class TicketController : Controller
{
    private readonly ITicketService _service;
    public TicketController(ITicketService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var ticketList = _service.GetAll();
        return View(ticketList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        //ViewBag.CompanyName = _service.GetAll();
        return View();
    }

    [HttpPost]
    public IActionResult Create(VmTicket model)
    {
        return _service.Create(model) ? RedirectToAction("Index") : RedirectToAction("Create");
    }

    [HttpGet]
    public IActionResult Update(long id)
    {
        var existingData = _service.GetById(id);
        return View(existingData);
    }

    [HttpPost]
    public IActionResult Update(VmTicket model)
    {
        return _service.Update(model) ? RedirectToAction("Index") : RedirectToAction("Update");
    }

    public IActionResult Delete(long id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }
}
