using System;
using System.ComponentModel.DataAnnotations;

namespace Taller.Dtos
{
    public class OrdenDto
    {
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public string Mecanico_Id { get; set; }
        
        [Required]
        public int Auto_Id { get; set; }
        
        [Required]
        public int Servicio_Id { get; set; }

        public MecanicoDto Mecanico { get; set; }
        
        public ShowAutoDto Auto { get; set; }
    
        public ServicioDto Servicio { get; set; }
    }
}