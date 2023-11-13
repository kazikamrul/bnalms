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
  selector: 'app-new-memberinfo',
  templateUrl: './new-memberinfo.component.html',
  styleUrls: ['./new-memberinfo.component.sass']
})
export class NewMemberInfoComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  MemberInfoForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
  bookInformationId:any;
  branchId:any;
  baseSchoolId:any;
  memberInfoList:any;
  selectedMemberCategory:SelectedModel[];
  selectedDesignation:SelectedModel[];
  selectedJobStatus:SelectedModel[];
  selectedRank:SelectedModel[];
  selectedShelfInfo:SelectedModel[];
  selectedSource:SelectedModel[];
  departmentName:SelectedModel[];
  options = [];
  filteredOptions;
  isShown: boolean = false ;
  bookTitleInfoId:number;
  issuableToggle:string;
  illustrationsToggle:string;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','memberName','director','mobileNoPersonal','email','expireDate', 'imageUrl', 'actions'];
  dataSource: MatTableDataSource<MemberInfo> = new MatTableDataSource();
  selection = new SelectionModel<MemberInfo>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private MemberInfoService: MemberInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('memberInfoId'); 
    //this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

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
            //memberInfoIdentity: res.memberInfoIdentity,
            email:res.email,
            imageUrl: res.imageUrl,
            region:res.region,
            director:res.director,
            memberName: res.memberName,
            memberShipDate: res.memberShipDate,
            memberExpireDate: res.memberExpireDate,
            memberShipNumber: res.memberShipNumber,
            fatherName: res.fatherName,
            motherName:res.motherName,
            yearlyFee: res.yearlyFee,
            presentAddress: res.presentAddress,
            permanentAddress: res.permanentAddress,
            nid:res.nid,
            sex: res.sex,
            issueDate: res.issueDate,
            expireDate: res.expireDate,
            pno:res.pno,
            department: res.department,
            tntOffice: res.tntOffice,
            mobileNoOffice:res.mobileNoOffice,
            familyContact:res.familyContact,
            mobileNoPersonal:res.mobileNoPersonal,
            //issueQty:res.issueQty,
            //lastPaymentDate:res.lastPaymentDate,
            //menuPosition: res.menuPosition,
          
          });   
          this.getselectedRank();
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
      this.getMemberInfoListByDepartment();
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getselectedMemberCategory();
    this.getselectedDesignation();
    this.getselectedJobStatus();
    //this.getselectedRank();
  }
  intitializeForm() {
    this.MemberInfoForm = this.fb.group({
      memberInfoId: [0],
      baseSchoolNameId: [''],
      //bookInformationId:[],
      memberCategoryId:[''],
       issueQty:[''],
       lastPaymentDate:[''],
      rankId: [''],
      designationId: [''],
      jobStatusId: [''],
      //memberInfoIdentity:[''],
      email:[''],
      imageUrl: [''],
      photo:[''],
      region:[''],
      director:[''],
      memberName:[''],
      memberShipDate:[''],
      memberExpireDate:[''],
      memberShipNumber:[],
      fatherName: [''],
      motherName: [],
      yearlyFee:[''],
      presentAddress: [],
      permanentAddress: [],
      nid: [''],
      sex:[''],
      issueDate: [],
      //expireDate: [],
      pno: [],
      department:[],
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
getMemberInfoListByDepartment(){
  this.isShown=true;
  var baseSchoolNameId =this.MemberInfoForm.value['baseSchoolNameId'];
  console.log(baseSchoolNameId);
    this.MemberInfoService.getMemberInfoListByDepartment(baseSchoolNameId).subscribe(res=>{
      this.memberInfoList=res
      console.log( this.memberInfoList);
      console.log( "memberInfoList");
    
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
      //this.getselectedRank();
    });
  }
  getselectedJobStatus(){
    this.MemberInfoService.getselectedJobStatus().subscribe(res=>{
      this.selectedJobStatus=res
    });
  }
  getselectedRank(){
    var designationId = this.MemberInfoForm.value['designationId'];
    this.MemberInfoService.getselectedRank(designationId).subscribe(res=>{
      this.selectedRank=res
      console.log("selectedRank" )
      console.log(this.selectedRank )
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
    //this.MemberInfoForm.get('baseSchoolNameId').setValue(this.branchId);
    //this.MemberInfoForm.get('bookInformationId').setValue(this.bookInformationId);
    console.log(this.MemberInfoForm)
    this.MemberInfoForm.get('issueDate').setValue((new Date(this.MemberInfoForm.get('issueDate').value)).toUTCString());
    this.MemberInfoForm.get('memberShipDate').setValue((new Date(this.MemberInfoForm.get('memberShipDate').value)).toUTCString());
    this.MemberInfoForm.get('memberExpireDate').setValue((new Date(this.MemberInfoForm.get('memberExpireDate').value)).toUTCString());

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
            this.router.navigateByUrl('/member-management/add-memberinfo');
            //this.reloadCurrentRoute();
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
        //this.router.navigateByUrl('/member-management/memberinfo-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  deleteItem(row) {
    const id = row.memberInfoId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.MemberInfoService.delete(id).subscribe(() => {
          //this.getMemberInfos();
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
