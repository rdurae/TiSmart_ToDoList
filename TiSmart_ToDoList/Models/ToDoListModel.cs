using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TiSmart_ToDoList.Models
{
    public class ToDoListModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public bool EstadoTarea { get; set; } = false;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; }
        public string Notas { get; set; } = string.Empty;
        public uint Prioridad { get; set; } = 0;
    }
}