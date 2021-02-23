using Microsoft.EntityFrameworkCore;
using Taller.Models;

namespace Taller.Data
{
    public class TallerDbContext:DbContext
    {
        string _connectionString;

        public DbSet<Auto> Autos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Mecanico> Mecanicos { get; set; }
        public DbSet<Orden> Ordenes { get; set; }
        public DbSet<OrdenDetalle> DetallesOrden { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<TipoMecanico> TiposMecanico { get; set; }


        public TallerDbContext(string connectionString):base()
        {
            _connectionString = connectionString;
        }


        public TallerDbContext() : base()
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           //optionsBuilder.UseSqlServer(_connectionString);
           optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB; database=TallerBD; Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

    }
}