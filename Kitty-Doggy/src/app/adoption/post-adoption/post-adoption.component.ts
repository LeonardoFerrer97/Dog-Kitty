import { Component, OnInit } from '@angular/core';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';

import { Router } from '@angular/router';
import { FormGroup, FormControl } from '@angular/forms';
import { Doacao } from 'src/domain/doacao';
import { AdoptionService } from 'src/app/services/adoption.service';
import { Animal } from 'src/domain/animal';
import { Foto } from 'src/domain/foto';
import { Raca } from 'src/domain/raca';
import { StatusEnum } from 'src/domain/enum/statusEnum';
import { Usuario } from 'src/domain/usuario';
import { RacaService } from 'src/app/services/raca.service';
import {UserService} from 'src/app/services/user.service'
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
@Component({
  selector: 'app-post-adoption',
  templateUrl: './post-adoption.component.html',
  styleUrls: ['./post-adoption.component.css']
})
export class PostAdoptionComponent implements OnInit {
  formDoacao: FormGroup
  doacao :Doacao = new Doacao();
  user: any;
  racas = new Array<Raca>();
  constructor(public router: Router,public doacaoService: AdoptionService,public racaService: RacaService,public userService:UserService,public dialog2: MatDialog) { 
    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;
    if(this.user == undefined){
      this.router.navigate(['']);
    }
  } 

  ngOnInit(): void {
    this.getRacas();
    this.createForm();
  }
  getNomeRaca(raca:any){
     return raca.nome;
  }
  getRacas():void{
    this.racaService.getRacas().subscribe((raca)=>{
      this.racas = raca;
    });
  }

  createForm() {
    this.doacao.Animal = new Animal();
    this.doacao.Animal.Foto = new Array<Foto>();
    this.doacao.Animal.Raca = new Raca();
    this.formDoacao = new FormGroup({
      localizacao: new FormControl(this.doacao.Localizacao? this.doacao.Localizacao : ""),
      descricao: new FormControl(this.doacao.Descricao? this.doacao.Descricao : ""),
      nomeAnimal: new FormControl(this.doacao.Animal.Nome? this.doacao.Animal.Foto : ""),
      fotoAnimal: new FormControl(this.doacao.Animal.Foto? this.doacao.Animal.Foto : ""),
      pesoAnimal: new FormControl(this.doacao.Animal.Peso? this.doacao.Animal.Peso : ""),
      idadeAnimal: new FormControl(this.doacao.Animal.Idade? this.doacao.Animal.Idade : ""),
      sexoAnimal: new FormControl(this.doacao.Animal.Sexo? this.doacao.Animal.Sexo : ""),
      porteAnimal: new FormControl(this.doacao.Animal.Porte? this.doacao.Animal.Porte : ""),
      tipoAnimal: new FormControl(this.doacao.Animal.TipoAnimal? this.doacao.Animal.TipoAnimal : ""),
      racaAnimal: new FormControl(this.doacao.Animal.Raca? this.doacao.Animal.Raca : ""),
    })
  }
  onAddFoto(event){
    const file = event.target.files[0];
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => {
      var foto = new Foto();
      foto.Imagem = reader.result.toString();
      this.doacao.Animal.Foto.push(foto);
    };
  }

  onChangeRaca(event :any){
    this.doacao.Animal.Raca.Id = parseInt((document.getElementById("racaSelect") as HTMLInputElement).value);
  }

getRacaId(raca:any){
  return raca.id;
}

  onSubmit(form:any) {
    this.doacao.Animal.Raca.Id = parseInt((document.getElementById("racaSelect") as HTMLInputElement).value);
    var newDoacao = new Doacao();
    newDoacao.Localizacao = this.formDoacao?.value.localizacao;
    newDoacao.Descricao = this.formDoacao?.value.descricao;
    newDoacao.Animal = new Animal();
    newDoacao.Animal.Nome =this.formDoacao?.value.nomeAnimal;
    newDoacao.Animal.Status = StatusEnum.Doacao;
    newDoacao.Animal.Peso =this.formDoacao?.value.pesoAnimal;
    newDoacao.Animal.Idade =this.formDoacao?.value.idadeAnimal;
    newDoacao.Animal.Sexo = parseInt(this.formDoacao?.value.sexoAnimal);
    newDoacao.Animal.Porte =parseInt(this.formDoacao?.value.porteAnimal);
    newDoacao.Animal.TipoAnimal =parseInt(this.formDoacao?.value.tipoAnimal);
    newDoacao.Animal.Raca = new Raca();
    newDoacao.Animal.Raca.Id = this.doacao.Animal.Raca.Id;
    newDoacao.Animal.Foto = this.doacao.Animal.Foto;
    newDoacao.Usuario = new Usuario();
      newDoacao.Usuario.Id=this.user.id;
      let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog2.open(MatSpinnerComponent, {
        panelClass: 'transparent',
        disableClose: true
      });
    this.doacaoService.createDoacao(newDoacao).subscribe(()=>{
      this.router.navigate(['']);dialogRef.close();
    },error=>{ dialogRef.close();})
  }

}
