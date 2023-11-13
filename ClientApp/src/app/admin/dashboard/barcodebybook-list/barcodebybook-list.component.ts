import { Component, OnInit } from '@angular/core';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BookInformation } from 'src/app/book-management/book-management-tab/models/BookInformation';
import { BookInformationService } from 'src/app/book-management/book-management-tab/service/BookInformation.service';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MasterData } from 'src/assets/data/master-data';
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthorInformationService } from 'src/app/book-management/book-management-tab/service/AuthorInformation.service';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/core/service/auth.service';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { throwError, of, catchError } from 'rxjs';
import { Role } from 'src/app/core/models/role';
import { DashboardService } from '../service/Dashboard.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-barcodebybook-list',
  templateUrl: './barcodebybook-list.component.html',
  styleUrls: ['./barcodebybook-list.component.sass']
})
export class BarcodeByBookListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  ELEMENT_DATA: BookInformation[] = [];
  isLoading = false;
  groupArrays: { bookCategoryName: string; datas: any }[];
  BookInformationForm: FormGroup;
  bookInformationList: any[];
  deleteResponse: any;
  bookInformationListSearch:any[];
  fileUrl= '/content/';
  validationErrors: string[] = [];
  bookCategoryId:any;
  bookCatId:any;
  departmentName:any;
  role:any;
  branchId:any;
  deptId:any;
  showHideDiv:any;
  selectedBookCategory:any;
  isExist:boolean;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  barcodePopup =false;
  message=false;
  showHideDivBarcode =false;
  barcodeId:any;
  pno:any;
  issuedUserInfo:any;
  userInfoPopup=false;

  displayedColumns: string[] = [ 'sl','bookCategoryName','accessionNo','bookTitleName','mainClass','authorName','publishersName','coverImage', 'actions'];
  dataSource: MatTableDataSource<BookInformation> = new MatTableDataSource();

  selection = new SelectionModel<BookInformation>(true, []);

  
  constructor(private snackBar: MatSnackBar, private _location: Location,private http: HttpClient,private authService: AuthService,private fb: FormBuilder,private AuthorInformationService:AuthorInformationService,private DashboardService:DashboardService,private BookInformationService:BookInformationService,private router: Router,private confirmService: ConfirmService) { }
  
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.pno =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.pno, this.branchId)

    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);    
    this.intitializeForm();

    //if(this.role != this.userRole.Member){
      this.getBookInformationList();
   // }

    this.getselectedBookCategory();

  }
  backClicked() {
    this._location.back();
  }
  intitializeForm() {
    this.BookInformationForm = this.fb.group({
      bookInformationId: [],
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.BookInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  getselectedBookCategory(){
    this.BookInformationService.getselectedBookCategory().subscribe(res=>{
      this.selectedBookCategory=res
    });
  }

  getBookInformations() {
    this.isLoading = true;
    this.BookInformationService.getBookInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      console.log("Data Source");
      console.log(this.dataSource.data);

       //this gives an object with dates as keys
      //  const groups = this.dataSource.data.reduce((groups, datas) => {
      //   const bookCategory = datas.bookCategory;
      //   if (!groups[bookCategory]) {
      //     groups[bookCategory] = [];
      //   }
      //   groups[bookCategory].push(datas);
      //   return groups;
      // }, {});

      // // Edit: to add it in the array format instead
      // this.groupArrays = Object.keys(groups).map((bookCategory) => {
      //   return {
      //     bookCategory,
      //     datas: groups[bookCategory],
      //   };
      // });

      // console.log(this.groupArrays);11 findArr.unitId == null ? 0 : findArr.unitId
    })
  }
  getBookInformationList(){
        this.BookInformationService.getBookInfoListByBaseSchoolNameId(this.branchId == null ? 1 :this.branchId,this.searchText,this.bookCatId == null ? 0 :this.bookCatId,this.paging.pageSize,this.paging.pageIndex).subscribe(response => {
          this.bookInformationListSearch=response;
          console.log("book information");
          console.log(this.bookInformationListSearch)
          console.log("this. dept id");
          console.log(this.deptId);
    
           // this gives an object with dates as keys
           const groups = this.bookInformationListSearch.reduce((groups, datas) => {
            const bookCategoryName = datas.bookCategoryName;
            if (!groups[bookCategoryName]) {
              groups[bookCategoryName] = [];
            }
            groups[bookCategoryName].push(datas);
            return groups;
          }, {});
    
          // Edit: to add it in the array format instead
          this.groupArrays = Object.keys(groups).map((bookCategoryName) => {
            return {
              bookCategoryName,
              datas: groups[bookCategoryName],
            };
          });
          console.log("group array");
          console.log(this.groupArrays);
        })
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
            body{  
              width: 99%;
            }
            label { 
              font-weight: 400;
              font-size: 13px;
              padding: 2px;
              margin-bottom: 5px;
            }
            .barcode-float .barcode-inner {
              border: 1px solid;
              text-align: center;
            }
            .barcode-float .barcode-inner .line {
              margin: 0;
            }
            .row.barcode-float .col-lg-2 {
              width: 19%;
              float:left;
              padding: 5px 3px;
            }
            .barcode-float .barcode-inner svg {
              width: 125px;
              height: 90px;
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
          <h3>Book Barcode List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onCategorySelectionChange(event){
    this.bookCategoryId=event;
    console.log(this.bookCategoryId);
    this.getBookInformationList();
  }
  onItemNameSelectionChange(){
   var bookInformationId= this.BookInformationForm.value['bookInformationId'];
   console.log(bookInformationId);
  this.AuthorInformationService.find(bookInformationId).subscribe((res) => {
       });
     
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
 
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBookInformationList();
  }

  applyFilter(searchText: any, deptId,bookCatId){ 
    this.searchText = searchText;
    this.branchId = deptId;
    this.bookCatId = bookCatId;
    console.log(this.searchText,this.deptId,this.bookCatId)
   this.getBookInformationList();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }

  deleteItem(row) {
    const id = row.bookInformationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
      this.BookInformationService.delete(id).subscribe(response => {
      
      console.log("response");
      this.deleteResponse=response;
      console.log(response)
      if(this.deleteResponse.id === 5){
        console.log("error");
        this.router.navigateByUrl('/book-management/book-management-tab/errorpagehandler');
      }
      else{
        this.reloadCurrentRoute();
        this.snackBar.open('Information Delete Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
      }
    }, error => {
      this.validationErrors = error;
    })
  }
}, )
  }

  onlineBookRequest(value,data){
    // console.log(data);
    // console.log(value)
    console.log("memberInfoId"+this.pno+"- "+"bookInformationId"+data.bookInformationId+" - "+"requestStatus"+data.requestStatus+"- "+"cancelStatus"+data.cancelStatus);
    this.DashboardService.getOnlineBookRequestIsExistCheck(this.pno,data.bookInformationId).subscribe(response => {
      this.isExist=response;
      if(this.isExist){
        this.message=true;
     console.log("Exist");
      }
      else{
           this.confirmService.confirm('Confirm Booking message', 'Are You Sure Booking This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.BookInformationService.onlineBookRequestByUser(value,this.pno).subscribe(response => {      
                    
          this.reloadCurrentRoute();
          this.snackBar.open('Online Book Request Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });      
        }, error => {
          this.validationErrors = error;
        })
      }
    },)
      }
      console.log("sbsbsbbs");
      console.log(this.isExist);
    })



  }

  getBarcodePopup(value){
    console.log(value)
    this.barcodePopup = true;
    this.barcodeId = value;
  }

  toggleBarcode() {
    this.showHideDivBarcode = !this.showHideDivBarcode;
  }
  printBarcodeSingle() {
    this.showHideDivBarcode = false;
    this.printBarcode();
  }
  printBarcode() {
    let printContents, popupWin;
    printContents = document.getElementById("print-barcode").innerHTML;
    popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
    popupWin.document.open();
    popupWin.document.write(`
      <html>
        <head>
          <style>
            body{  width: 99%;}
            .print-barcode-design .barcode svg g rect {
              height: 65px !important;
            }
            .print-barcode-design .barcode svg g text{
              display:none;
            }
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          <h3>Barcode </h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
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
}
