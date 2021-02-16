
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class CreateTipoMecanicoDto
    {
        [Required]
        public string Tiepo { get; set; }
    }

    public class ShowTipoMecanicoDto : UpdateTipoMecanicoDto
    {
        public ICollection<ShowMecanicoDto> Mecanicos { get; set; }

    }

    public class UpdateTipoMecanicoDto : CreateTipoMecanicoDto
    {
        [Required]
        public int Id { get; set; }
    }
}