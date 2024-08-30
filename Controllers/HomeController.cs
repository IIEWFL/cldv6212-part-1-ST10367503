using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Webapp_Part1.Models;
using Azure.Storage.Blobs;
using Azure.Data.Tables;
using Azure.Storage.Files;
using Azure.Storage.Queues;



namespace Webapp_Part1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
