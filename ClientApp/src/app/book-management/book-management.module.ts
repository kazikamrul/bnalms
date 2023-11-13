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
import { BookManagementRoutingModule } from './book-management-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { ReaderInformationListComponent } from './readerinformation/readerinformation-list/readerinformation-list.component';
import { NewReaderInformationComponent } from './readerinformation/new-readerinformation/new-readerinformation.component';
import { BookBindingInfoListComponent } from './bookbindinginfo/bookbindinginfo-list/bookbindinginfo-list.component';
import { NewBookBindingInfoComponent } from './bookbindinginfo/new-bookbindinginfo/new-bookbindinginfo.component'
import { DamageInformationByLibraryListComponent } from './damageinformationbylibrary/damageinformationbylibrary-list/damageinformationbylibrary-list.component';
import { NewDamageInformationByLibraryComponent } from './damageinformationbylibrary/new-damageinformationbylibrary/new-damageinformationbylibrary.component';
import { SoftCopyUploadListComponent } from './softcopyupload/softcopyupload-list/softcopyupload-list.component';
import { NewSoftCopyUploadComponent } from './softcopyupload/new-softcopyupload/new-softcopyupload.component';
// import { NoticeInfoListComponent } from './noticeinfo/noticeinfo-list/noticeinfo-list.component';
// import { NewNoticeInfoComponent } from './noticeinfo/new-noticeinfo/new-noticeinfo.component';
//import { NgxMatDatetimePickerModule, NgxMatTimepickerModule } from '@angular-material-components/datetime-picker';
import { MatTimepickerModule } from 'mat-timepicker';
import {BookIssueAndSubmissionListComponent} from './bookIssueandsubmission/bookIssueandsubmission-list/bookIssueandsubmission-list.component'
import {NewBookIssueAndSubmissionComponent} from './bookIssueandsubmission/new-bookIssueandsubmission/new-bookIssueandsubmission.component';
import { DamagedByBorrowerListComponent } from './damagedbyborrower/damagedbyborrower-list/damagedbyborrower-list.component';
import { NewDamageBbyBorrowerComponent } from './damagedbyborrower/new-damagedbyborrower/new-damagedbyborrower.component';
import { MatRadioModule } from '@angular/material/radio';
import {NewVideofilesComponent} from '../book-management/videofiles/new-videofiles/new-videofiles.component'
import {LoaderComponent} from '../book-management/videofiles/loader/loader.component'
import { VideoFileListComponent } from './videofiles/videofile-list/videofile-list.component';
import { DamageReturnComponent } from './bookIssueandsubmission/damagereturn/damagereturn.component';
import {ViewBookDetailsComponent} from '../book-management/view-bookdetails/view-bookdetails.component'
import { DamagedListComponent } from '../book-management/damagedbyborrower/damaged-list/damaged-list.component';
import {MemberFineListComponent} from './memberfine-list/memberfine-list.component'
import { BookByTitleListComponent } from '../book-management/bookbytitle-list/bookbytitle-list.component';


@NgModule({
  declarations: [
    DamagedListComponent,
    LoaderComponent,
    NewVideofilesComponent,
    VideoFileListComponent,
    BookIssueAndSubmissionListComponent,
    NewBookIssueAndSubmissionComponent,
    ReaderInformationListComponent,
    NewReaderInformationComponent,
    BookBindingInfoListComponent,
    NewBookBindingInfoComponent,
    DamageInformationByLibraryListComponent,
    NewDamageInformationByLibraryComponent,
    SoftCopyUploadListComponent,
    NewSoftCopyUploadComponent,
    DamagedByBorrowerListComponent,
    NewDamageBbyBorrowerComponent,
    DamageReturnComponent,
    ViewBookDetailsComponent,
    MemberFineListComponent,
    BookByTitleListComponent
  ],
  imports: [
    CommonModule,
    BookManagementRoutingModule,
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
    MatTimepickerModule,
    MatRadioModule
  ],
})
export class BookManagementModule { }
