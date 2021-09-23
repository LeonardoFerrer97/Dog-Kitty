import { Animal } from "./animal";
import { Usuario } from "./usuario";

export class Doacao {
    

    Id : number | undefined;
    Localizacao: string | undefined;
    Usuario: Usuario | undefined;
    Animal: Animal | undefined;
    Descricao : string | undefined;
}
