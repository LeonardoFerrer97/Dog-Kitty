import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AnimalEnum } from 'src/domain/enum/animalEnum';
import { PorteEnum } from 'src/domain/enum/porteEnum';
import { SexoEnum } from 'src/domain/enum/sexoEnum';

@Component({
  selector: 'app-adoption-data',
  templateUrl: './adoption-data.component.html',
  styleUrls: ['./adoption-data.component.css']
})
export class AdoptionDataComponent implements OnInit {

  constructor(public router: Router) { 
    this.doacao = this.router?.getCurrentNavigation()?.extras?.state?.doacao;
    if(this.doacao == undefined){
      this.router.navigate(['']);
    }}

  doacao:any;
  ngOnInit(): void {
  }

  getTipoAnimal(tipo){
    for(var p in AnimalEnum) {
        if(AnimalEnum.hasOwnProperty(p) && AnimalEnum[p] === tipo) {
             return p;
        }
    }
    return "";
  }

  getPorte(porte){
    for(var p in PorteEnum) {
        if(PorteEnum.hasOwnProperty(p) && PorteEnum[p] === porte) {
             return p;
        }
    }
    return "";
  }

  getSexo(sexo){
    for(var p in SexoEnum) {
        if(SexoEnum.hasOwnProperty(p) && SexoEnum[p] === sexo) {
             return p;
        }
    }
    return "";
  }

}
