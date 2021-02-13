
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class ServicioDto
    {
        public int Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Costo { get; set; }

        public ICollection<OrdenDto> Ordenes { get; set; }
    }
}