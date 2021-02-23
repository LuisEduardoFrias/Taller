
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class CreateServicioDto
    {
        public int Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Costo { get; set; }
    }

    public class ShowServicioDto : UpdateServicioDto
    {
        public ICollection<ShowOrdenDetalleDto> OrdenDetalle { get; set; }
    }

    public class UpdateServicioDto : CreateServicioDto
    {

    }


}