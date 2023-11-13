import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { NewDemandBookComponent } from './demandbook/new-demandbook/new-demandbook.component';
import { NewProfileComponent } from './profile/new-profile/new-profile.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  {
    path: 'add-demandbook',
    component: NewDemandBookComponent,
  },

  {
    path: 'profile-update',
    component: NewProfileComponent,
  },

  // {
  //   path: 'memberinfo-list',
  //   component: MemberInfoListComponent,
  // },
  // { path: 'update-memberinfo/:memberInfoId', 
  // component:  NewMemberInfoComponent,
  // },
  // {
  //   path: 'add-memberinfo',
  //   component: NewMemberInfoComponent,
  // },
  // { 
  //   path: 'view-memberinfo/:memberInfoId', 
  //   component: ViewMemberInfoComponent
  // },
  
  

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class MemberDemandRoutingModule { }
