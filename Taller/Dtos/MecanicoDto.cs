using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class MecanicoDto
    {
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int TipoMecanico_Id { get; set; }

        public TipoMecanicoDto TipoMecanico { get; set; }

        public ICollection<OrdenDto> Ordenes { get; set; }

    }
}