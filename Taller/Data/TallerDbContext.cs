using Microsoft.EntityFrameworkCore;
using Taller.Models;

namespace Taller.Data
{
    public class TallerDbContext:DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoMecanico> TiposMecanico { get; set; }

        public TallerDbContext():base()
        {

        }

    }
}