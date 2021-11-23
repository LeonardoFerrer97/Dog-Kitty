import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { MatSpinnerComponent } from 'src/app/mat-spinner/mat-spinner.component';
import { ChatService } from 'src/app/services/chat.service';
import { ChatMessages } from 'src/domain/ChatMessages';

@Component({
  selector: 'app-chat',
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent implements OnInit {
  newMessage:string;
  user:any;
  chat:any;
  constructor(public router:Router,public chatService: ChatService,
    public dialog: MatDialog) {
    this.user = this.router?.getCurrentNavigation()?.extras?.state?.user;    
    this.chat = this.router?.getCurrentNavigation()?.extras?.state?.chat;  

   }

  ngOnInit(): void {
  }
  createNewMessage(){

    var chat = new ChatMessages();
    chat.Date = new Date();
    chat.Message = this.newMessage;
    chat.Usuario_id = this.user.id;
    chat.Chat_id = this.chat.id;
    chat.Date = new Date();
    console.log(chat);
    console.log(this.chat)
    let dialogRef: MatDialogRef<MatSpinnerComponent> = this.dialog.open(MatSpinnerComponent, {
      panelClass: 'transparent',
      disableClose: true
    });
    this.chatService.createChatMessage(chat).subscribe(()=>{
      dialogRef.close();
      this.chat.chatMessages.Add(chat);
    },error=>{ dialogRef.close();});
  }

}
