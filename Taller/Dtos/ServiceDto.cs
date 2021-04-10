
namespace Taller.Dtos
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //

    public class CreateServiceDto
    {
        public int Codigo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Costo { get; set; }
    }

    public class ShowServiceDto : UpdateServiceDto
    {
        public ICollection<ShowOrderDetailDto> OrdenDetalle { get; set; }
    }

    public class UpdateServiceDto : CreateServiceDto
    {

    }


}