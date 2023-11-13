import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgxBarcodeModule } from 'ngx-barcode';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatSelectModule } from '@angular/material/select';
import { TabsRoutingModule } from './book-management-tab-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatStepperModule } from '@angular/material/stepper';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import { HttpClientModule } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MainTabLayoutComponent } from './main-tab-layout/main-tab-layout.component';
import { NewBookInformationComponent } from './bookinformation/new-bookinformation/new-bookinformation.component';
import { BookInformationListComponent } from './bookinformation/bookinformation-list/bookinformation-list.component';
import { NewAuthorInformationComponent } from './authornformation/new-authornformation/new-authornformation.component';
import { AuthorInformationListComponent } from './authornformation/authornformation-list/authornformation-list.component';
import { PublishersInformationListComponent } from './publishersinformation/publishersinformation-list/publishersinformation-list.component';
import { NewPublishersInformationComponent } from './publishersinformation/new-publishersinformation/new-publishersinformation.component';
import { MatTabsModule } from '@angular/material/tabs';
import { MatRadioModule } from '@angular/material/radio';
import { SupplierInformationListComponent } from './supplierinformation/supplierinformation-list/supplierinformation-list.component';
import { NewSupplierInformationComponent } from './supplierinformation/new-supplierinformation/new-supplierinformation.component';
import { SourceInformationListComponent } from './sourceinformation/sourceinformation-list/sourceinformation-list.component';
import { NewSourceInformationComponent } from './sourceinformation/new-sourceinformation/new-sourceinformation.component';
import { ViewBookInformationComponent } from './bookinformation/view-bookinformation/view-bookinformation.component';
import{ViewMemberInformationComponent} from './bookinformation/view-memberinformation/view-memberinformation.component';
import { NewBookInformationDamageComponent } from './bookinformation/new-bookinformationdamaged/new-bookinformationdamaged.component';


@NgModule({
  declarations: [
    NewBookInformationDamageComponent,
    MainTabLayoutComponent,
    NewBookInformationComponent,
    BookInformationListComponent,
    ViewBookInformationComponent,
    NewAuthorInformationComponent,
    AuthorInformationListComponent,
    PublishersInformationListComponent,
    NewPublishersInformationComponent,
    SupplierInformationListComponent,
    NewSupplierInformationComponent,
    SourceInformationListComponent,
    NewSourceInformationComponent,
    ViewMemberInformationComponent
  ],
  imports: [
    CommonModule,
    TabsRoutingModule,
    CommonModule,
    FormsModule, 
    MatTabsModule, 
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
   MatRadioModule,
   NgxBarcodeModule,    
  ]
})
export class TabModule { }
