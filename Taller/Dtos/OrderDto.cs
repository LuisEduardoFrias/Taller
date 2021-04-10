
namespace Taller.Dtos
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //

    public class CreateOrderDto
    {
        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Mecanico_Id { get; set; }

        [Required]
        public int Auto_Id { get; set; }

        [Required]
        public int Servicio_Id { get; set; }

        [Required]
        public decimal CostoServicio { get; set; }

    }

    public class ShowOrderDto : UpdateOrderDto
    {
        public ShowMechanicDto Mecanico { get; set; }

        public ShowCarDto Auto { get; set; }

        public string Mecanico_ => $"{Mecanico.Nombre}";

        public string Auto_ => $"{Auto.Placa} - {Auto.Marca} - {Auto.Modelo}";

        public ICollection<ShowOrderDetailDto> OrdenDetalle { get; set; }
            
    }

    public class UpdateOrderDto : CreateOrderDto
    {
        public int Id { get; set; }
    }

}