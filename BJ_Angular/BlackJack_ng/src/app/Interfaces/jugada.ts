import { Usuario } from "./usuario";

export interface Jugada {
    usuario: Usuario;
    estado: number;
    idJugada: number;
}
