
namespace Taller.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //

    public class CreateMechanicDto
    {
        public string Cedula { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public bool Estado { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int TipoMecanico_Id { get; set; }
    }

    public class ShowMechanicDto : UpdateMechanicDto
    {
        public ShowMechanicTypeDto TipoMecanico { get; set; }

        public string TipoMecanico_ => $"{TipoMecanico.Tipo}";

        public string FechaNacimiento_ => FechaNacimiento.ToString("dd/MM/yyyy");

        public int Edad => DateTime.Now.Year - FechaNacimiento.Year;

        public ICollection<ShowOrderDto> Ordenes { get; set; }
    }

    public class UpdateMechanicDto : CreateMechanicDto
    {

    }
}