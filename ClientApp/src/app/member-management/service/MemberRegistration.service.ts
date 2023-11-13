import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MemberRegistration } from '../models/MemberRegistration';
import { SelectedModel } from '../../core/models/selectedModel';
import {IMemberRegistrationPagination, MemberRegistrationPagination } from '../models/MemberRegistrationPagination'

@Injectable({
  providedIn: 'root'
})
export class MemberRegistrationService {

  baseUrl = environment.apiUrl;
  MemberRegistrations: MemberRegistration[] = [];
  MemberRegistrationPagination = new MemberRegistrationPagination();
  constructor(private http: HttpClient) { }

  getMemberRegistrations(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMemberRegistrationPagination>(this.baseUrl + '/member-registration/get-MemberRegistrations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MemberRegistrations = [...this.MemberRegistrations, ...response.body.items];
        this.MemberRegistrationPagination = response.body;
        return this.MemberRegistrationPagination;
      })
    );
  }
  // getMemberInfoListByDepartment( baseSchoolNameId:number){
  //   return this.http.get<MemberRegistration[]>(this.baseUrl + '/member-info/get-memberInformationListByDepartmentId?baseSchoolNameId='+baseSchoolNameId);
  //  }
  // acctiveMember(id: number) {
  //   return this.http.get<MemberRegistration>(this.baseUrl + '/member-info/active-memberInfo/' + id);
  // }
  // inAcctiveMember(id: number) {
  //   return this.http.get<MemberRegistration>(this.baseUrl + '/member-info/inActive-memberInfo/' + id);
  // }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselectedMemberCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/member-category/get-selectedMemberCategories')
  }
  getselectedDesignation(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/designation/get-selectedDesignations')
  }
  // getselectedJobStatus(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/job-status/get-selectedJobStatuses')
  // }
  getselectedArea(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/area/get-selectedAreas')
  }
  getselectedBase(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base/get-selectedBases')
  }
  getselectedRank(designationId){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/rank/get-rankByDesignation?designationId='+designationId)
    }
  find(id: number) {
    return this.http.get<MemberRegistration>(this.baseUrl + '/member-registration/get-MemberRegistrationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/member-registration/update-MemberRegistration/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/member-registration/save-MemberRegistration', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/member-registration/delete-MemberRegistration/'+id);
  }
}
