import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BookIssueAndSubmission } from '../models/BookIssueAndSubmission';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {IBookIssueAndSubmissionPagination, BookIssueAndSubmissionPagination } from '../models/BookIssueAndSubmissionPagination'
import { PostResponse } from 'src/app/core/models/PostResponse';

@Injectable({
  providedIn: 'root'
})
export class BookIssueAndSubmissionService {

  baseUrl = environment.apiUrl;
  BookIssueAndSubmissions: BookIssueAndSubmission[] = [];
  BookIssueAndSubmissionPagination = new BookIssueAndSubmissionPagination();
  constructor(private http: HttpClient) { }

  getBookIssueAndSubmissions(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBookIssueAndSubmissionPagination>(this.baseUrl + '/bookissue-and-submission/get-bookIssueAndSubmissions', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BookIssueAndSubmissions = [...this.BookIssueAndSubmissions, ...response.body.items];
        this.BookIssueAndSubmissionPagination = response.body;
        return this.BookIssueAndSubmissionPagination;
      })
    );
  }
  getBookIssueAndSubmissionsListByIsDamaged(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBookIssueAndSubmissionPagination>(this.baseUrl + '/bookissue-and-submission/get-bookIssueAndSubmissionsListByIsDamaged', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BookIssueAndSubmissions = [...this.BookIssueAndSubmissions, ...response.body.items];
        this.BookIssueAndSubmissionPagination = response.body;
        return this.BookIssueAndSubmissionPagination;
      })
    );
  }
  getBookIssueAndSubmissionsByUser(pageNumber, pageSize,searchText,baseSchoolNameId) {

    let params = new HttpParams(); 
    //bookissue-and-submission/get-bookIssueAndSubmissions?PageSize=5&PageNumber=1&baseSchoolNameId=201
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
    return this.http.get<IBookIssueAndSubmissionPagination>(this.baseUrl + '/bookissue-and-submission/get-bookIssueAndSubmissions', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BookIssueAndSubmissions = [...this.BookIssueAndSubmissions, ...response.body.items];
        this.BookIssueAndSubmissionPagination = response.body;
        return this.BookIssueAndSubmissionPagination;
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
    //autocomplete for Pno
  getSelectedPno(pno){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/member-info/get-autocompletePno?pno='+pno)
      .pipe(
        map((response:[]) => response.map(item => item))
      )
  }
  getDamagedByBorrowerListByMemberInfoId( memberInfoId:number){
    return this.http.get<BookIssueAndSubmission[]>(this.baseUrl + '/bookissue-and-submission/get-bookIssueListByMemberInfoId?memberInfoId='+memberInfoId);
   }

   getOnlineBookRequestCountByMember(baseSchoolNameId ,memberInfoId){
    return this.http.get<BookIssueAndSubmission[]>(this.baseUrl + '/online-book-request/get-onlineBookRequestCountByMemberAndLibrary?baseSchoolNameId='+baseSchoolNameId+'&memberInfoId='+memberInfoId+'');
   }

  getselectedRowInfo(shelfInfoId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/row-info/get-selectedRowNameByShelfInfo?shelfInfoId='+shelfInfoId)
  }

  BookIssueListByUser(userId){
    return this.http.get<any[]>(this.baseUrl + '/bookissue-and-submission/get-bookIssueAndSubmissionsListByUser?userId='+userId);
  }
  getselectedShelfInfo(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/shelf-info/get-selectedShelfInfos')
  }
  
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }
  getSelectedBookCategories(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/book-category/get-selectedBookCategories')
  }
  getBookCategoriesList(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/book-category/get-allBookCategoriesList')
  }
  getOnlineBookRequestListByBookInfo(bookInformationId) {
    return this.http.get<any[]>(this.baseUrl + "/online-book-request/get-onlineBookRequestListByBookInfo?bookInformationId="+bookInformationId);
  }
  find(id: number) {
    return this.http.get<BookIssueAndSubmission>(this.baseUrl + '/bookissue-and-submission/get-bookIssueAndSubmissionDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/bookissue-and-submission/update-bookIssueAndSubmission/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/bookissue-and-submission/save-bookIssueAndSubmission', model);
  }

  SaveIssueList(model: any) {
    console.log(model);
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post<PostResponse>(this.baseUrl + '/bookissue-and-submission/save-bookIssueAndSubmissionList', model, httpOptions).pipe(
      map((BNAExamMark: PostResponse) => {
        if (BNAExamMark) {
          console.log(BNAExamMark);
          return BNAExamMark;
        }
      })
    );
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/bookissue-and-submission/delete-bookIssueAndSubmission/'+id);
  }

  returnBookIssueAndSubmission(bookIssueAndSubmissionId,returnStatus){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/bookissue-and-submission/return-bookIssueAndSubmissions?bookIssueAndSubmissionId='+bookIssueAndSubmissionId+'&returnStatus='+returnStatus)
  }
}
