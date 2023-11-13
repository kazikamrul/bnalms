import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { ReaderInformationListComponent } from './readerinformation/readerinformation-list/readerinformation-list.component';
import { NewReaderInformationComponent } from './readerinformation/new-readerinformation/new-readerinformation.component';
import { BookBindingInfoListComponent } from './bookbindinginfo/bookbindinginfo-list/bookbindinginfo-list.component';
import { NewBookBindingInfoComponent } from './bookbindinginfo/new-bookbindinginfo/new-bookbindinginfo.component';
import { DamageInformationByLibraryListComponent } from './damageinformationbylibrary/damageinformationbylibrary-list/damageinformationbylibrary-list.component';
import { NewDamageInformationByLibraryComponent } from './damageinformationbylibrary/new-damageinformationbylibrary/new-damageinformationbylibrary.component';
import { SoftCopyUploadListComponent } from './softcopyupload/softcopyupload-list/softcopyupload-list.component';
import { NewSoftCopyUploadComponent } from './softcopyupload/new-softcopyupload/new-softcopyupload.component';
// import { NoticeInfoListComponent } from './noticeinfo/noticeinfo-list/noticeinfo-list.component';
// import { NewNoticeInfoComponent } from './noticeinfo/new-noticeinfo/new-noticeinfo.component';
import {BookIssueAndSubmissionListComponent} from './bookIssueandsubmission/bookIssueandsubmission-list/bookIssueandsubmission-list.component'
import {NewBookIssueAndSubmissionComponent} from './bookIssueandsubmission/new-bookIssueandsubmission/new-bookIssueandsubmission.component';
import { DamagedByBorrowerListComponent } from './damagedbyborrower/damagedbyborrower-list/damagedbyborrower-list.component';
import { NewDamageBbyBorrowerComponent } from './damagedbyborrower/new-damagedbyborrower/new-damagedbyborrower.component';
import {NewVideofilesComponent} from '../book-management/videofiles/new-videofiles/new-videofiles.component'
import { VideoFileListComponent } from './videofiles/videofile-list/videofile-list.component';
import { DamageReturnComponent } from './bookIssueandsubmission/damagereturn/damagereturn.component';
import {ViewBookDetailsComponent} from '../book-management/view-bookdetails/view-bookdetails.component'
import { DamagedListComponent } from './damagedbyborrower/damaged-list/damaged-list.component';
import {MemberFineListComponent} from './memberfine-list/memberfine-list.component'
import { BookByTitleListComponent } from '../book-management/bookbytitle-list/bookbytitle-list.component';


const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  {
    path: 'book-management-tab',
    loadChildren: () =>
      import('./book-management-tab/book-management-tab.module').then(
        (m) => m.TabModule
      ),
  },
//bookdetails
  {
    path: 'bookdetails/:bookInformationId',
    component: ViewBookDetailsComponent,
  },
  {
    path: 'memberfine-list',
    component: MemberFineListComponent,
  },
  
  {
    path: 'videofile-list',
    component: VideoFileListComponent,
  },
  { path: 'update-videofile/:videoFileId', 
  component:  NewVideofilesComponent,
  },
  {
    path: 'add-videofiles',
    component: NewVideofilesComponent,
  },


  {
    path: 'bookissueandsubmission-list',
    component: BookIssueAndSubmissionListComponent,
  },
  {
    path: 'add-bookissueandsubmission',
    component: NewBookIssueAndSubmissionComponent,
  },
  { path: 'update-bookissueandsubmission/:bookissueandsubmissionId', 
  component:  NewBookIssueAndSubmissionComponent,
  },


  
  { 
    path: 'update-damagereturn/:bookIssueAndSubmissionId', 
    component:  DamageReturnComponent,
  },
  
  {
    path: 'softcopyupload-list',
    component: SoftCopyUploadListComponent,
  },
  { path: 'update-softcopyupload/:softCopyUploadId', 
  component:  NewSoftCopyUploadComponent,
  },
  {
    path: 'add-softcopyupload',
    component: NewSoftCopyUploadComponent,
  },
  {
    path: 'readerinformation-list',
    component: ReaderInformationListComponent,
  },
  { path: 'update-readerinformation/:readerInformationId', 
  component:  NewReaderInformationComponent,
  },
  {
    path: 'add-readerinformation',
    component: NewReaderInformationComponent,
  },
  {
    path: 'damagedbyborrower-list',
    component: DamagedByBorrowerListComponent,
  },
  { path: 'update-damagedbyborrower/:bookIssueAndSubmissionId', 
  component:  NewDamageBbyBorrowerComponent,
  },
  {
    path: 'add-damagedbyborrower',
    component: NewDamageBbyBorrowerComponent,
  },
  {
    path: 'damaged-list',
    component: DamagedListComponent,
  },
  {
    path: 'bookbytitle-list',
    component: BookByTitleListComponent,
  },
  {
    path: 'bookbindinginfo-list',
    component: BookBindingInfoListComponent,
  },
  { path: 'update-bookbindinginfo/:bookBindingInfoId', 
  component:  NewBookBindingInfoComponent,
  },
  {
    path: 'add-bookbindinginfo',
    component: NewBookBindingInfoComponent,
  },
  {
    path: 'damageinformationbylibrary-list',
    component: DamageInformationByLibraryListComponent,
  },
  { path: 'update-damageinformationbylibrary/:damageInformationByLibraryId', 
  component:  NewDamageInformationByLibraryComponent,
  },
  {
    path: 'add-damageinformationbylibrary',
    component: NewDamageInformationByLibraryComponent,
  },

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class BookManagementRoutingModule { }
