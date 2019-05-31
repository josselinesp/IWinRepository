using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Iwin1._2.Domain
{
    public class anotacion
    {
        int identificador;
        Equipo equipo;
        Jugador jugador;
        Juego juego;
        int cantidadGoles;

        public anotacion(int identificador,  Equipo equipo, Jugador jugador, Juego juego, int cantidadGoles)
        {
            this.identificador = identificador;
            this.equipo = equipo;
            this.jugador = jugador ;
            this.juego = juego ;
            this.cantidadGoles = cantidadGoles;
        }
    }
}
