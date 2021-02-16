using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Taller.Dtos;
using Taller.Models;

namespace Taller.Data
{
    public class RepositoryAuto
    {

        private static RepositoryAuto Instance;
        private TallerDbContext _context;
        private readonly IMapper _mappear;


        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="context">Una instancia del contexto de datos</param>
        /// <param name="mapper">una instancia de automapper</param>
        /// <returns>retornar una instancia del repositorioauto</returns>
        public static RepositoryAuto GetInstance(TallerDbContext context, IMapper mapper)
        {
            if (Instance is null)
                Instance = new RepositoryAuto(context,mapper);

            Instance._context = context;

            return Instance;
        }


        private RepositoryAuto(TallerDbContext context, IMapper mappear)
        {
            _context = context;
            _mappear = mappear;
        }



        /// <summary>
        /// Busca un Auto segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retornar ShowAutoDto</returns>
        public async Task<ShowAutoDto> GetAutoPerId(int id)
        {
            Auto auto = await _context.Autos.FirstOrDefaultAsync(x => x.Id == id);

            if (auto == null)
                return null;

            return _mappear.Map<ShowAutoDto>(auto);
        }



        /// <summary>
        /// Metodo para mostara lista de autos
        /// </summary>
        /// <returns>retorna una lista un objerto de traferencia de datos auto </returns>
        public async Task<List<ShowAutoDto>> ShowListAutoDto()
        {
            List<Auto> ListAuto = await _context.Autos
                                                      .Include(x => x.Cliente)
                                                      .Include(x => x.Ordenes).ThenInclude(x => x.Servicio)
                                                      .Include(x => x.Ordenes).ThenInclude(x => x.Mecanico)
                                                      .OrderBy(x => x.Marca)
                                                      .ToListAsync();
                
            return _mappear.Map<List<ShowAutoDto>>(ListAuto);
        }



        /// <summary>
        /// Metodo para guardar un registro de un auto en la base de dato
        /// </summary>
        /// <param name="autoDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo auto en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> CreateAutoDto(CreateAutoDto autoDto)
        {
            Auto auto = _mappear.Map<Auto>(autoDto);

            _context.Autos.Add(auto);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }



        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="autoDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> UpdateAutoDto(UpdateAutoDto autoDto)
        {
            Auto auto = await _context.Autos.FirstOrDefaultAsync(x => x.Id == autoDto.Id);

            auto = _mappear.Map<Auto>(autoDto);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }


    }
}