
namespace Taller.Dtos
{
    using System.ComponentModel.DataAnnotations;
    //

    public class CreateOrderDetailDto
    {
        [Required]
        public int Orden_Id { get; set; }

        [Required]
        public int Servicio_Id { get; set; }
    }

    public class ShowOrderDetailDto : UpdateOrderDetailDto
    {
        public ShowOrderDto Orden { get; set; }

        public ShowServiceDto Servicio { get; set; }
    }

    public class UpdateOrderDetailDto : CreateOrderDetailDto
    {
        public int Id { get; set; }
    }
}