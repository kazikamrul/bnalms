import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SoftCopyUpload } from '../models/SoftCopyUpload';
import { SelectedModel } from 'src/app/core/models/selectedModel';
import {ISoftCopyUploadPagination, SoftCopyUploadPagination } from '../models/SoftCopyUploadPagination'

@Injectable({
  providedIn: 'root'
})
export class SoftCopyUploadService {

  baseUrl = environment.apiUrl;
  SoftCopyUploads: SoftCopyUpload[] = [];
  SoftCopyUploadPagination = new SoftCopyUploadPagination();
  constructor(private http: HttpClient) { }

  getSoftCopyUploads(pageNumber, pageSize,searchText,baseSchoolNameId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
    return this.http.get<ISoftCopyUploadPagination>(this.baseUrl + '/soft-copy-upload/get-SoftCopyUploads', { observe: 'response', params })
    .pipe(
      map(response => {
        this.SoftCopyUploads = [...this.SoftCopyUploads, ...response.body.items];
        this.SoftCopyUploadPagination = response.body;
        return this.SoftCopyUploadPagination;
      })
    );
  }

  getSoftCopyUploadsByDocumentType(pageNumber, pageSize,searchText,baseSchoolNameId,documentTypeId) {

    let params = new HttpParams();

    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
    params = params.append('documentTypeId', documentTypeId.toString());
    return this.http.get<ISoftCopyUploadPagination>(this.baseUrl + '/soft-copy-upload/get-SoftCopyUploadsByDocumentType', { observe: 'response', params })
    .pipe(
      map(response => {
        this.SoftCopyUploads = [...this.SoftCopyUploads, ...response.body.items];
        this.SoftCopyUploadPagination = response.body;
        return this.SoftCopyUploadPagination;
      })
    );
  }

  getSelectedPno(pno){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/member-info/get-autocompletePno?pno='+pno)
      .pipe(
        map((response:[]) => response.map(item => item))
      )
  }
  
  getSelectedSchoolName(baseNameId){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchoolNames?thirdLevel='+baseNameId)
  }

  getSelectedDocumentType(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/document-type/get-selectedDocumentTypes')
  }

  find(id: number) {
    return this.http.get<SoftCopyUpload>(this.baseUrl + '/soft-copy-upload/get-SoftCopyUploadDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/soft-copy-upload/update-SoftCopyUpload/'+id, model);
  }
  // submit(model: any) {
  //   return this.http.post(this.baseUrl + '/soft-copy-upload/save-SoftCopyUpload', model);
  // }

  submit(model: any) {
    return this.http.post(this.baseUrl + '/soft-copy-upload/save-SoftCopyUpload', model,{
      reportProgress: true,
      observe: 'events',
    }).pipe(
      map((VideoFile: any) => {
        if (VideoFile) {
          console.log(VideoFile);
          return VideoFile;
        }
      })
    );
  } 

  delete(id){
    return this.http.delete(this.baseUrl + '/soft-copy-upload/delete-SoftCopyUpload/'+id);
  }
}
