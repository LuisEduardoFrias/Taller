
namespace Taller.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //

    public class CreateClientDto
    {
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public bool Estado { get; set; }

    }

    public class ShowClientDto : UpdateClientDto
    {
        [Required]
        public string FechaNacimiento_ => FechaNacimiento.ToString("dd/MM/yyyy");

        public int Edad => DateTime.Now.Year - FechaNacimiento.Year;

        public ICollection<ShowCarDto> Autos { get; set; }
    }

    public class UpdateClientDto : CreateClientDto
    {

    }

}