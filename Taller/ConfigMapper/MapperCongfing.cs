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
        }
    }
}