using Microsoft.EntityFrameworkCore;
using Reserva_C.Models;

namespace Reserva_C.Data
{
    public class ReservaContext : DbContext 
    {

        public ReservaContext(DbContextOptions options): base (options) { 
        
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Empleado> Empleados { get; set; }


    }
}
