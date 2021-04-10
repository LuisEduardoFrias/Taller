
namespace Taller.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    //

    public interface IRepositoryCar
    {

        /// <summary>
        /// Busca un Auto segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retorna objeto del tipo ShowCarDto</returns>
        Task<ShowCarDto> GetCarPerIdAsync(int id);


        /// <summary>
        /// Metodo para mostara lista de autos
        /// </summary>
        /// <returns>retorna una lista de objerto del tipo ShowCarDto</returns>
        Task<List<ShowCarDto>> ShowListCarAsync();


        /// <summary>
        /// Metodo para guardar un registro de auto en la base de dato
        /// </summary>
        /// <param name="CarDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo auto en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> CreateCarAsync(CreateCarDto CarDto);


        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="CarDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> UpdateCarAsync(UpdateCarDto CarDto);

    }
}
