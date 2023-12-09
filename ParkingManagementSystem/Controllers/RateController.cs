using Microsoft.AspNetCore.Mvc;
using Service.Services.Rate;

namespace ParkingManagementSystem.Controllers;

public class RateController : Controller
{
    private readonly IRateService _service;
    public RateController(IRateService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var rateList = _service.GetAll();
        return View(rateList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(VmRate model)
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
    public IActionResult Update(VmRate model)
    {
        return _service.Update(model) ? RedirectToAction("Index") : RedirectToAction("Update");
    }

    public IActionResult Delete(long id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }
}
