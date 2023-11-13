import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
// import { StudentDashboardService } from '../services/StudentDashboard.service';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { DashboardService } from '../service/Dashboard.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-softcopymaterial',
  templateUrl: './softcopymaterial-list.component.html',
  styleUrls: ['./softcopymaterial-list.component.sass']
})
export class SoftcopyMaterialListComponent implements OnInit {
   masterData = MasterData;
  loading = false;
  userRole = Role;
  isLoading = false;
  pageTitle:any;
  fileIUrl = environment.fileUrl;
  ReadingMaterialBySchoolAndCourse:any;
  documentTypeId:any;
  status=1;
  showHideDiv:any;

  role:any;
  traineeId:any;
  branchId:any;


  groupArrays:{ readingMaterialTitle: string; courses: any; }[];
  
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1
  }
  searchText="";

  
  constructor(private snackBar: MatSnackBar,private _location: Location,private authService: AuthService,private dashboardService: DashboardService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute) { }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    // const branchId =  this.authService.currentUserValue.branchId.trim();
    this.branchId =  this.authService.currentUserValue.branchId  ? this.authService.currentUserValue.branchId.trim() : "";
    console.log(this.role, this.traineeId, this.branchId)
    
    var courseNameId = this.route.snapshot.paramMap.get('courseNameId');
    this.documentTypeId = this.route.snapshot.paramMap.get('documentTypeId');
    var baseSchoolNameId = this.route.snapshot.paramMap.get('baseSchoolNameId');
    if(this.documentTypeId){
      if(this.documentTypeId == this.masterData.documentType.books){
        this.pageTitle = "Books";
      }else if(this.documentTypeId == this.masterData.documentType.videos){
        this.pageTitle = "Videos";
      }else if(this.documentTypeId == this.masterData.documentType.slides){
        this.pageTitle = "Slides";
      }else if(this.documentTypeId == this.masterData.documentType.materials){
        this.pageTitle = "BR";
      }else {
        this.pageTitle = "Soft Copy";
      }
      this.getReadingMaterialList(this.documentTypeId);
    }
    // else{
    //   this.pageTitle = "Course Material";
    //   this.getReadingMaterialBySchoolAndCourse(baseSchoolNameId, courseNameId);
    // }
  }
  backClicked() {
    this._location.back();
  }
  getReadingMaterialList(documentTypeId){
    this.dashboardService.getSoftCopyUploadByType(documentTypeId).subscribe(res=>{            
      this.ReadingMaterialBySchoolAndCourse=res;     
      console.log(this.ReadingMaterialBySchoolAndCourse);  
    });
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
                  
                    .table.table.tbl-by-group.uploaded-list tr .cl-mrk{
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
                
          </style>
        </head>
        <body onload="window.print();window.close()">
          <div class="header-text">
          
          </div>
          <br>
         
          ${printContents}
          
        </body>
      </html>`);
    popupWin.document.close();
  }

  // getCourseModuleByCourseName(courseNameId){
  //   this.studentDashboardService.getSelectedCourseModulesByCourseNameId(courseNameId).subscribe(res=>{
  //     this.CourseModuleByCourseName = res;
  //     console.log(this.CourseModuleByCourseName)
  //   });
  // }

  // getReadingMaterialBySchoolAndCourse(baseSchoolNameId, courseNameId){    
  //   this.dashboardService.getReadingMAterialInfoBySchoolAndCourse(baseSchoolNameId, courseNameId).subscribe(res=>{
  //     this.ReadingMaterialBySchoolAndCourse = res;

  //     const groups = this.ReadingMaterialBySchoolAndCourse.reduce((groups, courses) => {
  //       const materialTitle = courses.readingMaterialTitle;
  //       if (!groups[materialTitle]) {
  //         groups[materialTitle] = [];
  //       }
  //       groups[materialTitle].push(courses);
  //       return groups;
  //     }, {});

  //     // Edit: to add it in the array format instead
  //     this.groupArrays = Object.keys(groups).map((readingMaterialTitle) => {
  //       return {
  //         readingMaterialTitle,
  //         courses: groups[readingMaterialTitle]
  //       };
  //     });
  //     console.log(this.groupArrays);

  //   });
  // }

}
