import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Chat } from 'src/domain/chat';
import { ChatMessages } from 'src/domain/ChatMessages';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  apiURL: string = 'https://kittyndoggy.azurewebsites.net/api/Chat';

  constructor(private httpClient: HttpClient) {};
  public createChat(chat: Chat){
    var listChats = Array<Chat>();
    return this.httpClient.post(`${this.apiURL}`,listChats);
  }
  public getChats(){
    return this.httpClient.get<Chat[]>(`${this.apiURL}`);
  }
  public createChatMessage(chatMessage: ChatMessages){
    return this.httpClient.post(`${this.apiURL}/message`,chatMessage);
  }
}
