import { RedeSocial } from "./RedeSocial";

export interface Palestrante{
  id: number;
  nome: string;
  dataEvento?: Date;
  miniCurriculo: string;
  imagemURL: string;
  telefone: string;
  email: string;
  redeSociais: RedeSocial;
  palestrantesEventos: Palestrante;
}
