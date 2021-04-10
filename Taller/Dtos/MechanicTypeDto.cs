
namespace Taller.Dtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //

    public class CreateMechanicTypeDto
    {
        [Required]
        public string Tipo { get; set; }
    }

    public class ShowMechanicTypeDto : UpdateMechanicTypeDto
    {
        public ICollection<ShowMechanicDto> Mecanicos { get; set; }
    }

    public class UpdateMechanicTypeDto : CreateMechanicTypeDto
    {
        [Required]
        public int Id { get; set; }
    }
}