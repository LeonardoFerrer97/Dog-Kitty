import { ChatMessages } from "./ChatMessages";

export class Chat {
    

        Id : number | undefined;
        Title : string | undefined;
        Messages : Array<ChatMessages> | undefined;
        Date : Date | undefined;
}