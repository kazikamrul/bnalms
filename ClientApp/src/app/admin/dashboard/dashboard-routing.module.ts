// import { DashboardComponent as studentDashboard } from './../../student/dashboard/dashboard.component';
// import { DashboardComponent as teacherDashboard } from './../../teacher/dashboard/dashboard.component';
// import { DashboardComponent as employeeDashboard } from './../../employee/dashboard/dashboard.component';
// import { DashboardComponent as userDashboard } from './../../user-dashboard/dashboard/dashboard.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MainComponent } from './main/main.component';
import { MemberDashboardComponent } from './memberdashboard/memberdashboard.component';
import {UserDashboardComponent} from './userdashboard/userdashboard.component';
import {BookinfoListComponent} from './bookinfo-list/bookinfo-list.component';
import {BookInformationListComponent} from './bookinformation-list/bookinformation-list.component';
import {OnlineBookRequestListComponent} from './onlinebookrequest-list/onlinebookrequest-list.component';
import {ViewSoftCopyComponent} from './view-softcopy/view-softcopy.component';
import {ViewSoftcopyListComponent} from './view-softcopylist/view-softcopylist.component';

import {SoftcopyMaterialListComponent} from './softcopymaterial-list/softcopymaterial-list.component';
import {ViewSoftcopyMaterialComponent} from './view-softcopymaterial/view-softcopymaterial.component';
import {MemberNoticeListComponent} from './membernotice-list/membernotice-list.component';
import { MyIssueBookforMemberListComponent } from './myissuebookformember-list/myissuebookformember-list.component';
import {OnlineRequestesBookListComponent} from './onlinerequestesbook-list/onlinerequestesbook-list.component';
import { ViewMemberInfoComponent } from 'src/app/member-management/memberinfo/view-memberinfo/view-memberinfo.component';
import {ViewBookIssueandSubmissionListComponent} from '../../../app/admin/dashboard/view-bookIssueandsubmission-list/view-bookIssueandsubmission-list.component'
import {BookInformationMemberListComponent} from '../../../app/admin/dashboard/bookinformationmember-list/bookinformationmember-list.component'
import { AllMemberinfoListComponent } from './allmemberinfo-list/allmemberinfo-list.component';
import { BookIssuedforMemberInfoListComponent } from './bookIssuedformemberinfo-list/bookIssuedformemberinfo-list.component';
import {OnlineBookRequestComponent} from './onlinebookrequest/onlinebookrequest.component'
import {BookBindingListComponent} from './bookbinding-list/bookbinding-listcomponent';
import {NewOnlineChatComponent} from '../../notification/onlinechat/new-onlinechat/new-onlinechat.component';
import {DamageBookBymemberListComponent} from '../dashboard/damagebookbymember-list/damagebookbymember-list.component'
import {InventoryDetailListComponent} from './inventorydetail-list/inventorydetail-list.component';
import {InventorybyTypeListComponent} from './inventorybytype-list/inventorybytype-list.component';
//import {BarcodeByBookListComponent} from './barcodebybook-list/barcodebybook-list.component';
import {BarcodeByBookListComponent} from './barcodebybook-list/barcodebybook-list.component';
import {BookByTitleMemberListComponent} from '../dashboard/bookbytitle-list/bookbytitlemember-list.component'
const routes: Routes = [
  {
    path: '',
    redirectTo: 'main',
    pathMatch: 'full',
  },

  {
    path: 'bookbytitlemember-list',
    component: BookByTitleMemberListComponent,
  },

  {
    path: 'main',
    component: MainComponent,
  },
  {
    path: 'damagebymember-list',
    component: DamageBookBymemberListComponent,
  },
  {
    path: 'bookbinding-list',
    component: BookBindingListComponent,
  },
  {
    path: 'user-dashboard',
    component: UserDashboardComponent,
  },

  {
    path: 'onlinerequestesbook-list',
    component: OnlineRequestesBookListComponent,
  },
  {
    path: 'membernotice-list',
    component: MemberNoticeListComponent,
  },
  {
    path: 'online-chat',
    component: NewOnlineChatComponent,
  },
  {
    path: 'onlinerequest',
    component: OnlineBookRequestComponent,
  },
  
  {
    path: 'view-softcopy',
    component: ViewSoftCopyComponent,
  },
  {
    path: 'inventorydetails-list',
    component: InventoryDetailListComponent,
  },
  {
    path: 'inventorybytype-list/:inventoryTypeId',
    component: InventorybyTypeListComponent,
  },
  {
    path: 'view-softcopymaterial',
    component: ViewSoftcopyMaterialComponent,
  },
  {
    path: 'view-softcopylist/:documentTypeId',
    component: ViewSoftcopyListComponent,
  },
  {
    path: 'view-softcopymateriallist/:documentTypeId',
    component: SoftcopyMaterialListComponent,
  },


  {
    path: 'memberdashboard',
    component: MemberDashboardComponent,
  },
  // {
  //   path: 'bookinfo-list',view-softcopylist
  //   component: BookinfoListComponent,
 // ViewBookIssueandSubmissionListComponent
  // },
  {
    path: 'viewbookissue-list',
    component: ViewBookIssueandSubmissionListComponent,
  },
  {
    path: 'bookIssuedformemberinfo-list/:memberInfoId',
    component: BookIssuedforMemberInfoListComponent,
  },
  {
    path: 'bookinfo-list',
    component: BookInformationListComponent,
  },
  
  {
    path: 'barcodebybook-list',
    component: BarcodeByBookListComponent,
  },
  

  {
    path: 'allmemberinfo-list',
    component: AllMemberinfoListComponent,
  },


  {
    path: 'bookinformationmember-list/:bookTitleInfoId',
    component: BookInformationMemberListComponent,
  },

  {
    path: 'onlinebookrequest-list/:bookInformationId',
    component: OnlineBookRequestListComponent,
  },

  {
    path: 'myissuebookformember-list/:memberInfoId',
    component: MyIssueBookforMemberListComponent,
  },
  {
    path: "view-profile/:profileStatus",
    component: ViewMemberInfoComponent,
  },
  
  // {
  //   path: 'teacher-dashboard',
  //   component: teacherDashboard,
  // },
  // {
  //   path: 'student-dashboard',
  //   component: studentDashboard,
  // },
];
@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}
