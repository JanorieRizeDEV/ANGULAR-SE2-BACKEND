using EBTarjeta.models;
using Microsoft.EntityFrameworkCore;

namespace EBTarjeta
{
    public class ApplicationDbContext: DbContext
    {
       public DbSet<TarjetaCredito> TarjetaCredit { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        internal void add(TarjetaCredito tarjeta)
        {
            throw new NotImplementedException();
        }
    }
}
