using Microsoft.EntityFrameworkCore;
using Reserva_C.Data;
using System.Linq;

namespace Reserva_C.Helpers
{
    public static class Generadores
    {
        
        public static int GetNextLegajo(ReservaContext context)
        {
            int legajoAsignado;

            if (!context.Empleados.Any())
            {
                legajoAsignado = 1;
            }
            else
            {
                legajoAsignado = (context.Empleados.Max(e => e.Legajo)) + 1;
            }


            return legajoAsignado;

        }
    }
}
