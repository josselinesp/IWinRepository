using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Iwin1._2.Domain
{
   public class TáblaPosiciones{
        private int golesFavor;
        private int golesContra;
        private int golDif;
        private int partidosJugados;
        private int partidosGanados;
        private int partidosPerdidos;
        private int partidosEmpatados;
        private int cantidadPuntos;
        Campeonato campeonato = new Campeonato();

        public int GolesFavor { get => golesFavor; set => golesFavor = value; }
        public int GolesContra { get => golesContra; set => golesContra = value; }
        public int GolDif { get => golDif; set => golDif = value; }
        public int PartidosJugados { get => partidosJugados; set => partidosJugados = value; }
        public int PartidosGanados { get => partidosGanados; set => partidosGanados= value; }
        public int PartidosPerdidos { get => partidosPerdidos; set => partidosPerdidos = value; }
        public int PartidosEmpatados { get => partidosPerdidos; set => partidosEmpatados= value; }
        public int CantidadPuntos { get => cantidadPuntos; set => cantidadPuntos = value; }

        public Campeonato Campeonato { get => campeonato; set => campeonato = value; }
    }
}
