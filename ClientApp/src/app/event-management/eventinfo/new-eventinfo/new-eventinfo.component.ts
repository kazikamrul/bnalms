import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {EventInfoService} from '../../service/EventInfo.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { EventInfo } from '../../models/EventInfo';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-eventinfo',
  templateUrl: './new-eventinfo.component.html',
  styleUrls: ['./new-eventinfo.component.sass']
})
export class NewEventInfoComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  EventInfoForm: FormGroup;
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

  
  dataSource: MatTableDataSource<EventInfo> = new MatTableDataSource();
  selection = new SelectionModel<EventInfo>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private EventInfoService: EventInfoService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('eventInfoId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Event Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.EventInfoService.find(+id).subscribe(
        res => {
          this.EventInfoForm.patchValue({          

            eventInfoId: res.eventInfoId,
            baseSchoolNameId: res.baseSchoolNameId,
            eventName:res.eventName,
            eventSubject:res.eventSubject,
            eventPurpose:res.eventPurpose,
            eventLocation:res.eventLocation,
            eventGuest:res.eventGuest,
            eventCharge:res.eventCharge,
            eventFrom:res.eventFrom,
            eventTo:res.eventTo,
            partcipant:res.partcipant,
            eventBudget:res.eventBudget,
            approveBadget:res.approveBadget,
            approvedName:res.approvedName,
            budgetDate:res.budgetDate,
            remarks:res.remarks,
           
           
            
          });   
          //this.memberInfoId=res.memberInfoId;
        }
      );
    } else {
      this.pageTitle = 'Create Event Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.EventInfoForm.get('baseSchoolNameId').setValue(this.branchId);
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    //this.getselectedFeeCategory();
  }
  intitializeForm() {
    this.EventInfoForm = this.fb.group({
      eventInfoId: [0],
      baseSchoolNameId: [''],
      eventName:[''],
      eventSubject:[''],
      eventPurpose:[''],
      eventLocation: [''],
      eventGuest: [''],
      eventCharge:[''],
      eventFrom: [''],
      eventTo: [''],
      partcipant: [''],
      eventBudget: [''],
      approveBadget: [''],
      approvedName: [''],
      budgetDate: [''],
      remarks: [''],
      isActive: [true],
     
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.EventInfoService.getSelectedSchoolName(baseNameId).subscribe(res=>{
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
    const id = this.EventInfoForm.get('eventInfoId').value;   
    this.EventInfoForm.get('baseSchoolNameId').setValue(this.branchId);
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.EventInfoService.update(+id,this.EventInfoForm.value).subscribe(response => {
            this.router.navigateByUrl('/event-management/eventinfo-list');
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
      this.EventInfoService.submit(this.EventInfoForm.value).subscribe(response => {
        //this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        this.router.navigateByUrl('/event-management/eventinfo-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  

}
