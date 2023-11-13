import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
//import { InterServiceDashboardService } from '../services/InterServiceDashboard.service';
import {MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from 'src/app/core/service/auth.service';
import { DatePipe } from '@angular/common';
import { Role } from 'src/app/core/models/role';
//import { DashboardService } from '../service/Dashboard.service';
import { DashboardService } from 'src/app/admin/dashboard/service/Dashboard.service';

@Component({
  selector: 'app-memberfine-list',
  templateUrl: './memberfine-list.component.html',
  styleUrls: ['./memberfine-list.component.sass']
})
export class MemberFineListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  bookList:any;
  bookListForFine:any;
  showHideDiv:any;
  onlineRequestCount:any;
  groupArrays: { schoolName: string; datas: any }[];
  groupArraysForFine: { memberName: string; datas: any }[];
  onlineBookRequestList:any
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";
  
  branchId:any;
  memberInfoId:any;
  traineeId:any;   
  role:any;
  fineAmountCount:any;
 
  displayedColumns: string[] = ['ser','name','duration', 'candidates', 'subject'];

  
  constructor(private datepipe: DatePipe,private DashboardService:DashboardService,private route: ActivatedRoute, private authService: AuthService,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    this.getFineListByMember(this.branchId);
  }
  toggle() {
    this.showHideDiv = !this.showHideDiv;
  }
  printSingle() {
    this.showHideDiv = false;
    this.print();
  }
  reloadCurrentRoute() {
    let currentUrl = this.router.url;
    this.router.navigateByUrl('/', {skipLocationChange: true}).then(() => {
        this.router.navigate([currentUrl]);
    });   
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
          <h3>Book Information List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  applyFilter(searchText){
  this.searchText =searchText;
  console.log(this.searchText);
  this.getFineListByMember(this.branchId);
  }

  getFineListByMember(baseSchoolNameId) {
    this.DashboardService.getBookIssueListForFineByMemberId(0,baseSchoolNameId,this.searchText).subscribe(response => {           
      this.bookListForFine=response.filter(x=>x.dayi > 0 );
     console.log(this.bookListForFine)
     console.log("bookListForFine")
      // console.log("fine booklist@@@@");
      // console.log(this.bookListForFine);

      // this gives an object with dates as keys
      const groups = this.bookListForFine.reduce((groups, datas) => {
        const memberName = datas.memberName+"  ("+datas.pno+")";
        if (!groups[memberName]) {
          groups[memberName] = [];
        }
        groups[memberName].push(datas);
        return groups;
      }, {});
    
      // Edit: to add it in the array format instead
      this.groupArraysForFine = Object.keys(groups).map((memberName) => {
        return {
          memberName,
          datas: groups[memberName],
        };
      });
      console.log(this.groupArraysForFine);
    })
  }
}
