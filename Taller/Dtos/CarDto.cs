
namespace Taller.Dtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //

    public class CreateCarDto
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

    public class ShowCarDto : UpdateCarDto
    {
        public ShowClientDto Cliente { get; set; }

        public string Cliente_ => $"{Cliente.Nombre }";

        public ICollection<ShowOrderDto> Ordenes { get; set; }

    }

    public class UpdateCarDto : CreateCarDto
    {
        [Required]
        public int Id { get; set; }
    }

}