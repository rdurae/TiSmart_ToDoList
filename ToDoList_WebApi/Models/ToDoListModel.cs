using System.ComponentModel.DataAnnotations;

namespace ToDoList_WebApi.Models
{

    public class ToDoListModel
    {

        public int Id { get; set; }

        public string Titulo { get; set; }
        public bool EstadoTarea { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaFin { get; set; }
        public string Notas { get; set; } 
        
        public int Prioridad { get; set; }
    }
}

