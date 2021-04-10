
namespace Taller.AdoRepository
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    using Taller.Interface;
    //

    public class AdoRepositoryServicio : IRepositoryService
    {
        private static AdoRepositoryServicio Instance;

        private readonly IMapper _mappear;

        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="mapper"></param>
        /// <returns>retornar una instancia de AdoRepositoryServicio</returns>
        public static IRepositoryService GetInstance(IMapper mapper)
        {
            if (Instance is null)
                Instance = new AdoRepositoryServicio(mapper);

            return Instance;
        }


        private AdoRepositoryServicio(IMapper mappear)
        {
            _mappear = mappear;
        }

        public Task<bool> CreateServiceDto(CreateServiceDto ServiceDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<ShowServiceDto> GetServicePerId(int code)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowServiceDto>> ShowListServiceDto()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateServiceDto(UpdateServiceDto ServiceDto)
        {
            throw new System.NotImplementedException();
        }

    }
}