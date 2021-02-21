using AutoMapper;
using System.Threading.Tasks;
using System.Web.Mvc;
//
using Taller.Data;
using Taller.Dtos;
using Taller.Repository;
//

namespace Taller.Controllers
{
    public class OrdenController : Controller
    {
        private readonly TallerDbContext _context;
        private readonly IMapper _mapper;



        public OrdenController(TallerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        /// <summary>
        /// Muestra el listado de Ordens
        /// </summary>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ViewResult> GetListOrdenes(bool error = false) =>
            View(await RepositoryOrden.GetInstance(_context, _mapper).ShowListOrdenDto());




        /// <summary>
        /// Mustra el formulario para agregar un nuevo Orden
        /// </summary>
        /// <param name="Orden">Opjeto Orden que se le pasara a la vista</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public ViewResult AddOrden(CreateClienteDto Orden, bool error = false)
        {
            ViewBag.error = error;

            return View(Orden);
        }


        /// <summary>
        /// Permite agregar un Orden a la base de datos
        /// </summary>
        /// <param name="Orden">Objeto Orden nesesario para registrarlo en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> AddingOrden(CreateOrdenDto Orden)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddOrden", new { @Orden = Orden });
            }

            if (await RepositoryOrden.GetInstance(_context, _mapper).CreateOrdenDto(Orden))
                return RedirectToAction("GetListOrden");
            else
                return RedirectToAction("AddOrden", new { @Orden = Orden, @error = true });
        }




        /// <summary>
        /// Mustra el formulario para actualizar un registro Orden
        /// </summary>
        /// <param name="id">Id del registro que se va a actualizar en la base de datos</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ActionResult> UpdateOrden(int? id, UpdateOrdenDto Orden, bool error = false)
        {
            if (id == null)
            {
                if (Orden == null)
                    return RedirectToAction("GetListOrden", new { @error = true });
                else
                {
                    ViewBag.error = error;

                    return View(Orden);
                }
            }
            else
            {
                UpdateOrdenDto OrdenDto = await RepositoryOrden.GetInstance(_context, _mapper).GetOrdenPerId(id.Value);

                return View(OrdenDto);
            }
        }


        /// <summary>
        /// Permite actualizar un registro de la base de datos
        /// </summary>
        /// <param name="Orden">>Objeto Orden nesesario que se va actualizar en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> UpdatingOrden(UpdateOrdenDto Orden)
        {
            if (!await RepositoryOrden.GetInstance(_context, _mapper).UpdateOrdenDto(Orden))
                return RedirectToAction("UpdateOrden", new { @Orden = Orden, @error = true });

            return RedirectToAction("GetListOrden");
        }

    }
}