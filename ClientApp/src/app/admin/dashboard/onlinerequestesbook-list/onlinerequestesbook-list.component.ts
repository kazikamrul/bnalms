import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
//import { InterServiceDashboardService } from '../services/InterServiceDashboard.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/core/models/role';
import { DashboardService } from '../service/Dashboard.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-onlinerequestesbook-list',
  templateUrl: './onlinerequestesbook-list.component.html',
  styleUrls: ['./onlinerequestesbook-list.component.sass']
})
export class OnlineRequestesBookListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  popupIssueRequest = false;
  bookList:any;
  showHideDiv:any;
  onlineRequestCount:any;
  infoPopUpTitle:any;
  issueRequestUserList:any;
  groupArrays: { baseSchoolName: string; datas: any }[];
  onlineBookRequestList:any
  // courseDurationId:number;
  // courseNameId:number;
  // courseTypeId:number;
  // traineeStatusId:number;
  // jcoCourseList:any;
  // baseSchoolNameId:any;
  // titleText:any;
  // dbType:any;
  // dbType1:any;
  // courseType3:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  
  branchId:any;
  memberInfoId:any;
  traineeId:any;   
  role:any;

  displayedColumns: string[] = ['ser','name','duration', 'candidates', 'subject'];

  
  constructor(private datepipe: DatePipe, private _location: Location,private DashboardService:DashboardService,private route: ActivatedRoute, private authService: AuthService,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    // this.userRole.InterSeeviceDesk
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
   // this.memberInfoId =this.authService.currentUserValue.pNo;
   console.log(this.authService.currentUserValue,this.traineeId+"------------");
 //  console.log(this.branchId);
   // console.log(this.role, this.traineeId, this.branchId+"--")
    this.getRequestedBookByMemberInfoId(this.traineeId);
  }
  backClicked() {
    this._location.back();
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });   
  }
  print() {
    let printContents, popupWin;
    printContents = document.getElementById("print-routine").innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
          body{  width: 99%;}
            label { font-weight: 400;
                    font-size: 13px;
                    padding: 2px;
                    margin-bottom: 5px;
                  }
            table, td, th {
                  border: 1px solid silver;
                    }
                    table td {
                  font-size: 13px;
                    }
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-action{
                      display: none;
                    }
        
                    .table.table.tbl-by-group.db-li-s-in tr td{
                      text-align:center;
                      padding: 0px 5px;
                    }
                    table th {
                  font-size: 13px;
                    }
              table {
                    border-collapse: collapse;
                    width: 98%;
                    }
                th {
                    height: 26px;
                    }
                .header-text{
                  text-align:center;
                }
                .header-text h3{
                  margin:0;
                }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Book Information List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  applyFilter(searchText){

  }
  getIssueRequestPopup(row){
    this.popupIssueRequest = true;
    // this.barcodeId = itemStoreId;
    console.log("popup apairs")
    
    this.infoPopUpTitle = "Online Request List";
    // this.requestedmembersList = true;
    // console.log(this.requestedmembersList);
    // console.log("Online Request List");
    // this.issuedBooksList = false;
    this.DashboardService.getOnlineBookRequestListByBookInfo(row.bookInformationId).subscribe(res => {
      console.log("res");
      this.issueRequestUserList = res;
      console.log(this.issueRequestUserList);
    });      
  }

  onButtonClick(number){
    console.log(number);
    this.confirmService.confirm('Confirm Request Cancel Message', 'Are You Sure Cancel This Request?').subscribe(result => {
      console.log(result);
      if (result) {
        if(this.role == this.userRole.Member){
          this.DashboardService.updateIssueOnlineRequestAndCancelStatus(number.onlineBookRequestId,number.bookInformationId).subscribe(response => {
            // this.router.navigateByUrl('/book-management/book-management-tab/bookinformation-list');
            this.reloadCurrentRoute();
             this.snackBar.open('Information Updated Successfully ', '', {
               duration: 2000,
               verticalPosition: 'bottom',
               horizontalPosition: 'right',
               panelClass: 'snackbar-success'
             });
           }, error => {
            // this.validationErrors = error;
           })
        }
        else{
          this.DashboardService.updateRequestAndCancelStatus(number.onlineBookRequestId).subscribe(response => {
            // this.router.navigateByUrl('/book-management/book-management-tab/bookinformation-list');
            this.reloadCurrentRoute();
             this.snackBar.open('Information Updated Successfully ', '', {
               duration: 2000,
               verticalPosition: 'bottom',
               horizontalPosition: 'right',
               panelClass: 'snackbar-success'
             });
           }, error => {
            // this.validationErrors = error;
           })
        }
      }
    })
  }
  getRequestedBookByMemberInfoId(memberInfoId) {
    this.DashboardService.getOnlineBookRequestByMemberId(memberInfoId).subscribe(response => {           
      this.bookList=response.filter(x=> x.cancelStatus==0);

      console.log("booklist");
    console.log(this.bookList);


      this.onlineRequestCount=response.length;

             // this gives an object with dates as keys
             const groups = this.bookList.reduce((groups, datas) => {
              const bookCategoryName = datas.baseSchoolName;
              if (!groups[bookCategoryName]) {
                groups[bookCategoryName] = [];
              }
              groups[bookCategoryName].push(datas);
              return groups;
            }, {});
      
            // Edit: to add it in the array format instead
            this.groupArrays = Object.keys(groups).map((baseSchoolName) => {
              return {
                baseSchoolName,
                datas: groups[baseSchoolName],
              };
            });
            console.log("888");
      console.log(this.bookList);
    })
  }

  getOnlineRequestedBookByBaseSchoolNameIdId(baseSchoolNameId) {
    this.DashboardService.getOnlineBookRequestListByBaseSchoolId(baseSchoolNameId,this.searchText).subscribe(response => {           
      this.onlineBookRequestList=response;

      console.log("booklist");
    console.log(this.bookList);


      this.onlineRequestCount=response.length;

             // this gives an object with dates as keys
             const groups = this.onlineBookRequestList.reduce((groups, datas) => {
              const bookCategoryName = datas.baseSchoolName;
              if (!groups[bookCategoryName]) {
                groups[bookCategoryName] = [];
              }
              groups[bookCategoryName].push(datas);
              return groups;
            }, {});
      
            // Edit: to add it in the array format instead
            this.groupArrays = Object.keys(groups).map((baseSchoolName) => {
              return {
                baseSchoolName,
                datas: groups[baseSchoolName],
              };
            });
            console.log("888");
      console.log(this.bookList);
    })
  }
}
