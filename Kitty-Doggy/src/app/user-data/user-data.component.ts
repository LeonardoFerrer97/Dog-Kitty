import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/domain/usuario';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from '../services/user.service';
@Component({
  selector: 'app-user-data',
  templateUrl: './user-data.component.html',
  styleUrls: ['./user-data.component.css']
})
export class UserDataComponent implements OnInit {
  formUser: FormGroup
  user :any;
  constructor(public router: Router,public userService: UserService) { 
    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;
  } 

  ngOnInit(): void {
    this.createForm(this.user)
  }
  createForm(user: any) {
    this.formUser = new FormGroup({
      nome: new FormControl(user.nome? user.nome : ""),
      email: new FormControl(user.email? user.email : ""),
      contato: new FormControl(user.contato? user.contato : ""),
      endereco: new FormControl(user.endereco? user.endereco : ""),
      isAdmin: new FormControl(user.isAdmin? user.isAdmin : ""),
    })
  }
  onSubmit(form:any) {
    var newUser = new Usuario();
    newUser.Email = this.formUser?.value.email;
    newUser.Nome = this.formUser?.value.nome;
    newUser.Contato = this.formUser?.value.contato;
    newUser.Endereco = this.formUser?.value.endereco;
    newUser.IsAdmin = this.formUser?.value.isAdmin;
    this.userService.updateUser(newUser).subscribe(()=>{
      this.router.navigate(['']);
    })
  }
}
