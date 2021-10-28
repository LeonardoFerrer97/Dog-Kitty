import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Chat } from 'src/domain/chat';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  apiURL: string = 'https://kittyndoggy.azurewebsites.net/api/Chat';

  constructor(private httpClient: HttpClient) {};
  public createChat(chat: Chat){
    var listChats = Array<Chat>();
    listChats.push(chat);
    return this.httpClient.post(`${this.apiURL}`,listChats);
  }
  public getChats(){
    return this.httpClient.get<Chat[]>(`${this.apiURL}`);
  }
}
