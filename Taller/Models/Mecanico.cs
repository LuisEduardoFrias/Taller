using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models
{
    public class Mecanico
    {
        [Column(TypeName = "varchar(11)")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Cedula { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Column(TypeName = "date")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int TipoMecanico_Id { get; set; }

        [ForeignKey("TipoMecanico_Id")]
        public TipoMecanico TipoMecanico { get; set; }

        public ICollection<Orden> Ordenes { get; set; }

    }

}