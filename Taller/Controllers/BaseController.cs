using AutoMapper;
using System.Web.Mvc;
using Taller.Data;
using Taller.Interface;
using Taller.EFRepository;
using Taller.AdoRepository;

namespace Taller.Controllers
{
    public abstract class BaseController : Controller
    {
        public enum DataAccess
        {
            EntityF,
            AdoNet
        }

        private readonly TallerDbContext _context;
        private readonly IMapper _mapper;
        private readonly DataAccess _dataAccess;

        public BaseController(TallerDbContext context, IMapper mapper, DataAccess dataAccess)
        {
            _context = context;
            _mapper = mapper;
            _dataAccess = dataAccess;
        }

        public IRepositoryAuto GetRepositoryAuto() => _dataAccess is DataAccess.AdoNet ? 
            EFRepositoryAuto.GetInstance(_context, _mapper) :
            AdoRepositoryCar.GetInstance(_mapper);

        public IRepositoryClient GetRepositoryCliente() => _dataAccess is DataAccess.AdoNet ?
            EFRepositoryClient.GetInstance(_context, _mapper) :
            AdoRepositoryClient.GetInstance(_mapper);


        public IRepositoryMechanic GetRepositoryMecanico() => _dataAccess is DataAccess.AdoNet ?
            EFRepositoryMechanic.GetInstance(_context, _mapper) :
            AdoRepositoryMechanic.GetInstance(_mapper);

        public IRepositoryOrder GetRepositoryOrden() => _dataAccess is DataAccess.AdoNet ?
            EFRepositoryOrder.GetInstance(_context, _mapper) :
            AdoRepositoryOrder.GetInstance(_mapper);

        public IRepositoryService GetRepositorySercicio() => _dataAccess is DataAccess.AdoNet ?
            EFRepositoryService.GetInstance(_context, _mapper) :
            AdoRepositoryServicio.GetInstance(_mapper);

        public IRepositoryMechanicType GetRepositoryTipoMecanico() => _dataAccess is DataAccess.AdoNet ?
            EFRepositoryMechanicType.GetInstance(_context, _mapper) :
            AdoRepositoryMechanicType.GetInstance(_mapper);

    }
}