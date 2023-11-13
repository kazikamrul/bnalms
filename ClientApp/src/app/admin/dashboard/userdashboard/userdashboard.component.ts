import { Component, OnInit, ViewChild } from "@angular/core";
import { DashboardService } from "../service/Dashboard.service";
import { AuthService } from 'src/app/core/service/auth.service';
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
  selector: "app-userdashboard",
  templateUrl: "./userdashboard.component.html",
  styleUrls: ["./userdashboard.component.scss"],
})
export class UserDashboardComponent implements OnInit {
  @ViewChild("chart") chart: ChartComponent;
  public areaChartOptions: Partial<areaChartOptions>;
  public barChartOptions: Partial<barChartOptions>;
  masterData = MasterData;
  //variables
  bookInfoList:any;
  bookInfoListCount:any;
  role:any;
  branchId:any;

  paging = {
    pageIndex: this.masterData.paging.pageIndex,
    pageSize: this.masterData.paging.pageSize,
    length: 1,
  };

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
    private datepipe: DatePipe,
    private dashboardService: DashboardService,
    private authService: AuthService
  ) {}

  ngOnInit() {

    this.role = this.authService.currentUserValue.role.trim();
    this.branchId =  this.authService.currentUserValue.branchId.trim();
    console.log(this.role,"----"+ this.branchId)

    this.getBookInfoListByBaseSchoolNameId();
  }

  getBookInfoListByBaseSchoolNameId(){
    this.dashboardService.getBookInfolistByBaseSchoolNameId(this.branchId).subscribe((response) => {
      this.bookInfoList = response;
      this.bookInfoListCount = response.length;
    });
  }
}
