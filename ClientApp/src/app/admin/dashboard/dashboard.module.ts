// //import { DashboardComponent as userDashboard } from "./../../user-dashboard/dashboard/dashboard.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { NgxDatatableModule } from "@swimlane/ngx-datatable";
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatStepperModule } from "@angular/material/stepper";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatSelectModule } from "@angular/material/select";
import { MatDatepickerModule } from "@angular/material/datepicker";
import { MaterialFileInputModule } from "ngx-material-file-input";
import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { PerfectScrollbarModule } from "ngx-perfect-scrollbar";
import { DashboardRoutingModule } from "./dashboard-routing.module";
import { MainComponent } from "./main/main.component";
import { NgxEchartsModule } from "ngx-echarts";
import { NgApexchartsModule } from "ng-apexcharts";
import { MatIconModule } from "@angular/material/icon";
import { MatButtonModule } from "@angular/material/button";
import { MatMenuModule } from "@angular/material/menu";
import { MemberDashboardComponent } from './memberdashboard/memberdashboard.component';
import {NgMarqueeModule} from 'ng-marquee'
import {UserDashboardComponent} from './userdashboard/userdashboard.component';
import {BookinfoListComponent} from './bookinfo-list/bookinfo-list.component';
import {BookInformationListComponent} from './bookinformation-list/bookinformation-list.component';
import {OnlineBookRequestListComponent} from './onlinebookrequest-list/onlinebookrequest-list.component';
import { NgxBarcodeModule } from "ngx-barcode";
import {ViewSoftCopyComponent} from './view-softcopy/view-softcopy.component'
import {ViewSoftcopyListComponent} from './view-softcopylist/view-softcopylist.component';
import { MyIssueBookforMemberListComponent } from './myissuebookformember-list/myissuebookformember-list.component';
import {OnlineRequestesBookListComponent} from './onlinerequestesbook-list/onlinerequestesbook-list.component';
import {MemberNoticeListComponent} from './membernotice-list/membernotice-list.component';
import {ViewBookIssueandSubmissionListComponent} from '../../../app/admin/dashboard/view-bookIssueandsubmission-list/view-bookIssueandsubmission-list.component'
import {BookInformationMemberListComponent} from '../../../app/admin/dashboard/bookinformationmember-list/bookinformationmember-list.component'

import {ViewSoftcopyMaterialComponent} from './view-softcopymaterial/view-softcopymaterial.component';
import {SoftcopyMaterialListComponent} from './softcopymaterial-list/softcopymaterial-list.component';

import { AllMemberinfoListComponent } from '../dashboard/allmemberinfo-list/allmemberinfo-list.component'
import { BookIssuedforMemberInfoListComponent } from '../dashboard/bookIssuedformemberinfo-list/bookIssuedformemberinfo-list.component'
import {OnlineBookRequestComponent} from './onlinebookrequest/onlinebookrequest.component'
import {BookBindingListComponent} from './bookbinding-list/bookbinding-listcomponent';
import {DamageBookBymemberListComponent} from '../dashboard/damagebookbymember-list/damagebookbymember-list.component'
import {InventoryDetailListComponent} from './inventorydetail-list/inventorydetail-list.component';
import {InventorybyTypeListComponent} from './inventorybytype-list/inventorybytype-list.component';
import {BarcodeByBookListComponent} from './barcodebybook-list/barcodebybook-list.component';
import {BookByTitleMemberListComponent} from '../dashboard/bookbytitle-list/bookbytitlemember-list.component'

// import { DashboardComponent } from "./dashboard/dashboard.component";
@NgModule({
  declarations: [
    MainComponent,
    MemberDashboardComponent,
    UserDashboardComponent,
    BookinfoListComponent,
    BookInformationListComponent,
    AllMemberinfoListComponent,
    BookIssuedforMemberInfoListComponent,
    OnlineBookRequestListComponent,
    ViewSoftCopyComponent,
    ViewSoftcopyListComponent,
    MyIssueBookforMemberListComponent,
    OnlineRequestesBookListComponent,
    MemberNoticeListComponent,
    ViewBookIssueandSubmissionListComponent,
    BookInformationMemberListComponent,
    ViewSoftcopyMaterialComponent,
    SoftcopyMaterialListComponent,
    OnlineBookRequestComponent,
    BookBindingListComponent,
    DamageBookBymemberListComponent,
    InventoryDetailListComponent,
    InventorybyTypeListComponent,
    BarcodeByBookListComponent,
    BookByTitleMemberListComponent
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    NgxEchartsModule.forRoot({
      echarts: () => import("echarts"),
    }),
    PerfectScrollbarModule,
    MatIconModule,
    NgApexchartsModule,
    MatButtonModule,
    MatMenuModule,
    PerfectScrollbarModule,
    MatIconModule,
    NgApexchartsModule,
    MatButtonModule,
    MatMenuModule,
    CommonModule,
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
    MatSelectModule,
    MatDatepickerModule,
    MaterialFileInputModule,
    NgMarqueeModule,
    NgxBarcodeModule
  ],
})
export class DashboardModule {}
