import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {InventoryService} from '../../service/Inventory.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { Inventory } from '../../models/Inventory';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { BaseSchoolNameService } from 'src/app/security/service/BaseSchoolName.service';

@Component({
  selector: 'app-new-Inventory',
  templateUrl: './new-Inventory.component.html',
  styleUrls: ['./new-Inventory.component.sass']
})
export class NewInventoryComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  InventoryForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
  branchId:any;
  InventoryList:Inventory[];
  baseSchoolId:any;
  selectedFeeCategory:SelectedModel[];
  selectedMemberName:SelectedModel[];
  departmentName:SelectedModel[];
  selectedInventoryTypes:SelectedModel[];
  itemValue: string;
  options = [];
  filteredOptions;
  bookTitleInfoId:number;
  issuableToggle:string;
  memberInfoId: number;
  illustrationsToggle:string;
  getmemberinfoid: number;
  getmembername: string;
  memberName:any;
  designation:any;
  department:any;
  mobileNoOffice:any
  isShown: boolean = false ;
  inventoryTypeId:any;
  showHideDiv:any;
  libraryName:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  tableShowStatus=false;
  tableShow=true;

  groupArrays: { inventoryType: string; datas: any }[];

  displayedColumns: string[] = [ 'sl','inventoryType','identityNo','location','brand','Quantity','model','purchaseDate','price', 'actions'];
  dataSource: MatTableDataSource<Inventory> = new MatTableDataSource();
  dataSourceForNotAvailable: MatTableDataSource<Inventory> = new MatTableDataSource();
  
  selection = new SelectionModel<Inventory>(true, []);
  constructor(private snackBar: MatSnackBar,private baseSchoolNameService: BaseSchoolNameService,private authService: AuthService,private confirmService: ConfirmService,private InventoryService: InventoryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('inventoryId'); 

    // this.userRole.Member
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Inventory';
      this.destination='Edit';
      this.buttonText="Update";
      this.InventoryService.find(+id).subscribe(
        res => {
          this.InventoryForm.patchValue({          
            inventoryId: res.inventoryId,
            inventoryTypeId: res.inventoryTypeId,
            baseSchoolNameId: res.baseSchoolNameId,
            identityNo: res.identityNo,
            location: res.location,
            remarks: res.remarks,
            brand: res.brand,
            quantity: res.quantity,
            model: res.model,
            purchaseDate: res.purchaseDate,
            companyName: res.companyName,
            contractNumber: res.contractNumber,
            price: res.price,
            damageStatus: res.damageStatus,
            damageDate: res.damageDate,
            damageReason: res.damageReason,
            menuPosition: res.menuPosition,
            isActive: res.isActive
          });   
          // this.getselectedInventoryTypes();
          //this.memberInfoId=res.memberInfoId;
        }
      );
    } else {
      this.pageTitle = 'Create Inventory';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.InventoryForm.get('baseSchoolNameId').setValue(this.branchId);
      // this.getInventoryListByDepartment();
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getselectedInventoryTypes();
    this.getInventorys();
    if(this.role == Role.Admin){
      this.baseSchoolNameService.find(this.branchId).subscribe(res=>{
        this.libraryName = res.schoolName;
      });
    }
  }
  intitializeForm() {
    this.InventoryForm = this.fb.group({
      inventoryId: [0],
      inventoryTypeId: [''],
      baseSchoolNameId: [''],
      identityNo: [''],
      location: [''],
      remarks: [''],
      brand: [''],
      quantity: [''],
      model: [''],
      purchaseDate: [''],
      companyName: [''],
      contractNumber: [''],
      price: [''],
      damageStatus: [0],
     // damageDate: [''],
     // damageReason: [''],
      // menuPosition: [''],
      isActive: [true],
     
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.InventoryService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getInventorys();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getInventorys();
  } 
  availableList(){
    var baseSchoolNameId =this.InventoryForm.value['baseSchoolNameId'];
    var inventoryTypeId =this.InventoryForm.value['inventoryTypeId'];
    if(baseSchoolNameId !=null && inventoryTypeId !=null){
      this.tableShow =true;
      this.tableShowStatus =false;
      this.getInventorys();
    }
  }
  notAvailableList(){
    var baseSchoolNameId =this.InventoryForm.value['baseSchoolNameId'];
    var inventoryTypeId =this.InventoryForm.value['inventoryTypeId'];
    if(baseSchoolNameId !=null && inventoryTypeId !=null){
      this.tableShow =false;
      this.tableShowStatus =true;
      this.getInventoryNotAvailableList();
    }
  }
  getInventoryNotAvailableList() {
    this.isLoading = true;
    var baseSchoolNameId =this.InventoryForm.value['baseSchoolNameId'];
    var inventoryTypeId =this.InventoryForm.value['inventoryTypeId'];

    this.InventoryService.getInventorys(this.paging.pageIndex, this.paging.pageSize,this.searchText,baseSchoolNameId,inventoryTypeId).subscribe(response => {
     
      this.dataSourceForNotAvailable.data = response.items; 

      this.dataSourceForNotAvailable.data=this.dataSourceForNotAvailable.data.filter(x=>x.damageStatus == 1);

      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      console.log("data source77777--");
      console.log(this.dataSourceForNotAvailable.data);
      
      const groups = this.dataSourceForNotAvailable.data.reduce((groups, datas) => {
        const inventoryType = datas.inventoryType;
        if (!groups[inventoryType]) {
          groups[inventoryType] = [];
        }
        groups[inventoryType].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((inventoryType) => {
        return {
          inventoryType,
          datas: groups[inventoryType],
        };
      });
      console.log("group array");
      console.log(this.groupArrays);
    })
  }

  getInventorys() {

    this.tableShow =true;
    this.tableShowStatus =false;

    this.isLoading = true;
    var baseSchoolNameId =this.InventoryForm.value['baseSchoolNameId'];
    var inventoryTypeId =this.InventoryForm.value['inventoryTypeId'];

    this.InventoryService.getInventorys(this.paging.pageIndex, this.paging.pageSize,this.searchText,baseSchoolNameId,inventoryTypeId).subscribe(response => {
     
      this.dataSource.data = response.items; 

      this.dataSource.data=this.dataSource.data.filter(x=>x.damageStatus == 0);

      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
      console.log("data source--");
      console.log(this.dataSource.data);
      
      const groups = this.dataSource.data.reduce((groups, datas) => {
        const inventoryType = datas.inventoryType;
        if (!groups[inventoryType]) {
          groups[inventoryType] = [];
        }
        groups[inventoryType].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((inventoryType) => {
        return {
          inventoryType,
          datas: groups[inventoryType],
        };
      });
      console.log("group array");
      console.log(this.groupArrays);
    })
  }
  getselectedInventoryTypes(){
    this.InventoryService.getselectedInventoryTypes().subscribe(res=>{
      this.selectedInventoryTypes=res
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
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
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-mrk-rmrk-act-i{
                      display: none;
                    }
                    .table.table.tbl-by-group.db-li-s-in tr .cl-itemnames{
                      display: none;
                    }
  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-trade{
                      display: none;
                    }
                    .table.table.tbl-by-group.db-li-s-in tr .cl-itemname-status{
                      display: none;
                    }
                    .table.table.tbl-by-group.db-li-s-in tr .cl-itemname-img{
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
          <h3>Inventory List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
  onSubmit() {
    const id = this.InventoryForm.get('inventoryId').value;   
    //this.InventoryForm.get('baseSchoolNameId').setValue(this.branchId);
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.InventoryService.update(+id,this.InventoryForm.value).subscribe(response => {
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
    else {
      this.InventoryService.submit(this.InventoryForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        //this.router.navigateByUrl('/Inventory-management/add-Inventory');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  deleteItem(row) {
    const id = row.inventoryId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.InventoryService.delete(id).subscribe(() => {
          this.reloadCurrentRoute();
          //this.getEventInfos();
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
