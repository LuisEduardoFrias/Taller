using System;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{

    public class CreateOrdenDto
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Mecanico_Id { get; set; }

        [Required]
        public int Auto_Id { get; set; }

        [Required]
        public int Servicio_Id { get; set; }

    }

    public class ShowOrdenDto : UpdateOrdenDto
    {
        public ShowMecanicoDto Mecanico { get; set; }

        public ShowAutoDto Auto { get; set; }

        public ShowServicioDto Servicio { get; set; }
    }

    public class UpdateOrdenDto : CreateOrdenDto
    {
        public int Id { get; set; }
    }

}