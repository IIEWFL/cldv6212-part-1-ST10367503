using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

public class OrderController : Controller
{
    private readonly AzureQueueService _queueService;

    public OrderController(AzureQueueService queueService)
    {
        _queueService = queueService;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessOrder(string orderDetails)
    {
        await _queueService.SendMessageAsync(orderDetails);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> GetOrder()
    {
        var message = await _queueService.ReceiveMessageAsync();
        return View("OrderDetails", message);
    }
}

