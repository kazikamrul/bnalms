import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {MemberRegistrationService} from '../../service/MemberRegistration.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { MemberRegistration } from '../../models/MemberRegistration';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-memberregistration',
  templateUrl: './new-memberregistration.component.html',
  styleUrls: ['./new-memberregistration.component.sass']
})
export class NewMemberRegistrationComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  MemberRegistrationForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
  bookInformationId:any;
  branchId:any;
  baseSchoolId:any;
  MemberRegistrationList:MemberRegistration[];
  selectedMemberCategory:SelectedModel[];
  selectedDesignation:SelectedModel[];
  selectedJobStatus:SelectedModel[];
  selectedRank:SelectedModel[];
  selectedArea:SelectedModel[];
  selectedBase:SelectedModel[];
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

  displayedColumns: string[] = [ 'sl','memberName','area','director','mobileNoPersonal','email','expireDate','imageUrl', 'actions'];
  dataSource: MatTableDataSource<MemberRegistration> = new MatTableDataSource();
  selection = new SelectionModel<MemberRegistration>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private MemberRegistrationService: MemberRegistrationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('memberRegistrationId'); 
    //this.bookInformationId = this.route.snapshot.paramMap.get('bookInformationId');

    // this.role = this.authService.currentUserValue.role.trim();
    // this.branchId =  this.authService.currentUserValue.branchId.trim();
    // console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Member Registration';
      this.destination='Edit';
      this.buttonText="Update";
      this.MemberRegistrationService.find(+id).subscribe(
        res => {
          this.MemberRegistrationForm.patchValue({          

            memberRegistrationId: res.memberRegistrationId,
            bookInformationId: res.bookInformationId,
            memberCategoryId:res.memberCategoryId,
            baseSchoolNameId:res.baseSchoolNameId,
            rankId:res.rankId,
            designationId: res.designationId,
            areaId:res.areaId,
            baseId:res.baseId,
            jobStatusId: res.jobStatusId,
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
            pno:res.pno,
            department: res.department,
            tntOffice: res.tntOffice,
            mobileNoOffice:res.mobileNoOffice,
            familyContact:res.familyContact,
            mobileNoPersonal:res.mobileNoPersonal,
            issueQty:res.issueQty,
            lastPaymentDate:res.lastPaymentDate,
            //menuPosition: res.menuPosition,
          
          });   
          this.getselectedRank();
           //this.onShelfNameelectionChangeGetRowName(res.shelfInfoId)
        }
      );
    } else {
      this.pageTitle = 'Create Member Registration';
      this.destination='Add';
      this.buttonText="Registrar";
    }
    this.intitializeForm();
    // if(this.role != this.userRole.SuperAdmin){
    //   this.MemberRegistrationForm.get('baseSchoolNameId').setValue(this.branchId);
    //   this.getMemberInfoListByDepartment();
      
    // }
    //this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getselectedMemberCategory();
    this.getselectedDesignation();
    this.getselectedArea();
    this.getselectedBase();
  }
  intitializeForm() {
    this.MemberRegistrationForm = this.fb.group({
      memberRegistrationId: [0],
      baseSchoolNameId: [''],
      //bookInformationId:[],
      memberCategoryId:[''],
       issueQty:[''],
       lastPaymentDate:[''],
      rankId: [''],
      designationId: [''],
      areaId:[''],
      baseId:[''],
      jobStatusId: [''],
      //memberInfoIdentity:[''],
      email:[''],
      imageUrl: [''],
      photo:[''],
      region:[''],
      director:[''],
      memberName:[''],
      fatherName: [''],
      motherName: [],
      yearlyFee:[''],
      presentAddress: [],
      permanentAddress: [],
      nid: [''],
      sex:[''],
      issueDate: [],
      expireDate: [],
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
// onFileChanged(event) {
//   if (event.target.files.length > 0) {
//     const file = event.target.files[0];
//     console.log('dddd')
//    console.log(file);
//     this.MemberInfoForm.patchValue({
//       photo: file,
//     });
//   }
// }
// GetDepartmentNameById(baseNameId){    
//   this.MemberRegistrationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
//     this.departmentName=res
//     console.log("departmentName")
//     console.log(this.departmentName)
//   }); 
// }
// getMemberInfoListByDepartment(){
//   this.isShown=true;
//   var baseSchoolNameId =this.MemberRegistrationForm.value['baseSchoolNameId'];
//   console.log(baseSchoolNameId);
//     this.MemberRegistrationService.getMemberInfoListByDepartment(baseSchoolNameId).subscribe(res=>{
//       this.memberInfoList=res
//       console.log( this.memberInfoList);
    
//     });
// }
getselectedMemberCategory(){
    this.MemberRegistrationService.getselectedMemberCategory().subscribe(res=>{
      this.selectedMemberCategory=res
    });
  }
  getselectedDesignation(){
    this.MemberRegistrationService.getselectedDesignation().subscribe(res=>{
      this.selectedDesignation=res
    });
  }
  // getselectedJobStatus(){
  //   this.MemberRegistrationService.getselectedJobStatus().subscribe(res=>{
  //     this.selectedJobStatus=res
  //   });
  // }
  getselectedRank(){
    var designationId = this.MemberRegistrationForm.value['designationId'];
    this.MemberRegistrationService.getselectedRank(designationId).subscribe(res=>{
      this.selectedRank=res
      console.log("selectedRank" )
      console.log(this.selectedRank )
    });
  }
  getselectedArea(){
    this.MemberRegistrationService.getselectedArea().subscribe(res=>{
      this.selectedArea=res
    });
  }
  getselectedBase(){
    this.MemberRegistrationService.getselectedBase().subscribe(res=>{
      this.selectedBase=res
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.MemberRegistrationForm.get('memberRegistrationId').value;   
    //this.MemberRegistrationForm.get('baseSchoolNameId').setValue(this.branchId);
    //this.MemberRegistrationForm.get('bookInformationId').setValue(this.bookInformationId);
    console.log(this.MemberRegistrationForm)
    //this.MemberRegistrationForm.get('issueDate').setValue((new Date(this.MemberRegistrationForm.get('issueDate').value)).toUTCString());
    //this.MemberRegistrationForm.get('expireDate').setValue((new Date(this.MemberRegistrationForm.get('expireDate').value)).toUTCString());

    // console.log(this.MemberRegistrationForm.value)
    // const formData = new FormData();
    // for (const key of Object.keys(this.MemberRegistrationForm.value)) {
    //   const value = this.MemberRegistrationForm.value[key];
    //   formData.append(key, value);
    // }
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.MemberRegistrationService.update(+id,this.MemberRegistrationForm.value).subscribe(response => {
            this.router.navigateByUrl('/member-management/add-memberregistration');
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
      this.MemberRegistrationService.submit(this.MemberRegistrationForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Registration Successfully ', '', {
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
    const id = row.memberRegistrationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.MemberRegistrationService.delete(id).subscribe(() => {
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
