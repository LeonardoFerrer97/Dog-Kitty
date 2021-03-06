import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AuthService } from '@auth0/auth0-angular';
import { StatusEnum } from 'src/domain/enum/statusEnum';
import { Usuario } from 'src/domain/usuario';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  styleUrls: ['./bar.component.css']
})
export class BarComponent implements OnInit {
  user:any | undefined;
  isLoggedIn=false;
  constructor(public auth: AuthService,public userService: UserService, public router:Router) {
    this.auth.user$.subscribe(
      (profile) => {
      if(profile!=null){
        this.isLoggedIn=true;
      this.userService.getUserByEmail(profile?.email).subscribe((user)=>{
        if(!user){
          var newUser = new Usuario();
          newUser.Email = profile?.email;
          newUser.IsAdmin = false;
          newUser.Nome = profile?.name;
          this.userService.createUser(newUser).subscribe();
          this.user=newUser;
        }else{
         this.user = user;
        }
      });
    }    
      }
    );
  }

  ngOnInit(): void {    
  }

  onClickText(click:string){
    if(click=="updatedata"){
      this.router.navigate(["user-data"],{state:{user:this.user}});   
     }else if(click=="createadoption"){
      this.router.navigate(["create-adoption"],{state:{status:StatusEnum.Doacao,user:this.user}});   
     }else if(click=="home"){
      this.router.navigate([""]);   
     }else if(click=="doacao"){
      this.router.navigate(["adocao"],{state:{status:StatusEnum.Doacao,isMyAdoption:false}});   
     }else if(click=="perdido"){
      this.router.navigate(["perdidos"],{state:{status:StatusEnum.Perdido,isMyAdoption:false}});   
     }else if(click=="myadoptions"){
      this.router.navigate(["myadoptions"],{state:{status:StatusEnum.Doacao,user:this.user,isMyAdoption:true}});   
     }else if(click=="mylostpets"){
      this.router.navigate(["mylostpets"],{state:{status:StatusEnum.Perdido,user:this.user,isMyAdoption:true}});   
     }else if(click=="createlost"){
      this.router.navigate(["create-lost"],{state:{status:StatusEnum.Perdido,user:this.user}});   
     }else if(click=="forum"){
      this.router.navigate(["forum"],{state:{user:this.user}});   
     }else if(click=="user-control"){
      this.router.navigate(["user-control"],{state:{user:this.user}});   
     }
    
  }
  Logout(){
    this.auth.logout({ returnTo: document.location.origin })
  }  
  Login(){
  
    this.auth.loginWithRedirect(); 



  }
}
