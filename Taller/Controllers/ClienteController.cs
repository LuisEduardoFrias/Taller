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
    public class ClienteController : Controller
    {
        private readonly TallerDbContext _context;
        private readonly IMapper _mapper;



        public ClienteController(TallerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        /// <summary>
        /// Muestra el listado de Clientes
        /// </summary>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ViewResult> GetListClientes(bool error = false) =>
            View(await RepositoryCliente.GetInstance(_context, _mapper).ShowListClienteDto());




        /// <summary>
        /// Mustra el formulario para agregar un nuevo Cliente
        /// </summary>
        /// <param name="Cliente">Opjeto Cliente que se le pasara a la vista</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public ViewResult AddCliente(CreateClienteDto Cliente, bool error = false)
        {
            ViewBag.error = error;

            return View(Cliente);
        }


        /// <summary>
        /// Permite agregar un Cliente a la base de datos
        /// </summary>
        /// <param name="Cliente">Objeto Cliente nesesario para registrarlo en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> AddingCliente(CreateClienteDto Cliente)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddCliente", new { @Cliente = Cliente });
            }

            if (await RepositoryCliente.GetInstance(_context, _mapper).CreateClienteDto(Cliente))
                return RedirectToAction("GetListCliente");
            else
                return RedirectToAction("AddCliente", new { @Cliente = Cliente, @error = true });
        }




        /// <summary>
        /// Mustra el formulario para actualizar un registro Cliente
        /// </summary>
        /// <param name="id">Id del registro que se va a actualizar en la base de datos</param>
        /// <returns>Retorna un vista</returns>
        [HttpGet]
        public async Task<ActionResult> UpdateCliente(string cedula, UpdateClienteDto Cliente, bool error = false)
        {
            if (cedula == null)
            {
                if (Cliente == null)
                    return RedirectToAction("GetListCliente", new { @error = true });
                else
                {
                    ViewBag.error = error;

                    return View(Cliente);
                }
            }
            else
            {
                UpdateClienteDto ClienteDto = await RepositoryCliente.GetInstance(_context, _mapper).GetClientePerId(cedula);

                return View(ClienteDto);
            }
        }


        /// <summary>
        /// Permite actualizar un registro de la base de datos
        /// </summary>
        /// <param name="Cliente">>Objeto Cliente nesesario que se va actualizar en la base de datos</param>
        /// <returns>Retorna un redirecionamiento a otra vista</returns>
        [HttpPost]
        public async Task<RedirectToRouteResult> UpdatingCliente(UpdateClienteDto Cliente)
        {
            if (!await RepositoryCliente.GetInstance(_context, _mapper).UpdateClienteDto(Cliente))
                return RedirectToAction("UpdateCliente", new { @Cliente = Cliente, @error = true });

            return RedirectToAction("GetListCliente");
        }

    }
}