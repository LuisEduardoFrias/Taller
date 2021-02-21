
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class CreateAutoDto
    {
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public int Años { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Placa { get; set; }

        [Required]
        public string Cliente_Id { get; set; }

    }

    public class ShowAutoDto : UpdateAutoDto
    {
        public ShowClienteDto Cliente { get; set; }

        public string Cliente_ => $"{Cliente.Nombre }";

        public ICollection<ShowOrdenDto> Ordenes { get; set; }

    }

    public class UpdateAutoDto : CreateAutoDto
    {
        [Required]
        public int Id { get; set; }
    }

}