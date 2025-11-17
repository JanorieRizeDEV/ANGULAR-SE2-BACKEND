using EBTarjeta.models;
using Microsoft.EntityFrameworkCore;

namespace EBTarjeta
{
    // Contexto de Entity Framework Core: representa la sesión con la base de datos
    // y expone los DbSet que se van a mapear a tablas.
    public class ApplicationDbContext: DbContext
    {
        // Colección de tarjetas de crédito en la base de datos.
        // Usar este DbSet para consultas LINQ y operaciones CRUD.
        public DbSet<TarjetaCredito> TarjetaCredit { get; set; }

        // El constructor recibe las opciones configuradas en Program.cs
        // (por ejemplo provider SQL Server y cadena de conexión).
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Método auxiliar sin implementar; si se mantiene, implementar la lógica
        // o eliminar para evitar confusión. Actualmente lanza NotImplementedException.
        internal void add(TarjetaCredito tarjeta)
        {
            throw new NotImplementedException();
        }
    }
}
