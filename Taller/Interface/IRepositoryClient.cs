
namespace Taller.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    //

    public interface IRepositoryClient
    {

        /// <summary>
        /// Busca un Cliente segun un Id obtenido
        /// </summary>
        /// <param name="identificationCard">Cedúla requerida para buscar un registro en la base de datos.</param>
        /// <returns>Retorna un objeto del tipo ShowClientDto</returns>
        Task<ShowClientDto> GetClientPerIdAsync(string identificationCard);


        /// <summary>
        /// Metodo para mostara lista de Clientes
        /// </summary>
        /// <returns>retorna una lista de objeto del tipo ShowClientDto</returns>
        Task<List<ShowClientDto>> ShowListClientAsync();


        /// <summary>
        /// Metodo para guardar un registro de un Cliente en la base de dato
        /// </summary>
        /// <param name="ClientDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo Cliente en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> CreateClientAsync(CreateClientDto ClientDto);


        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="ClientDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> UpdateClientAsync(UpdateClientDto ClientDto);

    }
}
