using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class CreateOrdenDetalleDto
    {
        [Required]
        public int Orden_Id { get; set; }

        [Required]
        public int Servicio_Id { get; set; }
    }

    public class ShowOrdenDetalleDto : UpdateOrdenDetalleDto
    {
        public ShowOrdenDto Orden { get; set; }

        public ShowServicioDto Servicio { get; set; }
    }

    public class UpdateOrdenDetalleDto : CreateOrdenDetalleDto
    {
        public int Id { get; set; }
    }
}