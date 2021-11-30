import { ChatMessages } from "./chatMessages";

export class Chat {
    

        Id : number | undefined;
        Title : string | undefined;
        Messages : Array<ChatMessages> | undefined;
        Date : Date | undefined;
        UsuarioId: number | undefined;
}