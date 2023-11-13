import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {AuthorInformationService} from '../../service/AuthorInformation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { AuthorInformation } from '../../models/AuthorInformation';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { BookInformationService } from '../../service/BookInformation.service';
//import { SelectedModel } from '../../../core/models/selectedModel';

@Component({
  selector: 'app-new-authornformation',
  templateUrl: './new-authornformation.component.html',
  styleUrls: ['./new-authornformation.component.sass']
})
export class NewAuthorInformationComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  AuthorInformationForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  branchId:any;
  bookInformationId:any;
  baseSchoolId:any;
  selectedAuthorCategory:SelectedModel[];
  departmentName:SelectedModel[];
  options = [];
  filteredOptions;
  bookTitleInfoId:number;
  userRole = Role;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  //displayedColumns: string[] = [ 'sl','bookTitleName','titleBangla','bookSubtitle','remarks', 'actions'];
  dataSource: MatTableDataSource<AuthorInformation> = new MatTableDataSource();
  selection = new SelectionModel<AuthorInformation>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private bookInformationService: BookInformationService,private confirmService: ConfirmService,private AuthorInformationService: AuthorInformationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('authorInformationId'); 
    this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');
    console.log(this.bookInformationId)
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Author Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.AuthorInformationService.find(+id).subscribe(
        res => {
          this.AuthorInformationForm.patchValue({          

            authorInformationId: res.authorInformationId,
            bookInformationId: res.bookInformationId,
            authorityCategoryId:res.authorityCategoryId,
            baseSchoolNameId:res.baseSchoolNameId,
            authorName:res.authorName,
            //menuPosition: res.menuPosition,
          
          }); 
        }
      );
    } else {
      this.pageTitle = 'Create Author Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.AuthorInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    else if (this.role == this.userRole.SuperAdmin){
      this.bookInformationService.find(this.bookInformationId).subscribe(res=>{
        console.log("super admin else if block")
        console.log(res)
        this.AuthorInformationForm.get('baseSchoolNameId').setValue(res.baseSchoolNameId);
      });      
    }
    this.getselectedAuthorCategory();
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.AuthorInformationForm = this.fb.group({
      authorInformationId: [0],
      bookInformationId: [''],
      baseSchoolNameId:[''],
      authorityCategoryId:[''],
      authorName: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
    
  }
  
  GetDepartmentNameById(baseNameId){    
    this.AuthorInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  getselectedAuthorCategory(){
    this.AuthorInformationService.getselectedAuthorCategory().subscribe(res=>{
      this.selectedAuthorCategory=res
    });
  }
  
  getAuthorInformations() {
    this.isLoading = true;
    this.AuthorInformationService.getAuthorInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.bookInformationId).subscribe(response => {
     

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
    this.getAuthorInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getAuthorInformations();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.AuthorInformationForm.get('authorInformationId').value;   
   // this.AuthorInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    this.AuthorInformationForm.get('bookInformationId').setValue(this.bookInformationId);
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.AuthorInformationService.update(+id,this.AuthorInformationForm.value).subscribe(response => {
            this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/authornformation/'+this.bookInformationId);
            this.snackBar.open('Information Updated Successfully ', '', {
              duration: 2000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          }, error => {
            this.validationErrors = error;
          })
        }
      })
    }
    else {
      this.AuthorInformationService.submit(this.AuthorInformationForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/authornformation/'+this.bookInformationId);
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
