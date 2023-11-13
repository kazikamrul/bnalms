import { Injectable } from "@angular/core";
import { HttpClient, HttpParams } from "@angular/common/http";
import { environment } from "src/environments/environment";
import { SelectedModel } from "src/app/core/models/selectedModel";
import { map } from "rxjs";
@Injectable({
  providedIn: "root",
})
export class DashboardService {
  baseUrl = environment.apiUrl;
  constructor(private http: HttpClient) {}
  // online-book-request/update-requestandcancelstatus/1013
  //dashboard/get-bookIssueListBySpRequest?baseSchoolNameId=201&searchText=4543
  //book-information/get-damagebymemberlist?memberInfoId=1006
  //book-information/get-bookInformationbytitleformember?baseSchoolNameId=0&bookCategoryId=0
 
  getBookListGroupByTitle(searchText){ //book-information/get-bookInformationbytitleformember?searchText
    return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookInformationbytitleformember?searchText='+searchText)
  }

  // getBookInfoListByBaseSchoolNameId(baseSchoolNameId,searchText,bookCategoryId,pageSize,pageNumber){
  //   return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookInformationListBySp?baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText+'&bookCategoryId='+bookCategoryId+'&pageSize='+pageSize+'&pageNumber='+pageNumber)
  // }
  getDamageListByMember(memberInfoId){
    return this.http.get<any[]>(this.baseUrl + '/book-information/get-damagebymemberlist?memberInfoId='+memberInfoId+'')
  }

  getOnlineBookRequestIsExistCheck(pno,bookInformationId){
    return this.http.get<boolean>(this.baseUrl + '/book-information/get-onlineBookRequestIsExistCheck?pno='+pno+'&bookInformationId='+bookInformationId+'')
  }
  getBookIssueAndSubmissionListSpRequest(baseSchoolNameId,searchText) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-bookIssueListBySpRequest?baseSchoolNameId="+baseSchoolNameId+"&searchText="+searchText+"");
  }
  getMemberInfoListByLibrarySpRequest(baseSchoolNameId,searchText) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-memberInfoListByLibrarySpRequest?baseSchoolNameId="+baseSchoolNameId+"&searchText="+searchText);
  }
  getAllMemberInfoListSpRequest(searchText) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-allMemberInfoListBySpRequest?searchText="+searchText+"");
  }
  getInventoryDetailListForDashboard(baseSchoolNameId) {
    return this.http.get<any[]>(this.baseUrl + "/inventory/get-inventoryDetailListForDashboard?baseSchoolNameId="+baseSchoolNameId);
  }
  findInventoryType(id: number) {
    return this.http.get<any>(this.baseUrl + '/inventory-types/get-InventoryTypeDetail/' + id);
  }
  getInventoryDetailListByType(baseSchoolNameId) {
    return this.http.get<any[]>(this.baseUrl + "/inventory/get-inventoryDetailListByType?baseSchoolNameId="+baseSchoolNameId);
  }
  getInventoryListByType(baseSchoolNameId,inventoryTypeId) {
    return this.http.get<any[]>(this.baseUrl + "/inventory/get-inventoryListByType?baseSchoolNameId="+baseSchoolNameId+"&inventoryTypeId="+inventoryTypeId);
  }
  getBookIssuedListForMemberInfoBySpRequest(memberInfoId,searchText) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-bookIssuedListForMemberInfoBySpRequest?memberInfoId="+memberInfoId+"&searchText="+searchText+"");
  }

  getOnlineChatDashboardCount(baseSchoolNameId,userRole) {
    return this.http.get<any[]>(this.baseUrl + "/online-chat/get-OnlineChatDashboardCount?id="+baseSchoolNameId+"&userRole="+userRole);
  }

