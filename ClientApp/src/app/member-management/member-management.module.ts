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
import { MemberManagementRoutingModule } from './Member-management-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatRadioModule } from '@angular/material/radio';
import { MemberInfoListComponent } from './memberinfo/memberinfo-list/memberinfo-list.component';
import { NewMemberInfoComponent } from './memberinfo/new-memberinfo/new-memberinfo.component';
import { ViewMemberInfoComponent } from './memberinfo/view-memberinfo/view-memberinfo.component';
import { FeeInformationListComponent } from './feeinformation/feeinformation-list/feeinformation-list.component';
import { NewFeeInformationComponent } from './feeinformation/new-feeinformation/new-feeinformation.component';
import { ActiveDeactiveMemberListComponent } from './memberinfo/activedeactivemember-list/activedeactivemember-list.component';
import { NewMemberRegistrationComponent } from './memberregistration/new-memberregistration/new-memberregistration.component';
import {FineForIssuereturnListComponent} from './fineforissuereturn-list/fineforissuereturn-list.component'
import {NewFineforIssueReturnMemberComponent} from './new-fineforissuereturn/new-fineforissuereturnmember.component'

@NgModule({
  declarations: [
    MemberInfoListComponent,
    NewMemberInfoComponent,
    ViewMemberInfoComponent,
    FeeInformationListComponent,
    NewFeeInformationComponent,
    ActiveDeactiveMemberListComponent,
    NewMemberRegistrationComponent,
    FineForIssuereturnListComponent,
    NewFineforIssueReturnMemberComponent

  ],
  imports: [
    CommonModule,
    MemberManagementRoutingModule,
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
export class MemberManagementModule { }
