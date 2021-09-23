import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Raca } from 'src/domain/raca';

@Injectable({
  providedIn: 'root'
})
export class RacaService {

  apiURL: string = 'https://localhost:5001/api/Raca';
  constructor(private httpClient: HttpClient) {};
  public createRaca(raca: Raca){
    return this.httpClient.post(`${this.apiURL}`,raca);
  }

  public getRacas(){
    return this.httpClient.get<Raca[]>(`${this.apiURL}`);
  }
}
