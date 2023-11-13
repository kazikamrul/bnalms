import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MainClass } from '../models/MainClass';
import {IMainClassPagination, MainClassPagination } from '../models/MainClassPagination'

@Injectable({
  providedIn: 'root'
})
export class MainClassService {

  baseUrl = environment.apiUrl;
  MainClasses: MainClass[] = [];
  MainClassPagination = new MainClassPagination();
  constructor(private http: HttpClient) { }

  getMainClasses(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMainClassPagination>(this.baseUrl + '/main-class/get-MainClasses', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MainClasses = [...this.MainClasses, ...response.body.items];
        this.MainClassPagination = response.body;
        return this.MainClassPagination;
      })
    );
  }
  find(id: number) {
    return this.http.get<MainClass>(this.baseUrl + '/main-class/get-MainClassDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/main-class/update-MainClass/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/main-class/save-MainClass', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/main-class/delete-MainClass/'+id);
  }
}
