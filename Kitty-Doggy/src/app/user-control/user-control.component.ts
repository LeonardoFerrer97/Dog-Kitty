import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { NewChatModalComponent } from '../forum/new-chat-modal/new-chat-modal.component';
import { MatSpinnerComponent } from '../mat-spinner/mat-spinner.component';
import { ChatService } from '../services/chat.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-user-control',
  templateUrl: './user-control.component.html',
  styleUrls: ['./user-control.component.css']
})
export class UserControlComponent implements OnInit {
  filtro:string;
  users:any[];
  usersToDisplay:any[];
  userAux:any[];
  user:any;
  pages = null
  constructor(public router: Router,public userService: UserService,public dialog: MatDialog,public dialogNewChat: MatDialog) {
    this.getUsers(); 

    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;
    if(this.user ==undefined){
      this.router.navigate([""]);
    }    
  }

  ngOnInit(): void {
  }
  getUsers(){
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.userService.getUsers().subscribe(chats=>{
      this.users =chats;
      this.usersToDisplay= Array.from(this.users);
      this.usersToDisplay = this.usersToDisplay.splice(0,4);
      this.userAux = this.usersToDisplay;
      dialogRef.close();
    },error=>{ dialogRef.close();});
  }
  onFiltro(event){
    this.usersToDisplay = this.userAux;
    this.usersToDisplay = this.users.filter(item =>
      item.nome.toLowerCase().includes(this.filtro.toLowerCase())
  ).splice(0,3);
  }
  onChangePage(page){
    this.pages=page
    this.usersToDisplay= Array.from(this.users);
    var index = page.pageIndex*4;
    if(index+2>this.usersToDisplay.length){
      this.usersToDisplay = this.usersToDisplay.splice(index,index+2); 
    }
    else if(index+1>this.usersToDisplay.length){
      this.usersToDisplay =this.usersToDisplay.splice(index,index+1); 
    }else{
      this.usersToDisplay =this.usersToDisplay.splice(index,index+3); 
    }
  }

  deleteUser(id){
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.userService.deleteUser(id).subscribe(()=>{
      dialogRef.close();
      var index = this.users.map(function(item) {
        return item.Id
      }).indexOf(id);
    this.users.splice(index, 1);
    var page:any ={};
    page.pageIndex = 0;
      this.onChangePage(this.pages==null?page:this.pages);
      this.filtro ="";
    },error=>{ dialogRef.close();});
  };
  
}
