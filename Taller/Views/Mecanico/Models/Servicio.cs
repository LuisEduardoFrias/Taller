
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models
{
    public class Servicio
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Codigo { get; set; }

        [Column(TypeName = "varchar(100)")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [Required]
        public decimal Costo { get; set; }

        public ICollection<OrdenDetalle> OrdenDetalle { get; set; }

    }
}