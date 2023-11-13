import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HelpLine } from '../models/HelpLine';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IHelpLinePagination, HelpLinePagination } from '../models/HelpLinePagination'

@Injectable({
  providedIn: 'root'
})
export class HelpLineService {

  baseUrl = environment.apiUrl;
  HelpLines: HelpLine[] = [];
  HelpLinePagination = new HelpLinePagination();
  constructor(private http: HttpClient) { }

  getHelpLines(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IHelpLinePagination>(this.baseUrl + '/help-line/get-HelpLines', { observe: 'response', params })
    .pipe(
      map(response => {
        this.HelpLines = [...this.HelpLines, ...response.body.items];
        this.HelpLinePagination = response.body;
        return this.HelpLinePagination;
      })
    );
  }
  getHelpLineListByDepartment( baseSchoolNameId:number){
    return this.http.get<HelpLine[]>(this.baseUrl + '/help-line/get-helpLineListByDepartmentId?baseSchoolNameId='+baseSchoolNameId);
   }
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getselectedLibraryAuthorities(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/library-authority/get-selectedLibraryAuthorities')
  }

  find(id: number) {
    return this.http.get<HelpLine>(this.baseUrl + '/help-line/get-HelpLineDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/help-line/update-HelpLine/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/help-line/save-HelpLine', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/help-line/delete-HelpLine/'+id);
  }
}
