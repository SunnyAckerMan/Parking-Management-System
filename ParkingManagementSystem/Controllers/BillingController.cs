using Microsoft.AspNetCore.Mvc;
using Service.Services.Billing;

namespace ParkingManagementSystem.Controllers;

public class BillingController : Controller
{
    private readonly IBillingService _service;
    public BillingController(IBillingService service)
    {
        _service = service;
    }
    public IActionResult Index()
    {
        var billingList = _service.GetAll();
        return View(billingList);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(VmBilling model)
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
    public IActionResult Update(VmBilling model)
    {
        return _service.Update(model) ? RedirectToAction("Index") : RedirectToAction("Update");
    }

    public IActionResult Delete(long id)
    {
        _service.Delete(id);
        return RedirectToAction("Index");
    }
}
