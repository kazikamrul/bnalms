import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {BookIssueAndSubmissionService} from '../../service/BookIssueAndSubmission.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { BookIssueAndSubmission } from '../../models/BookIssueAndSubmission';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { BookInformationService } from '../../book-management-tab/service/BookInformation.service';
import { MemberInfoService } from '../../../member-management/service/MemberInfo.service'
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-damagereturn',
  templateUrl: './damagereturn.component.html',
  styleUrls: ['./damagereturn.component.sass']
})
export class DamageReturnComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  DamageBbyBorrowerForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
  branchId:any;
  baseSchoolId:any;
  selectedFeeCategory:SelectedModel[];
  selectedMemberName:SelectedModel[];
  departmentName:SelectedModel[];
  selectedShelfInfo:SelectedModel[];
  selectedRowInfo:SelectedModel[];
  itemValue: string;
  options = [];
  filteredOptions;
  memberInfoId:number;
  issuableToggle:string;
  bookInformationId: number;
  bookTitleInfoId:number;
  illustrationsToggle:string;
  getmemberinfoid: number;
  getmembername: string;
  bookTitleEnglish:any;
  bookTitleBangla:any;
  memberName:any;
  designation:any;
  pno:any;
  mobileNoPersonal:any;
  price:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();
  selection = new SelectionModel<BookIssueAndSubmission>(true, []);
  constructor(private snackBar: MatSnackBar,private MemberInfoService:MemberInfoService,private BookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private BookIssueAndSubmissionService: BookIssueAndSubmissionService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bookIssueAndSubmissionId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Damaged By Borrower';
      this.destination='Edit';
      this.buttonText="Update";
      this.BookIssueAndSubmissionService.find(+id).subscribe(
        res => {
          console.log(res)
          this.DamageBbyBorrowerForm.patchValue({          
            bookIssueAndSubmissionId: res.bookIssueAndSubmissionId,
            baseSchoolNameId: res.baseSchoolNameId,
            memberInfoId:res.memberInfoId,
            bookInformationId:res.bookInformationId,
            shelfInfoId:res.shelfInfoId,
            rowInfoId:res.rowInfoId,
            issueDate:res.issueDate,
            dueDate:res.dueDate,
            submissionDate:res.submissionDate,
            fineForLate:res.fineForLate,
            fineForDamage:res.fineForDamage,
            isDamage:res.isDamage,
            bookStatus:res.bookStatus,
            cancelDate:res.cancelDate,
            cancelId:res.cancelId,
            onlineRequested:res.onlineRequested,
            acceptDate:res.acceptDate,
            requestDate:res.requestDate,
            remarksForIssue:res.remarksForIssue,
            mailTracking:res.mailTracking,
            seen:res.seen,
            remarksForSubmission:res.remarksForSubmission,
            issuedBy:res.issuedBy,
            menuPosition:res.menuPosition,        
            bookTitleBangla:res.bookTitleBangla             
          });   
          this.bookInformationId=res.bookInformationId;
          this.onMemberInfoById(res.memberInfoId);
          this.onTitleById(res.bookInformationId);
        }
      );
    } else {
      this.pageTitle = 'Create Damaged By Borrower';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.DamageBbyBorrowerForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
  }
  intitializeForm() {
    this.DamageBbyBorrowerForm = this.fb.group({
      bookIssueAndSubmissionId: [0],
      baseSchoolNameId: [''],
      memberInfoId:[''],
      bookInformationId:[''], 
      borrowerDamageRemarks:[''],   
      isDamage:[''],
      borrowerDamageFineAmount:['']
    })
  }

  onMemberInfoById(id: number) {
    console.log(id);
    this.MemberInfoService.find(id).subscribe(res => {
      console.log("res");
      console.log(res);
      this.memberName = res.memberName;
      this.designation = res.designation;
      this.pno = res.pno;
      this.mobileNoPersonal = res.mobileNoPersonal;
    
    });
  }

  onTitleById(id: number) {
    console.log(id);
    this.BookInformationService.find(id).subscribe(res => {
      console.log("res");
      console.log(res);
      this.bookTitleEnglish = res.bookTitleEnglish;
      this.bookTitleBangla = res.bookTitleBangla;
      this.price = res.price;
    });
  }
  
  onSubmit() {
    const id = this.DamageBbyBorrowerForm.get('bookIssueAndSubmissionId').value;   
    this.DamageBbyBorrowerForm.get('isDamage').setValue(1);
    console.log(this.DamageBbyBorrowerForm.value)
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.BookIssueAndSubmissionService.update(+id,this.DamageBbyBorrowerForm.value).subscribe(response => {
            this.router.navigateByUrl('/book-management/bookissueandsubmission-list');
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
    // else {
    //   this.BookIssueAndSubmissionService.submit(this.DamageBbyBorrowerForm.value).subscribe(response => {
    //     //this.reloadCurrentRoute();
    //     this.snackBar.open('Information Saved Successfully ', '', {
    //       duration: 2000,
    //       verticalPosition: 'bottom',
    //       horizontalPosition: 'right',
    //       panelClass: 'snackbar-success'
    //     });
    //     this.router.navigateByUrl('/book-management/damagedbyborrower-list');
    //   }, error => {
    //     this.validationErrors = error;
    //   })
    // }
 
  }
  

}
