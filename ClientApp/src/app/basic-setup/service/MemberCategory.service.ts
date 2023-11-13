import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { MemberCategory } from '../models/MemberCategory';
import {IMemberCategoryPagination, MemberCategoryPagination } from '../models/MemberCategoryPagination'

@Injectable({
  providedIn: 'root'
})
export class MemberCategoryService {

  baseUrl = environment.apiUrl;
  MemberCategorys: MemberCategory[] = [];
  MemberCategoryPagination = new MemberCategoryPagination();
  constructor(private http: HttpClient) { }

  getMemberCategorys(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IMemberCategoryPagination>(this.baseUrl + '/member-category/get-memberCategories', { observe: 'response', params })
    .pipe(
      map(response => {
        this.MemberCategorys = [...this.MemberCategorys, ...response.body.items];
        this.MemberCategoryPagination = response.body;
        return this.MemberCategoryPagination;
      })
    );
  }
  find(id: number) {
    return this.http.get<MemberCategory>(this.baseUrl + '/member-category/get-memberCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/member-category/update-memberCategory/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/member-category/save-memberCategory', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/member-category/delete-memberCategory/'+id);
  }
}
