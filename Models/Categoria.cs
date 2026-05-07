using System.ComponentModel.DataAnnotations;

namespace YerovyInventoryService.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [StringLength(100000)]
        public string Descripcion { get; set; }

        [StringLength(100000)]
        public string Estado { get; set; }
    }
}