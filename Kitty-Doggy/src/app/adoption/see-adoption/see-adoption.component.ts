import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';
import {MatExpansionModule} from '@angular/material/expansion';
import { Router } from '@angular/router';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';
import { AdoptionService } from 'src/app/services/adoption.service';
import { Doacao } from 'src/domain/doacao';
import { StatusEnum } from 'src/domain/enum/statusEnum';
import { FilterModalComponent } from './filter-modal/filter-modal.component';

@Component({
  selector: 'app-see-adoption',
  templateUrl: './see-adoption.component.html',
  styleUrls: ['./see-adoption.component.css']
})
export class SeeAdoptionComponent {
  status:StatusEnum;
  doacoes:any[];
  doacoesToDisplay:any[];
  constructor(public router: Router,public doacaoService: AdoptionService,public dialog: MatDialog,public dialog2: MatDialog) {
    this.status=this.router?.getCurrentNavigation()?.extras?.state?.status;    
    if(this.status == undefined){
      this.router.navigate(['']);
    }
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
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog2.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.doacaoService.getDoacaos(url,this.status).subscribe(doacoes=>{
      this.doacoes =doacoes;
      this.doacoesToDisplay= Array.from(this.doacoes);
      this.doacoesToDisplay = this.doacoesToDisplay.splice(0,3); dialogRef.close();
    },error=>{ dialogRef.close();});
  }
  openModal(){
    var dialogConfig = new MatDialogConfig();
    var localizacao=null;
    var raca = null;
    var porte = null;
    var sexo= null;
    var tipo=null;
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;        
    dialogConfig.data = {
      localizacao,raca,porte,sexo,tipo
    };
    const dialogRef = this.dialog.open(FilterModalComponent,
      dialogConfig);
    dialogRef.afterClosed().subscribe(
      val => this.getAnimais(val.raca,val.porte,val.sexo,val.tipo,val.localizacao)
    );
  }
  onChangePage(page){
    this.doacoesToDisplay= Array.from(this.doacoes);
    var index = page.pageIndex*3;
    if(index+2>this.doacoesToDisplay.length){
      this.doacoesToDisplay = this.doacoesToDisplay.splice(index,index+2); 
    }
    else if(index+1>this.doacoesToDisplay.length){
      this.doacoesToDisplay =this.doacoesToDisplay.splice(index,index+1); 
    }else{
      this.doacoesToDisplay =this.doacoesToDisplay.splice(index,index+3); 
    }
  }
  onClickDoacao(adocao:any){
    console.log(adocao);
    this.router.navigate(["adocao/dados"],{state:{doacao:adocao}});   
  }

}