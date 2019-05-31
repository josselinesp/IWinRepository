using Iwin1._2.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iwin1._2.Domain
{
    public class sancionColectiva
    {
    int identificador;
    Equipo equipo;
    Juego juego;
     string tipo;
        string motivo;

        public sancionColectiva(int identificador, Equipo equipo, Juego juego, string tipo, string motivo)
        {
            this.identificador = identificador;
            this.equipo = equipo;
            this.juego = juego;
            this.tipo = tipo;
            this.motivo = motivo;
        }
    }
}
