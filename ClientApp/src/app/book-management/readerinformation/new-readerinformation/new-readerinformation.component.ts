import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {ReaderInformationService} from '../../service/ReaderInformation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { ReaderInformation } from '../../models/ReaderInformation';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';


@Component({
  selector: 'app-new-readerinformation',
  templateUrl: './new-readerinformation.component.html',
  styleUrls: ['./new-readerinformation.component.sass']
})
export class NewReaderInformationComponent implements OnInit {
  
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  ReaderInformationForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  inDate:any;
  userRole=Role
  branchId:any;
  baseSchoolId:any;
  selectedFeeCategory:SelectedModel[];
  selectedMemberName:SelectedModel[];
  departmentName:SelectedModel[];
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
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  dataSource: MatTableDataSource<ReaderInformation> = new MatTableDataSource();
  selection = new SelectionModel<ReaderInformation>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private ReaderInformationService: ReaderInformationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('readerInformationId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Reader Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.ReaderInformationService.find(+id).subscribe(
        res => {
          this.ReaderInformationForm.patchValue({          

            readerInformationId: res.readerInformationId,
            memberInfoId: res.memberInfoId,
            readerName:res.readerName,
            baseSchoolNameId:res.baseSchoolNameId,
            inDate:res.inDate,
            outDate:res.outDate,
            pno:res.pno,
           
          
          });   
          this.memberInfoId=res.memberInfoId;
        }
      );
    } else {
      this.pageTitle = 'Create Reader Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.ReaderInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.ReaderInformationForm = this.fb.group({
      readerInformationId: [0],
      memberInfoId: [''],
      pno:[''],
      baseSchoolNameId:[''],
      readerName:[''],
      inDate: [''],
      outDate: [''],
      isActive: [true],
     
    })
    //autocomplete for BookTitle
    this.ReaderInformationForm.get('pno').valueChanges
    .subscribe(value => {
        this.getSelectedPno(value);
    })
  }
  //autocomplete for OrganizationName
  onPnoSelectionChanged(item) {
  this.bookTitleInfoId = item.value
  this.ReaderInformationForm.get('memberInfoId').setValue(item.value);
  this.ReaderInformationForm.get('pno').setValue(item.text);
}
  //autocomplete for BookTitle
  getSelectedPno(pno){
  this.ReaderInformationService.getSelectedPno(pno).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}
GetDepartmentNameById(baseNameId){    
  this.ReaderInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
    this.departmentName=res
    console.log("departmentName")
    console.log(this.departmentName)
  }); 
}
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
 
  onSubmit() {
    const id = this.ReaderInformationForm.get('readerInformationId').value;   
    //this.ReaderInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    console.log("Formvalue")
    console.log(this.ReaderInformationForm.value)
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.ReaderInformationService.update(+id,this.ReaderInformationForm.value).subscribe(response => {
            this.router.navigateByUrl('/book-management/readerinformation-list');
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
      this.ReaderInformationService.submit(this.ReaderInformationForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/book-management/readerinformation-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
