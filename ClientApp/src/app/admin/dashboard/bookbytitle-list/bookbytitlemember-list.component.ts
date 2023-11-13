import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
//import {BookIssueAndSubmission} from '../models/BookIssueAndSubmission';
import {BookIssueAndSubmission} from '../../../../app/book-management/models/BookIssueAndSubmission';
import { BookIssueAndSubmissionService } from 'src/app/book-management/service/BookIssueAndSubmission.service';
// import {BookIssueAndSubmissionService} from '../service/BookIssueAndSubmission.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DamageInformationByLibraryService } from 'src/app/book-management/service/DamageInformationByLibrary.service';
// import {DamageInformationByLibraryService} from '../service/DamageInformationByLibrary.service'
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { BookInformationService } from 'src/app/book-management/book-management-tab/service/BookInformation.service';
import { DashboardService } from '../service/Dashboard.service';
import { ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-bookbytitlemember-list',
  templateUrl: './bookbytitlemember-list.component.html',
  styleUrls: ['./bookbytitlemember-list.component.sass']
})
export class BookByTitleMemberListComponent implements OnInit {
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
  departmentName:any;
  deptId:any;
  bookTitleInfoId:any;

  displayedColumns: string[] = [ 'sl','accessionNo','pno','bookTitle', 'actions'];
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();

  selection = new SelectionModel<BookIssueAndSubmission>(true, []);

  
  constructor(private snackBar: MatSnackBar,private router: Router,private DashboardService:DashboardService,private BookInformationService:BookInformationService,private datepipe: DatePipe,private authService: AuthService,private fb: FormBuilder,private DamageInformationByLibraryService:DamageInformationByLibraryService,private BookIssueAndSubmissionService:BookIssueAndSubmissionService,private confirmService: ConfirmService, private route: ActivatedRoute) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId)

    this.bookTitleInfoId = this.route.snapshot.paramMap.get('bookTitleInfoId'); 

    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);

    this.getselectedBookCategory();
    this.getBookListByTitle();
  }
  
  GetDepartmentNameById(baseNameId){    
    this.BookInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }

  getselectedBookCategory(){
    this.DamageInformationByLibraryService.getselectedBookCategory().subscribe(res=>{
      this.selectedBookCategory=res
    });
  }
  // applyFilter(bookCatId,deptId,searchText:any){ 
  //   this.bookCatId = bookCatId;
  //   this.deptId =deptId;
  //   this.searchText = searchText;
  //   this.getBookListByTitle();
  //   console.log("eeeeeeeeeee");
  //   console.log(this.bookCatId)
  //   console.log(this.deptId)
  //   console.log(this.searchText)
  //   console.log("tttttttttttt");
  // } 
  applyFilter(searchText: any){ 
    // this.bookCatId=bookCatId;
    // this.deptId=deptId;
    this.searchText = searchText;
    console.log(this.searchText)
     console.log("tttttttttttt");
    this.getBookListByTitle();
  } 
  // getBookListByTitle(){
  //   // bookCatId == null ? 0 : bookCatId
  //    this.DashboardService.getBookListGroupByTitle(this.searchText).subscribe(res=>{
  //      this.BookByTitleList=res 
  //      console.log("okk1");
  //      console.log(this.role, this.traineeId, this.branchId)
  //      console.log(this.BookByTitleList);  
  //      console.log("okk");
  //    });
  //  }

  getBookListByTitle(){
    this.DashboardService.getBookListGroupByTitle(this.searchText).subscribe(res=>{
      this.BookByTitleList=res 
      console.log("okk");
      console.log(this.role, this.traineeId, this.branchId)
      console.log("okk11");
      console.log(this.BookByTitleList);  
      console.log("okk222");
    });
  }

  // getBookListByTitle(){
  //   this.DashboardService.getBookListGroupByTitle(this.deptId == null ? 0:this.deptId,this.searchText,this.bookCatId == null ? 0:this.bookCatId).subscribe(res=>{
  //     this.BookByTitleList=res 
  //     console.log("okk");
  //     console.log(this.role, this.traineeId, this.branchId)
  //     console.log("okk11");
  //     console.log(this.BookByTitleList);  
  //     console.log("okk222");
  //   });
  // }
  
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
