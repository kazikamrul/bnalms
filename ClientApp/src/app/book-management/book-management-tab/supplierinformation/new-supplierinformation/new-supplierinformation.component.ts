import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {SupplierInformationService} from '../../service/SupplierInformation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { SupplierInformation } from '../../models/SupplierInformation';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { BookInformationService } from '../../service/BookInformation.service';

@Component({
  selector: 'app-new-supplierinformation',
  templateUrl: './new-supplierinformation.component.html',
  styleUrls: ['./new-supplierinformation.component.sass']
})
export class NewSupplierInformationComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  SupplierInformationForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole = Role;
  branchId:any;
  bookInformationId:any;
  baseSchoolNameId:any;
  selectedAuthorCategory:SelectedModel[];
  departmentName:SelectedModel[];
  options = [];
  filteredOptions;
  bookTitleInfoId:number;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  //displayedColumns: string[] = [ 'sl','bookTitleName','titleBangla','bookSubtitle','remarks', 'actions'];
  dataSource: MatTableDataSource<SupplierInformation> = new MatTableDataSource();
  selection = new SelectionModel<SupplierInformation>(true, []);
  constructor(private snackBar: MatSnackBar,private bookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private SupplierInformationService: SupplierInformationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('supplierInformationId'); 
    this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');
    console.log(this.bookInformationId)
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Supplier Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.SupplierInformationService.find(+id).subscribe(
        res => {
          this.SupplierInformationForm.patchValue({          

            supplierInformationId: res.supplierInformationId,
            bookInformationId: res.bookInformationId,
            supplierName:res.supplierName,
            baseSchoolNameId:res.baseSchoolNameId,
            address:res.address,
            phone:res.phone,
            email:res.email,
            suppliedDate:res.suppliedDate,
            receivedDate:res.receivedDate,
            remarks:res.remarks,
            //menuPosition: res.menuPosition,
          
          }); 
        }
      );
    } else {
      this.pageTitle = 'Create Supplier Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.SupplierInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    else if (this.role == this.userRole.SuperAdmin){
      this.bookInformationService.find(this.bookInformationId).subscribe(res=>{
        console.log("super admin else if block")
        console.log(res)
        this.SupplierInformationForm.get('baseSchoolNameId').setValue(res.baseSchoolNameId);
      });      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.SupplierInformationForm = this.fb.group({
      supplierInformationId: [0],
      bookInformationId: [''],
      baseSchoolNameId:[''],
      supplierName:[''],
      address: [''],
      phone: [''],
      email: [''],
      suppliedDate: [''],
      receivedDate: [''],
      remarks: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
    
  }
  
  GetDepartmentNameById(baseNameId){    
    this.SupplierInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  getSupplierInformations() {
    this.isLoading = true;
    this.SupplierInformationService.getSupplierInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.bookInformationId).subscribe(response => {
     

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
    this.getSupplierInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSupplierInformations();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.SupplierInformationForm.get('supplierInformationId').value;   
    //this.SupplierInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    this.SupplierInformationForm.get('bookInformationId').setValue(this.bookInformationId);
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.SupplierInformationService.update(+id,this.SupplierInformationForm.value).subscribe(response => {
            this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/supplierinformation/'+this.bookInformationId);
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
      this.SupplierInformationService.submit(this.SupplierInformationForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/supplierinformation/'+this.bookInformationId);
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
