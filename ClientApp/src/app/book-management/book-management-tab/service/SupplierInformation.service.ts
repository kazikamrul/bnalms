import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SupplierInformation } from '../models/SupplierInformation';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {ISupplierInformationPagination, SupplierInformationPagination } from '../models/SupplierInformationPagination'

@Injectable({
  providedIn: 'root'
})
export class SupplierInformationService {

  baseUrl = environment.apiUrl;
  SupplierInformations: SupplierInformation[] = [];
  SupplierInformationPagination = new SupplierInformationPagination();
  constructor(private http: HttpClient) { }

  getSupplierInformations(pageNumber, pageSize,searchText,bookInformationId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('bookInformationId', bookInformationId.toString());
    return this.http.get<ISupplierInformationPagination>(this.baseUrl + '/supplier-information/get-SupplierInformations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.SupplierInformations = [...this.SupplierInformations, ...response.body.items];
        this.SupplierInformationPagination = response.body;
        return this.SupplierInformationPagination;
      })
    );
  }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  find(id: number) {
    return this.http.get<SupplierInformation>(this.baseUrl + '/supplier-information/get-SupplierInformationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/supplier-information/update-SupplierInformation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/supplier-information/save-SupplierInformation', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/supplier-information/delete-SupplierInformation/'+id);
  }
}
