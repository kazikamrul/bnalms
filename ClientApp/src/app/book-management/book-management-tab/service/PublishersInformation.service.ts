import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PublishersInformation } from '../models/PublishersInformation';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IPublishersInformationPagination, PublishersInformationPagination } from '../models/PublishersInformationPagination'

@Injectable({
  providedIn: 'root'
})
export class PublishersInformationService {

  baseUrl = environment.apiUrl;
  PublishersInformations: PublishersInformation[] = [];
  PublishersInformationPagination = new PublishersInformationPagination();
  constructor(private http: HttpClient) { }

  getPublishersInformations(pageNumber, pageSize,searchText, bookInformationId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('bookInformationId', bookInformationId.toString());
    return this.http.get<IPublishersInformationPagination>(this.baseUrl + '/publishers-information/get-PublishersInformations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.PublishersInformations = [...this.PublishersInformations, ...response.body.items];
        this.PublishersInformationPagination = response.body;
        return this.PublishersInformationPagination;
      })
    );
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<PublishersInformation>(this.baseUrl + '/publishers-information/get-PublishersInformationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/publishers-information/update-PublishersInformation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/publishers-information/save-PublishersInformation', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/publishers-information/delete-PublishersInformation/'+id);
  }
}
