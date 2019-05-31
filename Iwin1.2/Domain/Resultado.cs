using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iwin1._2.Domain
{
    public class Resultado
    {

        int id;
        Juego juego;
        Equipo equipo;
        int anotaciones;
        int sancionesColectivas;
        int sancionesIndividuales;

        public Resultado()
        {
        }

        public Resultado(int id, Juego juego, Equipo equipo, int anotaciones, int sancionesColectivas, int sancionesIndividuales)
        {
            this.id = id;
            this.juego = juego;
            this.equipo = equipo;
            this.anotaciones = anotaciones;
            this.sancionesColectivas = sancionesColectivas;
            this.sancionesIndividuales = sancionesIndividuales;
        }




    }
}
