import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { DamageInformationByLibrary } from '../models/DamageInformationByLibrary';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IDamageInformationByLibraryPagination, DamageInformationByLibraryPagination } from '../models/DamageInformationByLibraryPagination'

@Injectable({
  providedIn: 'root'
})
export class DamageInformationByLibraryService {

  baseUrl = environment.apiUrl;
  DamageInformationByLibrarys: DamageInformationByLibrary[] = [];
  DamageInformationByLibraryPagination = new DamageInformationByLibraryPagination();
  constructor(private http: HttpClient) { }

  getDamageInformationByLibrarys(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IDamageInformationByLibraryPagination>(this.baseUrl + '/damage-informationB -by-library/get-DamageInformationByLibraryies', { observe: 'response', params })
    .pipe(
      map(response => {
        this.DamageInformationByLibrarys = [...this.DamageInformationByLibrarys, ...response.body.items];
        this.DamageInformationByLibraryPagination = response.body;
        return this.DamageInformationByLibraryPagination;
      })
    );
  }
  //autocomplete for accessionNo
    getSelectedAccessionNo(accessionno){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/book-information/get-autocompleteAccessionNo?accessionNo='+accessionno)
        .pipe(
          map((response:[]) => response.map(item => item))
        )
    }
    getSelectedSchoolName(baseNameId){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
    }
    getDamageInformationByBorrower(baseSchoolNameId,searchText){
      return this.http.get<any[]>(this.baseUrl + '/book-information/get-damagebyBorrowerList?baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText)
    }
    getBookListByTitle(baseSchoolNameId,bookCategoryId){
      return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookListByTitle?baseSchoolNameId='+baseSchoolNameId+'&bookCategoryId='+bookCategoryId)
    }
    getselectedBookCategory(){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/book-category/get-selectedBookCategories')
    }
    getBookDetailByTitle(baseSchoolNameId,bookTitleInfoId){
      return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookDetailByTitle?baseSchoolNameId='+baseSchoolNameId+'&bookTitleInfoId='+bookTitleInfoId)
    }
    getDamageByBorrowerByDateRange(dateForm,dateTo,baseSchoolNameId){
      return this.http.get<any[]>(this.baseUrl + "/book-information/get-spGetDamageByBorrowerListbyDateRange?dateFrom="+dateForm+"&dateTo="+dateTo+"&baseSchoolNameId="+baseSchoolNameId)
    }
    //book-information/get-spGetDamageByBorrowerListbyDateRange?dateFrom=2023-01-10&dateTo=2023-01-10&baseSchoolNameId=201
   // book-information/get-damagebyBorrowerList?baseSchoolNameId=201&searchText=232'  
  find(id: number) {
    return this.http.get<DamageInformationByLibrary>(this.baseUrl + '/damage-informationB -by-library/get-DamageInformationByLibraryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/damage-informationB -by-library/update-DamageInformationByLibrary/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/damage-informationB -by-library/save-DamageInformationByLibrary', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/damage-informationB -by-library/delete-DamageInformationByLibrary/'+id);
  }
}
