// app.routing-module.ts has the following contents

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {UserDataComponent} from './user-data/user-data.component';
import { PostAdoptionComponent } from './adoption/post-adoption/post-adoption.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'user-data',
    component: UserDataComponent,
  },
  {
    path: 'create-adoption',
    component: PostAdoptionComponent,
  },
  
];

@NgModule({

  imports: [
      RouterModule.forRoot(routes)
  ],
  
  exports: [
      RouterModule
  ],
})
export class AppRoutingModule { }
