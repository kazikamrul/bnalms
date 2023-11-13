import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {BookBindingInfoService} from '../../service/BookBindingInfo.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { BookBindingInfo } from '../../models/BookBindingInfo';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BookInformationService } from '../../book-management-tab/service/BookInformation.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-bookbindinginfo',
  templateUrl: './new-bookbindinginfo.component.html',
  styleUrls: ['./new-bookbindinginfo.component.sass']
})
export class NewBookBindingInfoComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BookBindingInfoForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
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
  bookInformationId: number;
  illustrationsToggle:string;
  getmemberinfoid: number;
  getmembername: string;
  bookTitleEnglish:any;
  bookTitleBangla:any;
  countOnlineRequest:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  dataSource: MatTableDataSource<BookBindingInfo> = new MatTableDataSource();
  selection = new SelectionModel<BookBindingInfo>(true, []);
  constructor(private snackBar: MatSnackBar,private BookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private BookBindingInfoService: BookBindingInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bookBindingInfoId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Book Binding Info';
      this.destination='Edit';
      this.buttonText="Update";
      this.BookBindingInfoService.find(+id).subscribe(
        res => {
          this.BookBindingInfoForm.patchValue({          

            bookBindingInfoId: res.bookBindingInfoId,
            bookInformationId: res.bookInformationId,
            pressName:res.pressName,
            baseSchoolNameId:res.baseSchoolNameId,
            pressNumber:res.pressNumber,
            date:res.date,
            pressEmail:res.pressEmail,
            pressAddress:res.pressAddress,
            senderOfficer:res.senderOfficer,
            officeDispiseNumber:res.officeDispiseNumber,
            receivedOfficerName:res.receivedOfficerName,
            accessionNo:res.accessionNo,
           
          
          });   
          this.bookInformationId=res.bookInformationId;
        }
      );
    } else {
      this.pageTitle = 'Create Book Binding Info';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.BookBindingInfoForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.BookBindingInfoForm = this.fb.group({
      bookBindingInfoId: [0],
      bookInformationId: [''],
      accessionNo:[''],
      baseSchoolNameId:[''],
      pressName:[''],
      date:[""],
      pressNumber: [],
      pressAddress: [''],
      pressEmail: [''],
      senderOfficer: [''],
      officeDispiseNumber: [''],
      receivedOfficerName: [''],
      isActive: [true],
     
    })
    //autocomplete for accessionNo
    this.BookBindingInfoForm.get('accessionNo').valueChanges
    .subscribe(value => {
        this.getSelectedAccessionNo(value);
    })
  }
  //autocomplete for accessionNo
  onAccessionNoSelectionChanged(item) {
  this.bookTitleInfoId = item.value
  this.BookBindingInfoForm.get('bookInformationId').setValue(item.value);
  this.BookBindingInfoForm.get('accessionNo').setValue(item.text);
  console.log(item.value);
  //this.FeeInformationForm.get('memberInfoId').value;

  this.onTitleById(item.value);
}
  //autocomplete for accessionNo
  getSelectedAccessionNo(accessionNo){
  this.BookBindingInfoService.getSelectedAccessionNo(accessionNo).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}

  onTitleById(id: number) {
    console.log(id);
    this.BookInformationService.find(id).subscribe(res => {
      console.log("res");
      console.log(res);
      this.bookTitleEnglish = res.bookTitleEnglish;
      this.bookTitleBangla = res.bookTitleBangla;
      this.countOnlineRequest = res.countOnlineRequest;
      //this.mobileNoOffice = res.mobileNoOffice
    
    });
  }
  GetDepartmentNameById(baseNameId){    
    this.BookInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
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
    const id = this.BookBindingInfoForm.get('bookBindingInfoId').value;   
    //this.BookBindingInfoForm.get('baseSchoolNameId').setValue(this.branchId);
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.BookBindingInfoService.update(+id,this.BookBindingInfoForm.value).subscribe(response => {
            this.router.navigateByUrl('/book-management/bookbindinginfo-list');
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
      this.BookBindingInfoService.submit(this.BookBindingInfoForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/book-management/bookbindinginfo-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
