import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';
import { ChatService } from 'src/app/services/chat.service';
import { ChatMessages } from 'src/domain/chatMessages';
import { Usuario } from 'src/domain/usuario';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
}) 
export class ChatComponent implements OnInit {
  messagesToDisplay:any;
  newMessage:string;
  user:any;
  chat:any;
  pages=null;
  constructor(public router:Router,public chatService: ChatService,
    public dialog: MatDialog) {
    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;    
    this.chat = this.router?.getCurrentNavigation()?.extras?.state?.chat;
    this.messagesToDisplay= Array.from(this.chat.messages).splice(0,4);  
    if(this.user == null || this.chat ==null){
      this.router.navigate([""]);
    }

   }

  ngOnInit(): void {
  }
  createNewMessage(){
    var chat = new ChatMessages();
    chat.Usuario = new Usuario();
    chat.Usuario.Nome = this.user.nome;
    chat.Date = new Date();
    chat.Message = this.newMessage;
    chat.Usuario_id = this.user.id;
    chat.Chat_id = this.chat.id;
    chat.Date = new Date();
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.chatService.createChatMessage(chat).subscribe((id)=>{
      dialogRef.close();
      var newMessage:any ={};
      newMessage.id=chat.Id;
      newMessage.message = this.newMessage;
      newMessage.usuario=this.user;
      this.chat.messages.push(newMessage);
      if(this.messagesToDisplay.length<5){
        this.messagesToDisplay.push(newMessage);
      }
      this.newMessage ="";
    },error=>{ dialogRef.close();});
  }
  onChangePage(page){
    this.pages = page;
    this.messagesToDisplay= Array.from(this.chat.messages);
    var index = page.pageIndex*4;
    if(index+3>this.messagesToDisplay.length){
      this.messagesToDisplay = this.messagesToDisplay.splice(index,index+3); 
    }
    else if(index+2>this.messagesToDisplay.length){
      this.messagesToDisplay = this.messagesToDisplay.splice(index,index+2); 
    }
    else if(index+1>this.messagesToDisplay.length){
      this.messagesToDisplay =this.messagesToDisplay.splice(index,index+1); 
    }else{
      this.messagesToDisplay =this.messagesToDisplay.splice(index,index+4); 
    }
  }
  deleteMessage(id){
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.chatService.deleteChatMessage(id).subscribe(()=>{
      dialogRef.close();
      var index = this.chat.messages.map(function(item) {
        return item.Id
      }).indexOf(id);
    this.chat.messages.splice(index, 1);
    var page:any ={};
    page.pageIndex = 0;
      this.onChangePage(this.pages==null?page:this.pages);
      this.newMessage ="";
    },error=>{ dialogRef.close();});
  };
  
}
