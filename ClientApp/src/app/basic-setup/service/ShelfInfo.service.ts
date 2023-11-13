import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ShelfInfo } from '../models/ShelfInfo';
import {IShelfInfoPagination, ShelfInfoPagination } from '../models/ShelfInfoPagination'

@Injectable({
  providedIn: 'root'
})
export class ShelfInfoService {

  baseUrl = environment.apiUrl;
  ShelfInfos: ShelfInfo[] = [];
  ShelfInfoPagination = new ShelfInfoPagination();
  constructor(private http: HttpClient) { }

  getShelfInfos(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IShelfInfoPagination>(this.baseUrl + '/shelf-info/get-ShelfInfos', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ShelfInfos = [...this.ShelfInfos, ...response.body.items];
        this.ShelfInfoPagination = response.body;
        return this.ShelfInfoPagination;
      })
    );
  }
  find(id: number) {
    return this.http.get<ShelfInfo>(this.baseUrl + '/shelf-info/get-ShelfInfoDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/shelf-info/update-ShelfInfo/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/shelf-info/save-ShelfInfo', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/shelf-info/delete-ShelfInfo/'+id);
  }
}
