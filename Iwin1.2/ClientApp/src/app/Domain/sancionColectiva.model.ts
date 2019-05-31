export class SancionColectiva {
  identificador: number;
  identificadorJuego: number;
  identificadorEquipo: number;
  tipo: string;
  motivo: string;

  constructor(identificador?: number,
    identificadorJuego?: number,
    identificadorEquipo?: number,
    tipo?: string,
    motivo?: string,
  ) {

    this.identificador = identificador;
    this.identificadorEquipo = identificadorEquipo;
    this.identificadorJuego = identificadorJuego;
    this.motivo = motivo;
    this.tipo = tipo;


  }
}
