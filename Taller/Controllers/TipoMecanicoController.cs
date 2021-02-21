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
    public class TipoMecanicoController : Controller
    {
        private readonly TallerDbContext _context;
        private readonly IMapper _mapper;



        public TipoMecanicoController(TallerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        /// <summary>
        /// Muestra el listado de TipoMecanicos
        /// </summary>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ViewResult> GetListTiposMecanico(bool error = false) =>
            View(await RepositoryTipoMecanico.GetInstance(_context, _mapper).ShowListTipoMecanicoDto());




        /// <summary>
        /// Mustra el formulario para agregar un nuevo TipoMecanico
        /// </summary>
        /// <param name="TipoMecanico">Opjeto TipoMecanico que se le pasara a la vista</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public ViewResult AddTipoMecanico(CreateTipoMecanicoDto TipoMecanico, bool error = false)
        {
            ViewBag.error = error;

            return View(TipoMecanico);
        }


        /// <summary>
        /// Permite agregar un TipoMecanico a la base de datos
        /// </summary>
        /// <param name="TipoMecanico">Objeto TipoMecanico nesesario para registrarlo en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> AddingTipoMecanico(CreateTipoMecanicoDto TipoMecanico)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddTipoMecanico", new { @TipoMecanico = TipoMecanico });
            }

            if (await RepositoryTipoMecanico.GetInstance(_context, _mapper).CreateTipoMecanicoDto(TipoMecanico))
                return RedirectToAction("GetListTipoMecanico");
            else
                return RedirectToAction("AddTipoMecanico", new { @TipoMecanico = TipoMecanico, @error = true });
        }




        /// <summary>
        /// Mustra el formulario para actualizar un registro TipoMecanico
        /// </summary>
        /// <param name="id">Id del registro que se va a actualizar en la base de datos</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ActionResult> UpdateTipoMecanico(int? id, UpdateTipoMecanicoDto TipoMecanico, bool error = false)
        {
            if (id == null)
            {
                if (TipoMecanico == null)
                    return RedirectToAction("GetListTipoMecanico", new { @error = true });
                else
                {
                    ViewBag.error = error;

                    return View(TipoMecanico);
                }
            }
            else
            {
                UpdateTipoMecanicoDto TipoMecanicoDto = await RepositoryTipoMecanico.GetInstance(_context, _mapper).GetTipoMecanicoPerId(id.Value);

                return View(TipoMecanicoDto);
            }
        }


        /// <summary>
        /// Permite actualizar un registro de la base de datos
        /// </summary>
        /// <param name="TipoMecanico">>Objeto TipoMecanico nesesario que se va actualizar en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> UpdatingTipoMecanico(UpdateTipoMecanicoDto TipoMecanico)
        {
            if (!await RepositoryTipoMecanico.GetInstance(_context, _mapper).UpdateTipoMecanicoDto(TipoMecanico))
                return RedirectToAction("UpdateTipoMecanico", new { @TipoMecanico = TipoMecanico, @error = true });

            return RedirectToAction("GetListTipoMecanico");
        }

    }
}