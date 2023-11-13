import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DemandBook } from '../models/DemandBook';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IDemandBookPagination, DemandBookPagination } from '../models/DemandBookPagination'

@Injectable({
  providedIn: 'root'
})
export class DemandBookService {

  baseUrl = environment.apiUrl;
  DemandBooks: DemandBook[] = [];
  DemandBookPagination = new DemandBookPagination();
  constructor(private http: HttpClient) { }

  getDemandBooks(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IDemandBookPagination>(this.baseUrl + '/demand-book/get-DemandBooks', { observe: 'response', params })
    .pipe(
      map(response => {
        this.DemandBooks = [...this.DemandBooks, ...response.body.items];
        this.DemandBookPagination = response.body;
        return this.DemandBookPagination;
      })
    );
  }
  
  //autocomplete for Pno
    // getSelectedPno(pno){
    //   return this.http.get<SelectedModel[]>(this.baseUrl + '/member-info/get-autocompletePno?pno='+pno)
    //     .pipe(
    //       map((response:[]) => response.map(item => item))
    //     )
    // }
  //   getSelectedSchoolName(baseNameId){
  //     return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  //   }
  // getselectedFeeCategory(){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/fee-category/get-selectedFeeCategories')
  // }
  // getMemberNameById(id:number){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/member-info/get-memberNameByIdRequest?memberInfoId=' + id);
  // }

  find(id: number) {
    return this.http.get<DemandBook>(this.baseUrl + '/demand-book/get-DemandBookDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/demand-book/update-DemandBook/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/demand-book/save-DemandBook', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/demand-book/delete-DemandBook/'+id);
  }
}
