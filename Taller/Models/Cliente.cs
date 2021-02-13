using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models
{
    public class Cliente
    {
        [Column(TypeName = "varchar(11)")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string Cedula { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "Date")]
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Column(TypeName = "bit")]
        [Required]
        public bool Estado { get; set; }

        public ICollection<Auto> Autos { get; set; }
    }
}