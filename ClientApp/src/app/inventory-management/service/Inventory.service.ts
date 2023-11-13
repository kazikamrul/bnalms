import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Inventory } from '../models/Inventory';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IInventoryPagination, InventoryPagination } from '../models/InventoryPagination'

@Injectable({
  providedIn: 'root'
})
export class InventoryService {

  baseUrl = environment.apiUrl;
  Inventorys: Inventory[] = [];
  InventoryPagination = new InventoryPagination();
  constructor(private http: HttpClient) { }

  getInventorys(pageNumber, pageSize,searchText,baseSchoolNameId,inventoryTypeId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
    params = params.append('inventoryTypeId', inventoryTypeId.toString());
    return this.http.get<IInventoryPagination>(this.baseUrl + '/inventory/get-Inventorys', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Inventorys = [...this.Inventorys, ...response.body.items];
        this.InventoryPagination = response.body;
        return this.InventoryPagination;
      })
    );
  }
  getInventoryListByDepartment( baseSchoolNameId:number){
    return this.http.get<Inventory[]>(this.baseUrl + '/inventory/get-InventoryListByDepartmentId?baseSchoolNameId='+baseSchoolNameId);
   }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselectedLibraryAuthorities(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/library-authority/get-selectedLibraryAuthorities')
  }
  getselectedInventoryTypes(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/inventory-types/get-selectedInventoryTypes')
  }

  find(id: number) {
    return this.http.get<Inventory>(this.baseUrl + '/inventory/get-InventoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/inventory/update-Inventory/'+id, model);
  }
  //inventory/update-inventorystatus/1
  updateInventory(id: number,model: any){
    return this.http.put(this.baseUrl + '/inventory/update-inventorystatus/'+id, model);
  }

  submit(model: any) {
    return this.http.post(this.baseUrl + '/inventory/save-Inventory', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/inventory/delete-Inventory/'+id);
  }
}
