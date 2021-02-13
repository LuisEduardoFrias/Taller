using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class ClienteDto
    {
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public bool Estado { get; set; }

        public ICollection<ShowAutoDto> Autos { get; set; }
    }
}