import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Usuario } from '../../domain/usuario';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiURL: string = 'https://localhost:5001/api/Usuario';

  constructor(private httpClient: HttpClient) {};
  public createUser(user: Usuario){
    return this.httpClient.post(`${this.apiURL}`,user);
  }

public updateUser(user: Usuario){
  return this.httpClient.put(`${this.apiURL}`,user);
}

public deleteUser(id: number){

  return this.httpClient.delete(`${this.apiURL}/${id}`);
}

public getUserById(id: number){
  return this.httpClient.get<Usuario[]>(`${this.apiURL}/${id}`);
}
public getUserByEmail(email?: string){
  return this.httpClient.get<Usuario>(`${this.apiURL}/email/${email}`);
}

public getUsers(url?: string){
  return this.httpClient.get<Usuario[]>(`${this.apiURL}`);
}


}
