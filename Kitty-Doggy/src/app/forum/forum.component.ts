import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig, MatDialogRef } from '@angular/material/dialog';

import { Router } from '@angular/router';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';
import { ChatService } from '../services/chat.service';
import { NewChatModalComponent } from './new-chat-modal/new-chat-modal.component';
@Component({
  selector: 'app-forum',
  templateUrl: './forum.component.html',
  styleUrls: ['./forum.component.css']
})
export class ForumComponent implements OnInit {
  filtro:string;
  chats:any[];
  chatsToDisplay:any[];
  chatsAux:any[];
  user:any;
  pages = null
  constructor(public router: Router,public chatService: ChatService,public dialog: MatDialog,public dialogNewChat: MatDialog) {
    this.getChats(); 

    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;
    if(this.user ==undefined){
      this.router.navigate([""]);
    }    
  }

  ngOnInit(): void {
  }
  getChats(){
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.chatService.getChats().subscribe(chats=>{
      this.chats =chats;
      this.chatsToDisplay= Array.from(this.chats);
      this.chatsToDisplay = this.chatsToDisplay.splice(0,4);
      this.chatsAux = this.chatsToDisplay;
      dialogRef.close();
    },error=>{ dialogRef.close();});
  }
  onFiltro(event){
    this.chatsToDisplay = this.chatsAux;
    this.chatsToDisplay = this.chats.filter(item =>
      item.title.toLowerCase().includes(this.filtro.toLowerCase())
  ).splice(0,3);
  }
  onChangePage(page){
    this.pages=page
    this.chatsToDisplay= Array.from(this.chats);
    var index = page.pageIndex*4;
    if(index+2>this.chatsToDisplay.length){
      this.chatsToDisplay = this.chatsToDisplay.splice(index,index+2); 
    }
    else if(index+1>this.chatsToDisplay.length){
      this.chatsToDisplay =this.chatsToDisplay.splice(index,index+1); 
    }else{
      this.chatsToDisplay =this.chatsToDisplay.splice(index,index+3); 
    }
  }
  clickOnChat(chat){
    this.router.navigate(["forum/chat/"+chat.id],{state:{chat:chat,user:this.user}});   
  }
  createNewChat(){
    
    var dialogConfig = new MatDialogConfig();
    dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;        
    dialogConfig.data = {
      user:this.user
    };
    const dialogRef = this.dialogNewChat.open(NewChatModalComponent,
      dialogConfig);
    dialogRef.afterClosed().subscribe(()=>{
       this.getChats()
    });
  }

  
  deleteChat(id){
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.chatService.deleteChatMessage(id).subscribe(()=>{
      dialogRef.close();
      var index = this.chats.map(function(item) {
        return item.Id
      }).indexOf(id);
    this.chats.splice(index, 1);
    var page:any ={};
    page.pageIndex = 0;
      this.onChangePage(this.pages==null?page:this.pages);
      this.filtro ="";
    },error=>{ dialogRef.close();});
  };
  
}
