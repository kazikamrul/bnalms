import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {BookIssueAndSubmission} from '../../models/BookIssueAndSubmission';
import {BookIssueAndSubmissionService} from '../../service/BookIssueAndSubmission.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router, RoutesRecognized } from '@angular/router';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import {DamageInformationByLibraryService} from '../../service/DamageInformationByLibrary.service'
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { DatePipe } from '@angular/common';
import { BaseSchoolNameService } from 'src/app/security/service/BaseSchoolName.service';
import { filter, pairwise } from 'rxjs/operators';

@Component({
  selector: 'app-damaged-list',
  templateUrl: './damaged-list.component.html',
  styleUrls: ['./damaged-list.component.sass']
})
export class DamagedListComponent implements OnInit {
  masterData = MasterData;
  ELEMENT_DATA: BookIssueAndSubmission[] = [];
  isLoading = false;
  showHideDiv:any;
  damageByBorrowerList:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  role:any;
  branchId:any;
  DamageForm: FormGroup;
  dateFrom:any;
  dateTo:any;
  checkdateFrom:any;
  checkdateTo:any;
  damageByBorrowerByDateRange:any;
  libraryName:any;

  displayedColumns: string[] = [ 'sl','accessionNo','pno','bookTitle', 'actions'];
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();

  selection = new SelectionModel<BookIssueAndSubmission>(true, []);

  
  constructor(private snackBar: MatSnackBar, private baseSchoolNameService: BaseSchoolNameService,private datepipe: DatePipe,private authService: AuthService,private fb: FormBuilder,private DamageInformationByLibraryService:DamageInformationByLibraryService,private BookIssueAndSubmissionService:BookIssueAndSubmissionService,private router: Router,private confirmService: ConfirmService) { 
    this.router.events.pipe(filter((evt: any) => evt instanceof RoutesRecognized), pairwise()).subscribe((events: RoutesRecognized[]) => {
      console.log('previous url', events[0].urlAfterRedirects);
      // this.previousUrl = events[0].urlAfterRedirects;
      console.log('current url', events[1].urlAfterRedirects);
    }); 
  }
  
  ngOnInit() {
    
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();

    this.intitializeForm();
    this.DamageForm.get('dateFrom').setValue(new Date);
    this.DamageForm.get('dateTo').setValue(new Date);
    this.getDamageInformationByBorrower();

    if(this.role == Role.Admin){
      this.baseSchoolNameService.find(this.branchId).subscribe(res=>{
        this.libraryName = res.schoolName;
      });
    }
    
  }
  
  intitializeForm() {
    this.DamageForm = this.fb.group({
      dateFrom: [''],
      dateTo:['']
    })
  }
  getDamageInformationByBorrower(){
    this.DamageInformationByLibraryService.getDamageInformationByBorrower(this.branchId,this.searchText).subscribe(res=>{
      this.damageByBorrowerList=res 
      console.log("ajaja");
      console.log(this.damageByBorrowerList);  
    });
}
getDamageByBorrowerByDateRange(){
  this.DamageInformationByLibraryService.getDamageByBorrowerByDateRange(this.checkdateFrom,this.checkdateTo,this.branchId).subscribe(res=>{
    this.damageByBorrowerList=res 
    console.log("ajaja");
    console.log(this.damageByBorrowerByDateRange);  
  });
}
onSubmit(){
  this.dateFrom=this.DamageForm.value['dateFrom'];
  this.dateTo=this.DamageForm.value['dateTo'];
  
  let newDateFrom = new Date(this.dateFrom);
  let newDateTo = new Date(this.dateTo);
  
  this.checkdateFrom = this.datepipe.transform((newDateFrom), 'MM/dd/yyyy');
  this.checkdateTo = this.datepipe.transform((newDateTo), 'MM/dd/yyyy');
  this.getDamageByBorrowerByDateRange();
  
}
  getDamagedByBorrowersListByIsDamaged() {
    this.isLoading = true;
    this.BookIssueAndSubmissionService.getBookIssueAndSubmissionsListByIsDamaged(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
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
          <h3>${this.libraryName}</h3>
          <h3>Damaged by Member List</h3>
          
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
    this.getDamagedByBorrowersListByIsDamaged();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
   // this.getDamagedByBorrowersListByIsDamaged();
   this.getDamageInformationByBorrower();
  } 
  deleteItem(row) {
    const id = row.bookIssueAndSubmissionId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookIssueAndSubmissionService.delete(id).subscribe(() => {
          this.getDamagedByBorrowersListByIsDamaged();
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
