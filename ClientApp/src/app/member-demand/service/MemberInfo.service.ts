import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MemberInfo } from '../models/MemberInfo';
import { SelectedModel } from '../../core/models/selectedModel';
import {IMemberInfoPagination, MemberInfoPagination } from '../models/MemberInfoPagination'

@Injectable({
  providedIn: 'root'
})
export class MemberInfoService {

  baseUrl = environment.apiUrl;
  MemberInfos: MemberInfo[] = [];
  MemberInfoPagination = new MemberInfoPagination();
  constructor(private http: HttpClient) { }

  getMemberInfos(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMemberInfoPagination>(this.baseUrl + '/member-info/get-MemberInfos', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MemberInfos = [...this.MemberInfos, ...response.body.items];
        this.MemberInfoPagination = response.body;
        return this.MemberInfoPagination;
      })
    );
  }
  acctiveMember(id: number) {
    return this.http.get<MemberInfo>(this.baseUrl + '/member-info/active-memberInfo/' + id);
  }
  inAcctiveMember(id: number) {
    return this.http.get<MemberInfo>(this.baseUrl + '/member-info/inActive-memberInfo/' + id);
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselectedMemberCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/member-category/get-selectedMemberCategories')
  }
  getselectedArea(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/area/get-selectedAreas')
  }
  getselectedBase(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base/get-selectedBases')
  }
  getselectedSecurityQuestion(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/security-question/get-selectedSecurityQuestions')
  }
  getselectedDesignation(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/designation/get-selectedDesignations')
  }
  getselectedJobStatus(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/job-status/get-selectedJobStatuses')
  }
  getselectedRank(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/rank/get-selectedRanks')
  }
  find(id: number) {
    return this.http.get<MemberInfo>(this.baseUrl + '/member-info/get-MemberInfoDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/member-info/update-MemberInfo/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/member-info/save-MemberInfo', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/member-info/delete-MemberInfo/'+id);
  }
}
