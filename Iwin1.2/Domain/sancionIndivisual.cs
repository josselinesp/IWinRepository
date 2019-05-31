using Iwin1._2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Iwin1._2.Domain
{
    public class sancionIndivisual
    {
    int identificador;
    Equipo equipo;
    Jugador Jugador;
    string tarjeta;
    string motivo;

    public sancionIndivisual(int identificador, Equipo identificadorEquipo, Jugador jugador, string tipo, string motivo)
    {
        this.identificador = identificador;
        this.equipo = identificadorEquipo;
        Jugador = jugador;
        this.tarjeta = tipo;
        this.motivo = motivo;
    }
}
}
