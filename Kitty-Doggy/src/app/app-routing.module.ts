// app.routing-module.ts has the following contents

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {UserDataComponent} from './user-data/user-data.component';
import { PostAdoptionComponent } from './adoption/post-adoption/post-adoption.component';
import { SeeAdoptionComponent } from './adoption/see-adoption/see-adoption.component';
import { AdoptionDataComponent } from './adoption/see-adoption/adoption-data/adoption-data.component';

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
  {
    path: 'adocao',
    component: SeeAdoptionComponent,
  },
  {
    path: 'adocao/dados',
    component: AdoptionDataComponent,
  },
  {
    path: 'perdidos',
    component: SeeAdoptionComponent,
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
