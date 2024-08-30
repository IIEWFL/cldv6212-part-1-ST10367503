using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Webapp_Part1.Models;

public class CustomerController : Controller
{
    private readonly AzureTableService _tableService;

    public CustomerController(AzureTableService tableService)
    {
        _tableService = tableService;
    }

    public async Task<IActionResult> Index()
    {
        var profile = await _tableService.GetCustomerProfileAsync("partitionKey", "rowKey");
        return View(profile);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CustomerProfile profile)
    {
        await _tableService.AddCustomerProfileAsync(profile);
        return RedirectToAction("Index");
    }
}

