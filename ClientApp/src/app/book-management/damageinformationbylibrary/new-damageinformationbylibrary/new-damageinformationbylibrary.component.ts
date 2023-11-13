import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {DamageInformationByLibraryService} from '../../service/DamageInformationByLibrary.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { DamageInformationByLibrary } from '../../models/DamageInformationByLibrary';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BookInformationService } from '../../book-management-tab/service/BookInformation.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-damageinformationbylibrary',
  templateUrl: './new-damageinformationbylibrary.component.html',
  styleUrls: ['./new-damageinformationbylibrary.component.sass']
})
export class NewDamageInformationByLibraryComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  DamageInformationForm: FormGroup;
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
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  dataSource: MatTableDataSource<DamageInformationByLibrary> = new MatTableDataSource();
  selection = new SelectionModel<DamageInformationByLibrary>(true, []);
  constructor(private snackBar: MatSnackBar,private BookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private DamageInformationByLibraryService: DamageInformationByLibraryService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('damageInformationByLibraryId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Damage Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.DamageInformationByLibraryService.find(+id).subscribe(
        res => {
          this.DamageInformationForm.patchValue({          

            damageInformationByLibraryId: res.damageInformationByLibraryId,
            bookInformationId: res.bookInformationId,
            baseSchoolNameId:res.baseSchoolNameId,
            damageBy:res.damageBy,
            remarks:res.remarks,
            accessionNo:res.accessionNo,
           
          
          });   
          this.bookInformationId=res.bookInformationId;
        }
      );
    } else {
      this.pageTitle = 'Create Damage Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.DamageInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
  }
  intitializeForm() {
    this.DamageInformationForm = this.fb.group({
      damageInformationByLibraryId: [0],
      bookInformationId: [''],
      accessionNo:[''],
      baseSchoolNameId:[''],
      damageBy:[''],
      remarks: [],
      isActive: [true],
     
    })
    //autocomplete for accessionNo
    this.DamageInformationForm.get('accessionNo').valueChanges
    .subscribe(value => {
        this.getSelectedAccessionNo(value);
    })
  }
  //autocomplete for accessionNo
  onAccessionNoSelectionChanged(item) {
  this.bookTitleInfoId = item.value
  this.DamageInformationForm.get('bookInformationId').setValue(item.value);
  this.DamageInformationForm.get('accessionNo').setValue(item.text);
  console.log(item.value);
  //this.FeeInformationForm.get('memberInfoId').value;

  this.onTitleById(item.value);
}
  //autocomplete for accessionNo
  getSelectedAccessionNo(accessionNo){
  this.DamageInformationByLibraryService.getSelectedAccessionNo(accessionNo).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}
GetDepartmentNameById(baseNameId){    
  this.BookInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
    this.departmentName=res
    console.log("departmentName")
    console.log(this.departmentName)
  }); 
}
  onTitleById(id: number) {
    console.log(id);
    this.BookInformationService.find(id).subscribe(res => {
      this.bookTitleEnglish = res.bookTitleEnglish
      //this.bookTitleBangla = res.bookTitleBangla
    
    });
  }
  
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.DamageInformationForm.get('damageInformationByLibraryId').value;   
    //this.DamageInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.DamageInformationByLibraryService.update(+id,this.DamageInformationForm.value).subscribe(response => {
            this.router.navigateByUrl('/book-management/damageinformationbylibrary-list');
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
      this.DamageInformationByLibraryService.submit(this.DamageInformationForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/book-management/damageinformationbylibrary-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
