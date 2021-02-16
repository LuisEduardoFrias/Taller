using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class CreateMecanicoDto
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
    }

    public class ShowMecanicoDto : UpdateMecanicoDto
    {
        public ICollection<ShowOrdenDto> Ordenes { get; set; }
    }

    public class UpdateMecanicoDto : CreateMecanicoDto
    {

        public CreateTipoMecanicoDto TipoMecanico { get; set; }
    }
}