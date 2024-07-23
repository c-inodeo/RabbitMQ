using Microsoft.AspNetCore.Mvc;
using RabbitMQApplication.Models;
using RabbitMQApplication.Services.Interface;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace RabbitMQApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IChatService _chatService;
        private readonly IProducerService _producerService;
        public HomeController(
            ILogger<HomeController> logger, 
            IChatService chatService,
            IProducerService producerService
            )
        {
            _logger = logger;
            _chatService = chatService;
            _producerService = producerService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var messages = await _chatService.SendMessage();
            return View(messages);
        }
        [HttpPost]
        public async Task<IActionResult> SendMessages(ChatMessage chatMessage)
        { 
            chatMessage.Created = DateTime.UtcNow;
            await _producerService.SendMessage<ChatMessage>(chatMessage);
            return RedirectToAction("Index");
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
