import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {DemandBookService} from '../../service/DemandBook.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { DemandBook } from '../../models/DemandBook';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MemberInfoService } from '../../service/MemberInfo.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-demandbook',
  templateUrl: './new-demandbook.component.html',
  styleUrls: ['./new-demandbook.component.sass']
})
export class NewDemandBookComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  DemandBookForm: FormGroup;
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

  
  dataSource: MatTableDataSource<DemandBook> = new MatTableDataSource();
  selection = new SelectionModel<DemandBook>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private MemberInfoService: MemberInfoService,private confirmService: ConfirmService,private DemandBookService: DemandBookService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('demandBookId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Demand Book';
      this.destination='Edit';
      this.buttonText="Update";
      this.DemandBookService.find(+id).subscribe(
        res => {
          this.DemandBookForm.patchValue({          

            demandBookId: res.demandBookId,
            bookName: res.bookName,
            authorName:res.authorName,
          });   
          //this.memberInfoId=res.memberInfoId;
        }
      );
    } else {
      this.pageTitle = 'Create Demand Book';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    // if(this.role != this.userRole.SuperAdmin){
    //   this.DemandBookForm.get('baseSchoolNameId').setValue(this.branchId);
      
    // }
    // this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    //this.getselectedFeeCategory();
  }
  intitializeForm() {
    this.DemandBookForm = this.fb.group({
      demandBookId: [0],
      bookName: [''],
      authorName:[''],
      isActive: [true],
     
    })
    //autocomplete for pno
    // this.FeeInformationForm.get('pno').valueChanges
    // .subscribe(value => {
    //     this.getSelectedPno(value);
    // })
  }
  //autocomplete for pno
//   onPnoSelectionChanged(item) {
//   this.bookTitleInfoId = item.value
//   this.FeeInformationForm.get('memberInfoId').setValue(item.value);
//   this.FeeInformationForm.get('pno').setValue(item.text);
//   console.log(item.value);
//   //this.FeeInformationForm.get('memberInfoId').value;

  
// }
  //autocomplete for pno
//   getSelectedPno(pno){
//   this.FeeInformationService.getSelectedPno(pno).subscribe(response => {
//     this.options = response;
//     this.filteredOptions = response;
//   })
// }
// GetDepartmentNameById(baseNameId){    
//   this.FeeInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
//     this.departmentName=res
//     console.log("departmentName")
//     console.log(this.departmentName)
//   }); 
// }

  
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.DemandBookForm.get('demandBookId').value;   
    //this.DemandBookForm.get('baseSchoolNameId').setValue(this.branchId);
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.DemandBookService.update(+id,this.DemandBookForm.value).subscribe(response => {
            this.router.navigateByUrl('/member-demand/add-demandbook');
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
      this.DemandBookService.submit(this.DemandBookForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        //this.router.navigateByUrl('/member-demand/demandbook-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
