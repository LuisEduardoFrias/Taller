
namespace Taller.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    //

    public interface IRepositoryMechanic
    {

        /// <summary>
        /// Busca un Mecanico segun un Id obtenido
        /// </summary>
        /// <param name="identificationCard">Cedúla requerida para buscar un registro en la base de datos.</param>
        /// <returns>Retorna un objeto del tipo ShowMechanicDto</returns>
        Task<ShowMechanicDto> GetMechanicPerId(string identificationCard);


        /// <summary>
        /// Metodo para mostara lista de Mecanicos
        /// </summary>
        /// <returns>retorna una lista de objerto del tipo ShowMechanicDto</returns>
        Task<List<ShowMechanicDto>> ShowListMechanicAsync();


        /// <summary>
        /// Metodo para guardar un registro de un Mecanico en la base de dato
        /// </summary>
        /// <param name="MechanicDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo Mecanico en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> CreateMechanic(CreateMechanicDto MechanicDto);


        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="MechanicDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> UpdateMechanic(UpdateMechanicDto MechanicDto);
    }
}
