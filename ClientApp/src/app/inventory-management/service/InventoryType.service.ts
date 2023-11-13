import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { InventoryType } from '../models/InventoryType';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IInventoryTypePagination, InventoryTypePagination } from '../models/InventoryTypePagination'

@Injectable({
  providedIn: 'root'
})
export class InventoryTypeService {

  baseUrl = environment.apiUrl;
  InventoryTypes: InventoryType[] = [];
  InventoryPagination = new InventoryTypePagination();
  constructor(private http: HttpClient) { }

  getInventoryTypes(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IInventoryTypePagination>(this.baseUrl + '/inventory-types/get-InventoryTypes', { observe: 'response', params })
    .pipe(
      map(response => {
        this.InventoryTypes = [...this.InventoryTypes, ...response.body.items];
        this.InventoryPagination = response.body;
        return this.InventoryPagination;
      })
    );
  }
 

  find(id: number) {
    return this.http.get<InventoryType>(this.baseUrl + '/inventory-types/get-InventoryTypeDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/inventory-types/update-InventoryType/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/inventory-types/save-InventoryType', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/inventory-types/delete-InventoryType/'+id);
  }
}
