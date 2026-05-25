using System.ComponentModel.DataAnnotations;
using YerovyInventoryService.Models;

namespace YerovyInventoryService.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100,
            ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        [MinLength(3,
            ErrorMessage = "El nombre debe tener mínimo 3 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(1000,
            ErrorMessage = "La descripción no puede superar los 1000 caracteres")]
        [MinLength(5,
            ErrorMessage = "La descripción debe tener mínimo 5 caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio")]
        [RegularExpression("Activo|Inactivo",
            ErrorMessage = "El estado solo puede ser Activo o Inactivo")]
        public string Estado { get; set; }
    }
}