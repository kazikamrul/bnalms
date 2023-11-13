import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SourceInformation } from '../models/SourceInformation';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {ISourceInformationPagination, SourceInformationPagination } from '../models/SourceInformationPagination'

@Injectable({
  providedIn: 'root'
})
export class SourceInformationService {

  baseUrl = environment.apiUrl;
  SourceInformations: SourceInformation[] = [];
  SourceInformationPagination = new SourceInformationPagination();
  constructor(private http: HttpClient) { }

  getSourceInformations(pageNumber, pageSize,searchText,bookInformationId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('bookInformationId', bookInformationId.toString());
    return this.http.get<ISourceInformationPagination>(this.baseUrl + '/source-information/get-SourceInformations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.SourceInformations = [...this.SourceInformations, ...response.body.items];
        this.SourceInformationPagination = response.body;
        return this.SourceInformationPagination;
      })
    );
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<SourceInformation>(this.baseUrl + '/source-information/get-SourceInformationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/source-information/update-SourceInformation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/source-information/save-SourceInformation', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/source-information/delete-SourceInformation/'+id);
  }
}
