import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {SourceInformationService} from '../../service/SourceInformation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { SourceInformation } from '../../models/SourceInformation';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { BookInformationService } from '../../service/BookInformation.service';

@Component({
  selector: 'app-new-sourceinformation',
  templateUrl: './new-sourceinformation.component.html',
  styleUrls: ['./new-sourceinformation.component.sass']
})
export class NewSourceInformationComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  SourceInformationForm: FormGroup;
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
  dataSource: MatTableDataSource<SourceInformation> = new MatTableDataSource();
  selection = new SelectionModel<SourceInformation>(true, []);
  constructor(private snackBar: MatSnackBar,private bookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private SourceInformationService: SourceInformationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('sourceInformationId'); 
    this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');
    console.log(this.bookInformationId)
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Source Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.SourceInformationService.find(+id).subscribe(
        res => {
          this.SourceInformationForm.patchValue({          

            sourceInformationId: res.sourceInformationId,
            bookInformationId: res.bookInformationId,
            sourceName:res.sourceName,
            baseSchoolNameId:res.baseSchoolNameId,
            address:res.address,
            phone:res.phone,
            email:res.email,
            orderDate:res.orderDate,
            receivedDate:res.receivedDate,
            remarks:res.remarks,
            //menuPosition: res.menuPosition,
          
          }); 
        }
      );
    } else {
      this.pageTitle = 'Create Source Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.SourceInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    else if (this.role == this.userRole.SuperAdmin){
      this.bookInformationService.find(this.bookInformationId).subscribe(res=>{
        console.log("super admin else if block")
        console.log(res)
        this.SourceInformationForm.get('baseSchoolNameId').setValue(res.baseSchoolNameId);
      });      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.SourceInformationForm = this.fb.group({
      sourceInformationId: [0],
      bookInformationId: [''],
      baseSchoolNameId:[''],
      sourceName:[''],
      address: [''],
      phone: [],
      email: [''],
      orderDate: [''],
      receivedDate: [''],
      remarks: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
    
  }
  
  GetDepartmentNameById(baseNameId){    
    this.SourceInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  getSourceInformations() {
    this.isLoading = true;
    this.SourceInformationService.getSourceInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText, this.bookInformationId).subscribe(response => {
     

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
    this.getSourceInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getSourceInformations();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.SourceInformationForm.get('sourceInformationId').value;   
    //this.SourceInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    this.SourceInformationForm.get('bookInformationId').setValue(this.bookInformationId);
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.SourceInformationService.update(+id,this.SourceInformationForm.value).subscribe(response => {
            this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/sourceinformation/'+this.bookInformationId);
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
      this.SourceInformationService.submit(this.SourceInformationForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/sourceinformation/'+this.bookInformationId);
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
