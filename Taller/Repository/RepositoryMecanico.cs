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
    public class RepositoryMecanico
    {

        private static RepositoryMecanico Instance;
        private TallerDbContext _context;
        private readonly IMapper _mappear;


        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="context">Una instancia del contexto de datos</param>
        /// <param name="mapper">una instancia de Mecanicomapper</param>
        /// <returns>retornar una instancia del repositorioMecanico</returns>
        public static RepositoryMecanico GetInstance(TallerDbContext context, IMapper mapper)
        {
            if (Instance is null)
                Instance = new RepositoryMecanico(context, mapper);

            Instance._context = context;

            return Instance;
        }


        private RepositoryMecanico(TallerDbContext context, IMapper mappear)
        {
            _context = context;
            _mappear = mappear;
        }



        /// <summary>
        /// Busca un Mecanico segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retornar ShowMecanicoDto</returns>
        public async Task<ShowMecanicoDto> GetMecanicoPerId(string cedula)
        {
            Mecanico Mecanico = await _context.Mecanicos.FirstOrDefaultAsync(x => x.Cedula == cedula);

            if (Mecanico == null)
                return null;

            return _mappear.Map<ShowMecanicoDto>(Mecanico);
        }



        /// <summary>
        /// Metodo para mostara lista de Mecanicos
        /// </summary>
        /// <returns>retorna una lista un objerto de traferencia de datos Mecanico </returns>
        public async Task<List<ShowMecanicoDto>> ShowListMecanicoDto()
        {
            List<Mecanico> ListMecanico = await _context.Mecanicos
                                                      .Include(x => x.TipoMecanico)
                                                      .OrderBy(x => x.Nombre)
                                                      .Where(x => x.Estado == true)
                                                      .ToListAsync();

            return _mappear.Map<List<ShowMecanicoDto>>(ListMecanico);
        }



        /// <summary>
        /// Metodo para guardar un registro de un Mecanico en la base de dato
        /// </summary>
        /// <param name="MecanicoDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo Mecanico en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> CreateMecanicoDto(CreateMecanicoDto MecanicoDto)
        {
            Mecanico Mecanico = _mappear.Map<Mecanico>(MecanicoDto);

            _context.Mecanicos.Add(Mecanico);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }



        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="MecanicoDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> UpdateMecanicoDto(UpdateMecanicoDto MecanicoDto)
        {
            Mecanico Mecanico = await _context.Mecanicos.FirstOrDefaultAsync(x => x.Cedula == MecanicoDto.Cedula);

            Mecanico = _mappear.Map<Mecanico>(MecanicoDto);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }


    }
}