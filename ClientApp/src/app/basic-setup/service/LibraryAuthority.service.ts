import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LibraryAuthority } from '../models/LibraryAuthority';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {ILibraryAuthorityPagination, LibraryAuthorityPagination } from '../models/LibraryAuthorityPagination'

@Injectable({
  providedIn: 'root'
})
export class LibraryAuthorityService {

  baseUrl = environment.apiUrl;
  LibraryAuthoritys: LibraryAuthority[] = [];
  LibraryAuthorityPagination = new LibraryAuthorityPagination();
  constructor(private http: HttpClient) { }

  getLibraryAuthoritys(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<ILibraryAuthorityPagination>(this.baseUrl + '/library-authority/get-LibraryAuthorities', { observe: 'response', params })
    .pipe(
      map(response => {
        this.LibraryAuthoritys = [...this.LibraryAuthoritys, ...response.body.items];
        this.LibraryAuthorityPagination = response.body;
        return this.LibraryAuthorityPagination;
      })
    );
  }
  // getSelectedSchoolName(baseNameId){
  //   return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  // }
  find(id: number) {
    return this.http.get<LibraryAuthority>(this.baseUrl + '/library-authority/get-LibraryAuthorityDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/library-authority/update-LibraryAuthority/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/library-authority/save-LibraryAuthority', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/library-authority/delete-LibraryAuthority/'+id);
  }
}
