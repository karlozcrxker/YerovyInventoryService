using System.ComponentModel.DataAnnotations;

namespace YerovyInventoryService.Models
{
    public class Citas
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        public DateTimeOffset Fecha { get; set; }
    
    }
}
