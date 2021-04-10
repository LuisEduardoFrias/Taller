
namespace Taller.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    //

    public interface IRepositoryService
    {

        /// <summary>
        /// Busca un Servicio segun un Id obtenido
        /// </summary>
        /// <param name="code">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retorna un objeto del tipo ShowServiceDto</returns>
        Task<ShowServiceDto> GetServicePerId(int code);


        /// <summary>
        /// Metodo para mostara lista de Services
        /// </summary>
        /// <returns>retorna una lista de objeto del tipo ShowServiceDto</returns>
        Task<List<ShowServiceDto>> ShowListServiceDto();


        /// <summary>
        /// Metodo para guardar un registro de un Servicio en la base de dato
        /// </summary>
        /// <param name="ServiceDto">Objeto que guardara en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> CreateServiceDto(CreateServiceDto ServiceDto);


        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="ServiceDto">objeto nesesario para actualizar registro de la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> UpdateServiceDto(UpdateServiceDto ServiceDto);

    }
}
