import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SelectedModel } from '../../core/models/selectedModel';
import { RowInfo } from '../models/RowInfo';
import {IRowInfoPagination, RowInfoPagination } from '../models/RowInfoPagination'

@Injectable({
  providedIn: 'root'
})
export class RowInfoService {

  baseUrl = environment.apiUrl;
  RowInfos: RowInfo[] = [];
  RowInfoPagination = new RowInfoPagination();
  constructor(private http: HttpClient) { }

  getRowInfos(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IRowInfoPagination>(this.baseUrl + '/row-info/get-RowInfos', { observe: 'response', params })
    .pipe(
      map(response => {
        this.RowInfos = [...this.RowInfos, ...response.body.items];
        this.RowInfoPagination = response.body;
        return this.RowInfoPagination;
      })
    );
  }
  getselectedShelfInfo(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/shelf-info/get-selectedShelfInfos')
  }
  find(id: number) {
    return this.http.get<RowInfo>(this.baseUrl + '/row-info/get-RowInfoDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/row-info/update-RowInfo/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/row-info/save-RowInfo', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/row-info/delete-RowInfo/'+id);
  }
}
