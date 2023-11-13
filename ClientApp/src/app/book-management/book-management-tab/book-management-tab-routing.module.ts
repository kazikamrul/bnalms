import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
//import { Page404Component } from '.../authentication/page404/page404.component';
import { NewBookInformationComponent } from './bookinformation/new-bookinformation/new-bookinformation.component';
import { BookInformationListComponent } from './bookinformation/bookinformation-list/bookinformation-list.component';
import { AuthorInformationListComponent } from './authornformation/authornformation-list/authornformation-list.component';
import { NewAuthorInformationComponent } from './authornformation/new-authornformation/new-authornformation.component';
import { MainTabLayoutComponent } from './main-tab-layout/main-tab-layout.component';
import { PublishersInformationListComponent } from './publishersinformation/publishersinformation-list/publishersinformation-list.component';
import { NewPublishersInformationComponent } from './publishersinformation/new-publishersinformation/new-publishersinformation.component';
import { SupplierInformationListComponent } from './supplierinformation/supplierinformation-list/supplierinformation-list.component';
import { NewSupplierInformationComponent } from './supplierinformation/new-supplierinformation/new-supplierinformation.component';
import { SourceInformationListComponent } from './sourceinformation/sourceinformation-list/sourceinformation-list.component';
import { NewSourceInformationComponent } from './sourceinformation/new-sourceinformation/new-sourceinformation.component';
import { ViewBookInformationComponent } from './bookinformation/view-bookinformation/view-bookinformation.component';
import {ErrorPageHandlerComponent} from './errorpagehandler/errorpagehandler.component';
import{ViewMemberInformationComponent} from './bookinformation/view-memberinformation/view-memberinformation.component';
import { NewBookInformationDamageComponent } from './bookinformation/new-bookinformationdamaged/new-bookinformationdamaged.component';

const routes: Routes = [
  { path: 'main-tab-layout/:bookInformationId', 
   component: MainTabLayoutComponent, 
   },
  // {
  //   path: '',
  //   redirectTo: 'signin',
  //   pathMatch: 'full'
  // },
  {
    path: 'main-tab-layout/main-tab',
    component: MainTabLayoutComponent,
    children: [
      { path: '',redirectTo: 'main-tab-layout',pathMatch: 'full'},
      

      // {
      //   path: 'update-bookinformation/:bookInformationId',
      //   component: NewBookInformationComponent,
      // },

      { 
        path: 'authornformation/:bookInformationId', 
        component: AuthorInformationListComponent
      },
      { 
        path: 'add-authornformation/:bookInformationId', 
        component: NewAuthorInformationComponent
      },
      { 
        path: 'update-authornformation/:bookInformationId/:authorInformationId', 
        component: NewAuthorInformationComponent
      },

      { 
        path: 'publishersinformation/:bookInformationId', 
        component: PublishersInformationListComponent
      },
      { 
        path: 'add-publishersinformation/:bookInformationId', 
        component: NewPublishersInformationComponent
      },
      { 
        path: 'update-publishersinformation/:bookInformationId/:publishersInformationId', 
        component: NewPublishersInformationComponent
      },

      { 
        path: 'supplierinformation/:bookInformationId', 
        component: SupplierInformationListComponent
      },
      { 
        path: 'add-supplierinformation/:bookInformationId', 
        component: NewSupplierInformationComponent
      },
      { 
        path: 'update-supplierinformation/:bookInformationId/:supplierInformationId', 
        component: NewSupplierInformationComponent
      },
      { 
        path: 'sourceinformation/:bookInformationId', 
        component: SourceInformationListComponent
      },
      { 
        path: 'add-sourceinformation/:bookInformationId', 
        component: NewSourceInformationComponent
      },
      { 
        path: 'update-sourceinformation/:bookInformationId/:sourceInformationId', 
        component: NewSourceInformationComponent
      },

    
    ]
  },

  {
    path: 'bookinformation-list',
    component: BookInformationListComponent,
  },
  { path: 'update-bookinformation/:bookInformationId', 
  component:  NewBookInformationComponent,
  },
  {
    path: 'add-bookinformation',
    component: NewBookInformationComponent,
  },
  { 
    path: 'view-bookinformation/:bookInformationId', 
    component: ViewBookInformationComponent
  },
  { path: 'update-bookinformationdamaged/:bookInformationId', 
  component:  NewBookInformationDamageComponent,
  },

  {
    path: 'errorpagehandler',
    component: ErrorPageHandlerComponent,
  },
  
  { 
    path: 'view-memberinformation/:memberInfoId', 
    component: ViewMemberInformationComponent
  },

  
  //{ path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class TabsRoutingModule { }
