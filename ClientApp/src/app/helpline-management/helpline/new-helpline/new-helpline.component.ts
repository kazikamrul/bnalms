import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {HelpLineService} from '../../service/HelpLine.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { HelpLine } from '../../models/HelpLine';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-helpline',
  templateUrl: './new-helpline.component.html',
  styleUrls: ['./new-helpline.component.sass']
})
export class NewHelpLineComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  HelpLineForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  userRole=Role;
  branchId:any;
  helpLineList:HelpLine[];
  baseSchoolId:any;
  selectedFeeCategory:SelectedModel[];
  selectedMemberName:SelectedModel[];
  departmentName:SelectedModel[];
  selectedLibraryAuthorities:SelectedModel[];
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
  isShown: boolean = false ;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  groupArrays: { libraryName: string; datas: any }[];

  displayedColumns: string[] = [ 'sl','libraryAuthority','helpContact','emailAddress', 'actions'];
  dataSource: MatTableDataSource<HelpLine> = new MatTableDataSource();
  selection = new SelectionModel<HelpLine>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private confirmService: ConfirmService,private HelpLineService: HelpLineService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('helpLineId'); 

    // this.userRole.Member
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Help Line';
      this.destination='Edit';
      this.buttonText="Update";
      this.HelpLineService.find(+id).subscribe(
        res => {
          this.HelpLineForm.patchValue({          

            helpLineId: res.helpLineId,
            baseSchoolNameId: res.baseSchoolNameId,
            helpContact:res.helpContact,
            emailAddress:res.emailAddress,
            libraryAuthorityId:res.libraryAuthorityId,
            menuPosition:res.menuPosition,
            dashboardDisplayStatus:res.dashboardDisplayStatus,
           
           
            
          });   
          this.getselectedLibraryAuthorities();
          //this.memberInfoId=res.memberInfoId;
        }
      );
    } else {
      this.pageTitle = 'Create Help Line';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.HelpLineForm.get('baseSchoolNameId').setValue(this.branchId);
      this.getHelpLineListByDepartment();
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getselectedLibraryAuthorities();
  }
  intitializeForm() {
    this.HelpLineForm = this.fb.group({
      helpLineId: [0],
      baseSchoolNameId: [''],
      helpContact:[''],
      emailAddress:[''],
      libraryAuthorityId:[''],
      dashboardDisplayStatus: [''],
      isActive: [true],
     
    })
  }
  GetDepartmentNameById(baseNameId){    
    this.HelpLineService.getSelectedSchoolName(baseNameId).subscribe(res=>{
      this.departmentName=res
      console.log("departmentName")
      console.log(this.departmentName)
    }); 
  }
  getHelpLineListByDepartment(){
    this.isShown=true;
    var baseSchoolNameId =this.HelpLineForm.value['baseSchoolNameId'];
    if(this.role == this.userRole.Member){
      baseSchoolNameId = 0;
    }
    console.log(baseSchoolNameId);
      this.HelpLineService.getHelpLineListByDepartment(baseSchoolNameId).subscribe(res=>{
        this.helpLineList=res;
        console.log( this.helpLineList);

        // this gives an object with dates as keys
       const groups = this.helpLineList.reduce((groups, datas) => {
        const libraryName = datas.schoolName;
        if (!groups[libraryName]) {
          groups[libraryName] = [];
        }
        groups[libraryName].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((libraryName) => {
        return {
          libraryName,
          datas: groups[libraryName],
        };
      });
      console.log("group array");
      console.log(this.groupArrays);
      
      });
  }
  getselectedLibraryAuthorities(){
    this.HelpLineService.getselectedLibraryAuthorities().subscribe(res=>{
      this.selectedLibraryAuthorities=res
    });
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.HelpLineForm.get('helpLineId').value;   
    //this.HelpLineForm.get('baseSchoolNameId').setValue(this.branchId);
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.HelpLineService.update(+id,this.HelpLineForm.value).subscribe(response => {
            this.router.navigateByUrl('/helpline-management/add-helpline');
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
      this.HelpLineService.submit(this.HelpLineForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        //this.router.navigateByUrl('/helpline-management/add-helpline');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  deleteItem(row) {
    const id = row.helpLineId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.HelpLineService.delete(id).subscribe(() => {
          this.reloadCurrentRoute();
          //this.getEventInfos();
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
