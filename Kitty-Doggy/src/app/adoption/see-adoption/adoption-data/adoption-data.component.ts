import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AdoptionService } from 'src/app/services/adoption.service';
import { Animal } from 'src/domain/animal';
import { Doacao } from 'src/domain/doacao';
import { AnimalEnum } from 'src/domain/enum/animalEnum';
import { PorteEnum } from 'src/domain/enum/porteEnum';
import { SexoEnum } from 'src/domain/enum/sexoEnum';
import { StatusEnum } from 'src/domain/enum/statusEnum';

@Component({
  selector: 'app-adoption-data',
  templateUrl: './adoption-data.component.html',
  styleUrls: ['./adoption-data.component.css']
})
export class AdoptionDataComponent implements OnInit {
  isMyAdoption=false;
  user:any;
  status;
  constructor(public router: Router,public doacaoService: AdoptionService) { 
    this.doacao = this.router?.getCurrentNavigation()?.extras?.state?.doacao;
    console.log(this.doacao)
    this.isMyAdoption = this.router?.getCurrentNavigation()?.extras?.state?.isMyAdoption;
    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;
    this.status = this.router?.getCurrentNavigation()?.extras?.state?.status;
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

  DeleteDoacao(){
    var newDoacao = new Doacao();
    newDoacao.Id = this.doacao.id;
    newDoacao.Animal = new Animal();
    newDoacao.Animal.Id= this.doacao.animal.id;
    this.doacaoService.deleteDoacao(this.doacao).subscribe(()=>{
      this.router.navigate(["myadoptions"],{state:{status:this.status,user:this.user}});  
    })
  }
  UpdateDoacao(){
    this.router.navigate(["myadoptions/update"],{state:{doacao:this.doacao,status:this.status,user:this.user}});  
  }

}
