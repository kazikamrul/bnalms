import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {BookInformationService} from '../../service/BookInformation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { BookInformation } from '../../models/BookInformation';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-bookinformation',
  templateUrl: './new-bookinformation.component.html',
  styleUrls: ['./new-bookinformation.component.sass']
})
export class NewBookInformationComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BookInformationForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  branchId:any;
  baseSchoolId:any;
  selectedBookCategory:SelectedModel[];
  selectedMainClass:SelectedModel[];
  selectedLanguages:SelectedModel[];
  selectedRowInfo:SelectedModel[];
  selectedShelfInfo:SelectedModel[];
  selectedSource:SelectedModel[];
  departmentName:SelectedModel[];
  options = [];
  authorDamage: any;
  isExist:boolean;
  baseNameId:any;
  filteredOptions;
  bookTitleInfoId:number;
  issuableToggle:string;
  illustrationsToggle:string;
  userRole = Role;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','bookTitleName','titleBangla','bookSubtitle','remarks', 'actions'];
  dataSource: MatTableDataSource<BookInformation> = new MatTableDataSource();
  selection = new SelectionModel<BookInformation>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private BookInformationService: BookInformationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bookInformationId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Book Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.BookInformationService.find(+id).subscribe(
        res => {
          this.BookInformationForm.patchValue({          

            bookInformationId: res.bookInformationId,
            bookCategoryId: res.bookCategoryId,
            bookTitleInfoId:res.bookTitleInfoId,
            baseSchoolNameId:res.baseSchoolNameId,
            languageId:res.languageId,
            mergeId:res.mergeId,
            mainClassId: res.mainClassId,
            rowInfoId: res.rowInfoId,
            shelfInfoId: res.shelfInfoId,
            coverImage:res.coverImage,
            accessionNo: res.accessionNo,
            volume: res.volume,
            heading: res.heading,
            callNumber:res.callNumber,
            isbnNo: res.isbnNo,
            edition: res.edition,
            issuable: res.issuable,
            pageNo:res.pageNo,
            countOnlineRequest:res.countOnlineRequest,
            illustrations: res.illustrations,
            notes: res.notes,
            price: res.price,
            sourceId:res.sourceId,
            accessionDate: res.accessionDate,
            useableDays: res.useableDays,
            adminDamageStatus: res.adminDamageStatus,
            borrowerDamageStatus: res.borrowerDamageStatus,
            borrowerDamageFineAmount: res.borrowerDamageFineAmount,
            borrowerDamageRemarks: res.borrowerDamageRemarks,
            //borrowerDamageDate: res.borrowerDamageDate,
            title:res.bookTitle,
            issueStatus:res.issueStatus,
            bookBindingStatus:res.bookBindingStatus

          });   
          this.bookTitleInfoId=res.bookTitleInfoId;
           this.onShelfNameelectionChangeGetRowName(res.shelfInfoId)
        }
      );
    } else {
      this.pageTitle = 'Create Book Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.BookInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      //this.GetDepartmentNameById();    
      //this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    }
    this.getselectedBookCategory();
    this.getselectedMainClass();
    this.getselectedLanguages();
    //this.getselectedRowInfo();
    this.getselectedShelfInfo();
    this.getselectedSources();
    this.getBookInformations(); 
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
   
  }
  intitializeForm() {
    this.BookInformationForm = this.fb.group({
      bookInformationId: [0],
      bookCategoryId: [''],
      baseSchoolNameId:[''],
      languageId:[''],
      mainClassId: [''],
      rowInfoId: [''],
      shelfInfoId: [''],
      bookTitleInfoId:[''],
      title:[''],
      coverImage: [''],
      photo:[''],
      accessionNo: [''],
      mergeId:[''],
      issueStatus:[0],
      volume: [""],
      heading:[''],
      callNumber: [],
      isbnNo: [""],
      edition: [''],
      issuable:[''],
      pageNo: [""],
      countOnlineRequest: [0],
      adminDamageStatus: [0],
      borrowerDamageStatus: [0],
      borrowerDamageFineAmount: [0],
      borrowerDamageRemarks: [''],
      borrowerDamageDate: [''],
      illustrations: [''],
      notes: [""],
      price:[""],
      sourceId: [''],
      accessionDate: [],
      useableDays: [''],
      authorDamageStatus:[0],
      reason:[''],
      damageDate:[''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
      bookBindingStatus:[0]
     
    })
    //autocomplete for BookTitle
    this.BookInformationForm.get('title').valueChanges
    .subscribe(value => {
        this.getSelectedTitle(value);
    })
  }
  //autocomplete for BookTitle
  onBookTitleSelectionChanged(item) {
  this.bookTitleInfoId = item.value
  this.BookInformationForm.get('bookTitleInfoId').setValue(item.value);
  this.BookInformationForm.get('title').setValue(item.text);
}

onAccessionNoChange(value){
 console.log("accession no");
 console.log(value);
 this.BookInformationService.getBookInformationIsExistCheck(value).subscribe(response => {
  this.isExist=response;
  console.log("sbsbsbbs");
  console.log(this.isExist);
})
}
  //autocomplete for BookTitle
  getSelectedTitle(title){
  this.BookInformationService.getSelectedTitle(title).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}
onDamage(dropdown) {
  if (dropdown.isUserInput) {
    this.authorDamage = dropdown.source.value;
    console.log(this.authorDamage);
  }
}
changeIssuable(e) {
  this.issuableToggle=e.value;
}
changeIllustrations(e) {
  this.illustrationsToggle=e.value;
}
onFileChanged(event) {
  if (event.target.files.length > 0) {
    const file = event.target.files[0];
    console.log('dddd')
   console.log(file);
    this.BookInformationForm.patchValue({
      photo: file,
    });
  }
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
  getselectedMainClass(){
    this.BookInformationService.getselectedMainClass().subscribe(res=>{
      this.selectedMainClass=res
    });
  }
  getselectedLanguages(){
    this.BookInformationService.getselectedLanguages().subscribe(res=>{
      this.selectedLanguages=res
    });
  }
  onShelfNameelectionChangeGetRowName(shelfInfoId){
    //var shelfInfoId=this.BookInformationForm.value['shelfInfoId'];
    this.BookInformationService.getselectedRowInfo(shelfInfoId).subscribe(res=>{
      this.selectedRowInfo=res
    });
  }
  getselectedShelfInfo(){
    this.BookInformationService.getselectedShelfInfo().subscribe(res=>{
      this.selectedShelfInfo=res
    });
  }
  getselectedSources(){
    this.BookInformationService.getselectedSources().subscribe(res=>{
      this.selectedSource=res
    });
  }
  getBookInformations() {
    this.isLoading = true;
    this.BookInformationService.getBookInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

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
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getBookInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getBookInformations();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.BookInformationForm.get('bookInformationId').value;   
   var bookCategoryId = this.BookInformationForm.get('bookCategoryId').value;
   var accessionNo = this.BookInformationForm.get('accessionNo').value;
   var mergeId = bookCategoryId + accessionNo;

   this.BookInformationForm.get('mergeId').setValue(mergeId);

    //this.BookInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    console.log(this.BookInformationForm)
    this.BookInformationForm.get('accessionDate').setValue((new Date(this.BookInformationForm.get('accessionDate').value)).toUTCString());

    console.log(this.BookInformationForm.value)
    const formData = new FormData();
    for (const key of Object.keys(this.BookInformationForm.value)) {
      const value = this.BookInformationForm.value[key];
      formData.append(key, value);
    }
    console.log(id);
    if (id) {
      console.log(id);
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        console.log("hasan");
        if (result) {
          this.BookInformationService.update(id,formData).subscribe(response => {
          
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
            this.router.navigateByUrl('/book-management/book-management-tab/bookinformation-list');
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    }
    else {
      this.BookInformationService.submit(formData).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/book-management/book-management-tab/bookinformation-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
