import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {MemberInfoService} from '../../service/MemberInfo.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { MemberInfo } from '../../models/MemberInfo';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-profile',
  templateUrl: './new-profile.component.html',
  styleUrls: ['./new-profile.component.sass']
})
export class NewProfileComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  MemberInfoForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
  memberInfoId:any;
  bookInformationId:any;
  branchId:any;
  baseSchoolId:any;
  selectedMemberCategory:SelectedModel[];
  selectedDesignation:SelectedModel[];
  selectedJobStatus:SelectedModel[];
  selectedRank:SelectedModel[];
  selectedShelfInfo:SelectedModel[];
  selectedSource:SelectedModel[];
  departmentName:SelectedModel[];
  selectedArea:SelectedModel[];
  selectedBase:SelectedModel[];
  selectedSecurityQuestion:SelectedModel[];
  options = [];
  filteredOptions;
  bookTitleInfoId:number;
  issuableToggle:string;
  illustrationsToggle:string;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  dataSource: MatTableDataSource<MemberInfo> = new MatTableDataSource();
  selection = new SelectionModel<MemberInfo>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private MemberInfoService: MemberInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    // const id = this.route.snapshot.paramMap.get('memberInfoId'); 
    //this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');

    // this.role = this.authService.currentUserValue.role.trim();
    // this.branchId =  this.authService.currentUserValue.branchId.trim();
    // console.log(this.role,"-"+ this.branchId)
    this.role = this.authService.currentUserValue.role.trim();
    this.memberInfoId =  this.authService.currentUserValue.traineeId.trim();
   // console.log(this.role, this.traineeId)
    // const id = this.route.snapshot.paramMap.get('traineeId'); 
    const id = this.memberInfoId;

    if (id) {
      this.pageTitle = 'Edit Member Info';
      this.destination='Edit';
      this.buttonText="Update";
      this.MemberInfoService.find(+id).subscribe(
        res => {
          this.MemberInfoForm.patchValue({          

            memberInfoId: res.memberInfoId,
            bookInformationId: res.bookInformationId,
            memberCategoryId:res.memberCategoryId,
            baseSchoolNameId:res.baseSchoolNameId,
            rankId:res.rankId,
            designationId: res.designationId,
            jobStatusId: res.jobStatusId,
            //areaId:res.areaId,
            //baseId:res.baseId,
            //securityQuestionId:res.securityQuestionId,
            //answer:res.answer,
            //memberInfoIdentity: res.memberInfoIdentity,
            email:res.email,
            imageUrl: res.imageUrl,
            region:res.region,
            director:res.director,
            memberName: res.memberName,
            fatherName: res.fatherName,
            motherName:res.motherName,
            yearlyFee: res.yearlyFee,
            presentAddress: res.presentAddress,
            permanentAddress: res.permanentAddress,
            nid:res.nid,
            sex: res.sex,
            issueDate: res.issueDate,
            expireDate: res.expireDate,
            dob:res.dob,
            //pno:res.pno,
            department: res.department,
            tntOffice: res.tntOffice,
            mobileNoOffice:res.mobileNoOffice,
            familyContact:res.familyContact,
            mobileNoPersonal:res.mobileNoPersonal,
            //menuPosition: res.menuPosition,
          
          });   
          //this.bookTitleInfoId=res.bookTitleInfoId;
           //this.onShelfNameelectionChangeGetRowName(res.shelfInfoId)
        }
      );
    } else {
      this.pageTitle = 'Create Member Info';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.MemberInfoForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getselectedMemberCategory();
    this.getselectedDesignation();
    this.getselectedJobStatus();
    this.getselectedRank();
    this.getselectedArea();
    this.getselectedBase();
    this.getselectedSecurityQuestion();
  }
  intitializeForm() {
    this.MemberInfoForm = this.fb.group({
      memberInfoId: [0],
      baseSchoolNameId: [''],
      //bookInformationId:[],
      memberCategoryId:[''],
      //rankId: [''],
      //designationId: [''],
      jobStatusId: [''],
      areaId:[''],
      baseId:[''],
      securityQuestionId:[''],
      answer:[''],
      //memberInfoIdentity:[''],
      email:[''],
      imageUrl: [''],
      photo:[''],
      //region:[''],
      director:[''],
      memberName:[''],
      fatherName: [''],
      motherName: [],
      //yearlyFee:[''],
      presentAddress: [],
      permanentAddress: [],
      nid: [''],
      sex:[''],
      //issueDate: [],
      //expireDate: [],
      dob:[''],
      pno: [],
      //department:[],
      tntOffice: [''],
      mobileNoOffice: [],
      familyContact: [],
      mobileNoPersonal: [''],
      //menuPosition: ['', Validators.required],
      isActive: [true],
     
    })
  }
onFileChanged(event) {
  if (event.target.files.length > 0) {
    const file = event.target.files[0];
    console.log('dddd')
   console.log(file);
    this.MemberInfoForm.patchValue({
      photo: file,
    });
  }
}
GetDepartmentNameById(baseNameId){    
  this.MemberInfoService.getSelectedSchoolName(baseNameId).subscribe(res=>{
    this.departmentName=res
    console.log("departmentName")
    console.log(this.departmentName)
  }); 
}
getselectedMemberCategory(){
    this.MemberInfoService.getselectedMemberCategory().subscribe(res=>{
      this.selectedMemberCategory=res
    });
  }
  getselectedDesignation(){
    this.MemberInfoService.getselectedDesignation().subscribe(res=>{
      this.selectedDesignation=res
    });
  }
  getselectedJobStatus(){
    this.MemberInfoService.getselectedJobStatus().subscribe(res=>{
      this.selectedJobStatus=res
    });
  }
  getselectedArea(){
    this.MemberInfoService.getselectedArea().subscribe(res=>{
      this.selectedArea=res
    });
  }
  getselectedBase(){
    this.MemberInfoService.getselectedBase().subscribe(res=>{
      this.selectedBase=res
    });
  }
  getselectedSecurityQuestion(){
    this.MemberInfoService.getselectedSecurityQuestion().subscribe(res=>{
      this.selectedSecurityQuestion=res
    });
  }
  getselectedRank(){
    this.MemberInfoService.getselectedRank().subscribe(res=>{
      this.selectedRank=res
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.MemberInfoForm.get('memberInfoId').value;  
    console.log(this.MemberInfoForm)
    this.MemberInfoForm.get('dob').setValue((new Date(this.MemberInfoForm.get('dob').value)).toUTCString());
    //this.MemberInfoForm.get('expireDate').setValue((new Date(this.MemberInfoForm.get('expireDate').value)).toUTCString());

    console.log(this.MemberInfoForm.value)
    const formData = new FormData();
    for (const key of Object.keys(this.MemberInfoForm.value)) {
      const value = this.MemberInfoForm.value[key];
      formData.append(key, value);
    }
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.MemberInfoService.update(+id,formData).subscribe(response => {
            this.router.navigateByUrl('/member-demand/profile-update');
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
      this.MemberInfoService.submit(formData).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        //this.router.navigateByUrl('/member-demand/profile-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
