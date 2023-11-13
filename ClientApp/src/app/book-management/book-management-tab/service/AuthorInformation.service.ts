import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthorInformation } from '../models/AuthorInformation';
import { SelectedModel } from 'src/app/core/models/selectedModel';
//import { SelectedModel } from '../../core/models/selectedModel';
import {IAuthorInformationPagination, AuthorInformationPagination } from '../models/AuthorInformationPagination'

@Injectable({
  providedIn: 'root'
})
export class AuthorInformationService {

  baseUrl = environment.apiUrl;
  AuthorInformations: AuthorInformation[] = [];
  AuthorInformationPagination = new AuthorInformationPagination();
  constructor(private http: HttpClient) { }

  getAuthorInformations(pageNumber, pageSize,searchText, bookInformationId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('bookInformationId', bookInformationId.toString());
    return this.http.get<IAuthorInformationPagination>(this.baseUrl + '/author-information/get-AuthorInformations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.AuthorInformations = [...this.AuthorInformations, ...response.body.items];
        this.AuthorInformationPagination = response.body;
        return this.AuthorInformationPagination;
      })
    );
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselectedAuthorCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/authority-category/get-selectedAuthorityCategories')
  }
  find(id: number) {
    return this.http.get<AuthorInformation>(this.baseUrl + '/author-information/get-AuthorInformationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/author-information/update-AuthorInformation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/author-information/save-AuthorInformation', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/author-information/delete-AuthorInformation/'+id);
  }
}
