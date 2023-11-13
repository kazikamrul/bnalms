import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import {InventoryService} from '../../../inventory-management/service/Inventory.service';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import {InventoryType} from '../../models/InventoryType';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-inventoryupdate',
  templateUrl: './inventoryupdate.component.html',
  styleUrls: ['./inventoryupdate.component.sass']
})
export class InventoryUpdateComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  InventoryTypeForm: FormGroup;
  validationErrors: string[] = [];
  departmentName:SelectedModel[];
  role:any;
  userRole=Role;
  branchId:any;
  isLoading = false;
  baseSchoolNameId:any;
  isShown: boolean = false ;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','name','menuPosition',  'actions'];
  dataSource: MatTableDataSource<InventoryType> = new MatTableDataSource();

  selection = new SelectionModel<InventoryType>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private InventoryService: InventoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('inventoryTypeId');
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    // if (id) {
    //   this.pageTitle = 'Inventory';
    //   this.destination='Edit';
    //   this.buttonText="Update";
    //   this.InventoryTypeService.find(+id).subscribe(
    //     res => {
    //       this.InventoryTypeForm.patchValue({          

    //         inventoryTypeId: res.inventoryTypeId,
    //         name: res.name,
    //         menuPosition: res.menuPosition,
    //         isActive: res.isActive    
    //       });          
    //     }
    //   );
    // } else {
      this.pageTitle = 'Inventory';
      this.destination='Add';
      this.buttonText="Save";
   // }
    this.intitializeForm();
    // if(this.role != this.userRole.SuperAdmin){
    //   this.FineForIssueReturnForm.get('baseSchoolNameId').setValue(this.branchId);
    //   this.getFineForIssueReturns();
      
    // }
    // this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
   // this.getInventoryTypes();
  }
  intitializeForm() {
    this.InventoryTypeForm = this.fb.group({
      inventoryId: [''],
      damageDate: [''],
      damageReason: [''],
      damageStatus:[1], 
    })
  }
  // getInventoryTypes() {
  //   this.isShown=true;
  //   this.InventoryTypeService.getInventoryTypes(this.paging.pageIndex, this.paging.pageSize,this.searchText).subscribe(response => {
  //      this.dataSource.data = response.items; 
  //     console.log(this.dataSource.data);
  //     console.log("data");
  //     this.paging.length = response.totalItemsCount    
  //     this.isLoading = false;
  //   })
  // }
  // GetDepartmentNameById(baseNameId){    
  //   this.FineForIssueReturnService.getSelectedSchoolName(baseNameId).subscribe(res=>{
  //     this.departmentName=res
  //     console.log("departmentName")
  //     console.log(this.departmentName)
  //   }); 
  // }
  
  // pageChanged(event: PageEvent) {
  //   this.paging.pageIndex = event.pageIndex
  //   this.paging.pageSize = event.pageSize
  //   this.paging.pageIndex = this.paging.pageIndex + 1
  //   this.getInventoryTypes();
  // }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.route.snapshot.paramMap.get('inventoryId');   
   // inventoryId
    this.InventoryTypeForm.get('inventoryId').setValue(id);
    console.log(this.InventoryTypeForm.value);
    console.log(id);
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        console.log(result);
        if (result) {
          this.InventoryService.updateInventory(+id,this.InventoryTypeForm.value).subscribe(response => {
            this.router.navigateByUrl('/inventory-management/add-inventory');
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
}
