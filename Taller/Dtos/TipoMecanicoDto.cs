
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class TipoMecanicoDto
    {
        public int Id { get; set; }

        [Required]
        public string Tiepo { get; set; }

        public ICollection<MecanicoDto> Mecanicos { get; set; }
    }
}