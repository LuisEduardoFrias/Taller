
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
    public class AutoController : BaseController
    {

        public AutoController(TallerDbContext context, IMapper mapper, DataAccess dataAccess) : base (context, mapper, dataAccess)
        {
        }



        /// <summary>
        /// Muestra el listado de autos
        /// </summary>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ViewResult> GetListAuto(bool error = false) =>
            View(await RepositoryAuto.ShowListAutoAsync() );




        /// <summary>
        /// Mustra el formulario para agregar un nuevo auto
        /// </summary>
        /// <param name="auto">Opjeto auto que se le pasara a la vista</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public ViewResult AddAuto(CreateAutoDto auto, bool error = false)
        {
            ViewBag.error = error;

            return View(auto);
        }


        /// <summary>
        /// Permite agregar un auto a la base de datos
        /// </summary>
        /// <param name="auto">Objeto auto nesesario para registrarlo en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> AddingAuto(CreateAutoDto auto)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddAuto", new { @auto = auto });
            }

            if(await RepositoryAuto.GetInstance(_context, _mapper).CreateAutoDto(auto))
                return RedirectToAction("GetListAuto");
            else
                return RedirectToAction("AddAuto", new { @auto = auto ,@error = true});
        }




        /// <summary>
        /// Mustra el formulario para actualizar un registro auto
        /// </summary>
        /// <param name="id">Id del registro que se va a actualizar en la base de datos</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ActionResult> UpdateAuto(int? id, UpdateAutoDto auto, bool error = false )
        {
            if (id == null)
            {
                if (auto == null)
                    return RedirectToAction("GetListAuto", new { @error = true });
                else
                {
                    ViewBag.error = error;

                    return View(auto);
                }
            }
            else
            {
                UpdateAutoDto autoDto = await RepositoryAuto.GetInstance(_context, _mapper).GetAutoPerId(id.Value);

                return View(autoDto);
            }
        }


        /// <summary>
        /// Permite actualizar un registro de la base de datos
        /// </summary>
        /// <param name="auto">>Objeto auto nesesario que se va actualizar en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> UpdatingAuto(UpdateAutoDto auto)
        {
            if(!await RepositoryAuto.GetInstance(_context, _mapper).UpdateAutoDto(auto))
                return RedirectToAction("UpdateAuto", new { @auto = auto, @error = true });

            return RedirectToAction("GetListAuto");
        }

    }
}