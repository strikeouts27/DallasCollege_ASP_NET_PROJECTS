using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MyWebsite2.Models;

namespace MyWebsite2.Controllers
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

        public ActionResult Contacts()
        {
            // Simulate contact info
            var contact = new
            {
                Name = "Jane Doe",
                Email = "jane.doe@example.com",
                Phone = "(555) 123-4567",
                Title = "Senior Analyst"
            };

            // Pass to view using ViewBag
            ViewBag.Contact = contact;

            return View();
        }

    }
}
