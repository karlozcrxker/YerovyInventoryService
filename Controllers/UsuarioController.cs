using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YerovyInventoryService.Helpers;
using YerovyInventoryService.Data;
using YerovyInventoryService.Models;


namespace YerovyInventoryService.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly YerovyContext _context;

        public UsuarioController(YerovyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var usuarios = _context.Usuarios.ToList();

            return View(usuarios);
        }

        //Guardar usuario

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Usuario") == "Cliente")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            if (HttpContext.Session.GetString("Usuario") == "Cliente")
            {
                return RedirectToAction("Index", "Home");
            }

            if (ModelState.IsValid)
            {
                usuario.Clave = HashHelper.ObtenerHash(usuario.Clave);

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(usuario);

        }

        //Formulario editar
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var usuario = _context.Usuarios.Find(id);
            ViewBag.Usuarios = _context.Usuarios.ToList();

            return View(usuario);
        }

        //Actualizar usuario
        [HttpPost]
        public IActionResult Edit(Usuario usuario)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                usuario.Clave = HashHelper.ObtenerHash(usuario.Clave);

                _context.Usuarios.Update(usuario);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        //Eliminar usuario
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var usuario = _context.Usuarios.Find(id);

            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
