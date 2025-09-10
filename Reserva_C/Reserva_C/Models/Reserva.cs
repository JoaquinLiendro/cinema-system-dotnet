using System;

namespace Reserva_C.Models
{
    public class Reserva
    {
        //        - Activa(flag)
        //        - CantidadButacas
        //        - Cliente
        //        - FechaAlta
        //        - Funcion

        public int IdReserva { get; set; }
        public bool Activa { get; set; }
        public int CantButacas { get; set; }
        public Cliente Cliente { get; set; }
        public DateOnly FechaAlta { get; set; }
        public Funcion Funcion { get; set; }
        

    }
}
