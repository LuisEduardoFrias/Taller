using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Taller.Dtos;
using Taller.Interface;

namespace Taller.AdoRepository
{
    public class AdoRepositoryClient : IRepositoryClient
    {
        private static AdoRepositoryClient Instance;

        private readonly IMapper _mappear;

        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="mapper"></param>
        /// <returns>retornar una instancia de AdoRepositoryClient</returns>
        public static IRepositoryClient GetInstance(IMapper mapper)
        {
            if (Instance is null)
                Instance = new AdoRepositoryClient(mapper);

            return Instance;
        }

        private AdoRepositoryClient(IMapper mappear)
        {
            _mappear = mappear;
        }


        public Task<ShowClientDto> GetClientPerIdAsync(string identificationCard)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowClientDto>> ShowListClientAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateClientAsync(CreateClientDto ClientDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateClientAsync(UpdateClientDto ClientDto)
        {
            throw new System.NotImplementedException();
        }

    }
}