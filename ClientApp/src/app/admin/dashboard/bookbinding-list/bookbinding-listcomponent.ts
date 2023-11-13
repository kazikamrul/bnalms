import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { BookBindingInfoService } from 'src/app/book-management/service/BookBindingInfo.service';
//import { InterServiceDashboardService } from '../services/InterServiceDashboard.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/core/models/role';
import { DashboardService } from '../service/Dashboard.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-bookbinding-list',
  templateUrl: './bookbinding-list.component.html',
  styleUrls: ['./bookbinding-list.component.sass']
})
export class BookBindingListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  bookList:any;
  showHideDiv:any;
  onlineRequestCount:any;
  groupArrays: { bookTitleName: string;datas: any }[];
  onlineBookRequestList:any
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

  
  constructor(private datepipe: DatePipe,private BookBindingInfoService: BookBindingInfoService,private _location: Location,private DashboardService:DashboardService,private route: ActivatedRoute, private authService: AuthService,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    // this.userRole.InterSeeviceDesk
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
   console.log(this.branchId,this.traineeId+"------------");

    this.getBooBindingList(this.branchId == null ? 1 :this.branchId);
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
          <h3>Book Binding List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  applyFilter(searchText){
  this.searchText =searchText;
  console.log(this.searchText);
  this.getBooBindingList(this.branchId == null ? 1 :this.branchId);
  }
  // onButtonClick(number){
  //   console.log(number);
  //   this.confirmService.confirm('Confirm Request Cancel Message', 'Are You Sure Cancel This Request?').subscribe(result => {
  //     console.log(result);
  //     if (result) {
  //       if(this.role == this.userRole.Member){
  //         this.DashboardService.updateIssueOnlineRequestAndCancelStatus(number.onlineBookRequestId,number.bookInformationId).subscribe(response => {
  //           this.reloadCurrentRoute();
  //            this.snackBar.open('Information Updated Successfully ', '', {
  //              duration: 2000,
  //              verticalPosition: 'bottom',
  //              horizontalPosition: 'right',
  //              panelClass: 'snackbar-success'
  //            });
  //          }, error => {
  //          })
  //       }
  //       else{
  //         this.DashboardService.updateRequestAndCancelStatus(number.onlineBookRequestId).subscribe(response => {
  //           this.reloadCurrentRoute();
  //            this.snackBar.open('Information Updated Successfully ', '', {
  //              duration: 2000,
  //              verticalPosition: 'bottom',
  //              horizontalPosition: 'right',
  //              panelClass: 'snackbar-success'
  //            });
  //          }, error => {
  //          })
  //       }
  //     }
  //   })
  // }
  getBooBindingList(baseSchoolNameId) {
    this.DashboardService.getBooBindingList(baseSchoolNameId,this.searchText).subscribe(response => {           
      this.bookList=response;

      console.log("booklist");
    console.log(this.bookList);


      // this.onlineRequestCount=response.length;

      //        // this gives an object with dates as keys
      //        const groups = this.bookList.reduce((groups, datas) => {
      //         const bookCategoryName = datas.bookTitleName+" "+datas.titleBangla;
      //         if (!groups[bookCategoryName]) { 
      //           groups[bookCategoryName] = [];
      //         }
      //         groups[bookCategoryName].push(datas);
      //         return groups;
      //       }, {});
      
      //       // Edit: to add it in the array format instead
      //       this.groupArrays = Object.keys(groups).map((bookTitleName) => {
      //         return {
      //           bookTitleName,
      //           datas: groups[bookTitleName],
      //         };
      //       });
            console.log("888");
      console.log(this.groupArrays);
    })
  }
  returnItem(bookInformationId){
    // const id = row.bookInformationId; 
     console.log("row");
     console.log(bookInformationId);
     
     this.confirmService.confirm('Confirm Return message', 'Are You Sure Return This Item?').subscribe(result => {
       console.log(result);
       if (result) { 
         this.BookBindingInfoService.returnBookBindingInfo(bookInformationId).subscribe(() => {
          this.getBooBindingList(this.branchId == null ? 1 :this.branchId);
           this.snackBar.open('Information Returned Successfully ', '', {
             duration: 2000,
             verticalPosition: 'bottom',
             horizontalPosition: 'right',
             panelClass: 'snackbar-success'
           });
         })
       }
     })
   }
}
