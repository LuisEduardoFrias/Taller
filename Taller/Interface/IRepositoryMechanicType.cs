
namespace Taller.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    //

    public interface IRepositoryMechanicType
    {

        /// <summary>
        /// Busca un TMechanicType segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retorna un objeto del tipo ShowTMechanicTypeDto</returns>
        Task<ShowMechanicTypeDto> GetTMechanicTypePerId(int id);


        /// <summary>
        /// Metodo para mostara lista de TMechanicTypes
        /// </summary>
        /// <returns>retorna una lista de objeto del tipo ShowTMechanicTypeDto</returns>
        Task<List<ShowMechanicTypeDto>> ShowListTMechanicTypeDto();


        /// <summary>
        /// Metodo para guardar un registro de un tipo de mecanico en la base de dato
        /// </summary>
        /// <param name="TMechanicTypeDto">Objeto que de guardara en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> CreateTMechanicTypeDto(CreateMechanicTypeDto TMechanicTypeDto);


        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="TMechanicTypeDto">objeto nesesario para actualizar registro en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> UpdateTMechanicTypeDto(UpdateMechanicTypeDto TMechanicTypeDto);

    }
}
