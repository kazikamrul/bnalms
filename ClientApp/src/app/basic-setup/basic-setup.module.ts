import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { BasicSetupRoutingModule } from './basic-setup-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { BranchListComponent } from './branch/branch-list/branch-list.component';
import { NewBranchComponent } from './branch/new-branch/new-branch.component';
import { BaseNameListComponent } from './basename/basename-list/basename-list.component';
import { NewBaseNameComponent } from './basename/new-basename/new-basename.component';
import { BaseSchoolNameListComponent } from './baseschoolname/baseschoolname-list/baseschoolname-list.component';
import { NewBaseSchoolNameComponent } from './baseschoolname/new-baseschoolname/new-baseschoolname.component';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import {CoursetypeListComponent} from './courseType/coursetype-list/coursetype-list.component';
import { NewCoursetypeComponent } from './courseType/new-coursetype/new-coursetype.component';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
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
import { MatRadioModule } from '@angular/material/radio';
import { InformationFezupListComponent } from './informationfezup/informationfezup-list/informationfezup-list.component';
import { NewLibraryAuthorityComponent } from './libraryauthority/new-libraryauthority/new-libraryauthority.component';
import {NewFineForIssueReturnComponent} from './fineforissuereturn/new-fineforissuereturn/new-fineforissuereturn.component'
import {FineForIssueReturnListComponent} from './fineforissuereturn/fineforissuereturn-list/fineforissuereturn-list.component';


@NgModule({
  declarations: [
    NewLibraryAuthorityComponent,
    InformationFezupListComponent,
    RankListComponent,
    NewRankComponent,
    NewMemberCategoryComponent,
    MemberCategoryListComponent,
    BranchListComponent,
    NewBranchComponent,
    BaseNameListComponent,
    NewBaseNameComponent,
    BaseSchoolNameListComponent,
    NewBaseSchoolNameComponent,
    CoursetypeListComponent,
    NewCoursetypeComponent,
    NewBookTitleInfoComponent,
    BookCategoryListComponent,
    NewBookCategoryComponent,
    MainClassListComponent,
    NewMainClassComponent,
    ShelfInfoListComponent,
    NewShelfInfoComponent,
    RowInfoListComponent,
    NewRowInfoComponent,
    AuthorityCategoryListComponent,
    NewAuthorityCategoryComponent,
    DesignationListComponent,
    NewDesignationComponent,
    NewFineForIssueReturnComponent,
    FineForIssueReturnListComponent
  ],
  imports: [
    CommonModule,
    BasicSetupRoutingModule,
    CommonModule,
    FormsModule,  
    ReactiveFormsModule,
    NgxDatatableModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatStepperModule,
    MatSnackBarModule,
    MatButtonModule,
    MatIconModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MaterialFileInputModule,
    MatProgressSpinnerModule,
    HttpClientModule,
    MatAutocompleteModule,
    MatRadioModule
    
  ]
})
export class BasicSetupModule { }
