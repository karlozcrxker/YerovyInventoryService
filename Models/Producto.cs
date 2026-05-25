using System.ComponentModel.DataAnnotations;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El tipo es obligatorio")]
        [StringLength(100)]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100,
            ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        [MinLength(3, ErrorMessage = "El nombre debe tener mínimo 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(1, 100000000000,
            ErrorMessage = "El precio debe ser mayor a 0")]
        public double Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio")]
        [Range(0, 1000,
            ErrorMessage = "El stock debe estar entre 0 y 1000")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int CategoriaId { get; set; }

        public Categoria? Categoria { get; set; }

        public string? ImagenUrl { get; set; }

        public double CalcularValorInventario()
        {
            return Precio * Stock;
        }

        public bool TieneStock()
        {
            return Stock > 0;
        }
    }
}