
namespace Taller.AdoRepository
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    using Taller.Interface;
    //

    public class AdoRepositoryMechanicType : IRepositoryMechanicType
    {
        private static AdoRepositoryMechanicType Instance;

        private readonly IMapper _mappear;

        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="mapper"></param>
        /// <returns>retornar una instancia de AdoRepositoryMechanicType</returns>
        public static IRepositoryMechanicType GetInstance(IMapper mapper)
        {
            if (Instance is null)
                Instance = new AdoRepositoryMechanicType(mapper);

            return Instance;
        }

        private AdoRepositoryMechanicType(IMapper mappear)
        {
            _mappear = mappear;
        }

        public Task<ShowMechanicTypeDto> GetTMechanicTypePerId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowMechanicTypeDto>> ShowListTMechanicTypeDto()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateTMechanicTypeDto(CreateMechanicTypeDto TMechanicTypeDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateTMechanicTypeDto(UpdateMechanicTypeDto TMechanicTypeDto)
        {
            throw new System.NotImplementedException();
        }

    }
}