import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
//import { InterServiceDashboardService } from '../services/InterServiceDashboard.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/core/models/role';
import { DashboardService } from '../service/Dashboard.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-myissuebookformember-list',
  templateUrl: './myissuebookformember-list.component.html',
  styleUrls: ['./myissuebookformember-list.component.sass']
})
export class MyIssueBookforMemberListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  MyIssueBookforMemberForm: FormGroup;
  groupArrays: { departmentName: string; datas: any }[];
  bookIssuList:any;
  CountBookIssue:any;
  showHideDiv:any;
  // courseDurationId:number;
  // courseNameId:number;
  // courseTypeId:number;
  // traineeStatusId:number;
  // jcoCourseList:any;
  // baseSchoolNameId:any;
  // titleText:any;
  // dbType:any;
  // dbType1:any;
  // courseType3:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  memberInfoId:any;
  branchId:any;
  traineeId:any;
  role:any;

  displayedColumns: string[] = ['ser','name','duration', 'candidates', 'subject'];

  
  constructor(private datepipe: DatePipe,private _location: Location,private DashboardService:DashboardService,private fb: FormBuilder,private route: ActivatedRoute, private authService: AuthService,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('memberInfoId'); 
    //this.FeeInformationForm.get('baseSchoolNameId').setValue(this.branchId);
   
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId)
   
    this.getBookIssueListForMemberByMemberInfoId();
   
  }
  backClicked() {
    this._location.back();
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
                  
                    .table.table.tbl-by-group.db-li-s-in tr .cl-action{
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
          <h3>My Issued Book List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  applyFilter(searchText){

  }
  getBookIssueListForMemberByMemberInfoId() {
    this.DashboardService.getBookIssueListForMemberByMemberInfoId(this.traineeId).subscribe(response => {           
      this.bookIssuList=response;
      this.CountBookIssue = response.length;
      console.log("MY Book Issue List");
      console.log(this.bookIssuList);
      console.log("MY Book Issue List Count");
      console.log(this.CountBookIssue);

       // this gives an object with dates as keys
       const groups = this.bookIssuList.reduce((groups, datas) => {
        const departmentName = datas.departmentName;
        if (!groups[departmentName]) {
          groups[departmentName] = [];
        }
        groups[departmentName].push(datas);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          datas: groups[departmentName],
        };
      });
      console.log("group array");
      console.log(this.groupArrays);
    })
  }

  
}