updateRequestAndCancelStatus(id: number){
    return this.http.put(this.baseUrl + '/online-book-request/update-requestandcancelstatus/'+id, id);
}
updateIssueOnlineRequestAndCancelStatus(onlineBookRequsetId,bookInformationId){
  return this.http.get(this.baseUrl + '/online-book-request/update-issueonlinerequestcountandcancelstatus?onlineBookRequsetId='+onlineBookRequsetId+'&bookInformationId='+bookInformationId+'');
}
  getBookInfolistByBaseSchoolNameId(baseSchoolNameId) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-bookInfoListByBaseSchoolNameIdSpRequest?baseSchoolNameId="+baseSchoolNameId+"");
  }
  getBulletinListByLibrary(baseSchoolNameId) {
    return this.http.get<any[]>(this.baseUrl + "/bulletin/get-spBulletinListByLibrary?baseSchoolNameId="+baseSchoolNameId);
  }
    getBooBindingList(baseSchoolNameId,searchText) {
    return this.http.get<any[]>(this.baseUrl + "/book-binding-info/get-bookBindingInfoList?baseSchoolNameId="+baseSchoolNameId+"&searchText="+searchText+"");
  }
  getBookIssueListForMemberByMemberInfoId(memberInfoId) {
    return this.http.get<any[]>(this.baseUrl + "/bookissue-and-submission/get-bookIssueListByMemberInfoId?memberInfoId="+memberInfoId);
  }

  getBookIssueListForFineByMemberId(memberInfoId,baseSchoolNameId,searchText) {
    return this.http.get<any[]>(this.baseUrl + "/bookissue-and-submission/get-bookissueandsubmissionforfine?memberInfoId="+memberInfoId+"&baseSchoolNameId="+baseSchoolNameId+"&searchText="+searchText+"");
  }

  getNoticeInfoCountByMember(memberInfoId) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-noticeInfoCountByMember?memberInfoId="+memberInfoId);
  }

  saveBookIssueAndSubmission(model:any){
    return this.http.post(this.baseUrl + "/bookissue-and-submission/save-bookIssueAndSubmission", model);
  }

  // submit(model: any) {
  //   return this.http.post(this.baseUrl + '/bookissue-and-submission/save-bookIssueAndSubmission', model);
  // }
  getOnlineBookRequestByMemberId(memberInfoid) {
    return this.http.get<any[]>(this.baseUrl + "/online-book-request/get-onlineBookRequestListByMemberInfoId?memberid="+memberInfoid);
  }
  //book-information/get-onlinebookrequestlistsp?baseSchoolNameId=201

  getOnlineBookRequestListByBaseSchoolId(baseSchoolNameId,searchText){
    return this.http.get<any[]>(this.baseUrl + "/book-information/get-onlinebookrequestlistsp?baseSchoolNameId="+baseSchoolNameId+"&searchText="+searchText);
  }

  getSoftCopyUploadByType(documentType){
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-softCopyUploadByType?documentTypeId="+documentType+"");
  }
  
  getOnlineBookRequestListByBookInfo(bookInformationId) {
    return this.http.get<any[]>(this.baseUrl + "/online-book-request/get-onlineBookRequestListByBookInfo?bookInformationId="+bookInformationId);
  }

  getAircraftFlyingData(id) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-aircraftinFlightData?departmentId="+id);
  }
  //dashboard/get-nonOpearionalAircraftNameCount?departmentId=0
  getTodayNoticeBoardData(id) {
    return this.http.get<any[]>(this.baseUrl + "/dashboard/get-todayNoticeBoardData?departmentId="+id);
  }
  
  getActiveBulletinList(memberInfoId){
    return this.http.get<any>(this.baseUrl + '/bulletin/get-spBulletinList?memberInfoId='+memberInfoId)
  }
  getOperatinalAircraftNameCount(id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-opearionalAircraftNameCount?departmentId=" +
        id +
        ""
    );
  }

  getNonOperatinalAircraftNameCount(id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-nonOpearionalAircraftNameCount?departmentId=" +
        id +
        ""
    );
  }

  getRemainProcurementQty(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-remainProcurementQty?departmentId=" + id
    );
  }

  getPendingDemands(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-pendingDemands?departmentId=" + id
    );
  }
  getTrainingCrew(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-trainingCrew?departmentId=" + id
    );
  }
  getPendingProcurements(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-pendingProcurements?departmentId=" + id
    );
  }

  getPendingAcceptances(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-pendingAcceptances?departmentId=" + id
    );
  }

  getAvailableQty(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-availableQty?departmentId=" + id
    );
  }
  getFlyingTimeByAricraft(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-flyingTimeByAricraft?departmentId=" + id
    );
  }
  getAricraftFlying(current, id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-aricraftFlying?currentDate=" +
        current +
        "&departmentId=" +
        id
    );
  }
  getDemandSpGetCompleteStatus(id) {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-SpGetCompleteStatus?departmentId=" + id
    );
  }
  getSelectedSchoolName(baseNameId) {
    return this.http.get<SelectedModel[]>(
      this.baseUrl +
        "/base-School-name/get-selectedSchoolNames?thirdLevel=" +
        baseNameId
    );
  }
  getAricraftFlyingSchedule(current, id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-spFlyingSchedule?currentDate=" +
        current +
        "&departmentId=" +
        id
    );
  }
  getAricraftUnderMaintenance(current, id) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-spAcUnderMaintenance?currentDate=" +
        current +
        "&departmentId=" +
        id
    );
  }
  getAircraftStatusCount(departmentId) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-spAricraftStatusCount?departmentId=" +
        departmentId
    );
  }
  getAircraftStatus(current, departmentId) {
    return this.http.get<any>(
      this.baseUrl +
        "/dashboard/get-spAricraftStatus?currentDate=" +
        current +
        "&departmentId=" +
        departmentId
    );
  }
  getPersonalState(departmentId) {
    return this.http.get<any[]>(
      this.baseUrl + "/dashboard/get-personalState?departmentId=" + departmentId
    );
  }
  maintenanceScheduleListByDepartmentAndAirCraftName(airCraftNameId:number, departmentNameId:number){
    return this.http.get<any[]>(this.baseUrl + '/maintenance-schedule/get-maintenanceScheduleListByDepartmentNameId?airCraftNameId='+airCraftNameId+'&departmentNameId='+departmentNameId);
  }
  getPersonalStateTotalCount() {
    return this.http.get<any>(
      this.baseUrl + "/dashboard/get-personalStateTotalCount"
    );
  }
}
