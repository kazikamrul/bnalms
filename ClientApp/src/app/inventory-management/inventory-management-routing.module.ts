import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { NewInventoryComponent } from './inventory/new-inventory/new-inventory.component';
import { NewInventoryTypeComponent } from './inventorytype/new-inventorytype/new-inventorytype.component';
import {InventoryUpdateComponent} from './inventoryupdate/inventoryupdate/inventoryupdate.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  


  // {
  //   path: 'eventinfo-list',
  //InventoryUpdateComponent
  //   component: EventInfoListComponent,
  
  
  // },
  { path: 'inventory-update/:inventoryId', 
  component:  InventoryUpdateComponent,
  },

  { path: 'update-inventory/:inventoryId', 
  component:  NewInventoryComponent,
  },
  {
    path: 'add-inventory',
    component: NewInventoryComponent,
  },

  { path: 'update-inventorytype/:inventoryTypeId', 
  component:  NewInventoryTypeComponent,
  },
  {
    path: 'add-inventorytype',
    component: NewInventoryTypeComponent,
  },

  
  
  

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class InventoryManagementRoutingModule { }
