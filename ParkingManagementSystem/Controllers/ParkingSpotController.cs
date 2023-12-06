using Microsoft.AspNetCore.Mvc;
using Service.Services.ParkingSpot;

namespace ParkingManagementSystem.Controllers;

public class ParkingSpotController : Controller
{
    private readonly IParkingSpotService _service;
    public ParkingSpotController(IParkingSpotService Service)
    {
        _service = Service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var data = _service.GetAll();
        return View(data);
    }

    [HttpGet]
    public IActionResult Create() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(VmParkingSpot model)
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
    public IActionResult Update(VmParkingSpot model)
    {
        return _service.Update(model) ? RedirectToAction("Index") : RedirectToAction("Update");
    }

    public IActionResult Delete(long id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }

}
