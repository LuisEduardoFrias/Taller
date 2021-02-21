using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.Data;
//
using Taller.Dtos;
using Taller.Models;
//

namespace Taller.Repository
{
    public class RepositoryCliente
    {

        private static RepositoryCliente Instance;
        private TallerDbContext _context;
        private readonly IMapper _mappear;


        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="context">Una instancia del contexto de datos</param>
        /// <param name="mapper">una instancia de Clientemapper</param>
        /// <returns>retornar una instancia del repositorioCliente</returns>
        public static RepositoryCliente GetInstance(TallerDbContext context, IMapper mapper)
        {
            if (Instance is null)
                Instance = new RepositoryCliente(context, mapper);

            Instance._context = context;

            return Instance;
        }


        private RepositoryCliente(TallerDbContext context, IMapper mappear)
        {
            _context = context;
            _mappear = mappear;
        }



        /// <summary>
        /// Busca un Cliente segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retornar ShowClienteDto</returns>
        public async Task<ShowClienteDto> GetClientePerId(string cedula)
        {
            Cliente Cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Cedula == cedula);

            if (Cliente == null)
                return null;

            return _mappear.Map<ShowClienteDto>(Cliente);
        }



        /// <summary>
        /// Metodo para mostara lista de Clientes
        /// </summary>
        /// <returns>retorna una lista un objerto de traferencia de datos Cliente </returns>
        public async Task<List<ShowClienteDto>> ShowListClienteDto()
        {
            List<Cliente> ListCliente = await _context.Clientes
                                                      .OrderBy(x => x.Nombre)
                                                      .ToListAsync();

            return _mappear.Map<List<ShowClienteDto>>(ListCliente);
        }



        /// <summary>
        /// Metodo para guardar un registro de un Cliente en la base de dato
        /// </summary>
        /// <param name="ClienteDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo Cliente en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> CreateClienteDto(CreateClienteDto ClienteDto)
        {
            Cliente Cliente = _mappear.Map<Cliente>(ClienteDto);

            _context.Clientes.Add(Cliente);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }



        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="ClienteDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> UpdateClienteDto(UpdateClienteDto ClienteDto)
        {
            Cliente Cliente = await _context.Clientes.FirstOrDefaultAsync(x => x.Cedula == ClienteDto.Cedula);

            Cliente = _mappear.Map<Cliente>(ClienteDto);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }


    }
}