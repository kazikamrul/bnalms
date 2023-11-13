import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { BookCategory } from '../models/BookCategory';
import {IBookCategoryPagination, BookCategoryPagination } from '../models/BookCategoryPagination'

@Injectable({
  providedIn: 'root'
})
export class BookCategoryService {

  baseUrl = environment.apiUrl;
  BookCategorys: BookCategory[] = [];
  BookCategoryPagination = new BookCategoryPagination();
  constructor(private http: HttpClient) { }

  getBookCategorys(pageNumber, pageSize,searchText) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    return this.http.get<IBookCategoryPagination>(this.baseUrl + '/book-category/get-BookCategories', { observe: 'response', params })
    .pipe(
      map(response => {
        this.BookCategorys = [...this.BookCategorys, ...response.body.items];
        this.BookCategoryPagination = response.body;
        return this.BookCategoryPagination;
      })
    );
  }
  find(id: number) {
    return this.http.get<BookCategory>(this.baseUrl + '/book-category/get-BookCategoryDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/book-category/update-BookCategory/'+id, model);
  }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/book-category/save-BookCategory', model);
  }
  delete(id){
    return this.http.delete(this.baseUrl + '/book-category/delete-BookCategory/'+id);
  }
}
