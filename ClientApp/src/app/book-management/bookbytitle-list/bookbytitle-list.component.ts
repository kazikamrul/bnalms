import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BookIssueAndSubmission} from '../models/BookIssueAndSubmission';
import {BookIssueAndSubmissionService} from '../service/BookIssueAndSubmission.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import {DamageInformationByLibraryService} from '../service/DamageInformationByLibrary.service'
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-bookbytitle-list',
  templateUrl: './bookbytitle-list.component.html',
  styleUrls: ['./bookbytitle-list.component.sass']
})
export class BookByTitleListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: BookIssueAndSubmission[] = [];
  isLoading = false;
  showHideDiv:any;
  BookByTitleList:any;
  bookCatId:any;
  selectedBookCategory:any;
  BookByTitleDetailList:any;
  userInfoPopup=false;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  role:any;
  traineeId:any;
  branchId:any;

  DamageForm: FormGroup;
  dateFrom:any;
  dateTo:any;
  checkdateFrom:any;
  checkdateTo:any;
  damageByBorrowerByDateRange:any;

  displayedColumns: string[] = [ 'sl','accessionNo','pno','bookTitle', 'actions'];
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();

  selection = new SelectionModel<BookIssueAndSubmission>(true, []);

  
  constructor(private snackBar: MatSnackBar,private datepipe: DatePipe,private authService: AuthService,private fb: FormBuilder,private DamageInformationByLibraryService:DamageInformationByLibraryService,private BookIssueAndSubmissionService:BookIssueAndSubmissionService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId)

    this.getselectedBookCategory();
    this.getBookListByTitle(0);
  }
  
  getselectedBookCategory(){
    this.DamageInformationByLibraryService.getselectedBookCategory().subscribe(res=>{
      this.selectedBookCategory=res
    });
  }
  applyFilter(bookCatId){ 
    this.bookCatId = bookCatId;
    console.log(this.bookCatId)
   this.getBookListByTitle(this.bookCatId);
  } 
  getBookListByTitle(bookCatId){
    this.DamageInformationByLibraryService.getBookListByTitle(this.branchId,bookCatId).subscribe(res=>{
      this.BookByTitleList=res 

      console.log("okk");
      console.log(this.role, this.traineeId, this.branchId)
      console.log(this.BookByTitleList);  
    });
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
          <h3>Damaged by Member List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
 
  getBookBindingInfoPopup(value){
    console.log(value)
    this.userInfoPopup = true;
    this.DamageInformationByLibraryService.getBookDetailByTitle(this.branchId,value).subscribe(res=>{
      this.BookByTitleDetailList=res;
      console.log(this.BookByTitleDetailList);  
    });
  }
}
