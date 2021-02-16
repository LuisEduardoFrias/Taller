using AutoMapper;
using Taller.Dtos;
using Taller.Models;

namespace Taller.ConfigMapper
{
    public class MapperCongfing:Profile
    {
        public MapperCongfing()
        {
            //map auto
            CreateMap<Auto, ShowAutoDto>();
            CreateMap<CreateAutoDto, Auto >();
            CreateMap<UpdateAutoDto, Auto >();

            //map cliente
            CreateMap<Cliente, ShowClienteDto> ();
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();

            //map mecanico
            CreateMap<Mecanico,ShowMecanicoDto>();
            CreateMap<CreateMecanicoDto, Mecanico>();
            CreateMap<UpdateMecanicoDto, Mecanico>();
            
            //map orden
            CreateMap<Orden,ShowOrdenDto>();
            CreateMap<CreateOrdenDto, Orden>();
            CreateMap<UpdateOrdenDto, Orden>();

            //map serivicio
            CreateMap<Servicio,ShowServicioDto>();
            CreateMap<CreateServicioDto, Servicio>();
            CreateMap<UpdateServicioDto, Servicio>();

            //map tipo mecanico
            CreateMap<TipoMecanico,ShowTipoMecanicoDto>();
            CreateMap<CreateTipoMecanicoDto, TipoMecanico>();
            CreateMap<UpdateTipoMecanicoDto, TipoMecanico>();

        }
    }
}