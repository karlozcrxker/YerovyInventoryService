using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Controllers
{
    public class CitasController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public CitasController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            return View();
        }
    }
}
