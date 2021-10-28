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

  chats:any[];
  chatsToDisplay:any[];
  constructor(public router: Router,public chatService: ChatService,public dialog: MatDialog,public dialogNewChat: MatDialog) {
    this.getChats(); }

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
      this.chatsToDisplay = this.chatsToDisplay.splice(0,6);
      dialogRef.close();
    },error=>{ dialogRef.close();});
  }

  onChangePage(page){
    this.chatsToDisplay= Array.from(this.chats);
    var index = page.pageIndex*6;
    if(index+5>this.chatsToDisplay.length){
      this.chatsToDisplay = this.chatsToDisplay.splice(index,index+5); 
    }
    else if(index+4>this.chatsToDisplay.length){
      this.chatsToDisplay = this.chatsToDisplay.splice(index,index+4); 
    }
    else if(index+3>this.chatsToDisplay.length){
      this.chatsToDisplay = this.chatsToDisplay.splice(index,index+3); 
    }
    else if(index+2>this.chatsToDisplay.length){
      this.chatsToDisplay = this.chatsToDisplay.splice(index,index+2); 
    }
    else if(index+1>this.chatsToDisplay.length){
      this.chatsToDisplay =this.chatsToDisplay.splice(index,index+1); 
    }else{
      this.chatsToDisplay =this.chatsToDisplay.splice(index,index+6); 
    }
  }
  createNewChat(){
    
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
    const dialogRef = this.dialogNewChat.open(NewChatModalComponent,
      dialogConfig);
    dialogRef.afterClosed().subscribe(()=>{
       this.getChats()
    });
  }
}
