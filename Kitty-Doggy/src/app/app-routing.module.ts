// app.routing-module.ts has the following contents

import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {UserDataComponent} from './user-data/user-data.component';
import { PostAdoptionComponent } from './adoption/post-adoption/post-adoption.component';
import { SeeAdoptionComponent } from './adoption/see-adoption/see-adoption.component';
import { AdoptionDataComponent } from './adoption/see-adoption/adoption-data/adoption-data.component';
import { ForumComponent } from './forum/forum.component';
import { UpdateDoacaoComponent } from './adoption/see-adoption/adoption-data/update-doacao/update-doacao.component';
import { ChatComponent } from './forum/chat/chat.component';

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
    path: 'create-lost',
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
  {
    path: 'mylostpets',
    component: SeeAdoptionComponent,
  },
  {
    path: 'myadoptions',
    component: SeeAdoptionComponent,
  },
  {
    path: 'myadoptions/update',
    component: UpdateDoacaoComponent,
  },
  {
    path: 'forum',
    component: ForumComponent,
  },
  {
    path: 'forum/chat',
    component: ChatComponent,
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
