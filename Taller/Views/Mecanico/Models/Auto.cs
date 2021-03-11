
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models
{
    public class Auto
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Marca { get; set; }

        [Column(TypeName = "varchar(50)")]
        [Required]
        public string Modelo { get; set; }

        [Column(TypeName = "tinyint")]
        [Required]
        public int Años { get; set; }

        [Column(TypeName = "varchar(20)")]
        [Required]
        public string Color { get; set; }

        [Column(TypeName = "varchar(10)")]
        [Required]
        public string Placa { get; set; }

        [Column(TypeName = "varchar(11)")]
        [Required]
        public string Cliente_Id { get; set; }

        [ForeignKey("Cliente_Id")]
        public Cliente Cliente { get; set; }

        public ICollection<Orden> Ordenes { get; set; }

    }
}