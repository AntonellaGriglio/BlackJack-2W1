import { Carta } from "./carta";
import { Partida } from "./partida";

export interface CartaJugada {
    id: number;
    cartaJ: Carta;
    idCarta:number;
    jugador: string;
    partida: Partida;
}
