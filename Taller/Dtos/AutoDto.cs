
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class CreateAutoDto
    {
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelos { get; set; }

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
        public ClienteDto Cliente { get; set; }

        public ICollection<OrdenDto> Ordenes { get; set; }

    }

    public class UpdateAutoDto : CreateAutoDto
    {
        [Required]
        public int Id { get; set; }
    }

}