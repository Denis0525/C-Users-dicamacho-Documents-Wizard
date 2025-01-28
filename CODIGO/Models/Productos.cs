using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoWizard.Models
{
    public class Productos
    {
        [Key]

        [Display(Name = "Id")]
        public int id_producto { get; set; }
        [Display(Name = "Nombre")]
        [Column(TypeName = "varchar(255)")]
        public string? nombre { get; set; }
        [Display(Name = "Precio")]
        public decimal precio { get; set; }
        [Display(Name = "Cantidad")]
        public int cantidad { get; set; }
        [Display(Name = "Fecha")]
        public DateTime fecha_registro { get; set; }
        [Display(Name = "Estado")]
        public bool estado { get; set; }
    }
}