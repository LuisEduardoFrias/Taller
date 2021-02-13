
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Taller.Models
{
    public class TipoMecanico
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "varchar(30)")]
        [Required]
        public string Tiepo { get; set; }

        public ICollection<Mecanico> Mecanicos { get; set; }
    }
}