import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Rank } from '../models/Rank';
import {IRankPagination, RankPagination } from '../models/RankPagination';
import { SelectedModel } from '../../core/models/selectedModel';

@Injectable({
  providedIn: 'root'
})
export class RankService {

  baseUrl = environment.apiUrl;
  Ranks: Rank[] = [];
  RankPagination = new RankPagination();
  constructor(private http: HttpClient) { }

  getRanks(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IRankPagination>(this.baseUrl + '/rank/get-Ranks', { observe: 'response', params })
    .pipe(
      map(response => {
        this.Ranks = [...this.Ranks, ...response.body.items];
        this.RankPagination = response.body;
        return this.RankPagination;
      })
    );
  }
  getselectedDesignation(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/designation/get-selectedDesignations')
  }
  find(id: number) {
    return this.http.get<Rank>(this.baseUrl + '/rank/get-RankDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/rank/update-Rank/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/rank/save-Rank', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/rank/delete-Rank/'+id);
  }
}
