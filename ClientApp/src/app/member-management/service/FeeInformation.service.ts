import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FeeInformation } from '../models/FeeInformation';
import { SelectedModel } from 'src/app/core/models/selectedModel';
//import { SelectedModel } from '../../core/models/selectedModel';
import {IFeeInformationPagination, FeeInformationPagination } from '../models/FeeInformationPagination'

@Injectable({
  providedIn: 'root'
})
export class FeeInformationService {

  baseUrl = environment.apiUrl;
  FeeInformations: FeeInformation[] = [];
  FeeInformationPagination = new FeeInformationPagination();
  constructor(private http: HttpClient) { }

  getFeeInformations(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IFeeInformationPagination>(this.baseUrl + '/fee-information/get-FeeInformations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.FeeInformations = [...this.FeeInformations, ...response.body.items];
        this.FeeInformationPagination = response.body;
        return this.FeeInformationPagination;
      })
    );
  }
  //bookissue-and-submission/get-bookissueandsubmissionforfinebybaseschoolnameid?baseSchoolNameId=201&searchText=2208'
  getFineForIssueReturnList(baseSchoolNameId,searchText){
    return this.http.get<any[]>(this.baseUrl + '/bookissue-and-submission/get-bookissueandsubmissionforfinebybaseschoolnameid?baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText+'');
  }

  //autocomplete for Pno
    getSelectedPno(pno){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/member-info/get-autocompletePno?pno='+pno)
        .pipe(
          map((response:[]) => response.map(item => item))
        )
    }
     //autocomplete for accessionNo
     getSelectedAccessionNo(accessionno){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/book-information/get-autocompleteAccessionNo?accessionNo='+accessionno)
        .pipe(
          map((response:[]) => response.map(item => item))
        )
    }
    getFeeInformationListByPNO( memberInfoId:number){
      return this.http.get<FeeInformation[]>(this.baseUrl + '/fee-information/get-feeInformationListByPno?memberInfoId='+memberInfoId);
     }
    getSelectedSchoolName(baseNameId){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
    }
  getselectedFeeCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/fee-category/get-selectedFeeCategories')
  }
  getMemberNameById(id:number){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/member-info/get-memberNameByIdRequest?memberInfoId=' + id);
  }

  find(id: number) {
    return this.http.get<FeeInformation>(this.baseUrl + '/fee-information/get-FeeInformationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/fee-information/update-FeeInformation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/fee-information/save-FeeInformation', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/fee-information/delete-FeeInformation/'+id);
  }
}
