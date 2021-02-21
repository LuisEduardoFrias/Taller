using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class CreateClienteDto
    {
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public bool Estado { get; set; }

    }

    public class ShowClienteDto : UpdateClienteDto
    {
        [Required]
        public string FechaNacimiento_ => $"{FechaNacimiento.Date.ToString("dd/MM/yyyy")}";

        public int Edad => DateTime.Now.Year - FechaNacimiento.Year;

        public ICollection<ShowAutoDto> Autos { get; set; }
    }

    public class UpdateClienteDto : CreateClienteDto
    {

    }

}