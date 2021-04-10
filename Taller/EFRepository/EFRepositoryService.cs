
namespace Taller.EFRepository
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Taller.Data;
    //
    using Taller.Dtos;
    using Taller.Interface;
    //

    public class EFRepositoryService : IRepositoryService
    {

        private static EFRepositoryService Instance;
        private TallerDbContext _context;
        private readonly IMapper _mappear;


        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="context">Una instancia del contexto de datos</param>
        /// <param name="mapper">una instancia de Serviciomapper</param>
        /// <returns>retornar una instancia del repositorioServicio</returns>
        public static EFRepositoryService GetInstance(TallerDbContext context, IMapper mapper)
        {
            if (Instance is null)
                Instance = new EFRepositoryService(context, mapper);

            Instance._context = context;

            return Instance;
        }

        private EFRepositoryService(TallerDbContext context, IMapper mappear)
        {
            _context = context;
            _mappear = mappear;
        }

        public Task<ShowServiceDto> GetServicePerId(int code)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowServiceDto>> ShowListServiceDto()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateServiceDto(CreateServiceDto ServiceDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateServiceDto(UpdateServiceDto ServiceDto)
        {
            throw new System.NotImplementedException();
        }



        /*

        /// <summary>
        /// Busca un Servicio segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retornar ShowServicioDto</returns>
        public async Task<ShowServicioDto> GetServicioPerId(int codigo)
        {
            Servicio Servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Codigo == codigo);

            if (Servicio == null)
                return null;

            return _mappear.Map<ShowServicioDto>(Servicio);
        }



        /// <summary>
        /// Metodo para mostara lista de Servicios
        /// </summary>
        /// <returns>retorna una lista un objerto de traferencia de datos Servicio </returns>
        public async Task<List<ShowServicioDto>> ShowListServicioDto()
        {
            List<Servicio> ListServicio = await _context.Servicios
                                                      .OrderBy(x => x.Nombre)
                                                      .ToListAsync();

            return _mappear.Map<List<ShowServicioDto>>(ListServicio);
        }



        /// <summary>
        /// Metodo para guardar un registro de un Servicio en la base de dato
        /// </summary>
        /// <param name="ServicioDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo Servicio en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> CreateServicioDto(CreateServicioDto ServicioDto)
        {
            Servicio Servicio = _mappear.Map<Servicio>(ServicioDto);

            _context.Servicios.Add(Servicio);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }



        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="ServicioDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> UpdateServicioDto(UpdateServicioDto ServicioDto)
        {
            Servicio Servicio = await _context.Servicios.FirstOrDefaultAsync(x => x.Codigo == ServicioDto.Codigo);

            Servicio = _mappear.Map<Servicio>(ServicioDto);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }*/


    }
}