import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { EventInfoListComponent } from './eventinfo/eventinfo-list/eventinfo-list.component';
import { NewEventInfoComponent } from './eventinfo/new-eventinfo/new-eventinfo.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  


  {
    path: 'eventinfo-list',
    component: EventInfoListComponent,
  },
  { path: 'update-eventinfo/:eventInfoId', 
  component:  NewEventInfoComponent,
  },
  {
    path: 'add-eventinfo',
    component: NewEventInfoComponent,
  },

  // {
  //   path: 'eventbudget-list',
  //   component: EventBudgetListComponent,
  // },
  // { path: 'update-eventbudget/:eventBudgetId', 
  // component:  NewEventBudgetComponent,
  // },
  // {
  //   path: 'add-eventbudget',
  //   component: NewEventBudgetComponent,
  // },
  
  
  

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class EventManagementRoutingModule { }
