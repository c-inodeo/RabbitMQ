using Microsoft.AspNetCore.Mvc;
using RabbitMQApplication.Models;
using RabbitMQApplication.Services.Interface;
using System.Diagnostics;

namespace RabbitMQApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProducerService _producerService;
        public HomeController(ILogger<HomeController> logger, IProducerService producerService)
        {
            _logger = logger;
            _producerService = producerService;
        }

        public IActionResult Index()
        {
            _producerService.SendMessage("hello");
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
