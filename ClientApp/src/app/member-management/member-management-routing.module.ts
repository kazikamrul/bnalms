import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { MemberInfoListComponent } from './memberinfo/memberinfo-list/memberinfo-list.component';
import { NewMemberInfoComponent } from './memberinfo/new-memberinfo/new-memberinfo.component';
import { ViewMemberInfoComponent } from './memberinfo/view-memberinfo/view-memberinfo.component';
import { FeeInformationListComponent } from './feeinformation/feeinformation-list/feeinformation-list.component';
import { NewFeeInformationComponent } from './feeinformation/new-feeinformation/new-feeinformation.component';
import { ActiveDeactiveMemberListComponent } from './memberinfo/activedeactivemember-list/activedeactivemember-list.component';
import { NewMemberRegistrationComponent } from './memberregistration/new-memberregistration/new-memberregistration.component';
import {FineForIssuereturnListComponent} from './fineforissuereturn-list/fineforissuereturn-list.component'
import {NewFineforIssueReturnMemberComponent} from './new-fineforissuereturn/new-fineforissuereturnmember.component'

const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  
  {
    path: 'activedeactivemember-list',
    component: ActiveDeactiveMemberListComponent,
  },
  {
    path: 'add-fineforissuereturnmember/:baseSchoolNameId/:bookIssueAndSubmissionId',
    component: NewFineforIssueReturnMemberComponent,
  },
  
  {
    path: 'fineforissuereturn-list',
    component: FineForIssuereturnListComponent,
  },
  
  {
    path: 'memberinfo-list',
    component: MemberInfoListComponent,
  },
  { path: 'update-memberinfo/:memberInfoId', 
  component:  NewMemberInfoComponent,
  },
  {
    path: 'add-memberinfo',
    component: NewMemberInfoComponent,
  },
  { 
    path: 'view-memberinfo/:memberInfoId', 
    component: ViewMemberInfoComponent
  },

  {
    path: 'add-memberregistration',
    component: NewMemberRegistrationComponent,
  },
  
  {
    path: 'feeinformation-list',
    component: FeeInformationListComponent,
  },
  { path: 'update-feeinformation/:feeInformationId', 
  component:  NewFeeInformationComponent,
  },
  {
    path: 'add-feeinformation',
    component: NewFeeInformationComponent,
  },

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class MemberManagementRoutingModule { }
