import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import {CourseTypeService} from '../../service/CourseType.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import {FineForIssueReturnService} from '../../../basic-setup/service/FineForIssueReturn.service';
import { Role } from 'src/app/core/models/role';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import {FineForIssueReturn} from '../../models/FineForIssueReturn';
import { SelectionModel } from '@angular/cdk/collections';
import { MatPaginator, PageEvent } from '@angular/material/paginator';

@Component({
  selector: 'app-new-fineforissuereturn',
  templateUrl: './new-fineforissuereturn.component.html',
  styleUrls: ['./new-fineforissuereturn.component.sass']
})
export class NewFineForIssueReturnComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  FineForIssueReturnForm: FormGroup;
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

  displayedColumns: string[] = [ 'sl','dateCreated','amount',  'actions'];
  dataSource: MatTableDataSource<FineForIssueReturn> = new MatTableDataSource();

  selection = new SelectionModel<FineForIssueReturn>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private FineForIssueReturnService: FineForIssueReturnService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('fineForIssueReturnId');
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Fine for Issue Return';
      this.destination='Edit';
      this.buttonText="Update";
      this.FineForIssueReturnService.find(+id).subscribe(
        res => {
          this.FineForIssueReturnForm.patchValue({          

            fineForIssueReturnId: res.fineForIssueReturnId,
            baseSchoolNameId: res.baseSchoolNameId,
            amount: res.amount,
            menuPosition: res.menuPosition,
            isActive: res.isActive    
          });          
        }
      );
    } else {
      this.pageTitle = 'Create Late Fine Amount List';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.FineForIssueReturnForm.get('baseSchoolNameId').setValue(this.branchId);
      this.getFineForIssueReturns();
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.FineForIssueReturnForm = this.fb.group({
      fineForIssueReturnId: [0],
      baseSchoolNameId: [''],
      amount: [],
      menuPosition: [],
      isActive: true    
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.FineForIssueReturnService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  getFineForIssueReturns() {
    this.isShown=true;
    var baseSchoolNameId =this.FineForIssueReturnForm.value['baseSchoolNameId'];
    console.log(baseSchoolNameId);
    console.log("School Id");
    this.FineForIssueReturnService.getFineForIssueReturns(this.paging.pageIndex, this.paging.pageSize,this.searchText,baseSchoolNameId).subscribe(response => {
       this.dataSource.data = response.items; 
      console.log(this.dataSource.data);
      console.log("data");
      this.paging.length = response.totalItemsCount    
      this.isLoading = false;
    })
  }
  activeFineForIssueReturn(row){
    const id = row.fineForIssueReturnId; 
          this.confirmService.confirm('Confirm Active message', 'Are You Sure Active This Item').subscribe(result => {
            if (result) {
              console.log(result)
          this.FineForIssueReturnService.activeFineForIssueReturn(id).subscribe(() => {
            //this.getselectedPresentStocks(this.departmentId);
            this.reloadCurrentRoute();
            this.snackBar.open('Information Active Successfully ', '', {
              duration: 3000,
              verticalPosition: 'bottom',
              horizontalPosition: 'right',
              panelClass: 'snackbar-success'
            });
          })
        }
      })
    
}
inActiveFineForIssueReturn(row){
  const id = row.fineForIssueReturnId; 
        this.confirmService.confirm('Confirm  InActive message', 'Are You Sure InActive This Item').subscribe(result => {
          if (result) {
            console.log(result)
        this.FineForIssueReturnService.inActiveFineForIssueReturn(id).subscribe(() => {
          //this.getselectedPresentStocks(this.departmentId);
          this.reloadCurrentRoute();
          this.snackBar.open('Information InActive Successfully ', '', {
            duration: 3000,
            verticalPosition: 'bottom',
            horizontalPosition: 'right',
            panelClass: 'snackbar-success'
          });
        })
      }
    })
  
}
  pageChanged(event: PageEvent) {
    this.paging.pageIndex = event.pageIndex
    this.paging.pageSize = event.pageSize
    this.paging.pageIndex = this.paging.pageIndex + 1
    this.getFineForIssueReturns();
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.FineForIssueReturnForm.get('fineForIssueReturnId').value;   
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item').subscribe(result => {
        console.log(result);
        if (result) {
          this.FineForIssueReturnService.update(+id,this.FineForIssueReturnForm.value).subscribe(response => {
            this.router.navigateByUrl('/basic-setup/add-fineforissuereturn');
            this.reloadCurrentRoute();
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
      this.FineForIssueReturnService.submit(this.FineForIssueReturnForm.value).subscribe(response => {
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.reloadCurrentRoute();
        this.router.navigateByUrl('/basic-setup/add-fineforissuereturn');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  deleteItem(row) {
    const id = row.fineForIssueReturnId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item').subscribe(result => {
      console.log(result);
      if (result) { 
        this.FineForIssueReturnService.delete(id).subscribe(() => {
          this.getFineForIssueReturns();
          this.reloadCurrentRoute();
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
