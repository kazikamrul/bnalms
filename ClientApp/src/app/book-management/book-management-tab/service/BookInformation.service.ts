import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BookInformation } from '../models/BookInformation';
import { SelectedModel } from 'src/app/core/models/selectedModel';
//import { SelectedModel } from '../../core/models/selectedModel';
import {IBookInformationPagination, BookInformationPagination } from '../models/BookInformationPagination'

@Injectable({
  providedIn: 'root'
})
export class BookInformationService {

  baseUrl = environment.apiUrl;
  BookInformations: BookInformation[] = [];
  BookInformationPagination = new BookInformationPagination();
  constructor(private http: HttpClient) { }

  getBookInformations(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBookInformationPagination>(this.baseUrl + '/book-information/get-BookInformations', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BookInformations = [...this.BookInformations, ...response.body.items];
        this.BookInformationPagination = response.body;
        return this.BookInformationPagination;
      })
    );
  }
  //autocomplete for BookTitle
    getSelectedTitle(title){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/book-title-info/get-autocompleteBookTitle?title='+title)
        .pipe(
          map((response:[]) => response.map(item => item))
        )
    }
    getBookInformationList(){
      return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookInformationListBySp')
    }
    // getBookInfoListByBaseSchoolNameId(baseSchoolNameId){
    //   return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookInformationListBySp?baseSchoolNameId='+baseSchoolNameId+'')
    // }book-information/get-accessionNoIsExistCheck?accessionNo=12
    getBookInformationIsExistCheck(accessionNo){
      return this.http.get<boolean>(this.baseUrl + '/book-information/get-accessionNoIsExistCheck?accessionNo='+accessionNo+'')
    }
    
    getOnlineRequestIsExistCheck(bookInformationId,MemberInfoId){
      return this.http.get<boolean>(this.baseUrl + '/online-book-request/get-onlineRequestIsExistCheck?bookInformationId='+bookInformationId+'&MemberInfoId='+MemberInfoId)
    }


    //previous book information list menu
    // getBookInfoListByBaseSchoolNameId(baseSchoolNameId,searchText,bookCategoryId){
    //   return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookInformationListBySp?baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText+'&bookCategoryId='+bookCategoryId)
    // }

    getBookInfoListByBaseSchoolNameId(baseSchoolNameId,searchText,bookCategoryId,pageSize,pageNumber){
      return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookInformationListBySp?baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText+'&bookCategoryId='+bookCategoryId+'&pageSize='+pageSize+'&pageNumber='+pageNumber)
    }
    //

    getBookInfoListForMemberByBaseSchoolNameId(memberInfoId,baseSchoolNameId,searchText,bookCategoryId,bookTitleInfoId){
      return this.http.get<any[]>(this.baseUrl + '/book-information/get-bookInformationListForMemberBySp?memberInfoId='+memberInfoId+'&baseSchoolNameId='+baseSchoolNameId+'&searchText='+searchText+'&bookCategoryId='+bookCategoryId+'&bookTitleInfoId='+bookTitleInfoId+'')
    }

    //book-information/get-bookInformationListForMemberBySp?memberInfoId=2008&baseSchoolNameId=1224&bookCategoryId=0&bookTitleInfoId=60525'

    getBookIssueInfoByUser(bookInformationId){
      return this.http.get<any>(this.baseUrl + '/book-information/get-bookIssueInfoByUserSp?bookInformationId='+bookInformationId)
    }

    getSelectedSchoolName(baseNameId){
      return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
    }

  getselectedBookCategory(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/book-category/get-selectedBookCategories')
  }
  
  getselectedMainClass(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/main-class/get-selectedMainClasses')
  }
  getselectedLanguages(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/language/get-selectedLanguages')
  }
  getselectedRowInfo(shelfInfoId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/row-info/get-selectedRowNameByShelfInfo?shelfInfoId='+shelfInfoId)
  }
  getselectedShelfInfo(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/shelf-info/get-selectedShelfInfos')
  }
  getselectedSources(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/source/get-selectedSources')
  }

  onlineBookRequestByUser(bookInformationId,memberInfoId){
    return this.http.get(this.baseUrl + '/online-book-request/user-onlineBookRequest?bookInformationId='+bookInformationId+'&memberInfoId='+memberInfoId)
  }

  find(id: number) {
    return this.http.get<BookInformation>(this.baseUrl + '/book-information/get-BookInformationDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/book-information/update-BookInformation/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/book-information/save-BookInformation', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/book-information/delete-BookInformation/'+id);
  }
}
