import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {LibraryAuthorityService} from '../../service/LibraryAuthority.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { LibraryAuthority } from '../../models/LibraryAuthority';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-libraryauthority',
  templateUrl: './new-libraryauthority.component.html',
  styleUrls: ['./new-libraryauthority.component.sass']
})
export class NewLibraryAuthorityComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  LibraryAuthorityForm: FormGroup;
  validationErrors: string[] = [];
  departmentName:SelectedModel[];
  isLoading = false;
  role:any;
  userRole=Role;
  branchId:any;
  baseSchoolId:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','name','menuPosition','actions'];
  dataSource: MatTableDataSource<LibraryAuthority> = new MatTableDataSource();
  selection = new SelectionModel<LibraryAuthority>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private LibraryAuthorityService: LibraryAuthorityService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('libraryAuthorityId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Library Authority';
      this.destination='Edit';
      this.buttonText="Update";
      this.LibraryAuthorityService.find(+id).subscribe(
        res => {
          this.LibraryAuthorityForm.patchValue({          

            libraryAuthorityId: res.libraryAuthorityId,
            name: res.name,
            menuPosition:res.menuPosition,
            //menuPosition: res.menuPosition,
          
          });   
          this.getLibraryAuthoritys();  
           
        }
      );
    } else {
      this.pageTitle = 'Create Library Authority';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    // if(this.role != this.userRole.SuperAdmin){
    //   this.LibraryAuthorityForm.get('baseSchoolNameId').setValue(this.branchId);
      
    // }
    //this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getLibraryAuthoritys(); 
  }
  intitializeForm() {
    this.LibraryAuthorityForm = this.fb.group({
      libraryAuthorityId: [0],
      name: [''],
      menuPosition:[''],
      isActive: [true],
     
    })
  }
  getLibraryAuthoritys() {
    this.isLoading = true;
    this.LibraryAuthorityService.getLibraryAuthoritys(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
     

      this.dataSource.data = response.items; 
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  // GetDepartmentNameById(baseNameId){    
  //   this.BookTitleInfoService.getSelectedSchoolName(baseNameId).subscribe(res=>{
  //     this.departmentName=res
  //     console.log("departmentName")
  //     console.log(this.departmentName)
  //   }); 
  // }
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
    this.getLibraryAuthoritys();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getLibraryAuthoritys();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.LibraryAuthorityForm.get('libraryAuthorityId').value;   
    //this.BookTitleInfoForm.get('baseSchoolNameId').setValue(this.branchId);
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.LibraryAuthorityService.update(+id,this.LibraryAuthorityForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-libraryauthority');
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
      this.LibraryAuthorityService.submit(this.LibraryAuthorityForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        //this.router.navigateByUrl('/basic-setup/add-libraryauthority');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  deleteItem(row) {
    const id = row.libraryAuthorityId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) {
        this.LibraryAuthorityService.delete(id).subscribe(() => {
         // this.getCastes();
          this.snackBar.open('Information Deleted Successfully ', '', {
            duration: 2000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-danger'
          });
          this.reloadCurrentRoute();
        })
      }
    })    
  }

}
