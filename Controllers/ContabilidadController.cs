using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Controllers
{
    public class ContabilidadController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ContabilidadController(ILogger<HomeController> logger)
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
