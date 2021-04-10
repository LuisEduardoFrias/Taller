
namespace Taller.Interface
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    //
    using Taller.Dtos;
    //

    public interface IRepositoryOrder
    {
        /// <summary>
        /// Busca una Orden segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retorna un objeto del tipo ShowOrderDto</returns>
        Task<ShowOrderDto> GetOrderPerIdAsync(int id);


        /// <summary>
        /// Metodo para mostara lista de Orders
        /// </summary>
        /// <returns>retorna una lista de objeto del tipo ShowOrderDto</returns>
        Task<List<ShowOrderDto>> ShowListOrderAsync();


        /// <summary>
        /// Metodo para guardar un registro de un Orden en la base de dato
        /// </summary>
        /// <param name="OrderDto">Objeto que contiene los datos nesesarios para guardar un registro de una Orden en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> CreateOrderAsync(CreateOrderDto OrderDto);


        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="OrderDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        Task<bool> UpdateOrderAsync(UpdateOrderDto OrderDto);
    }
}
