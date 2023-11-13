import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BookIssueAndSubmission} from '../../../book-management/models/BookIssueAndSubmission';
import {BookIssueAndSubmissionService} from '../../../book-management/service/BookIssueAndSubmission.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DashboardService } from '../service/Dashboard.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import {MemberInfoService} from '../../../../app/member-management/service/MemberInfo.service'
import {Location} from '@angular/common';


@Component({
  selector: 'app-view-bookIssueandsubmission-list',
  templateUrl: './view-bookIssueandsubmission-list.component.html',
  styleUrls: ['./view-bookIssueandsubmission-list.component.sass']
})
export class ViewBookIssueandSubmissionListComponent 
implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: BookIssueAndSubmission[] = [];
  isLoading = false;
  groupArrays: { pno: string; datas: any }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  showHideDiv:any;
  searchText="";
  userRole = Role;
  getUserDataRow:any;
  firstUserData:any;
  IssueListByUser:any[];
  IssueListByUserLength:any;
  bookIssueList:any;
  role:any;
  branchId:any;
  pno:any;
  userInfoPopup=false;

  memberInfoId: any;
  bookInformationId: any;
  baseSchoolNameId: any;
  memberCategoryId: any;
  rankId: any;
  designationId: any;
  jobStatusId: any;
  areaId: any;
  baseId: any;
  securityQuestionId: any;
  answer: any;
  memberInfoIdentity: any;
  email: any;
  imageUrl: any;
  region: any;
  director: any;
  memberName: any;
  fatherName: any;
  motherName: any;
  yearlyFee: any;
  presentAddress: any;
  permanentAddress:any;
  nid: any;
  sex: any;
  issueDate: any;
  expireDate:any;
  dob: any;
  department: any;
  tntOffice: any;
  mobileNoOffice: any;
  familyContact: any;
  mobileNoPersonal: any;
  empStatus: any;
  menuPosition: any;
  isActive: any;
  issueQty: any;
  lastPaymentDate: any;
  memberCategory:any; 
  rank: any;
  designation: any;
  jobStatus: any

  displayedColumns: string[] = [ 'sl','pno','accessionNo','bookTitle','issueDate','returnDate','due', 'actions'];
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();

  selection = new SelectionModel<BookIssueAndSubmission>(true, []);

  
  constructor(private snackBar: MatSnackBar,private _location: Location,private MemberInfoService: MemberInfoService,private authService: AuthService,private dashboardService: DashboardService,private BookIssueAndSubmissionService:BookIssueAndSubmissionService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
  this.role = this.authService.currentUserValue.role.trim();
  this.pno =  this.authService.currentUserValue.traineeId.trim();
  this.branchId =  this.authService.currentUserValue.branchId.trim();
  console.log(this.role, this.pno, this.branchId)
  this.getBookIssueAndSubmissions();
  }
  backClicked() {
    this._location.back();
  }
  getBookIssueAndSubmissions() {
    this.isLoading = true;
    this.dashboardService.getBookIssueAndSubmissionListSpRequest(this.branchId == null ? 1 :this.branchId,this.searchText).subscribe(response => {     
      this.dataSource.data = response;

      this.firstUserData = this.dataSource.data[0].memberInfoId;
      console.log(this.firstUserData);
    //  this.paging.length = response.totalItemsCount    
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
          <h3>Book Issued List</h3>
          
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
  //  this.getBookIssueAndSubmissions();
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
   this.getBookIssueAndSubmissions();
    console.log(this.searchText);
    // if(this.searchText !=''){
    //   console.log("value");
    //   this.getUserDataRow = 1;
    //   this.getDataByUserAfterSearch();
    // }else{
    //   console.log("not value");
    //   this.getUserDataRow = 0;
    // }
  } 

  returnItem(row){
    const id = row.bookIssueAndSubmissionId; 
    console.log("return "+id);
    
    this.confirmService.confirm('Confirm Return message', 'Are You Sure Return This Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookIssueAndSubmissionService.returnBookIssueAndSubmission(id,1).subscribe(() => {
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

  getUserInfoPopup(value){
   // console.log("sssssss");
    //console.log(value[0].memberInfoId)
    var memberInfoId=value[0].memberInfoId
    this.userInfoPopup = true;

    this.MemberInfoService.find(+memberInfoId).subscribe( res => {
      console.log(res);
      this.memberName= res.memberName;
      this.email= res.email;
      this.fatherName= res.fatherName;
      this.motherName= res.motherName;
      this.presentAddress= res.presentAddress;
      this.permanentAddress=res.permanentAddress;
      this.nid= res.nid;
      this.sex= res.sex;
      this.issueDate= res.issueDate;
      this.expireDate=res.expireDate;
      this.dob= res.dob;
      this.pno= res.pno;
      this.department= res.department;
      this.tntOffice= res.tntOffice;
      this.mobileNoOffice= res.mobileNoOffice;
      this.familyContact= res.familyContact;
      this.mobileNoPersonal= res.mobileNoPersonal;
      this.region= res.region;
      this.director= res.director;
      this.yearlyFee= res.yearlyFee;
      this.isActive= res.isActive;
      this.issueQty= res.issueQty;
      this.lastPaymentDate= res.lastPaymentDate;
      this.memberCategory=res.memberCategory;
      this.rank= res.rank;
      this.designation= res.designation;
      this.jobStatus= res.jobStatus
      this.memberInfoId = res.memberInfoId;
      this.bookInformationId = res.bookInformationId;
      this.baseSchoolNameId= res.baseSchoolNameId;
      this.memberInfoIdentity= res.memberInfoIdentity;
      this.imageUrl= res.imageUrl;  
    })

  }

}
