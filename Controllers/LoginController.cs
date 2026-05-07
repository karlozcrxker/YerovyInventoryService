using Microsoft.AspNetCore.Mvc;
using System.Linq;
using YerovyInventoryService.Data;
using YerovyInventoryService.Helpers;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Controllers
{
    public class LoginController : Controller
    {
        private readonly YerovyContext _context;
        public LoginController(YerovyContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string correo, string clave)
        {
            string claveHash = HashHelper.ObtenerHash(clave);

            var usuario = _context.Usuarios
                .FirstOrDefault(u => u.Correo == correo && u.Clave == claveHash);
            if (usuario != null)
            {
                HttpContext.Session.SetString("Usuario", usuario.Nombre);
                HttpContext.Session.SetString("Rol", usuario.Rol);

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Credenciales incorrectas";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}