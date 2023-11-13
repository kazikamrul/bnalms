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
import { BaseSchoolNameService } from 'src/app/security/service/BaseSchoolName.service';
import { BookInformationService } from 'src/app/book-management/book-management-tab/service/BookInformation.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-onlinebookrequest',
  templateUrl: './onlinebookrequest.component.html',
  styleUrls: ['./onlinebookrequest.component.sass']
})
export class OnlineBookRequestComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  bookList:any;
  showHideDiv:any;
  userInfoPopup=false;
  issuedUserInfo:any;
  onlineRequestCount:any;
  groupArrays: { bookTitleName: string;datas: any }[];
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
  libraryName:any;
  schoolLogo:any;
  loggedUserRole:any;
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

  
  constructor(private datepipe: DatePipe,private _location: Location,private BookInformationService: BookInformationService,private DashboardService:DashboardService, private baseSchoolNameService: BaseSchoolNameService,private route: ActivatedRoute, private authService: AuthService,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    // this.userRole.InterSeeviceDesk
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
   console.log(this.branchId,this.traineeId+"------------");


    this.getRequestedBookByMemberInfoId(this.branchId == null ? 1 :this.branchId,this.searchText);

    if(this.loggedUserRole != this.userRole.SuperAdmin  && this.loggedUserRole != this.userRole.Member){
      this.baseSchoolNameService.find(this.branchId).subscribe(res=>{
        console.log(res)
        this.libraryName = res.schoolName;
        this.schoolLogo =res.schoolLogo;
        console.log(this.libraryName+ "_"+ this.schoolLogo)
        console.log("Find School Name")
      });
    }
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
  getUserInfoPopup(value){
    console.log(value)
    this.userInfoPopup = true;
    // this.barcodeId = value;
    this.BookInformationService.getBookIssueInfoByUser(value).subscribe(response => {
      this.issuedUserInfo=response;
      // console.log("book information");
      console.log(response)
    })
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
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-mrk-rmrk-act-r{
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
          <h3>${this.libraryName}</h3>
          <h3>Online Requested Book List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  applyFilter(searchText){
    // console.log(searchText)
    this.searchText = searchText;

    this.getRequestedBookByMemberInfoId(this.branchId == null ? 1 :this.branchId,this.searchText);
  }
  IssuedForMember(number){
    console.log(number);
    this.confirmService.confirm('Confirm Issue Message', 'Are You Sure Issue This?').subscribe(result => {
      console.log(result);
      if (result) {
        this.DashboardService.saveBookIssueAndSubmission(number).subscribe(response => {
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
    })
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
  getRequestedBookByMemberInfoId(baseSchoolNameId,searchText) {
    this.DashboardService.getOnlineBookRequestListByBaseSchoolId(baseSchoolNameId,searchText).subscribe(response => {           
      this.bookList=response;

      console.log("booklist##");
    console.log(this.bookList);


      this.onlineRequestCount=response.length;

             // this gives an object with dates as keys
             const groups = this.bookList.reduce((groups, datas) => {
              const bookCategoryName = datas.accessionNo+" - "+datas.bookTitleName+" "+datas.titleBangla;
              if (!groups[bookCategoryName]) { 
                groups[bookCategoryName] = [];
              }
              groups[bookCategoryName].push(datas);
              return groups;
            }, {});
      
            // Edit: to add it in the array format instead
            this.groupArrays = Object.keys(groups).map((bookTitleName) => {
              return {
                bookTitleName,
                datas: groups[bookTitleName],
              };
            });
            console.log("888");
      console.log(this.groupArrays);
    })
  }
}
