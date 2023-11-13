import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {PublishersInformationService} from '../../service/PublishersInformation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../../core/service/confirm.service';
//import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { PublishersInformation } from '../../models/PublishersInformation';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';
import { BookInformationService } from '../../service/BookInformation.service';
//import { SelectedModel } from '../../../core/models/selectedModel';

@Component({
  selector: 'app-new-publishersinformation',
  templateUrl: './new-publishersinformation.component.html',
  styleUrls: ['./new-publishersinformation.component.sass']
})
export class NewPublishersInformationComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  PublishersInformationForm: FormGroup;
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
  dataSource: MatTableDataSource<PublishersInformation> = new MatTableDataSource();
  selection = new SelectionModel<PublishersInformation>(true, []);
  constructor(private snackBar: MatSnackBar,private bookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private PublishersInformationService: PublishersInformationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('publishersInformationId'); 
    this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');
    console.log(this.bookInformationId)
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Publishers Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.PublishersInformationService.find(+id).subscribe(
        res => {
          this.PublishersInformationForm.patchValue({          

            publishersInformationId: res.publishersInformationId,
            bookInformationId: res.bookInformationId,
            publishersName:res.publishersName,
            baseSchoolNameId:res.baseSchoolNameId,
            publishersAddress:res.publishersAddress,
            publisherDate:res.publisherDate,
            publisherPlace:res.publisherPlace,
            //menuPosition: res.menuPosition,
          
          }); 
        }
      );
    } else {
      this.pageTitle = 'Create Publishers Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.PublishersInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }else if (this.role == this.userRole.SuperAdmin){
      this.bookInformationService.find(this.bookInformationId).subscribe(res=>{
        console.log("super admin else if block")
        console.log(res)
        this.PublishersInformationForm.get('baseSchoolNameId').setValue(res.baseSchoolNameId);
      });      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.PublishersInformationForm = this.fb.group({
      publishersInformationId: [0],
      bookInformationId: [''],
      baseSchoolNameId:[''],
      publishersName:[''],
      publishersAddress: [''],
      publisherDate: [''],
      publisherPlace: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
    
  }
  
  GetDepartmentNameById(baseNameId){    
    this.PublishersInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  getPublishersInformations() {
    this.isLoading = true;
    this.PublishersInformationService.getPublishersInformations(this.paging.pageIndex, this.paging.pageSize,this.searchText,this.bookInformationId).subscribe(response => {
     

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
    this.getPublishersInformations();
  }

  applyFilter(searchText: any){ 
    this.searchText = searchText;
    this.getPublishersInformations();
  } 
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.PublishersInformationForm.get('publishersInformationId').value;   
    //this.PublishersInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    this.PublishersInformationForm.get('bookInformationId').setValue(this.bookInformationId);
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.PublishersInformationService.update(+id,this.PublishersInformationForm.value).subscribe(response => {
            this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/publishersinformation/'+this.bookInformationId);
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
      this.PublishersInformationService.submit(this.PublishersInformationForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('book-management/book-management-tab/main-tab-layout/main-tab/publishersinformation/'+this.bookInformationId);
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
