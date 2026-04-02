using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Data
{
    public class YerovyContext : DbContext
    {
        public YerovyContext(DbContextOptions<YerovyContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}