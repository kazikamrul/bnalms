import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { NewHelpLineComponent } from './helpline/new-helpline/new-helpline.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  


  // {
  //   path: 'eventinfo-list',
  //   component: EventInfoListComponent,
  // },
  { path: 'update-helpline/:helpLineId', 
  component:  NewHelpLineComponent,
  },
  {
    path: 'add-helpline',
    component: NewHelpLineComponent,
  },

  
  
  

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class HelpLineManagementRoutingModule { }
