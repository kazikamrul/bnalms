import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { Page404Component } from '../authentication/page404/page404.component';
import { BranchListComponent } from './branch/branch-list/branch-list.component';
import { NewBranchComponent } from './branch/new-branch/new-branch.component';
import { BaseNameListComponent } from './basename/basename-list/basename-list.component';
import { NewBaseNameComponent } from './basename/new-basename/new-basename.component';
import { BaseSchoolNameListComponent } from './baseschoolname/baseschoolname-list/baseschoolname-list.component';
import { NewBaseSchoolNameComponent } from './baseschoolname/new-baseschoolname/new-baseschoolname.component';
import { CoursetypeListComponent } from './courseType/coursetype-list/coursetype-list.component';
import {NewCoursetypeComponent} from './courseType/new-coursetype/new-coursetype.component';
import { NewBookTitleInfoComponent } from './booktitleinfo/new-booktitleinfo/new-booktitleinfo.component';
import { BookCategoryListComponent } from './bookcategory/bookcategory-list/bookcategory-list.component';
import { NewBookCategoryComponent } from './bookcategory/new-bookcategory/new-bookcategory.component';
import { MainClassListComponent } from './mainclass/mainclass-list/mainclass-list.component';
import { NewMainClassComponent } from './mainclass/new-mainclass/new-mainclass.component';
import { ShelfInfoListComponent } from './shelfinfo/shelfinfo-list/shelfinfo-list.component';
import { NewShelfInfoComponent } from './shelfinfo/new-shelfinfo/new-shelfinfo.component';
import { RowInfoListComponent } from './rowinfo/rowinfo-list/rowinfo-list.component';
import { NewRowInfoComponent } from './rowinfo/new-rowinfo/new-rowinfo.component';
import {NewMemberCategoryComponent} from './membercategory/new-membercategory/new-membercategory.component';
import {MemberCategoryListComponent} from './membercategory/membercategory-list/membercategory-list.component'
import { AuthorityCategoryListComponent } from './authoritycategory/authoritycategory-list/authoritycategory-list.component';
import { NewAuthorityCategoryComponent } from './authoritycategory/new-authoritycategory/new-authoritycategory.component';
import { DesignationListComponent } from './designation/designation-list/designation-list.component';
import { NewDesignationComponent } from './designation/new-designation/new-designation.component';
import { RankListComponent } from './rank/rank-list/rank-list.component';
import { NewRankComponent } from './rank/new-rank/new-rank.component';
import { InformationFezupListComponent } from './informationfezup/informationfezup-list/informationfezup-list.component';
import { NewLibraryAuthorityComponent } from './libraryauthority/new-libraryauthority/new-libraryauthority.component';
import {NewFineForIssueReturnComponent} from './fineforissuereturn/new-fineforissuereturn/new-fineforissuereturn.component'
import {FineForIssueReturnListComponent} from './fineforissuereturn/fineforissuereturn-list/fineforissuereturn-list.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'signin',
    pathMatch: 'full'
  },
  {
    path: 'informationfezup-list',
    component: InformationFezupListComponent,
  },

  {
    path: 'add-fineforissuereturn',
    component: NewFineForIssueReturnComponent,
  },
  {
    path: 'update-fineforissuereturn/:fineForIssueReturnId',
    component: NewFineForIssueReturnComponent,
  },
  {
    path: 'fineforissuereturn-list',
    component: FineForIssueReturnListComponent,
  },

  


  {
    path: 'membercategory-list',
    component: MemberCategoryListComponent,
  },
  { path: 'update-membercategory/:memberCategoryId', 
  component:  NewMemberCategoryComponent,
  },
  {
    path: 'add-membercategory',
    component: NewMemberCategoryComponent,
  },


  {
    path: 'coursetype-list',
    component: CoursetypeListComponent,
  },
  { path: 'update-coursetype/:courseTypeId', 
  component:  NewCoursetypeComponent,
  },
  {
    path: 'add-coursetype',
    component: NewCoursetypeComponent,
  },
  { path: 'update-booktitleinfo/:bookTitleInfoId', 
  component:  NewBookTitleInfoComponent,
  },
  {
    path: 'add-booktitleinfo',
    component: NewBookTitleInfoComponent,
  },

  { path: 'update-libraryauthority/:libraryAuthorityId', 
  component:  NewLibraryAuthorityComponent,
  },
  {
    path: 'add-libraryauthority',
    component: NewLibraryAuthorityComponent,
  },
  {
    path: 'bookcategory-list',
    component: BookCategoryListComponent,
  },
  { path: 'update-bookcategory/:bookCategoryId', 
  component:  NewBookCategoryComponent,
  },
  {
    path: 'add-bookcategory',
    component: NewBookCategoryComponent,
  },

  {
    path: 'mainclass-list',
    component: MainClassListComponent,
  },
  { path: 'update-mainclass/:mainClassId', 
  component:  NewMainClassComponent,
  },
  {
    path: 'add-mainclass',
    component: NewMainClassComponent,
  },
  {
    path: 'shelfinfo-list',
    component: ShelfInfoListComponent,
  },
  { path: 'update-shelfinfo/:shelfInfoId', 
  component:  NewShelfInfoComponent,
  },
  {
    path: 'add-shelfinfo',
    component: NewShelfInfoComponent,
  },

  {
    path: 'rank-list',
    component: RankListComponent,
  },
  { path: 'update-rank/:rankId', 
  component:  NewRankComponent,
  },
  {
    path: 'add-rank',
    component: NewRankComponent,
  },

  {
    path: 'designation-list',
    component: DesignationListComponent,
  },
  { path: 'update-designation/:designationId', 
  component:  NewDesignationComponent,
  },
  {
    path: 'add-designation',
    component: NewDesignationComponent,
  },
  {
    path: 'rowinfo-list',
    component: RowInfoListComponent,
  },
  { path: 'update-rowinfo/:rowInfoId', 
  component:  NewRowInfoComponent,
  },
  {
    path: 'add-rowinfo',
    component: NewRowInfoComponent,
  },
  {
    path: 'authoritycategory-list',
    component: AuthorityCategoryListComponent,
  },
  { path: 'update-authoritycategory/:authorityCategoryId', 
  component:  NewAuthorityCategoryComponent,
  },
  {
    path: 'add-authoritycategory',
    component: NewAuthorityCategoryComponent,
  },

  {
    path: 'branch-list',
    component: BranchListComponent,
  },
  { path: 'update-branch/:branchId', 
  component: NewBranchComponent
  },
  {
    path: 'add-branch',
    component: NewBranchComponent,
  },
  

  {
    path: 'basename-list',
    component: BaseNameListComponent,
  },
  { path: 'update-basename/:baseNameId', 
  component: NewBaseNameComponent, 
  },
  {
    path: 'add-basename',
    component: NewBaseNameComponent,
  },

  {
    path: 'baseschoolname-list',
    component: BaseSchoolNameListComponent,
  },
  { path: 'update-baseschoolname/:baseSchoolNameId', 
  component: NewBaseSchoolNameComponent, 
  },
  {
    path: 'add-baseschoolname',
    component: NewBaseSchoolNameComponent,
  },

  
  { path: '**', component: Page404Component },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})

export class BasicSetupRoutingModule { }
