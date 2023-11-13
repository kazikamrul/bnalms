import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { FineForIssueReturn } from '../models/FineForIssueReturn';
import {IFineForIssueReturnPagination, FineForIssueReturnPagination } from '../models/FineForIssueReturnPagination'
import { SelectedModel } from 'src/app/core/models/selectedModel';

@Injectable({
  providedIn: 'root'
})
export class FineForIssueReturnService {

  baseUrl = environment.apiUrl;
  FineForIssueReturns: FineForIssueReturn[] = [];
  FineForIssueReturnPagination = new FineForIssueReturnPagination();
  constructor(private http: HttpClient) { }

  getFineForIssueReturns(pageNumber, pageSize,searchText, baseSchoolNameId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
    return this.http.get<IFineForIssueReturnPagination>(this.baseUrl + '/fine-for-issuereturns/get-FineForIssueReturns', { observe: 'response', params })
    .pipe(
      map(response => {
        this.FineForIssueReturns = [...this.FineForIssueReturns, ...response.body.items];
        this.FineForIssueReturnPagination = response.body;
        return this.FineForIssueReturnPagination;
      })
    );
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  activeFineForIssueReturn(id: number) {
    return this.http.get<FineForIssueReturn>(this.baseUrl + '/fine-for-issuereturns/active-fineForIssueReturn/' + id);
  }
  inActiveFineForIssueReturn(id: number) {
    return this.http.get<FineForIssueReturn>(this.baseUrl + '/fine-for-issuereturns/inActive-fineForIssueReturn/' + id);
  }
  find(id: number) {
    return this.http.get<FineForIssueReturn>(this.baseUrl + '/fine-for-issuereturns/get-FineForIssueReturnDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/fine-for-issuereturns/update-FineForIssueReturn/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/fine-for-issuereturns/save-FineForIssueReturn', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/fine-for-issuereturns/delete-FineForIssueReturn/'+id);
  }
}
