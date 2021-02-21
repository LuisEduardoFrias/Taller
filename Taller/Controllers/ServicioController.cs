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
    public class ServicioController : Controller
    {
        private readonly TallerDbContext _context;
        private readonly IMapper _mapper;



        public ServicioController(TallerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        /// <summary>
        /// Muestra el listado de Servicios
        /// </summary>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ViewResult> GetListServicios(bool error = false) =>
            View(await RepositoryServicio.GetInstance(_context, _mapper).ShowListServicioDto());




        /// <summary>
        /// Mustra el formulario para agregar un nuevo Servicio
        /// </summary>
        /// <param name="Servicio">Opjeto Servicio que se le pasara a la vista</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public ViewResult AddServicio(CreateServicioDto Servicio, bool error = false)
        {
            ViewBag.error = error;

            return View(Servicio);
        }


        /// <summary>
        /// Permite agregar un Servicio a la base de datos
        /// </summary>
        /// <param name="Servicio">Objeto Servicio nesesario para registrarlo en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> AddingServicio(CreateServicioDto Servicio)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddServicio", new { @Servicio = Servicio });
            }

            if (await RepositoryServicio.GetInstance(_context, _mapper).CreateServicioDto(Servicio))
                return RedirectToAction("GetListServicio");
            else
                return RedirectToAction("AddServicio", new { @Servicio = Servicio, @error = true });
        }




        /// <summary>
        /// Mustra el formulario para actualizar un registro Servicio
        /// </summary>
        /// <param name="id">Id del registro que se va a actualizar en la base de datos</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ActionResult> UpdateServicio(int? id, UpdateServicioDto Servicio, bool error = false)
        {
            if (id == null)
            {
                if (Servicio == null)
                    return RedirectToAction("GetListServicio", new { @error = true });
                else
                {
                    ViewBag.error = error;

                    return View(Servicio);
                }
            }
            else
            {
                UpdateServicioDto ServicioDto = await RepositoryServicio.GetInstance(_context, _mapper).GetServicioPerId(id.Value);

                return View(ServicioDto);
            }
        }


        /// <summary>
        /// Permite actualizar un registro de la base de datos
        /// </summary>
        /// <param name="Servicio">>Objeto Servicio nesesario que se va actualizar en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> UpdatingServicio(UpdateServicioDto Servicio)
        {
            if (!await RepositoryServicio.GetInstance(_context, _mapper).UpdateServicioDto(Servicio))
                return RedirectToAction("UpdateServicio", new { @Servicio = Servicio, @error = true });

            return RedirectToAction("GetListServicio");
        }

    }
}