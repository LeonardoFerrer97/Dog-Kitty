import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doacao } from 'src/domain/doacao';

@Injectable({
  providedIn: 'root'
})
export class AdoptionService {

  apiURL: string = 'https://kittyndoggy.azurewebsites.net/api/Doacao';

  constructor(private httpClient: HttpClient) {};
  public createDoacao(adocao: Doacao){
    return this.httpClient.post(`${this.apiURL}`,adocao);
  }

public updateDoacao(adocao: Doacao){
  console.log(adocao)
  return this.httpClient.put(`${this.apiURL}`,adocao);
}

public deleteDoacao(adocao: Doacao){

  return this.httpClient.delete(`${this.apiURL}`,{body:adocao});
}

public getDoacaoById(id: number){
  return this.httpClient.get<Doacao[]>(`${this.apiURL}/${id}`);
}

public getDoacaos(url: string,status){
  url = this.apiURL+"/"+ status + url;
  console.log(url);
  return this.httpClient.get<Doacao[]>(`${url}`);
}
}
