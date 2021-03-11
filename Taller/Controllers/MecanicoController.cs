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
    public class MecanicoController : Controller
    {
        private readonly TallerDbContext _context;
        private readonly IMapper _mapper;



        public MecanicoController(TallerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        /// <summary>
        /// Muestra el listado de Mecanicos
        /// </summary>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ViewResult> GetListMecanicos(bool error = false) =>
            View(await RepositoryMecanico.GetInstance(_context, _mapper).ShowListMecanicoDto());




        /// <summary>
        /// Mustra el formulario para agregar un nuevo Mecanico
        /// </summary>
        /// <param name="Mecanico">Opjeto Mecanico que se le pasara a la vista</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public ViewResult AddMecanico(CreateMecanicoDto Mecanico, bool error = false)
        {
            ViewBag.error = error;

            return View(Mecanico);
        }


        /// <summary>
        /// Permite agregar un Mecanico a la base de datos
        /// </summary>
        /// <param name="Mecanico">Objeto Mecanico nesesario para registrarlo en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> AddingMecanico(CreateMecanicoDto Mecanico)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddMecanico", new { @Mecanico = Mecanico });
            }

            if (await RepositoryMecanico.GetInstance(_context, _mapper).CreateMecanicoDto(Mecanico))
                return RedirectToAction("GetListMecanico");
            else
                return RedirectToAction("AddMecanico", new { @Mecanico = Mecanico, @error = true });
        }




        /// <summary>
        /// Mustra el formulario para actualizar un registro Mecanico
        /// </summary>
        /// <param name="id">Id del registro que se va a actualizar en la base de datos</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ActionResult> UpdateMecanico(string cedula, UpdateMecanicoDto Mecanico = null, bool error = false)
        {
            if (cedula == null)
            {
                if (Mecanico == null)
                else
                    return RedirectToAction("GetListMecanico", new { @error = true });
                {
                    ViewBag.error = error;

                    return View(Mecanico);
                }
            }
            else
            {
                UpdateMecanicoDto MecanicoDto = await RepositoryMecanico.GetInstance(_context, _mapper).GetMecanicoPerId(cedula);

                return View(MecanicoDto);
            }
        }


        /// <summary>
        /// Permite actualizar un registro de la base de datos
        /// </summary>
        /// <param name="Mecanico">>Objeto Mecanico nesesario que se va actualizar en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> UpdatingMecanico(UpdateMecanicoDto Mecanico)
        {
            if (!await RepositoryMecanico.GetInstance(_context, _mapper).UpdateMecanicoDto(Mecanico))
                return RedirectToAction("UpdateMecanico", new { @Mecanico = Mecanico, @error = true });

            return RedirectToAction("GetListMecanico");
        }

    }
}