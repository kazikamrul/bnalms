import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BookBindingInfo } from '../models/BookBindingInfo';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IBookBindingInfoPagination, BookBindingInfoPagination } from '../models/BookBindingInfoPagination'

@Injectable({
  providedIn: 'root'
})
export class BookBindingInfoService {

  baseUrl = environment.apiUrl;
  BookBindingInfos: BookBindingInfo[] = [];
  BookBindingInfoPagination = new BookBindingInfoPagination();
  constructor(private http: HttpClient) { }

  getBookBindingInfos(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBookBindingInfoPagination>(this.baseUrl + '/book-binding-info/get-BookBindingInfos', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BookBindingInfos = [...this.BookBindingInfos, ...response.body.items];
        this.BookBindingInfoPagination = response.body;
        return this.BookBindingInfoPagination;
      })
    );
  }

  returnBookBindingInfo(bookInformationId){
    return this.http.get<any[]>(this.baseUrl + '/book-binding-info/return-bookbindinginfo?bookInformationId='+bookInformationId+'')
  }
  getBookBindingInfoListByBaseSchoolNameId(baseSchoolNameId,searchText){
    return this.http.get<any[]>(this.baseUrl + '/book-binding-info/get-bookBindingInfoList?baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText)
  }
  //autocomplete for accessionNo
    getSelectedAccessionNo(accessionno){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/book-information/get-autocompleteAccessionNo?accessionNo='+accessionno)
        .pipe(
          map((response:[]) => response.map(item => item))
        )
    }
    
    getSelectedAccessionNoByDepartment(accessionno,departmentId){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/book-information/get-autocompleteAccessionNoByDept?accessionNo='+accessionno+'&departmentId='+departmentId)
        .pipe(
          map((response:[]) => response.map(item => item))
        )
    }
  
    getSelectedSchoolName(baseNameId){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
    }
  find(id: number) {
    return this.http.get<BookBindingInfo>(this.baseUrl + '/book-binding-info/get-BookBindingInfoDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/book-binding-info/update-BookBindingInfo/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/book-binding-info/save-BookBindingInfo', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/book-binding-info/delete-BookBindingInfo/'+id);
  }
}
