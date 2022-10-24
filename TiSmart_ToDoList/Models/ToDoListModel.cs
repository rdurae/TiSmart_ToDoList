﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace TiSmart_ToDoList.Models
{
    public class ToDoListModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; } = string.Empty;
        public bool EstadoTarea { get; set; } = false;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public DateTime FechaFin { get; set; } = (DateTime)SqlDateTime.MinValue;
        [Required]
        public string Notas { get; set; } = string.Empty;
        [Required]
        public int Prioridad { get; set; } 
    }


}