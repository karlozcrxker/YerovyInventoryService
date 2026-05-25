using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YerovyInventoryService.Data;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly YerovyContext _context;

        public CategoriaController(YerovyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var categorias = _context.Categorias.ToList();

            return View(categorias);
        }

        //Guardar producto

        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewBag.Categorias = _context.Categorias.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Categoria categoria)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (ModelState.IsValid)
            {
                _context.Categorias.Add(categoria);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        //Formulario editar
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var categoria = _context.Categorias.Find(id);
            ViewBag.Categorias = _context.Categorias.ToList();

            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            _context.Categorias.Update(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        //Eliminar producto
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var categoria = _context.Categorias.Find(id);

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
