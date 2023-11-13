import { Component, OnInit, ViewChild,ElementRef  } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { SelectionModel } from '@angular/cdk/collections';
import { ActivatedRoute,Router } from '@angular/router';
import { ConfirmService } from 'src/app/core/service/confirm.service';
import{MasterData} from 'src/assets/data/master-data'
import { MatSnackBar } from '@angular/material/snack-bar';
import { environment } from 'src/environments/environment';
import { AuthService } from 'src/app/core/service/auth.service';
import { Role } from 'src/app/core/models/role';
import { DashboardService } from '../service/Dashboard.service';
import {Location} from '@angular/common';

@Component({
  selector: 'app-view-softcopylist',
  templateUrl: './view-softcopylist.component.html',
  styleUrls: ['./view-softcopylist.component.sass']
})
export class ViewSoftcopyListComponent implements OnInit {
  masterData = MasterData;
  userRole = Role;
  isLoading = false;
  pageTitle:any;
  fileIUrl = '/Content/';
  // ELEMENT_DATA: BNASubjectName[] = [];
  ReadingMaterialBySchoolAndCourse:any;
  documentTypeId:any;
  status=1;
  videoList:any;

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

  displayedReadingMaterialColumns: string[] = ['ser','readingMaterialTitle','documentName','documentLink'];

  
  //  selection = new SelectionModel<BNASubjectName>(true, []);

  
  constructor(private snackBar: MatSnackBar,private _location: Location,private authService: AuthService,private dashboardService:DashboardService,private router: Router,private confirmService: ConfirmService,private route: ActivatedRoute) { }

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
        this.pageTitle = "Reading Material";
      }else {
        this.pageTitle = "Material";
      }
      this.getSoftCopyListByType(this.documentTypeId);
    }else{
      this.pageTitle = "Course Material";
      this.getReadingMaterialBySchoolAndCourse(baseSchoolNameId, courseNameId);
    }
  }
  backClicked() {
    this._location.back();
  }

  getSoftCopyListByType(documentTypeId){
    this.dashboardService.getSoftCopyUploadByType(documentTypeId).subscribe(res=>{            
      this.videoList=res; 
    });
  }

  // this.dashboardService.getSoftCopyUploadByType(this.masterData.documentType.books).subscribe(res=>{            
  //   this.bookList=res; 
  //   this.countbooks = this.bookList.length;    
  //   console.log(this.bookList);  
  // })

  getReadingMaterialList(documentTypeId){
    // this.studentDashboardService.getReadingMaterialListByType(documentTypeId).subscribe(res=>{            
    //   this.ReadingMaterialBySchoolAndCourse=res;     
    //   console.log(this.ReadingMaterialBySchoolAndCourse);  
    // });
  }

  // getCourseModuleByCourseName(courseNameId){
  //   this.studentDashboardService.getSelectedCourseModulesByCourseNameId(courseNameId).subscribe(res=>{
  //     this.CourseModuleByCourseName = res;
  //     console.log(this.CourseModuleByCourseName)
  //   });
  // }

  getReadingMaterialBySchoolAndCourse(baseSchoolNameId, courseNameId){    
    // this.studentDashboardService.getReadingMAterialInfoBySchoolAndCourse(baseSchoolNameId, courseNameId).subscribe(res=>{
    //   this.ReadingMaterialBySchoolAndCourse = res;

    //   const groups = this.ReadingMaterialBySchoolAndCourse.reduce((groups, courses) => {
    //     const materialTitle = courses.readingMaterialTitle;
    //     if (!groups[materialTitle]) {
    //       groups[materialTitle] = [];
    //     }
    //     groups[materialTitle].push(courses);
    //     return groups;
    //   }, {});

    //   // Edit: to add it in the array format instead
    //   this.groupArrays = Object.keys(groups).map((readingMaterialTitle) => {
    //     return {
    //       readingMaterialTitle,
    //       courses: groups[readingMaterialTitle]
    //     };
    //   });
    //   console.log(this.groupArrays);

    // });
  }

}
