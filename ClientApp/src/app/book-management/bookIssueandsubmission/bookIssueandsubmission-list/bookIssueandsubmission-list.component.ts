import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BookIssueAndSubmission} from '../../models/BookIssueAndSubmission';
import {BookIssueAndSubmissionService} from '../../service/BookIssueAndSubmission.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-bookIssueandsubmission-list',
  templateUrl: './bookIssueandsubmission-list.component.html',
  styleUrls: ['./bookIssueandsubmission-list.component.sass']
})
export class BookIssueAndSubmissionListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: BookIssueAndSubmission[] = [];
  isLoading = false;
  groupArrays: { pno: string; datas: any }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  showHideDiv:any;
  userRole = Role;
  getUserDataRow:any;
  firstUserData:any;
  IssueListByUser:any[];
  IssueListByUserLength:any;
  role:any;
  branchId:any;
  pno:any;

  displayedColumns: string[] = [ 'sl','pno','accessionNo','bookTitle','issueDate','returnDate','due', 'actions'];
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();

  selection = new SelectionModel<BookIssueAndSubmission>(true, []);

  
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private BookIssueAndSubmissionService:BookIssueAndSubmissionService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.pno =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.pno, this.branchId)

    this.getBookIssueAndSubmissions();
  }
  
  getBookIssueAndSubmissions() {
    this.isLoading = true;
    this.BookIssueAndSubmissionService.getBookIssueAndSubmissionsByUser(this.paging.pageIndex, 100000,this.searchText,this.branchId).subscribe(response => {     
      this.dataSource.data = response.items;

      this.firstUserData = this.dataSource.data[0].memberInfoId;
      console.log(this.firstUserData);
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      console.log("dtaa source")
      console.log(this.dataSource.data.length);

      // this gives an object with dates as keys
      const groups = this.dataSource.data.reduce((groups, datas) => {
        const pno = datas.pno;
        if (!groups[pno]) {
          groups[pno] = [];
        }
        groups[pno].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((pno) => {
        return {
          pno,
          datas: groups[pno],
        };
      });

      console.log(this.groupArrays);

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
                  
                    .table.table.tbl-by-group.db-li-s-in tr .thbm{
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
       
          <h3>Issued List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  getDueDays(returnDate){
    if(returnDate != null){
      let currentDate = new Date();
    returnDate = new Date(returnDate);

    return Math.floor((Date.UTC(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate()) - Date.UTC(returnDate.getFullYear(), returnDate.getMonth(), returnDate.getDate()) ) /(1000 * 60 * 60 * 24));
    }
    
  }
 
  getDataByUserAfterSearch(){
    this.BookIssueAndSubmissionService.BookIssueListByUser(this.firstUserData).subscribe(response => {
      console.log(response);
      this.IssueListByUser = response;
      this.IssueListByUserLength = response.length;
      console.log(this.IssueListByUserLength)
    });
  }

  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBookIssueAndSubmissions();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBookIssueAndSubmissions();
    console.log(this.searchText);
    if(this.searchText !=''){
      console.log("value");
      this.getUserDataRow = 1;
      this.getDataByUserAfterSearch();
    }else{
      console.log("not value");
      this.getUserDataRow = 0;
    }
  } 

  returnItem(row){
    const id = row.bookIssueAndSubmissionId; 
    console.log("return "+id);
    

    this.confirmService.confirm('Confirm Return message', 'Are You Sure Return This Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookIssueAndSubmissionService.returnBookIssueAndSubmission(id,1).subscribe(() => {
          this.getBookIssueAndSubmissions();
          this.reloadCurrentRoute();
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
  damageReturnItem(row){
    const id = row.bookIssueAndSubmissionId; 
    console.log("damage return "+id);

    this.confirmService.confirm('Confirm Damage Return message', 'Are You Sure Damage Return This Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookIssueAndSubmissionService.returnBookIssueAndSubmission(id,2).subscribe(() => {
          this.getBookIssueAndSubmissions();
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
  deleteItem(row) {
    const id = row.bookIssueAndSubmissionId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookIssueAndSubmissionService.delete(id).subscribe(() => {
          this.getBookIssueAndSubmissions();
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
