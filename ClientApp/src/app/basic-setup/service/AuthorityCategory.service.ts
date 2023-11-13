import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthorityCategory } from '../models/AuthorityCategory';
import {IAuthorityCategoryPagination, AuthorityCategoryPagination } from '../models/AuthorityCategoryPagination'

@Injectable({
  providedIn: 'root'
})
export class AuthorityCategoryService {

  baseUrl = environment.apiUrl;
  AuthorityCategorys: AuthorityCategory[] = [];
  AuthorityCategoryPagination = new AuthorityCategoryPagination();
  constructor(private http: HttpClient) { }

  getAuthorityCategorys(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IAuthorityCategoryPagination>(this.baseUrl + '/authority-category/get-AuthorityCategories', { observe: 'response', params })
    .pipe(
      map(response => {
        this.AuthorityCategorys = [...this.AuthorityCategorys, ...response.body.items];
        this.AuthorityCategoryPagination = response.body;
        return this.AuthorityCategoryPagination;
      })
    );
  }
  find(id: number) {
    return this.http.get<AuthorityCategory>(this.baseUrl + '/authority-category/get-AuthorityCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/authority-category/update-AuthorityCategory/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/authority-category/save-AuthorityCategory', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/authority-category/delete-AuthorityCategory/'+id);
  }
}
