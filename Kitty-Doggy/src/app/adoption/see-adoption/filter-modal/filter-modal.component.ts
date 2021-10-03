import {Component, Inject, OnInit, ViewEncapsulation} from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from "@angular/material/dialog";
import {FormBuilder, Validators, FormGroup} from "@angular/forms";
import { Filtro } from 'src/domain/filtro';
import { RacaService } from 'src/app/services/raca.service';

@Component({
  selector: 'app-filter-modal',
  templateUrl: './filter-modal.component.html',
  styleUrls: ['./filter-modal.component.css']
})
export class FilterModalComponent implements OnInit {

  form: FormGroup;
  localizacao:string;
  racas: any;
  constructor(
      private fb: FormBuilder,
      private dialogRef: MatDialogRef<FilterModalComponent>,
      @Inject(MAT_DIALOG_DATA) {localizacao,raca,porte,sexo,tipo}:Filtro,public racaService: RacaService) {

        this.racaService.getRacas().subscribe((racas)=>{
          this.racas=racas
        });
        this.form = fb.group({
          localizacao: [localizacao],
          raca: [raca],
          porte: [porte],
          sexo: [sexo],
          tipo: [tipo],
        });

  }

  ngOnInit() {

  }


  getRacas():void{
  }
  save() {
      this.dialogRef.close(this.form.value);
  }

  close() {
      this.dialogRef.close();
  }
}
