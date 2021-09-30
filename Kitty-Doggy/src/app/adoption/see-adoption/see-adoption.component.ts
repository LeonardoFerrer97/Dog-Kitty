import { Component, OnInit } from '@angular/core';
import {MatExpansionModule} from '@angular/material/expansion';
import { Router } from '@angular/router';
import { AdoptionService } from 'src/app/services/adoption.service';
import { Doacao } from 'src/domain/doacao';
import { StatusEnum } from 'src/domain/enum/statusEnum';

@Component({
  selector: 'app-see-adoption',
  templateUrl: './see-adoption.component.html',
  styleUrls: ['./see-adoption.component.css']
})
export class SeeAdoptionComponent implements OnInit {
  status:StatusEnum;
  doacoes:Doacao[];
  constructor(public router: Router,public doacaoService: AdoptionService) {
    console.log(this.router?.getCurrentNavigation().extras?.state);
    this.status=this.router?.getCurrentNavigation()?.extras?.state?.status;    
    if(this.status == undefined){
      this.router.navigate(['']);
    }
   }

  ngOnInit(): void {
    this.getAnimais(null,null,null,null,null);
  }
  getAnimais(raca,porte,sexo,tipoAnimal,localizacao){
    var url="",hasParameter=false;
    if(raca!=undefined){
      if(hasParameter){
        url+="&raca=" +raca
      }else
        url+="raca=" +raca
      hasParameter =true;
    }
    if(sexo!=undefined){
      if(hasParameter){
        url+="&sexo=" +sexo
      }else
        url+="sexo=" +sexo
      hasParameter =true;
    }
    if(porte!=undefined){
      if(hasParameter){
        url+="&porte=" +porte
      }else
        url+="porte=" +porte
      hasParameter =true;
    }
    if(tipoAnimal!=undefined){
      if(hasParameter){
        url+="&animal=" +tipoAnimal
      }else
        url+="animal=" +tipoAnimal
      
      hasParameter =true;
    }
    if(localizacao!=undefined){
      if(hasParameter){
        url+="&localizacao=" +localizacao
      }else
        url+="localizacao=" +localizacao
      hasParameter =true;
    }
    if(hasParameter){
      url= "?"+url;
    }
    this.doacaoService.getDoacaos(url,this.status).subscribe(doacoes=>{
      console.log(doacoes);
      this.doacoes =doacoes;
    });
    console.log(this.doacoes);
  }

}
