import { Component, OnInit } from '@angular/core';

import { AuthService } from '@auth0/auth0-angular';
import { Usuario } from 'src/domain/usuario';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-bar',
  templateUrl: './bar.component.html',
  styleUrls: ['./bar.component.css']
})
export class BarComponent implements OnInit {

  isLoggedIn=false;
  constructor(public auth: AuthService,public userService: UserService) {}

  ngOnInit(): void {    
    this.auth.user$.subscribe(
    (profile) => {
      console.log(profile)
    if(profile!=null){
      this.isLoggedIn=true;
    this.userService.getUserByEmail(profile?.email).subscribe((user)=>{
      if(!user){
        var newUser = new Usuario();
        newUser.Email = profile?.email;
        newUser.IsAdmin = false;
        this.userService.createUser(newUser).subscribe();

      }
    });
  }    
    }
  );
  }

  onClickText(){
    
  }
  Logout(){
    this.auth.logout({ returnTo: document.location.origin })
  }  
  Login(){
  
    this.auth.loginWithRedirect(); 



  }
}
