import { Component, OnInit, ViewChild } from "@angular/core";
import { DashboardService } from "../service/Dashboard.service";
import { AuthService } from 'src/app/core/service/auth.service';
import { HelpLineService } from "src/app/helpline-management/service/HelpLine.service";
import { Role } from 'src/app/core/models/role';
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
  selector: "app-memberdashboard",
  templateUrl: "./memberdashboard.component.html",
  styleUrls: ["./memberdashboard.component.scss"],
})
export class MemberDashboardComponent implements OnInit {
  @ViewChild("chart") chart: ChartComponent;
  public areaChartOptions: Partial<areaChartOptions>;
  public barChartOptions: Partial<barChartOptions>;
  masterData = MasterData;
  //variables

  bookInfoList:any;
  bookInfoListCount:any; 


  pendingDemandCount: any;
  trainingCrewCount: any;
  pendingProcurementCount: any;
  pendingAcceptancesCount: any;
  availableQtyList: any;
  CountavailableQty: any;
  FlyingTimeByAricraftList: any;
  CountFlyingTimeByAricraft: any;
  aircraftStatustotalCount: any;
  AricraftFlyingList: any;
  AricraftFlyingScheduleList: any;
  CountAricraftFlying: any;
  CountAricraftFlyingSchedule: any;
  AricraftUnderMaintenanceList: any;
  CountAricraftUnderMaintenance: any;
  PersonalStateList: any;
  MaintanenceScheduleListFromData: any;
  CountMaintanenceScheduleListFromData: any;
  BookIssueList:any;
  CountBookIssue:any;
  bookIssuList:any;
  CountUnreadNotice:any;
  aircraftStatusList: any;
  CountPersonalState: any;
  RemainProcurementQtyList: any;
  operationalAircraftNameCount: any;
  nonOperationalAircraftNameCount: any;
  aircraftStatusCount: any;
  CountRemainProcurement: any;
  aircraftFlyingData: any[];
  todayNoticeBoardData: any[];
  deptName: string = "All";
  RemainProcurement: string = "All";
  FlyingTimeByDeptName: string = "All";
  FlyingByDeptName: string = "All";
  StatusByDeptName: string = "All";
  StatusList: any;
  bulletinList:any;
  role:any;
  branchId:any;
  traineeId:any;
  CountStatus: any;
  isShown: boolean = false;
  groupArrays: { departmentName: string; courses: any }[];
  groupArrayFlightStatus: { departmentName: string; courses: any }[];
  onlineRequestCount:any;
  bookList:any;
  helpLineList:any;
  chatCount:any;
  userRole = Role;
  groupArraysOne: { shortName: string; datas: any }[];
  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };
  bookissueForfine:any;
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
  //displayedAircraftInfoColumns: string[] = [ 'ser', 'deptName','airCraftName', 'flyTime'];

  constructor(
    private datepipe: DatePipe,
    private dashboardService: DashboardService,private HelpLineService: HelpLineService,private authService: AuthService,
  ) {}

  ngOnInit() {
    this.role = this.authService.currentUserValue.role.trim();
    this.traineeId =  this.authService.currentUserValue.traineeId.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role, this.traineeId, this.branchId)
   
    this.getBookIssueListForMemberByMemberInfoId();
    this.getBookInfoListByBaseSchoolNameId();
    this.getRequestedBookByMemberInfoId(this.traineeId);
    this.getActiveBulletins(this.traineeId);
    this.getNoticeInfoCountByMember(this.traineeId);
    this.getHelpLineListByDepartment();
    if(this.role == this.userRole.SuperAdmin){
      this.getOnlineChatDashboardCount(0,this.role);
    }else{
      this.getOnlineChatDashboardCount(this.traineeId,this.role);
    }
    //this.getBookIssueListForFineByMemberId();
  }

  // getBookInfoListByBaseSchoolNameId(){
  //   this.dashboardService.getBookInfolistByBaseSchoolNameId(201).subscribe((response) => {
  //     this.bookInfoList = response;
  //     this.bookInfoListCount = response.length;
  //   });
  // }

  // getBookIssueListForFineByMemberId(){
  //   this.dashboardService.getBookIssueListForFineByMemberId(this.traineeId).subscribe(response => {           
  //     this.bookissueForfine=response;
  //   //  this.CountBookIssue = response.length;
  //     console.log("MY Book Issue List");
  //     console.log(this.bookIssuList);
  //     console.log("MY Book Issue List Count");
  //     console.log(this.CountBookIssue);
  //   })
  // }

  getDamageListByMember(){
    
  }
  getBookIssueListForMemberByMemberInfoId() {
    this.dashboardService.getBookIssueListForMemberByMemberInfoId(this.traineeId).subscribe(response => {           
      this.bookIssuList=response;
      this.CountBookIssue = response.length;
      console.log("MY Book Issue List");
      console.log(this.bookIssuList);
      console.log("MY Book Issue List Count");
      console.log(this.CountBookIssue);
    })
  }
  getOnlineChatDashboardCount(branchId,userRole){
    this.dashboardService.getOnlineChatDashboardCount(branchId,userRole).subscribe((response) => {
      // this.bookBindingList = response;
      this.chatCount = response[0].countTotal;
      // console.log(response)
    });
  }
  getNoticeInfoCountByMember(traineeId) {
    this.dashboardService.getNoticeInfoCountByMember(traineeId).subscribe(response => {           
      // this.bookIssuList=response;
      this.CountUnreadNotice = response.length;
    })
  }
  getBookInfoListByBaseSchoolNameId(){
    this.dashboardService.getBookInfolistByBaseSchoolNameId(this.branchId == null ? 1 :this.branchId).subscribe((response) => {
      this.bookInfoList = response;
      this.bookInfoListCount = response.length;
    });
  }

  getHelpLineListByDepartment(){
    var baseSchoolNameId =null;
    if(this.role == this.userRole.Member){
      baseSchoolNameId = 0;
    }

    this.HelpLineService.getHelpLineListByDepartment(baseSchoolNameId).subscribe(res=>{
      this.helpLineList=res;
      console.log("4444444444444");
      console.log( this.helpLineList);

      // this gives an object with dates as keys
     const groups = this.helpLineList.reduce((groups, datas) => {
      const libraryName = datas.shortName;
      if (!groups[libraryName]) {
        groups[libraryName] = [];
      }
      groups[libraryName].push(datas);
      return groups;
    }, {});

    // Edit: to add it in the array format instead
    this.groupArraysOne = Object.keys(groups).map((shortName) => {
      return {
        shortName,
        datas: groups[shortName],
      };
    });
    console.log("group 6666array");
    console.log(this.groupArraysOne);
    
    });
}

  getAircraftFlyingData(departmentId) {
    this.dashboardService.getAircraftFlyingData(departmentId).subscribe((response) => {
      this.aircraftFlyingData = response;

      const groups = this.aircraftFlyingData.reduce((groups, courses) => {
        const schoolName = courses.departmentName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrayFlightStatus = Object.keys(groups).map(
        (departmentName) => {
          return {
            departmentName,
            courses: groups[departmentName],
          };
        }
      );
    });
  }
  getActiveBulletins(memberInfoId){
    this.dashboardService.getActiveBulletinList(memberInfoId).subscribe(res=>{
      this.bulletinList=res;  
      console.log("bulletinList");
      console.log(this.bulletinList);
    });
  }
  getRequestedBookByMemberInfoId(memberInfoId) {
    this.dashboardService.getOnlineBookRequestByMemberId(memberInfoId).subscribe(response => {           
      this.bookList=response.filter(x=>x.cancelStatus==0);
      console.log("booklist");
      this.onlineRequestCount=this.bookList.length;
            console.log("888");
    })
  }

  getTodayNoticeBoardData(departmentId) {
    this.dashboardService.getTodayNoticeBoardData(departmentId).subscribe((response) => {
      this.todayNoticeBoardData = response;
      console.log("this.todayNoticeBoardData");
      console.log(this.todayNoticeBoardData);

      const groups = this.todayNoticeBoardData.reduce((groups, courses) => {
        const schoolName = courses.departmentName;
        if (!groups[schoolName]) {
          groups[schoolName] = [];
        }
        groups[schoolName].push(courses);
        return groups;
      }, {});

      // Edit: to add it in the array format instead
      this.groupArrays = Object.keys(groups).map((departmentName) => {
        return {
          departmentName,
          courses: groups[departmentName],
        };
      });
    });
  }

  getNonOperatinalAircraftNameCount() {
    this.dashboardService
      .getNonOperatinalAircraftNameCount(0)
      .subscribe((response) => {
        this.nonOperationalAircraftNameCount = response.length;
      });
  }

  getOperatinalAircraftNameCount() {
    this.dashboardService
      .getOperatinalAircraftNameCount(0)
      .subscribe((response) => {
        this.operationalAircraftNameCount = response.length;
      });
  }

  getPendingDemand() {
    this.dashboardService.getPendingDemands(0).subscribe((response) => {
      this.pendingDemandCount = response.length;
    });
  }

  getPendingProcurements() {
    this.dashboardService.getPendingProcurements(0).subscribe((response) => {
      this.pendingProcurementCount = response.length;
    });
  }

  getPendingAcceptances() {
    this.dashboardService.getPendingAcceptances(0).subscribe((response) => {
      this.pendingAcceptancesCount = response.length;
    });
  }
  // getRemainProcurementQty(){
  //   this.dashboardService.getRemainProcurementQty(0).subscribe(response => {
  //     this.RemainProcurementQtyList=response;
  //     this.CountRemainProcurement=response.length;
  //     console.log(this.RemainProcurementQtyList)
  //   })
  // }
  // RemainProcurementQty(id, name){
  //   this.RemainProcurement = name;
  //   this.dashboardService.getRemainProcurementQty(id).subscribe(response => {
  //     this.RemainProcurementQtyList = response;
  //     this.CountRemainProcurement = response.length;
  //   })
  // }

  getAvailableQty() {
    this.dashboardService.getAvailableQty(0).subscribe((response) => {
      this.availableQtyList = response;
      this.CountavailableQty = response.length;
    });
  }

  inActiveItem(id, name) {
    this.deptName = name;
    this.dashboardService.getAvailableQty(id).subscribe((response) => {
      this.availableQtyList = response;
      this.CountavailableQty = response.length;
    });
  }
  getDemandSpGetCompleteStatus() {
    this.dashboardService
      .getDemandSpGetCompleteStatus(0)
      .subscribe((response) => {
        this.StatusList = response;
        this.CountStatus = response.length;
        //console.log(this.StatusList)
      });
  }
  StatusByDept(id, name) {
    this.StatusByDeptName = name;
    //let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
    this.dashboardService
      .getDemandSpGetCompleteStatus(id)
      .subscribe((response) => {
        this.StatusList = response;
        this.CountStatus = response.length;
      });
  }
  getAricraftFlyingSchedule() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAricraftFlyingSchedule(currentDateTime, 0)
      .subscribe((response) => {
        this.AricraftFlyingScheduleList = response;
        this.CountAricraftFlyingSchedule = response.length;
        //console.log(this.AricraftFlyingScheduleList)
        //console.log(this.CountAricraftFlyingSchedule)
      });
  }
  getAricraftUnderMaintenance() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAricraftUnderMaintenance(currentDateTime, 0)
      .subscribe((response) => {
        this.AricraftUnderMaintenanceList = response;
        this.CountAricraftUnderMaintenance = response.length;
        //console.log(this.AricraftUnderMaintenanceList)
        //console.log("count aircraft Maintenance");
        //console.log(this.CountAricraftUnderMaintenance)
      });
  }
  getAircraftStatusCount() {
    this.dashboardService.getAircraftStatusCount(0).subscribe((response) => {
      this.aircraftStatustotalCount = response.length;
      // console.log("this.aircraftStatusCount")
      // console.log(this.aircraftStatusCount)
    });
  }
  getAircraftStatus() {
    let currentDateTime = this.datepipe.transform(new Date(), "MM/dd/yyyy");
    this.dashboardService
      .getAircraftStatus(currentDateTime, 0)
      .subscribe((response) => {
        this.aircraftStatusList = response;
        this.aircraftStatusCount = response.length;
        console.log("this.aircraftStatusCount");
        console.log(this.aircraftStatusList);
        console.log(this.aircraftStatusCount);
      });
  }
  getPersonalState() {
    this.dashboardService.getPersonalState(0).subscribe((response) => {
      this.PersonalStateList = response;
      this.CountPersonalState = response.length;
      //console.log("this.PersonalStateList")
      //console.log(this.CountPersonalState)
    });
  }

  getUnderMaintanenceCount(){
    this.dashboardService.maintenanceScheduleListByDepartmentAndAirCraftName(0, 0).subscribe(res => {
      this.MaintanenceScheduleListFromData = res;   
      this.CountMaintanenceScheduleListFromData = res.length;
      console.log(this.MaintanenceScheduleListFromData);          
    });
  }

  // getFlyingTimeByAricraft(){
  //   this.dashboardService.getFlyingTimeByAricraft(0).subscribe(response => {
  //     this.FlyingTimeByAricraftList=response;
  //     this.CountFlyingTimeByAricraft = response.length;
  //     console.log(this.FlyingTimeByAricraftList)
  //   })
  // }

  // FlyingTimeByDept(id, name){
  //   this.FlyingTimeByDeptName = name;
  //   this.dashboardService.getFlyingTimeByAricraft(id).subscribe(response => {
  //     this.FlyingTimeByAricraftList = response;
  //     this.CountFlyingTimeByAricraft = response.length;
  //   })
  // }

  // getAricraftFlying(){
  //   let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
  //   this.dashboardService.getAricraftFlying(currentDateTime,0).subscribe(response => {
  //     this.AricraftFlyingList=response;
  //     this.CountAricraftFlying = response.length;
  //     console.log(this.AricraftFlyingList)
  //   })
  // }

  // FlyingByDept(id, name){
  //   this.FlyingByDeptName = name;
  //   let currentDateTime =this.datepipe.transform((new Date), 'MM/dd/yyyy');
  //   this.dashboardService.getAricraftFlying(currentDateTime,id).subscribe(response => {
  //     this.AricraftFlyingList=response;
  //     this.CountAricraftFlying = response.length;
  //   })
  // }

  getTrainingCrew() {
    this.dashboardService.getTrainingCrew(0).subscribe((response) => {
      this.trainingCrewCount = response.length;
      //console.log(this.trainingCrewCount)
    });
  }

  private chart1() {
    this.areaChartOptions = {
      series: [
        {
          name: "new students",
          data: [31, 40, 28, 51, 42, 85, 77],
        },
        {
          name: "old students",
          data: [11, 32, 45, 32, 34, 52, 41],
        },
      ],
      chart: {
        height: 350,
        type: "area",
        toolbar: {
          show: false,
        },
        foreColor: "#9aa0ac",
      },
      colors: ["#9F8DF1", "#E79A3B"],
      dataLabels: {
        enabled: false,
      },
      stroke: {
        curve: "smooth",
      },
      xaxis: {
        type: "datetime",
        categories: [
          "2018-09-19T00:00:00.000Z",
          "2018-09-19T01:30:00.000Z",
          "2018-09-19T02:30:00.000Z",
          "2018-09-19T03:30:00.000Z",
          "2018-09-19T04:30:00.000Z",
          "2018-09-19T05:30:00.000Z",
          "2018-09-19T06:30:00.000Z",
        ],
      },
      legend: {
        show: true,
        position: "top",
        horizontalAlign: "center",
        offsetX: 0,
        offsetY: 0,
      },

      tooltip: {
        x: {
          format: "dd/MM/yy HH:mm",
        },
      },
    };
  }

  private chart2() {
    this.barChartOptions = {
      series: [
        {
          name: "percent",
          data: [5, 8, 10, 14, 9, 7, 11, 5, 9, 16, 7, 5],
        },
      ],
      chart: {
        height: 320,
        type: "bar",
        toolbar: {
          show: false,
        },
        foreColor: "#9aa0ac",
      },
      plotOptions: {
        bar: {
          dataLabels: {
            position: "top", // top, center, bottom
          },
        },
      },
      dataLabels: {
        enabled: true,
        formatter: function (val) {
          return val + "%";
        },
        offsetY: -20,
        style: {
          fontSize: "12px",
          colors: ["#9aa0ac"],
        },
      },

      xaxis: {
        categories: [
          "Jan",
          "Feb",
          "Mar",
          "Apr",
          "May",
          "Jun",
          "Jul",
          "Aug",
          "Sep",
          "Oct",
          "Nov",
          "Dec",
        ],
        position: "bottom",
        labels: {
          offsetY: 0,
        },
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
        crosshairs: {
          fill: {
            type: "gradient",
            gradient: {
              colorFrom: "#D8E3F0",
              colorTo: "#BED1E6",
              stops: [0, 100],
              opacityFrom: 0.4,
              opacityTo: 0.5,
            },
          },
        },
        tooltip: {
          enabled: true,
          offsetY: -35,
        },
      },
      fill: {
        type: "gradient",
        colors: ["#4F86F8", "#4F86F8"],
        gradient: {
          shade: "light",
          type: "horizontal",
          shadeIntensity: 0.25,
          gradientToColors: undefined,
          inverseColors: true,
          opacityFrom: 1,
          opacityTo: 1,
          stops: [50, 0, 100, 100],
        },
      },
      yaxis: {
        axisBorder: {
          show: false,
        },
        axisTicks: {
          show: false,
        },
        labels: {
          show: false,
          formatter: function (val) {
            return val + "%";
          },
        },
      },
    };
  }
}
