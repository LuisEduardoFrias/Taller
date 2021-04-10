
namespace Taller.AdoRepository
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    using Taller.Interface;
    //

    public class AdoRepositoryCar : IRepositoryCar
    {
        private static AdoRepositoryCar Instance;

        private readonly IMapper _mappear;

        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="mapper"></param>
        /// <returns>retornar una instancia de AdoRepositoryCar</returns>
        public static IRepositoryCar GetInstance(IMapper mapper)
        {
            if (Instance is null)
                Instance = new AdoRepositoryCar(mapper);

            return Instance;
        }

        private AdoRepositoryCar(IMapper mappear)
        {
            _mappear = mappear;
        }


        public Task<ShowCarDto> GetCarPerIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowCarDto>> ShowListCarAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateCarAsync(CreateCarDto CarDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateCarAsync(UpdateCarDto CarDto)
        {
            throw new System.NotImplementedException();
        }

    }
}