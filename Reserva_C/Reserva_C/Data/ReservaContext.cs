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

        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Pelicula> Peliculas{ get; set; }

        public DbSet<Reserva> reservas { get; set; }
        public DbSet<Sala> Sala { get; set; }
        public DbSet<TipoSala> TipoSala { get; set; }


    }
}
