import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BookBindingInfo} from '../../models/BookBindingInfo';
import {BookBindingInfoService} from '../../service/BookBindingInfo.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-bookbindinginfo-list',
  templateUrl: './bookbindinginfo-list.component.html',
  styleUrls: ['./bookbindinginfo-list.component.sass']
})
export class BookBindingInfoListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: BookBindingInfo[] = [];
  isLoading = false;
  bookBindingList:any[];
  branchId:any;
  deptId:any;
  role:any;
  showHideDiv:any;
  userRole = Role;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  accessionNo: any;
  bookTitleEnglish: any;
  bookTitleBangla: any;
  date: any;
  pressName: any;
  pressNumber:any;
  pressEmail: any;
  pressAddress: any;
  senderOfficer: any;
  officeDispiseNumber: any;
  category:any;


  userInfoPopup=false;
  displayedColumns: string[] = [ 'sl','accessionNo','category','bookTitleEnglish','pressName','pressAddress','pressEmail','senderOfficer', 'actions'];
  dataSource: MatTableDataSource<BookBindingInfo> = new MatTableDataSource();

  selection = new SelectionModel<BookBindingInfo>(true, []);

  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private BookBindingInfoService:BookBindingInfoService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)
    this.getBookBindingInfos();
    this.getBookBindingInfoList();
  }
  
  getBookBindingInfos() {
    this.isLoading = true;
    this.BookBindingInfoService.getBookBindingInfos(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
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
          this.getBookBindingInfoList();
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

  getBookBindingInfoPopup(value){
    console.log(value)
    this.userInfoPopup = true;
    // this.barcodeId = value;
    this.BookBindingInfoService.find(value).subscribe(response => {
      this.accessionNo= response.accessionNo;
      this.bookTitleEnglish= response.bookTitleEnglish;
      this.bookTitleBangla= response.bookTitleBangla;
      this.date= response.date;
      this.pressName= response.pressName;
      this.pressNumber=response.pressNumber;
      this.pressEmail= response.pressEmail;
      this.pressAddress= response.pressAddress;
      this.senderOfficer= response.senderOfficer;
      this.officeDispiseNumber= response.officeDispiseNumber;
      this.category =response.category;
      // this.issuedUserInfo=response;
      //  console.log("book information");
      // console.log(response)
    })
  }

  getBookBindingInfoList(){
    this.BookBindingInfoService.getBookBindingInfoListByBaseSchoolNameId(this.branchId == null ? 1 :this.branchId,this.searchText).subscribe(response => {
      this.bookBindingList=response;
      console.log("book information");
      console.log(this.bookBindingList)
      console.log("this. dept id");
      console.log(this.deptId);

      //  // this gives an object with dates as keys
      //  const groups = this.bookInformationListSearch.reduce((groups, datas) => {
      //   const bookCategoryName = datas.bookCategoryName;
      //   if (!groups[bookCategoryName]) {
      //     groups[bookCategoryName] = [];
      //   }
      //   groups[bookCategoryName].push(datas);
      //   return groups;
      // }, {});

      // // Edit: to add it in the array format instead
      // this.groupArrays = Object.keys(groups).map((bookCategoryName) => {
      //   return {
      //     bookCategoryName,
      //     datas: groups[bookCategoryName],
      //   };
      // });
      // console.log("group array");
      // console.log(this.groupArrays);
    })
}
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.filteredData.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected()
      ? this.selection.clear()
      : this.dataSource.filteredData.forEach((row) =>
          this.selection.select(row)
        );
  }
  addNew(){
    
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
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
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-mrk-rmrk-act{
                      display: none;
                    }
                    .table.table.tbl-by-group.db-li-s-in tr .cl-itemnames{
                      display: none;
                    }

                    .table.table.tbl-by-group.db-li-s-in tr .cl-trade{
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
          <h3>Book Binding Information List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBookBindingInfos();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBookBindingInfoList();
    this.getBookBindingInfos();
  } 
  deleteItem(row) {
    const id = row.bookBindingInfoId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookBindingInfoService.delete(id).subscribe(() => {
          this.getBookBindingInfoList();
          this.getBookBindingInfos();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });

        })
      }
      
    })
    
  }
}
