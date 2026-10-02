using System.ComponentModel.DataAnnotations;

namespace TechStore.Models
{
    public class Categoria
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        // Relación: 1 Categoría tiene muchos Productos
        public virtual ICollection<Producto> Productos { get; set; }
    }
}