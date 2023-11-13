import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ReaderInformation } from '../models/ReaderInformation';
import { SelectedModel } from '../../core/models/selectedModel';
import {IReaderInformationPagination, ReaderInformationPagination } from '../models/ReaderInformationPagination'

@Injectable({
  providedIn: 'root'
})
export class ReaderInformationService {

  baseUrl = environment.apiUrl;
  ReaderInformations: ReaderInformation[] = [];
  ReaderInformationPagination = new ReaderInformationPagination();
  constructor(private http: HttpClient) { }

  getReaderInformations(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IReaderInformationPagination>(this.baseUrl + '/reader-information/get-ReaderInformations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.ReaderInformations = [...this.ReaderInformations, ...response.body.items];
        this.ReaderInformationPagination = response.body;
        return this.ReaderInformationPagination;
      })
    );
  }
  //autocomplete for Pno
  getSelectedPno(pno){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/member-info/get-autocompletePno?pno='+pno)
      .pipe(
        map((response:[]) => response.map(item => item))
      )
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<ReaderInformation>(this.baseUrl + '/reader-information/get-ReaderInformationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/reader-information/update-ReaderInformation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/reader-information/save-ReaderInformation', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/reader-information/delete-ReaderInformation/'+id);
  }
}
