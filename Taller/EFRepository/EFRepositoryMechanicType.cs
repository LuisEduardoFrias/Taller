
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

    public class EFRepositoryMechanicType : IRepositoryMechanicType
    {

        private static EFRepositoryMechanicType Instance;
        private TallerDbContext _context;
        private readonly IMapper _mappear;


        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="context">Una instancia del contexto de datos</param>
        /// <param name="mapper">una instancia de TipoMecanicomapper</param>
        /// <returns>retornar una instancia del repositorioTipoMecanico</returns>
        public static EFRepositoryMechanicType GetInstance(TallerDbContext context, IMapper mapper)
        {
            if (Instance is null)
                Instance = new EFRepositoryMechanicType(context, mapper);

            Instance._context = context;

            return Instance;
        }

        private EFRepositoryMechanicType(TallerDbContext context, IMapper mappear)
        {
            _context = context;
            _mappear = mappear;
        }

        public Task<ShowMechanicTypeDto> GetTMechanicTypePerId(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowMechanicTypeDto>> ShowListTMechanicTypeDto()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateTMechanicTypeDto(CreateMechanicTypeDto TMechanicTypeDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateTMechanicTypeDto(UpdateMechanicTypeDto TMechanicTypeDto)
        {
            throw new System.NotImplementedException();
        }




        /*
        /// <summary>
        /// Busca un TipoMecanico segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retornar ShowTipoMecanicoDto</returns>
        public async Task<ShowTipoMecanicoDto> GetTipoMecanicoPerId(int id)
        {
            TipoMecanico TipoMecanico = await _context.TiposMecanico.FirstOrDefaultAsync(x => x.Id == id);

            if (TipoMecanico == null)
                return null;

            return _mappear.Map<ShowTipoMecanicoDto>(TipoMecanico);
        }



        /// <summary>
        /// Metodo para mostara lista de TipoMecanicos
        /// </summary>
        /// <returns>retorna una lista un objerto de traferencia de datos TipoMecanico </returns>
        public async Task<List<ShowTipoMecanicoDto>> ShowListTipoMecanicoDto()
        {
            List<TipoMecanico> ListTipoMecanico = await _context.TiposMecanico
                                                      .OrderBy(x => x.Tipo)
                                                      .ToListAsync();

            return _mappear.Map<List<ShowTipoMecanicoDto>>(ListTipoMecanico);
        }



        /// <summary>
        /// Metodo para guardar un registro de un TipoMecanico en la base de dato
        /// </summary>
        /// <param name="TipoMecanicoDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo TipoMecanico en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> CreateTipoMecanicoDto(CreateTipoMecanicoDto TipoMecanicoDto)
        {
            TipoMecanico TipoMecanico = _mappear.Map<TipoMecanico>(TipoMecanicoDto);

            _context.TiposMecanico.Add(TipoMecanico);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }



        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="TipoMecanicoDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> UpdateTipoMecanicoDto(UpdateTipoMecanicoDto TipoMecanicoDto)
        {
            TipoMecanico TipoMecanico = await _context.TiposMecanico.FirstOrDefaultAsync(x => x.Id == TipoMecanicoDto.Id);

            TipoMecanico = _mappear.Map<TipoMecanico>(TipoMecanicoDto);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }*/


    }
}