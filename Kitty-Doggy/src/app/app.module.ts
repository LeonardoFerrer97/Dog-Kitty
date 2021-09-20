import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BarComponent } from './bar/bar.component';import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { HttpClientModule } from '@angular/common/http';
import { UserService } from './services/user.service';    
import { AuthModule, AuthService } from '@auth0/auth0-angular';
import { HomeComponent } from './home/home.component';
import { UserDataComponent } from './user-data/user-data.component';

import { FormsModule,ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    BarComponent,
    HomeComponent,
    UserDataComponent,
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
    }),HttpClientModule,ReactiveFormsModule,FormsModule
  ],
  providers: [AuthService,UserService],
  bootstrap: [AppComponent]
})
export class AppModule { }
