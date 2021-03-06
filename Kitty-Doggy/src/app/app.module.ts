import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BarComponent } from './bar/bar.component';import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatExpansionModule} from '@angular/material/expansion';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from './services/user.service';    
import { AuthModule, AuthService } from '@auth0/auth0-angular';
import { HomeComponent } from './home/home.component';
import { UserDataComponent } from './user-data/user-data.component';
import {MatDialogModule} from '@angular/material/dialog';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { PostAdoptionComponent } from './adoption/post-adoption/post-adoption.component';
import { SeeAdoptionComponent } from './adoption/see-adoption/see-adoption.component';
import { FilterModalComponent } from './adoption/see-adoption/filter-modal/filter-modal.component';
import { MatInputModule } from "@angular/material/input";
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';

import { MatSelectModule } from "@angular/material/select";
import { MatSpinnerComponent } from './mat-spinner/mat-spinner.component';
import { AdoptionDataComponent } from './adoption/see-adoption/adoption-data/adoption-data.component';
import { ForumComponent } from './forum/forum.component';
import { NewChatModalComponent } from './forum/new-chat-modal/new-chat-modal.component';
import { UpdateDoacaoComponent } from './adoption/see-adoption/adoption-data/update-doacao/update-doacao.component';
import { AdoptionService } from './services/adoption.service';
import { ChatComponent } from './forum/chat/chat.component';
import { UserControlComponent } from './user-control/user-control.component';
@NgModule({
  declarations: [
    AppComponent,
    BarComponent,
    HomeComponent,
    UserDataComponent,
    PostAdoptionComponent,
    SeeAdoptionComponent,
    FilterModalComponent,
    MatSpinnerComponent,
    AdoptionDataComponent,
    ForumComponent,
    NewChatModalComponent,
    UpdateDoacaoComponent,
    ChatComponent,
    UserControlComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatIconModule,
    BrowserAnimationsModule,
    MatMenuModule,
    AuthModule.forRoot({
      domain: 'dev-d1olx9ru.auth0.com',
      clientId: 'wnK9bKI1imlksxrkvuyVUM8fQ1zlL6uu'
    }),HttpClientModule,ReactiveFormsModule,FormsModule,MatExpansionModule,MatDialogModule,MatInputModule,MatSelectModule,
    MatPaginatorModule,MatProgressSpinnerModule

  ],
  providers: [AuthService,UserService,AdoptionService],
  bootstrap: [AppComponent],

  entryComponents: [
    FilterModalComponent,MatSpinnerComponent
  ]
})
export class AppModule { }
