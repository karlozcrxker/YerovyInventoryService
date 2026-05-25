using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YerovyInventoryService.Data;
using YerovyInventoryService.Models;

namespace TiendaVirtualGuacas.Controllers
{
    public class ProductoController : Controller
    {
        private readonly YerovyContext _context;

        public ProductoController(YerovyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var productos = _context.Productos
                .Include(p => p.Categoria)
                .ToList();

            return View(productos);
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
        public IActionResult Create(Producto producto, IFormFile imagen)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            if (imagen == null)
            {
                ModelState.AddModelError("ImagenUrl",
                    "La imagen es obligatoria");
            }

            if (ModelState.IsValid)
            {
                var nombreArchivo = Guid.NewGuid().ToString()
                                    + Path.GetExtension(imagen.FileName);

                var ruta = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/images",
                    nombreArchivo);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    imagen.CopyTo(stream);
                }

                producto.ImagenUrl = "/images/" + nombreArchivo;

                _context.Productos.Add(producto);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.Categorias = _context.Categorias.ToList();

            return View(producto);
        }

        //Formulario editar
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var producto = _context.Productos.Find(id);
            ViewBag.Categorias = _context.Categorias.ToList();

            return View(producto);
        }

        [HttpPost]
        public IActionResult Edit(Producto producto, IFormFile imagen)
        {
            if (HttpContext.Session.GetString("Usuario") == null)
            {
                return RedirectToAction("Index", "Login");
            }

            var productoBD = _context.Productos.Find(producto.Id);
            if (productoBD == null)
                return NotFound();
            //Actualizar datos normales
            productoBD.Nombre = producto.Nombre;
            productoBD.Precio = producto.Precio;
            productoBD.Stock = producto.Stock;
            productoBD.CategoriaId = producto.CategoriaId;

            //Si sube nueva imagne
            if (imagen != null)
            {
                var carpeta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                if (!Directory.Exists(carpeta))
                {
                    Directory.CreateDirectory(carpeta);
                }

                var ruta = Path.Combine(carpeta, imagen.FileName);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    imagen.CopyTo(stream);
                }
                productoBD.ImagenUrl = "/images/" + imagen.FileName;
            }

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

            var rol = HttpContext.Session.GetString("Rol");

            //SOLO ADMIN PUEDE ELIMINAR
            if (rol != "admin")
            {
                return RedirectToAction("Index");
            }

            var producto = _context.Productos.Find(id);

            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
