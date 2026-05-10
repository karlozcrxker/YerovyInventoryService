using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YerovyInventoryService.Helpers;
using YerovyInventoryService.Data;
using YerovyInventoryService.Models;


namespace YerovyInventoryService.Controllers
{
    public class CitasController : Controller
    {
        private readonly YerovyContext _context;

        public CitasController(YerovyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var citas = _context.Citas.ToList();

            return View(citas);
        }
    }
}
