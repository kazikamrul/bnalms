import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EventInfo } from '../models/EventInfo';
import { SelectedModel } from 'src/app/core/models/selectedModel';
//import { SelectedModel } from '../../core/models/selectedModel';
import {IEventInfoPagination, EventInfoPagination } from '../models/EventInfoPagination'

@Injectable({
  providedIn: 'root'
})
export class EventInfoService {

  baseUrl = environment.apiUrl;
  EventInfos: EventInfo[] = [];
  EventInfoPagination = new EventInfoPagination();
  constructor(private http: HttpClient) { }

  getEventInfos(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IEventInfoPagination>(this.baseUrl + '/event-info/get-EventInfos', { observe: 'response', params })
    .pipe(
      map(response => {
        this.EventInfos = [...this.EventInfos, ...response.body.items];
        this.EventInfoPagination = response.body;
        return this.EventInfoPagination;
      })
    );
  }
  
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }

  find(id: number) {
    return this.http.get<EventInfo>(this.baseUrl + '/event-info/get-EventInfoDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/event-info/update-EventInfo/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/event-info/save-EventInfo', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/event-info/delete-EventInfo/'+id);
  }
}
