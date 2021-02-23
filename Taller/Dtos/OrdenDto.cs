using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{

    public class CreateOrdenDto
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

    public class ShowOrdenDto : UpdateOrdenDto
    {
        public ShowMecanicoDto Mecanico { get; set; }

        public ShowAutoDto Auto { get; set; }

        public string Mecanico_ => $"{Mecanico.Nombre}";

        public string Auto_ => $"{Auto.Placa} - {Auto.Marca} - {Auto.Modelo}";

        public ICollection<ShowOrdenDetalleDto> OrdenDetalle { get; set; }
            
    }

    public class UpdateOrdenDto : CreateOrdenDto
    {
        public int Id { get; set; }
    }

}