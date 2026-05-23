using System.ComponentModel.DataAnnotations;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string Tipo { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Range(0, 100000000000)]
        public double Precio { get; set; }

        [Range(0, 100)]
        public int Stock { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public double CalcularValorInventario()
        {
            return Precio * Stock;
        }
        public bool TieneStock()
        {
            return Stock > 0;
        }

        public string ImagenUrl { get; set; }
    }
}
