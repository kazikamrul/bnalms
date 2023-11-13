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
import { DashboardService } from '../service/Dashboard.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-inventorybytype-list',
  templateUrl: './inventorybytype-list.component.html',
  styleUrls: ['./inventorybytype-list.component.sass']
})
export class InventorybyTypeListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  PageTitle:any;
  inventoryDetailsList:any;
  showHideDiv:any;
  memberInfoId:any;

  groupArrays: { libraryName: string; datas: any }[];

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
  
  branchId:any;
  traineeId:any;
  role:any;

  listType:any;

  displayedColumns: string[] = ['ser','name','duration', 'candidates', 'subject'];

  
  constructor(private datepipe: DatePipe,private _location: Location,private DashboardService:DashboardService,private route: ActivatedRoute, private authService: AuthService,private snackBar: MatSnackBar,private router: Router,private confirmService: ConfirmService) { }

  ngOnInit() {
    // this.userRole.InterSeeviceDesk
    var inventoryTypeId = this.route.snapshot.paramMap.get('inventoryTypeId');
    
    this.DashboardService.findInventoryType(Number(inventoryTypeId)).subscribe(res=>{
      this.PageTitle = res.name + " List";
      console.log(res);
    });
    
    // this.PageTitle = "Inventory Details List";
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId)

    if(this.role == this.userRole.SuperAdmin){
      this.getInventoryListByType(0,inventoryTypeId);
    }else{
      this.getInventoryListByType(this.branchId,inventoryTypeId);
    }
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
          <h3>All Member Info List</h3>
          
          </div>
          <br>
          <hr>
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  // applyFilter(searchText:any){
  //   this.searchText = searchText;
  //   this.getAllMemberInfoListSpRequest(this.listType);
  // }
 
  getInventoryListByType(baseSchoolNameId,inventoryTypeId){
    
      this.DashboardService.getInventoryListByType(baseSchoolNameId,inventoryTypeId).subscribe((response) => {
        this.inventoryDetailsList = response;
        console.log(this.inventoryDetailsList)

        // this gives an object with dates as keys
        const groups = this.inventoryDetailsList.reduce((groups, datas) => {
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
  
}
