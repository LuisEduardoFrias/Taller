
namespace Taller.AdoRepository
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    using Taller.Interface;
    //

    public class AdoRepositoryOrder : IRepositoryOrder
    {
        private static AdoRepositoryOrder Instance;

        private readonly IMapper _mappear;

        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="mapper"></param>
        /// <returns>retornar una instancia de AdoRepositoryOrder</returns>
        public static IRepositoryOrder GetInstance(IMapper mapper)
        {
            if (Instance is null)
                Instance = new AdoRepositoryOrder(mapper);

            return Instance;
        }

        private AdoRepositoryOrder(IMapper mappear)
        {
            _mappear = mappear;
        }

        public Task<ShowOrderDto> GetOrderPerIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowOrderDto>> ShowListOrderAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateOrderAsync(CreateOrderDto OrderDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateOrderAsync(UpdateOrderDto OrderDto)
        {
            throw new System.NotImplementedException();
        }

    }
}