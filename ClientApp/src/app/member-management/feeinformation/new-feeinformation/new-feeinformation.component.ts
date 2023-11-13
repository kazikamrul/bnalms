import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PageEvent } from '@angular/material/paginator';
import { ActivatedRoute, Router } from '@angular/router';
import {FeeInformationService} from '../../service/FeeInformation.service'
import { MatSnackBar } from '@angular/material/snack-bar';
import { ConfirmService } from '../../../core/service/confirm.service';
import { MasterData } from 'src/assets/data/master-data';
import { MatTableDataSource } from '@angular/material/table';
import { FeeInformation } from '../../models/FeeInformation';
import { SelectionModel } from '@angular/cdk/collections';
import { AuthService } from 'src/app/core/service/auth.service';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MemberInfoService } from '../../service/MemberInfo.service';
import { Role } from 'src/app/core/models/role';

@Component({
  selector: 'app-new-feeinformation',
  templateUrl: './new-feeinformation.component.html',
  styleUrls: ['./new-feeinformation.component.sass']
})
export class NewFeeInformationComponent implements OnInit {
  masterData = MasterData;
  buttonText:string;
  pageTitle: string;
  destination:string;
  FeeInformationForm: FormGroup;
  validationErrors: string[] = [];
  isLoading = false;
  role:any;
  showHideDiv:any;
  userRole=Role;
  branchId:any;
  baseSchoolId:any;
  feeInformationList: any[];
  selectedFeeCategory:SelectedModel[];
  selectedMemberName:SelectedModel[];
  departmentName:SelectedModel[];
  itemValue: string;
  groupArrays: { pno: string; datas: any }[];
  options = [];
  isCategoryShow = false;
  filteredOptions;
  bookTitleInfoId:number;
  issuableToggle:string;
  memberInfoId: number;
  illustrationsToggle:string;
  getmemberinfoid: number;
  getmembername: string;
  memberName:any;
  rank:any;
  isShown: boolean = false ;
  designation:any;
  department:any;
  mobileNoPersonal:any
  lostDamage: any;
  feeAnual: any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  displayedColumns: string[] = [ 'sl','accessionNo','pno','cagegory','paidAmount','paidDate','expiredDate', 'actions'];
  dataSource: MatTableDataSource<FeeInformation> = new MatTableDataSource();
  selection = new SelectionModel<FeeInformation>(true, []);
  constructor(private snackBar: MatSnackBar,private authService: AuthService,private MemberInfoService: MemberInfoService,private confirmService: ConfirmService,private FeeInformationService: FeeInformationService,private fb: FormBuilder, private router: Router,  private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('feeInformationId'); 

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    if (id) {
      this.pageTitle = 'Edit Fee Information';
      this.destination='Edit';
      this.buttonText="Update";
      this.FeeInformationService.find(+id).subscribe(
        res => {
          this.FeeInformationForm.patchValue({          

            feeInformationId: res.feeInformationId,
            memberInfoId: res.memberInfoId,
            bookInformationId:res.bookInformationId,
            feeCategoryId:res.feeCategoryId,
            baseSchoolNameId:res.baseSchoolNameId,
            paidDate:res.paidDate,
            expiredDate:res.expiredDate,
            paidAmount:res.paidAmount,
            receivedAmount:res.receivedAmount,
            pno:res.pno,
           
          
          });   
          this.memberInfoId=res.memberInfoId;
          this.onMemberNameById(this.memberInfoId);
          this.getCategoryField();
        }
      );
    } else {
      this.pageTitle = 'Create Fee Information';
      this.destination='Add';
      this.buttonText="Save";
    }
    this.intitializeForm();
    if(this.role != this.userRole.SuperAdmin){
      this.FeeInformationForm.get('baseSchoolNameId').setValue(this.branchId);
      //this.FeeInformationForm.get('memberInfoId').setValue(this.memberInfoId)
      this.getFeeInformationListByPNO();
      
    }
    this.GetDepartmentNameById(this.masterData.schoolDept.issakhanLMS);
    this.getselectedFeeCategory();
  }
  intitializeForm() {
    this.FeeInformationForm = this.fb.group({
      feeInformationId: [0],
      memberInfoId: [''],
      bookInformationId:[''],
      accessionNo:[''],
      pno:[''],
      baseSchoolNameId:[''],
      feeCategoryId:[''],
      paidDate: [''],
      expiredDate:[''],
      paidAmount: [''],
      receivedAmount: [''],
      isActive: [true],
     
    })
    //autocomplete for pno
    this.FeeInformationForm.get('pno').valueChanges
    .subscribe(value => {
        this.getSelectedPno(value);
    })
     //autocomplete for accessionNo
     this.FeeInformationForm.get('accessionNo').valueChanges
     .subscribe(value => {
         this.getSelectedAccessionNo(value);
     })
  }
  //autocomplete for pno
  onPnoSelectionChanged(item) {
  this.bookTitleInfoId = item.value
  this.FeeInformationForm.get('memberInfoId').setValue(item.value);
  this.FeeInformationForm.get('pno').setValue(item.text);
  console.log(item.value);
  //this.FeeInformationForm.get('memberInfoId').value;

  this.onMemberNameById(item.value);
  this.getFeeInformationListByPNO();
}
  //autocomplete for pno
  getSelectedPno(pno){
  this.FeeInformationService.getSelectedPno(pno).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}
 //autocomplete for accessionNo
 onAccessionNoSelectionChanged(item) {
  this.bookTitleInfoId = item.value
  this.FeeInformationForm.get('bookInformationId').setValue(item.value);
  this.FeeInformationForm.get('accessionNo').setValue(item.text);
  console.log(item.value);
  //this.FeeInformationForm.get('memberInfoId').value;

  //this.onTitleById(item.value);
}
  //autocomplete for accessionNo
  getSelectedAccessionNo(accessionNo){
  this.FeeInformationService.getSelectedAccessionNo(accessionNo).subscribe(response => {
    this.options = response;
    this.filteredOptions = response;
  })
}
getFeeInformationListByPNO(){
  this.isShown=true;
  var memberInfoId =this.FeeInformationForm.value['memberInfoId'];
  console.log(memberInfoId);
    this.FeeInformationService.getFeeInformationListByPNO(memberInfoId).subscribe(res=>{
      this.feeInformationList=res
      console.log( this.feeInformationList);

      const groups = this.feeInformationList.reduce((groups, datas) => {
        const pno = datas.pno;
        if (!groups[pno]) {
          groups[pno] = [];
        }
        groups[pno].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((pno) => {
        return {
          pno,
          datas: groups[pno],
        };
      });
      console.log("group array");
      console.log(this.groupArrays);
    
    });
}
getCategoryField() {
  var feeCategoryId = this.FeeInformationForm.value["feeCategoryId"];
  if (feeCategoryId == 1) {
    console.log("feeCategoryId "+feeCategoryId);
    this.isCategoryShow = true;
  } else {
    this.isCategoryShow = false;
  }
}
onDamage(dropdown) {
  if (dropdown.isUserInput) {
    this.lostDamage = dropdown.source.value;
    console.log(this.lostDamage);
  }
 
}
toggle() {
  this.showHideDiv = !this.showHideDiv;
}
printSingle() {
  this.showHideDiv = false;
  this.print();
}
print() {
  let printContents, popupWin;
  printContents = document.getElementById("print-routine").innerHTML;
  popupWin = window.open("", "_blank", "top=0,left=0,height=100%,width=auto");
  popupWin.document.open();
  popupWin.document.write(`
    <html>
      <head>
        <style>
        body{  width: 99%;}
          label { font-weight: 400;
                  font-size: 13px;
                  padding: 2px;
                  margin-bottom: 5px;
                }
          table, td, th {
                border: 1px solid silver;
                  }
                  table td {
                font-size: 13px;
                  }
                
                  .table.table.tbl-by-group.db-li-s-in tr .cl-mrk-rmrk-act{
                    display: none;
                  }
                  .table.table.tbl-by-group.db-li-s-in tr .cl-itemnames{
                    display: none;
                  }

                  .table.table.tbl-by-group.db-li-s-in tr .cl-trade{
                    display: none;
                  }
      
                  .table.table.tbl-by-group.db-li-s-in tr td{
                    text-align:center;
                    padding: 0px 5px;
                  }
                  table th {
                font-size: 13px;
                  }
            table {
                  border-collapse: collapse;
                  width: 98%;
                  }
              th {
                  height: 26px;
                  }
              .header-text{
                text-align:center;
              }
              .header-text h3{
                margin:0;
              }
        </style>
      </head>
      <body onload="window.print();window.close()">
        <div class="header-text">
        <h3>Fee Information List</h3>
        
        </div>
        <br>
        <hr>
        ${printContents}
        
      </body>
    </html>`);
  popupWin.document.close();
}
// onfeeAnual(dropdown) {
//   if (dropdown.isUserInput) {
//     this.feeAnual = dropdown.source.value;
//     console.log(this.feeAnual);
//   }
// }
GetDepartmentNameById(baseNameId){    
  this.FeeInformationService.getSelectedSchoolName(baseNameId).subscribe(res=>{
    this.departmentName=res
    console.log("departmentName")
    console.log(this.departmentName)
  }); 
}
getselectedFeeCategory(){
    this.FeeInformationService.getselectedFeeCategory().subscribe(res=>{
      this.selectedFeeCategory=res
    });
  }
  
  onMemberNameById(id: number) {
    console.log(id);
    this.MemberInfoService.find(id).subscribe(res => {
      console.log(res);
      console.log("Member Info");
      this.memberName = res.memberName
      this.rank=res.rank
      this.designation = res.designation
      this.department = res.department
      this.mobileNoPersonal = res.mobileNoPersonal
    
    });
  }
  
  
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });
  }
  
  onSubmit() {
    const id = this.FeeInformationForm.get('feeInformationId').value;   
    //this.FeeInformationForm.get('baseSchoolNameId').setValue(this.branchId);
    
    if (id) {
      this.confirmService.confirm('Confirm Update message', 'Are You Sure Update This Item?').subscribe(result => {
        console.log(result);
        if (result) {
          this.FeeInformationService.update(+id,this.FeeInformationForm.value).subscribe(response => {
            this.router.navigateByUrl('/member-management/add-feeinformation');
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
      this.FeeInformationService.submit(this.FeeInformationForm.value).subscribe(response => {
        this.reloadCurrentRoute();
        this.snackBar.open('Information Saved Successfully ', '', {
          duration: 2000,
          verticalPosition: 'bottom',
          horizontalPosition: 'right',
          panelClass: 'snackbar-success'
        });
        //this.router.navigateByUrl('/member-management/feeinformation-list');
      }, error => {
        this.validationErrors = error;
      })
    }
 
  }
  deleteItem(row) {
    const id = row.feeInformationId; 
    this.confirmService.confirm('Confirm delete message', 'Are You Sure Delete This  Item?').subscribe(result => {
      console.log(result);
      if (result) { 
        this.FeeInformationService.delete(id).subscribe(() => {
          //this.getFeeInformations();
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
