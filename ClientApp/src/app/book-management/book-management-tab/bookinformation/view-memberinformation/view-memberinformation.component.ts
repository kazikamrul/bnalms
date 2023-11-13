import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { BookInformation } from '../../models/BookInformation';
import { BookInformationService } from '../../service/BookInformation.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import {MemberInfoService} from '../../../../member-management/service/MemberInfo.service'

@Component({
  selector: 'app-view-memberinformation',
  templateUrl: './view-memberinformation.component.html',
  styleUrls: ['./view-memberinformation.component.sass']
})
export class ViewMemberInformationComponent implements OnInit {

  masterData = MasterData;
  showHideDiv:any;
  ELEMENT_DATA: BookInformation[] = [];
  isLoading = false;
    role:any;
    branchId:any;
    userRole = Role;

    memberInfoId: any;
    bookInformationId: any;
    baseSchoolNameId: any;
    memberCategoryId: any;
    rankId: any;
    designationId: any;
    jobStatusId: any;
    areaId: any;
    baseId: any;
    securityQuestionId: any;
    answer: any;
    memberInfoIdentity: any;
    email: any;
    imageUrl: any;
    region: any;
    director: any;
    memberName: any;
    fatherName: any;
    motherName: any;
    yearlyFee: any;
    presentAddress: any;
    permanentAddress:any;
    nid: any;
    sex: any;
    issueDate: any;
    expireDate:any;
    dob: any;
    pno: any;
    department: any;
    tntOffice: any;
    mobileNoOffice: any;
    familyContact: any;
    mobileNoPersonal: any;
    empStatus: any;
    menuPosition: any;
    isActive: any;
    issueQty: any;
    lastPaymentDate: any;
    memberCategory:any; 
    rank: any;
    designation: any;
    jobStatus: any

  constructor(private route: ActivatedRoute,private authService: AuthService,private MemberInfoService: MemberInfoService,private snackBar: MatSnackBar,private BookInformationService: BookInformationService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"-"+ this.branchId)

    const id = this.route.snapshot.paramMap.get('memberInfoId'); 
    this.MemberInfoService.find(+id).subscribe( res => {
      console.log(res);
      this.memberName= res.memberName;
      this.email= res.email;
      this.fatherName= res.fatherName;
      this.motherName= res.motherName;
      this.presentAddress= res.presentAddress;
      this.permanentAddress=res.permanentAddress;
      this.nid= res.nid;
      this.sex= res.sex;
      this.issueDate= res.issueDate;
      this.expireDate=res.expireDate;
      this.dob= res.dob;
      this.pno= res.pno;
      this.department= res.department;
      this.tntOffice= res.tntOffice;
      this.mobileNoOffice= res.mobileNoOffice;
      this.familyContact= res.familyContact;
      this.mobileNoPersonal= res.mobileNoPersonal;
      this.region= res.region;
      this.director= res.director;
      this.yearlyFee= res.yearlyFee;
      this.isActive= res.isActive;
      this.issueQty= res.issueQty;
      this.lastPaymentDate= res.lastPaymentDate;
      this.memberCategory=res.memberCategory;
      this.rank= res.rank;
      this.designation= res.designation;
      this.jobStatus= res.jobStatus
      this.memberInfoId = res.memberInfoId;
      this.bookInformationId = res.bookInformationId;
      this.baseSchoolNameId= res.baseSchoolNameId;
      this.memberInfoIdentity= res.memberInfoIdentity;
      this.imageUrl= res.imageUrl;  
    })
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
                    td{
                      padding-left:5px;
                    }
                  
                    .table.table-bordered-v tr .coverImage{
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
          <h3>Member Info Details</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
}
