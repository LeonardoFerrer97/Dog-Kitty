import { AnimalEnum } from "./enum/animalEnum";
import { PorteEnum } from "./enum/porteEnum";
import { SexoEnum } from "./enum/sexoEnum";
import { StatusEnum } from "./enum/statusEnum";
import { Foto } from "./foto";
import { Raca } from "./raca";

export class Animal {

    Id: number|undefined;
    Nome: string|undefined;
    Status: StatusEnum|undefined;
    Foto: Array<Foto>|undefined; 
    Peso: number|undefined;
    Idade : number|undefined;
    Sexo: SexoEnum |undefined;
    Porte:PorteEnum|undefined;
    TipoAnimal: AnimalEnum |undefined;
    Raca : Raca|undefined;
}
