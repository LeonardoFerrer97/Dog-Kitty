import { AnimalEnum } from "./enum/animalEnum";
import { PorteEnum } from "./enum/porteEnum";
import { SexoEnum } from "./enum/sexoEnum";
import { Raca } from "./raca";
export class Filtro {
    localizacao: string|undefined; 
    raca: Raca|undefined;
    sexo: SexoEnum |undefined;
    porte:PorteEnum|undefined;
    tipo: AnimalEnum |undefined;
}