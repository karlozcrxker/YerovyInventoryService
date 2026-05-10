using Microsoft.AspNetCore.Mvc;

namespace YerovyInventoryService.Models
{
    public class Citas : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
