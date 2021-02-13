using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models
{
    public class Orden
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        public DateTime Fecha { get; set; }

        [Column(TypeName = "varchar(11)")]
        [Required]
        public string Mecanico_Id { get; set; }
        
        [Required]
        public int Auto_Id { get; set; }
        
        [Required]
        public int Servicio_Id { get; set; }

        [ForeignKey("Mecanico_Id")]
        public Mecanico Mecanico { get; set; }
        
        [ForeignKey("Auto_Id")]
        public Auto Auto { get; set; }
    
        [ForeignKey("Servicio_Id")]
        public Servicio Servicio { get; set; }
    }
}