import { Component, OnInit,ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MemberInfo } from '../../models/MemberInfo';
import { MemberInfoService } from '../../service/MemberInfo.service';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import { MasterData } from 'src/assets/data/master-data';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import { AuthService } from 'src/app/core/service/auth.service';

@Component({
  selector: 'app-view-memberinfo',
  templateUrl: './view-memberinfo.component.html',
  styleUrls: ['./view-memberinfo.component.sass']
})
export class ViewMemberInfoComponent implements OnInit {

  masterData = MasterData;
  showHideDiv:any;
  ELEMENT_DATA: MemberInfo[] = [];
  isLoading = false;
  pageTitle:any;
  memberInfoId: number; 
  memberCategoryId: number;
  memberCategory:any;
  rankId:number;
  rank:string;
  designationId: number;
  designation:string;
  jobStatusId: number;
  jobStatus:any;
  pno: any;
  region:any;
  director:any;
  yearlyFee: any;
  memberName: any;
  memberShipDate:any;
  memberExpireDate:any;
  memberShipNumber:any;
  fatherName:any;
  motherName: any;
  presentAddress:any;
  permanentAddress: any;
  email:any;
  nid: any;
  sex: any;
  issueDate: Date;
  expireDate: Date;
  department: any;
  tntOffice: any;
  mobileNoOffice: any;
  familyContact: any;
  mobileNoPersonal: any;
  imageUrl: string;
  profileStatus:any;

  constructor(private route: ActivatedRoute,private authService: AuthService,private snackBar: MatSnackBar,private MemberInfoService: MemberInfoService,private router: Router,private confirmService: ConfirmService) { }
  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('memberInfoId'); 
    this.profileStatus = this.route.snapshot.paramMap.get('profileStatus'); 
    if(this.profileStatus){
      this.pageTitle = 'View Profile';
      console.log('inside');
      var minfoId = this.authService.currentUserValue.traineeId;
      
      this.memberInfoId = Number(minfoId);
      console.log(this.memberInfoId);
      console.log("this.memberInfoId");
    }
    this.MemberInfoService.find(+id).subscribe( res => {
      console.log(res);
      console.log("member data");
      this.memberInfoId= res.memberInfoId,
      this.memberCategoryId=res.memberCategoryId,
      this.memberCategory=res.memberCategory,
      this.rankId = res.rankId,
      this.rank = res.rank,
      this.designationId= res.designationId,
      this.designation= res.designation,
      this.jobStatusId=res.jobStatusId,
      this.jobStatus = res.jobStatus,
      this.pno= res.pno,
      this.region= res.region,
      this.director= res.director,
      this.yearlyFee= res.yearlyFee,
      this.memberName= res.memberName,
      this.memberShipDate=res.memberShipDate,
      this.memberExpireDate=res.memberExpireDate,
      this.memberShipNumber=res.memberShipNumber,
      this.fatherName=res.fatherName,
      this.motherName = res.motherName,
      this.presentAddress= res.presentAddress,
      this.permanentAddress= res.permanentAddress,
      this.email=res.email,
      this.nid=res.nid,
      this.sex=res.sex,
      this.issueDate=res.issueDate,
      this.expireDate=res.expireDate,
      this.department=res.department,
      this.tntOffice=res.tntOffice,
      this.mobileNoOffice=res.mobileNoOffice,
      this.familyContact=res.familyContact,
      this.mobileNoPersonal=res.mobileNoPersonal,
      this.imageUrl=res.imageUrl
      
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
                  
                    .table.table-bordered-v tr .imageUrl{
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
          <h3>Member Information Details</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }
}
