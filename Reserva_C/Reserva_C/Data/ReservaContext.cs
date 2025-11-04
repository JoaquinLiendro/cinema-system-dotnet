using Microsoft.EntityFrameworkCore;
using Reserva_C.Models;

namespace Reserva_C.Data
{
    public class ReservaContext : DbContext 
    {

        public ReservaContext(DbContextOptions options): base (options) { 
        
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Funcion> Funciones { get; set; }
        public DbSet<Pelicula> Peliculas{ get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<Sala> Salas { get; set; }
        public DbSet<TipoSala> TiposSala { get; set; }


    }
}
