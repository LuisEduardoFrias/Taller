
namespace Taller.AdoRepository
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    using Taller.Interface;
    //

    public class AdoRepositoryMechanic : IRepositoryMechanic
    {
        private static AdoRepositoryMechanic Instance;
        //private TallerDbContext _context;
        private readonly IMapper _mappear;

        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="mapper"></param>
        /// <returns>retornar una instancia de AdoRepositoryMechanic</returns>
        public static IRepositoryMechanic GetInstance(IMapper mapper)
        {
            if (Instance is null)
                Instance = new AdoRepositoryMechanic(mapper);

            return Instance;
        }

        public Task<ShowMechanicDto> GetMechanicPerId(string identificationCard)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowMechanicDto>> ShowListMechanicAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateMechanic(CreateMechanicDto MechanicDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateMechanic(UpdateMechanicDto MechanicDto)
        {
            throw new System.NotImplementedException();
        }

        private AdoRepositoryMechanic(IMapper mappear)
        {
            _mappear = mappear;
        }
    }
}