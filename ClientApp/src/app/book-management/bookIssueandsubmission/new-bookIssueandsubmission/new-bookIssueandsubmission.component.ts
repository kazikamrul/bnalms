import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray  } from '@angular/forms';
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
import { Role } from 'src/app/core/models/role';
import { ReaderInformationService } from '../../service/ReaderInformation.service'; 
import { BookBindingInfoService } from '../../service/BookBindingInfo.service';
import {MemberInfoService} from '../../../member-management/service/MemberInfo.service'
import { DatePipe } from '@angular/common';
import { DashboardService } from 'src/app/admin/dashboard/service/Dashboard.service'
import { AuthorInformationService } from '../../book-management-tab/service/AuthorInformation.service';
// import {MomentDateAdapter} from '@angular/material-moment-adapter';
// import {DateAdapter, MAT_DATE_FORMATS, MAT_DATE_LOCALE} from '@angular/material/core';

// export const MY_FORMATS = {
//   parse: {
//     dateInput: 'LL',
//   },
//   display: {
//     dateInput: 'DD-MM-YYYY',
//     monthYearLabel: 'YYYY',
//     dateA11yLabel: 'LL',
//     monthYearA11yLabel: 'YYYY',
//   },
// };

@Component({
  selector: 'app-new-bookIssueandsubmission',
  templateUrl: './new-bookIssueandsubmission.component.html',
  styleUrls: ['./new-bookIssueandsubmission.component.sass'],
  // providers: [
  //   // `MomentDateAdapter` can be automatically provided by importing `MomentDateModule` in your
  //   // application's root module. We provide it at the component level here, due to limitations of
  //   // our example generation script.
  //   {provide: DateAdapter, useClass: MomentDateAdapter, deps: [MAT_DATE_LOCALE]},

  //   {provide: MAT_DATE_FORMATS, useValue: MY_FORMATS},
  // ],
})
export class NewBookIssueAndSubmissionComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  BookIssueAndSubmissionForm: FormGroup;
  issueListForm: FormArray;
  validationErrors: string[] = [];
  isLoading = false;
  isShown = false;
  role:any;
  userRole=Role;
  branchId:any;
  baseSchoolId:any;
  selectedNoticeType:SelectedModel[];
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
  memberinfoId:any;
  memberInfo= false;
  bookInfo= false;
  memberName:any;
  issuedBookList:any;
  issuedBookListLength:any;
  rank:any;
  designation:any;
  mobileNoPersonal:any;
  email:any;
  onlineRequest:any = 0;
  usableDays:any;
  issuable:any;

  popup = false;
  popupIssueRequest = false;
  popupOnlineRequest = false;
  onlineRequestByMemberAndLibrary:any;
  reqIsExist = true;
  issuedBooksList = true;
  requestedmembersList = true;

  infoPopUpTitle:any;
  memberShipDate:any;
  memberShipNumber:any;
  memberExpireDate:any;
  expireDate:any;
  paymentDate:any;
  edition:any;
  price:any;
  language:any;
  bookCategory:any;
  rowName:any;
  shelfName:any;
  onlineBookRequestCount:any;

  bookCategoriesList:any[];
  issueRequestUserList:any[];

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  dataSource: MatTableDataSource<BookIssueAndSubmission> = new MatTableDataSource();
  selection = new SelectionModel<BookIssueAndSubmission>(true, []);
  constructor(private snackBar: MatSnackBar,private datePipe: DatePipe,private AuthorInformationService: AuthorInformationService,private DashboardService : DashboardService,private MemberInfoService:MemberInfoService,private BookBindingInfoService: BookBindingInfoService,private ReaderInformationService: ReaderInformationService,private BookInformationService: BookInformationService,private authService: AuthService,private confirmService: ConfirmService,private BookIssueAndSubmissionService: BookIssueAndSubmissionService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('bookIssueAndSubmissionId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Book Issue';
      this.destination='Edit';
      this.buttonText="Update";
      this.BookIssueAndSubmissionService.find(+id).subscribe(
        res => {
          this.BookIssueAndSubmissionForm.patchValue({          
            bookIssueAndSubmissionId:res.bookIssueAndSubmissionId,
            baseSchoolNameId: res.baseSchoolNameId,
            memberInfoId: res.memberInfoId,
            bookInformationId: res.bookInformationId,
            shelfInfoId: res.shelfInfoId,
            rowInfoId: res.rowInfoId,
            issueDate: res.issueDate,
            dueDate: res.dueDate,
            submissionDate:res.submissionDate,
            fineForLate: res.fineForLate,
            fineForDamage:res.fineForDamage,
            isDamage: res.isDamage,
            bookStatus: res.bookStatus,
            cancelDate: res.cancelDate,
            cancelId: res.cancelId,
            onlineRequested: res.onlineRequested,
            acceptDate: res.acceptDate,
            requestDate:res.requestDate,
            remarksForIssue: res.remarksForIssue,
            mailTracking: res.mailTracking,
            seen: res.seen,
            remarksForSubmission: res.remarksForSubmission,
            issuedBy: res.issuedBy,
            menuPosition:res.menuPosition,
            isActive: res.isActive
          });   
          //this.bookInformationId=res.bookInformationId;
        }
      );
    } else {
      this.pageTitle = 'Create Book Issue';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.BookIssueAndSubmissionForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
   // this.getselectedNoticeType();
   this.clearInitial();
  }
  intitializeForm() {
    this.BookIssueAndSubmissionForm = this.fb.group({
      bookIssueAndSubmissionId:[0],
      baseSchoolNameId: [''],
      memberInfoId: [''],
      bookInformationId: [''],
      pno:[''],
      accessionNo:[''],
      shelfInfoId: [''],
      rowInfoId: [''],
      // issueDate: [''],
      // returnDate: [''],
      submissionDate:[''],
      fineForLate: [''],
      fineForDamage:[''],
      isDamage: [''],
      bookStatus: [''],
      cancelDate: [''],
      cancelId: [''],
      onlineRequested: [''],
      acceptDate: [''],
      requestDate:[''],
      remarksForIssue: [''],
      mailTracking: [''],
      seen: [''],
      remarksForSubmission: [''],
      issuedBy: [''],
      menuPosition:[''],
      isActive: [true],
      issueListForm: this.fb.array([ this.createItem() ])
    })
        //autocomplete for BookTitle
        this.BookIssueAndSubmissionForm.get('pno').valueChanges
        .subscribe(value => {
            this.getSelectedPno(value);
        })

          //autocomplete for accessionNo
    this.BookIssueAndSubmissionForm.get('accessionNo').valueChanges
    .subscribe(value => {
        this.getSelectedAccessionNo(value);
    })
  }
    //autocomplete for BookTitle
    getSelectedPno(pno){
      this.ReaderInformationService.getSelectedPno(pno).subscribe(response => {
        this.options = response;
        this.filteredOptions = response;
      })
    }
  GetDepartmentNameById(baseNameId){    
    this.BookIssueAndSubmissionService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }

  createItem(): FormGroup {
    return this.fb.group({
      bookInformationId: [''],
      shelfInfoId: [''],
      rowInfoId: [''],
      accessionNo: '',
      bookTitle:'',
      issueDate: '',
      returnDate: ''
    });
  }
  clearInitial(){
    const control = <FormArray>this.BookIssueAndSubmissionForm.controls["issueListForm"];
    console.log(control)
    while (control.length) {
      control.removeAt(control.length - 1);            
    }
  }

  clearList(item) {
    console.log(item);
    const control = <FormArray>this.BookIssueAndSubmissionForm.controls["issueListForm"];
    console.log(control)
    // while (control.length) {
    //   if(control.length == item){
    //     control.removeAt(control[item]);
    //   }
      
    // }
    control.removeAt(item);
    control.clearValidators();
  }
 
  addItem(): void {
    this.issueListForm = this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray;
    this.issueListForm.push(this.createItem());
  }

  insertBookInfoByAssessionNo() {
    this.addItem();
    var accessionNo = this.BookIssueAndSubmissionForm.get('accessionNo').value; 
    this.BookIssueAndSubmissionForm.get('accessionNo').setValue('');
    const control = <FormArray>this.BookIssueAndSubmissionForm.controls["issueListForm"];
    var index = control.length-1;
    var current = new Date();
    var extensionDate = this.usableDays;
    var returnDate = new Date(current.getTime() + extensionDate*24*60*60*1000);
    // var today = this.datePipe.transform((new Date), 'MM/dd/yyyy');
    console.log(index,accessionNo.value,accessionNo.text);
    console.log(returnDate);



    (this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray).at(index).get('bookInformationId').setValue(accessionNo.value);
    (this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray).at(index).get('accessionNo').setValue(accessionNo.text);
    (this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray).at(index).get('bookTitle').setValue(this.bookTitleEnglish);
    (this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray).at(index).get('issueDate').setValue(current);
    (this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray).at(index).get('returnDate').setValue(returnDate);
    
    this.BookInformationService.find(accessionNo.value).subscribe(res => {
      console.log("res");
      console.log(res);
      (this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray).at(index).get('shelfInfoId').setValue(res.shelfInfoId);
      (this.BookIssueAndSubmissionForm.get('issueListForm') as FormArray).at(index).get('rowInfoId').setValue(res.rowInfoId);
    });

    this.isShown = true;
  }
  BookIssueListByUser(memberId){
    this.BookIssueAndSubmissionService.BookIssueListByUser(memberId).subscribe(res=>{
      this.issuedBookList = res;
      this.issuedBookListLength = res.length;
    });
  }

    //autocomplete for OrganizationName
    onPnoSelectionChanged(item) {
      this.memberInfo = true;
      this.memberinfoId = item.value
      console.log(item.value);
      this.BookIssueAndSubmissionForm.get('memberInfoId').setValue(item.value);
      this.BookIssueAndSubmissionForm.get('pno').setValue(item.text);


      this.BookIssueListByUser(item.value);
    // get MemberInfo Data
    this.MemberInfoService.find(this.memberinfoId).subscribe( res => {
        this.memberName=res.memberName,
        this.rank=res.rank,
        this.designation=res.designation,
        this.mobileNoPersonal=res.mobileNoPersonal,
        this.email=res.email,
        this.paymentDate = res.lastPaymentDate,
        this.expireDate=res.expireDate,
        this.memberShipDate=res.memberShipDate,
        this.memberExpireDate=res.memberExpireDate,
        this.memberShipNumber=res.memberShipNumber,
        console.log(res);
        console.log("Member Info");

        this.BookIssueAndSubmissionService.getOnlineBookRequestCountByMember(this.branchId,this.memberinfoId).subscribe(res=>{
          this.onlineBookRequestCount = res.length;
        });
      }
    );
    }
  // getselectedNoticeType(){
  //   this.BookIssueAndSubmissionService.getselectedNoticeType().subscribe(res=>{
  //     this.selectedNoticeType=res
  //   });
  // }


    //autocomplete for accessionNo
    onAccessionNoSelectionChanged(item) {
      this.bookInfo = true;
      var member = this.BookIssueAndSubmissionForm.get('memberInfoId').value;
      console.log("item value");
      console.log(item.value);
      this.BookInformationService.find(item.value).subscribe(res => {
        console.log("res");
        console.log(res);
        if(res.countOnlineRequest > 0){
          console.log("check onlone request");
          this.BookInformationService.getOnlineRequestIsExistCheck(item.value, member).subscribe(response => {
            if(response == true){
              this.reqIsExist = true;
            }else{
              this.reqIsExist = false;
            }
          })
        }else{
          console.log("issue direct");
          this.reqIsExist = true;
        }
      });
      this.bookInformationId = item.value;
      this.BookIssueAndSubmissionForm.get('bookInformationId').setValue(item.value);
      this.BookIssueAndSubmissionForm.get('accessionNo').setValue(item.text);
      console.log(item.value);
     
      //this.FeeInformationForm.get('memberInfoId').value;
    
      this.onTitleById(item.value);
    }

  onTitleById(id: number) {
    console.log(id);
    this.BookInformationService.find(id).subscribe(res => {
      console.log("find data");
      console.log(res);
      this.bookTitleEnglish = res.bookTitleEnglish;
      this.bookTitleBangla = res.bookTitleBangla;
      this.edition=res.edition;
      this.price=res.price;
      this.language=res.language;
      this.bookCategory=res.bookCategory;
      this.rowName=res.rowName;
      this.shelfName=res.shelfName;
      this.usableDays=res.useableDays;
      this.issuable=res.issuable;
      this.onlineRequest=res.countOnlineRequest;
  //     this.department = res.department
  //     this.mobileNoOffice = res.mobileNoOffice
  
    });
  }
  
    //autocomplete for accessionNo
    getSelectedAccessionNo(accessionNo){
      var departmentId = this.BookIssueAndSubmissionForm.get('baseSchoolNameId').value; 
      this.BookBindingInfoService.getSelectedAccessionNoByDepartment(accessionNo,departmentId).subscribe(response => {
        this.options = response;
        this.filteredOptions = response;
      })
    }
  onFileChanged(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log('dddd')
     console.log(file);
      this.BookIssueAndSubmissionForm.patchValue({
        doc: file,
      });
    }
  }
  
  getPopup(){
    this.popup = true;
    // this.barcodeId = itemStoreId;
    console.log("popup apairs")
    this.BookIssueAndSubmissionService.getBookCategoriesList().subscribe(res => {
      console.log("res");
      this.bookCategoriesList = res;
      console.log(this.bookCategoriesList);
    });
  }

  getDueDays(returnDate){
    if(returnDate != null){
      let currentDate = new Date();
    returnDate = new Date(returnDate);

    return Math.floor((Date.UTC(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate()) - Date.UTC(returnDate.getFullYear(), returnDate.getMonth(), returnDate.getDate()) ) /(1000 * 60 * 60 * 24));
    }   
  }
    
  getIssueRequestPopup(displayValue){
    this.popupIssueRequest = true;
    // this.barcodeId = itemStoreId;
    console.log("popup apairs")
    if(displayValue == 1){
      this.infoPopUpTitle = "Issued Book List";
      this.issuedBooksList = true;
      this.requestedmembersList = false;
      this.BookIssueListByUser(this.memberinfoId);
    }else if(displayValue == 2){
      this.infoPopUpTitle = "Online Request List";
      this.requestedmembersList = true;
      console.log(this.requestedmembersList);
      console.log("Online Request List");
      this.issuedBooksList = false;
      this.BookIssueAndSubmissionService.getOnlineBookRequestListByBookInfo(this.bookInformationId).subscribe(res => {
        console.log("res");
        this.issueRequestUserList = res;
        console.log(this.issueRequestUserList);
      });
    }
    
  }
  getOnlineRequestPopup(){
    this.popupOnlineRequest = true;
    // this.barcodeId = itemStoreId;
    console.log("popup apairs")
    this.BookIssueAndSubmissionService.getOnlineBookRequestCountByMember(this.branchId,this.memberinfoId).subscribe(res => {
      console.log("res");
      this.onlineRequestByMemberAndLibrary = res;
      console.log(this.onlineRequestByMemberAndLibrary);
    });
  }

  IssuedForMember(number){
    console.log(number);
    this.confirmService.confirm('Confirm Issue Message', 'Are You Sure Issue This?').subscribe(result => {
      console.log(result);
      if (result) {
        this.DashboardService.saveBookIssueAndSubmission(number).subscribe(response => {
          // this.router.navigateByUrl('/book-management/book-management-tab/bookinformation-list');
          this.reloadCurrentRoute();
           this.snackBar.open('Information Updated Successfully ', '', {
             duration: 2000,
             verticalPosition: 'bottom',
             horizontalPosition: 'right',
             panelClass: 'snackbar-success'
           });
         }, error => {
          // this.validationErrors = error;
         })
      }
    })
  }

  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.BookIssueAndSubmissionForm.get('bookIssueAndSubmissionId').value;   
    //this.BookIssueAndSubmissionForm.get('baseSchoolNameId').setValue(this.branchId);
    console.log(this.BookIssueAndSubmissionForm.value)
    // const formData = new FormData();
    // for (const key of Object.keys(this.BookIssueAndSubmissionForm.value)) {
    //   const value = this.BookIssueAndSubmissionForm.value[key];
    //   formData.append(key, value);
    // }

    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.BookIssueAndSubmissionService.update(+id,this.BookIssueAndSubmissionForm.value).subscribe(response => {
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
      this.BookIssueAndSubmissionService.SaveIssueList(JSON.stringify(this.BookIssueAndSubmissionForm.value)).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/book-management/bookissueandsubmission-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
