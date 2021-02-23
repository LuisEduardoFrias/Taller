using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models
{
    public class OrdenDetalle
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public int Orden_Id { get; set; }

        [Required]
        public int Servicio_Id { get; set; }


        [ForeignKey("Orden_Id")]
        public Orden Orden { get; set; }

        [ForeignKey("Servicio_Id")]
        public Servicio Servicio { get; set; }

    }
}