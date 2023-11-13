import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BookTitleInfo } from '../models/BookTitleInfo';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IBookTitleInfoPagination, BookTitleInfoPagination } from '../models/BookTitleInfoPagination'

@Injectable({
  providedIn: 'root'
})
export class BookTitleInfoService {

  baseUrl = environment.apiUrl;
  BookTitleInfos: BookTitleInfo[] = [];
  BookTitleInfoPagination = new BookTitleInfoPagination();
  constructor(private http: HttpClient) { }

  getBookTitleInfos(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBookTitleInfoPagination>(this.baseUrl + '/book-title-info/get-BookTitleInfos', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BookTitleInfos = [...this.BookTitleInfos, ...response.body.items];
        this.BookTitleInfoPagination = response.body;
        return this.BookTitleInfoPagination;
      })
    );
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<BookTitleInfo>(this.baseUrl + '/book-title-info/get-BookTitleInfoDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/book-title-info/update-BookTitleInfo/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/book-title-info/save-BookTitleInfo', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/book-title-info/delete-BookTitleInfo/'+id);
  }
}
