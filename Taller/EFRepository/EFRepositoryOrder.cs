
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

    public class EFRepositoryOrder : IRepositoryOrder
    {

        private static EFRepositoryOrder Instance;
        private TallerDbContext _context;
        private readonly IMapper _mappear;


        /// <summary>
        /// Patring Singletom
        /// </summary>
        /// <param name="context">Una instancia del contexto de datos</param>
        /// <param name="mapper">una instancia de Ordenmapper</param>
        /// <returns>retornar una instancia del repositorioOrden</returns>
        public static EFRepositoryOrder GetInstance(TallerDbContext context, IMapper mapper)
        {
            if (Instance is null)
                Instance = new EFRepositoryOrder(context, mapper);

            Instance._context = context;

            return Instance;
        }

        public Task<ShowOrderDto> GetOrderPerIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<ShowOrderDto>> ShowListOrderAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> CreateOrderAsync(CreateOrderDto OrderDto)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateOrderAsync(UpdateOrderDto OrderDto)
        {
            throw new System.NotImplementedException();
        }

        private EFRepositoryOrder(TallerDbContext context, IMapper mappear)
        {
            _context = context;
            _mappear = mappear;
        }

        /*
        /// <summary>
        /// Busca un Orden segun un Id obtenido
        /// </summary>
        /// <param name="id">Id requerido para buscar un registro en la base de datos.</param>
        /// <returns>Retornar ShowOrdenDto</returns>
        public async Task<ShowOrdenDto> GetOrdenPerId(int id)
        {
            Orden Orden = await _context.Ordenes.FirstOrDefaultAsync(x => x.Id == id);

            if (Orden == null)
                return null;

            return _mappear.Map<ShowOrdenDto>(Orden);
        }



        /// <summary>
        /// Metodo para mostara lista de Ordens
        /// </summary>
        /// <returns>retorna una lista un objerto de traferencia de datos Orden </returns>
        public async Task<List<ShowOrdenDto>> ShowListOrdenDto()
        {
            List<Orden> ListOrden = await _context.Ordenes
                                                      .Include(x => x.Mecanico)
                                                      .Include(x => x.Auto)
                                                      .Include(x => x.OrdenDetalle)
                                                      .OrderBy(x => x.Fecha)
                                                      .ToListAsync();

            return _mappear.Map<List<ShowOrdenDto>>(ListOrden);
        }



        /// <summary>
        /// Metodo para guardar un registro de un Orden en la base de dato
        /// </summary>
        /// <param name="OrdenDto">Objeto que contiene los datos nesesarios para guardar un registro de un nuevo Orden en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> CreateOrdenDto(CreateOrdenDto OrdenDto)
        {
            Orden Orden = _mappear.Map<Orden>(OrdenDto);

            _context.Ordenes.Add(Orden);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }



        /// <summary>
        /// Metodos que actualizar un registro de la base de datos
        /// </summary>
        /// <param name="OrdenDto">objeto nesesario que se va a actualizar en la base de datos</param>
        /// <returns>retornar un booleano: true si la operacion fue sastesficha, en caso contrario false</returns>
        public async Task<bool> UpdateOrdenDto(UpdateOrdenDto OrdenDto)
        {
            Orden Orden = await _context.Ordenes.FirstOrDefaultAsync(x => x.Id == OrdenDto.Id);

            Orden = _mappear.Map<Orden>(OrdenDto);

            if (await _context.SaveChangesAsync() == -1)
                return false;

            return true;
        }*/

    }
}