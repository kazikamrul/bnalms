import { Component, OnInit, ViewChild } from "@angular/core";
import { DashboardService } from "../service/Dashboard.service";
import { AuthService } from 'src/app/core/service/auth.service';
import { HelpLineService } from "src/app/helpline-management/service/HelpLine.service";
import {BookIssueAndSubmissionService} from '../../../book-management/service/BookIssueAndSubmission.service';
import {
  ChartComponent,
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexYAxis,
  ApexPlotOptions,
  ApexStroke,
  ApexLegend,
  ApexFill,
} from "ng-apexcharts";
import { MasterData } from "src/assets/data/master-data";
import { DatePipe } from "@angular/common";
import { Role } from 'src/app/core/models/role';

export type areaChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis;
  stroke: ApexStroke;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
  legend: ApexLegend;
  colors: string[];
};

export type barChartOptions = {
  series: ApexAxisChartSeries;
  chart: ApexChart;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  yaxis: ApexYAxis;
  xaxis: ApexXAxis;
  fill: ApexFill;
  colors: string[];
};

@Component({
  selector: "app-main",
  templateUrl: "./main.component.html",
  styleUrls: ["./main.component.scss"],
})
export class MainComponent implements OnInit {
  @ViewChild("chart") chart: ChartComponent;
  public areaChartOptions: Partial<areaChartOptions>;
  public barChartOptions: Partial<barChartOptions>;
  masterData = MasterData;
  userRole = Role;
  //variables
  bookInfoList:any;
  inventoryDetailListCount:any;
  bookInfoListCount:any;
  bookIssueList:any;
  bulletinList:any;
  allMemberInfoList:any;
  allMemberInfoListCount:any;
  MemberInfoByLibraryList:any;
  MemberInfoByLibraryListCount:any;
  bookIssueListCount:any;
  onlineBookRequestList:any;
  onlineBookRequestListCount:any;
  role:any;
  branchId:any;
  searchText="";
  pno:any;
  chatCount:any;
  bookBindingListCount:any;
  bookBindingList:any;
  helpLineList:any;
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  groupArrays: { libraryName: string; datas: any }[];
  procurementColumns: string[] = [
    "sl",
    "tenderNumber",
    "dateOfDelivery",
    "dateOfTenderFloat",
    "cstTec",
    "qty",
    "sftQty",
  ];
  displayedAvailableColumns: string[] = [
    "ser",
    "sparesCategory",
    "deptName",
    "partNo",
    "nameOfItem",
    "minimumStock",
    "availableQty",
  ];
  displayedFlyingColumns: string[] = [
    "ser",
    "airCraftName",
    "date",
    "crew",
    "callSign",
    "mon",
    "startUp",
    "dur",
    "endurance",
    "fuel",
    "opaOff",
    "remarks",
  ];
  displayNoticeBoardList: string[] = [
    "departmentName",
    "date",
    "event",
    "orderBy",
  ];
  displayedAircraftInFlightColumns: string[] = [
    "departmentName",
    "airCraftName",
    "startUp",
    "runningHour",
    "restHour",
  ];

  constructor(
    private datepipe: DatePipe,private HelpLineService: HelpLineService,private BookIssueAndSubmissionService:BookIssueAndSubmissionService,private dashboardService: DashboardService,private authService: AuthService) 
  {

  }

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.pno =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.pno, this.branchId)

    this.getBookInfoListByBaseSchoolNameId();
    this.getBookIssueAndSubmissionListSpRequest();
    this.getAllMemberInfoListSpRequest();
    this.getOnlineBookRequestListByBaseSchoolId();
    this.getMemberInfoListByLibrarySpRequest();
    this.getBooBindingList();
    

    if(this.role == this.userRole.SuperAdmin){
      this.getOnlineChatDashboardCount(0,this.role);
      this.getInventoryDetailListByType(0);
      this.getBulletinListByLibrary(0);
      this.getHelpLineListByDepartment(0);
    }else{
      this.getOnlineChatDashboardCount(this.branchId,this.role);
      this.getInventoryDetailListByType(this.branchId);
      this.getBulletinListByLibrary(this.branchId);
      this.getHelpLineListByDepartment(this.branchId);
    }
  }

  getInventoryDetailListByType(branchId){
    this.dashboardService.getInventoryDetailListByType(branchId).subscribe((response) => {
      // this.bookInfoList = response;
      console.log(response)
      this.inventoryDetailListCount = response.length;
    });
  }
  getBookInfoListByBaseSchoolNameId(){
    this.dashboardService.getBookInfolistByBaseSchoolNameId(this.branchId == null ? 1 :this.branchId).subscribe((response) => {
      this.bookInfoList = response;
      this.bookInfoListCount = response.length;
    });
  }

  getBooBindingList(){
    this.dashboardService.getBooBindingList(this.branchId == null ? 1 :this.branchId,"").subscribe((response) => {
      this.bookBindingList = response;
      this.bookBindingListCount = response.length;
    });
  }
  getBulletinListByLibrary(branchId){
    this.dashboardService.getBulletinListByLibrary(branchId).subscribe((response) => {
      this.bulletinList = response;
      // this.bookBindingListCount = response.length;
    });
  }
  
  getOnlineChatDashboardCount(branchId,userRole){
    this.dashboardService.getOnlineChatDashboardCount(branchId,userRole).subscribe((response) => {
      // this.bookBindingList = response;
      this.chatCount = response[0].countTotal;
      // console.log(response)
    });
  }
  getOnlineBookRequestListByBaseSchoolId(){
    this.dashboardService.getOnlineBookRequestListByBaseSchoolId(this.branchId == null ? 1 :this.branchId, this.searchText).subscribe((response) => {
      this.onlineBookRequestList = response;
      this.onlineBookRequestListCount = response.length;
    });
  }
  getBookIssueAndSubmissionListSpRequest(){
    this.dashboardService.getBookIssueAndSubmissionListSpRequest(this.branchId == null ? 1 :this.branchId,this.searchText).subscribe((response) => {
      this.bookIssueList = response;
      this.bookIssueListCount = response.length;
    });
  }
  getAllMemberInfoListSpRequest(){
    this.dashboardService.getAllMemberInfoListSpRequest(this.searchText).subscribe((response) => {
      this.allMemberInfoList = response;
      this.allMemberInfoListCount = response.length;
    });
  }
  getMemberInfoListByLibrarySpRequest(){
    this.dashboardService.getMemberInfoListByLibrarySpRequest(this.branchId == null ? 1 :this.branchId,this.searchText).subscribe((response) => {
      this.MemberInfoByLibraryList = response;
      this.MemberInfoByLibraryListCount = response.length;
    });
  }
  getHelpLineListByDepartment(branchId){
      this.HelpLineService.getHelpLineListByDepartment(branchId).subscribe(res=>{
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
}
