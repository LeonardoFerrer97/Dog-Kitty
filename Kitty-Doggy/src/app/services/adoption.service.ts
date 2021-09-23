import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Doacao } from 'src/domain/doacao';

@Injectable({
  providedIn: 'root'
})
export class AdoptionService {

  apiURL: string = 'https://localhost:5001/api/Doacao';

  constructor(private httpClient: HttpClient) {};
  public createDoacao(adocao: Doacao){
    return this.httpClient.post(`${this.apiURL}`,adocao);
  }

public updateDoacao(adocao: Doacao){
  return this.httpClient.put(`${this.apiURL}`,adocao);
}

public deleteDoacao(id: number){

  return this.httpClient.delete(`${this.apiURL}/${id}`);
}

public getDoacaoById(id: number){
  return this.httpClient.get<Doacao[]>(`${this.apiURL}/${id}`);
}

public getDoacaos(url?: string){
  return this.httpClient.get<Doacao[]>(`${this.apiURL}`);
}
}
