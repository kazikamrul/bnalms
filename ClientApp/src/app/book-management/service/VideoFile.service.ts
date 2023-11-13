import { Injectable } from '@angular/core';

import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { IVideoFilePagination,VideoFilePagination } from '../models/VideoFilePagination';
import { VideoFile } from '../models/VideoFile';
import { SelectedModel } from '../../core/models/selectedModel';
import { map } from 'rxjs';
import { PostResponse } from 'src/app/core/models/PostResponse';

@Injectable({
  providedIn: 'root'
})
export class VideoFileService {
  baseUrl = environment.apiUrl;
  VideoFiles: VideoFile[] = [];
  VideoFilePagination = new VideoFilePagination(); 
  constructor(private http: HttpClient) { }

  getSelectedVideoFile(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/reading-material-title/get-selectedVideoFileTitles')
  }
  getselectedcoursename(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/course-name/get-selectedCourseNames')
  }

  getselectedschools(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/base-School-name/get-selectedSchools')
  }

  getselectedDocumentType(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/document-type/get-selectedDocumentTypes')
  }

  getselectedShowRight(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/show-right/get-selectedShowRight')
  }

  getselecteddownloadright(){
    return this.http.get<SelectedModel[]>(this.baseUrl + '/download-right/get-selectedDownloadRights')
  }
 

  getVideoFilesBySchool(pageNumber, pageSize,searchText, baseSchoolNameId) {

    let params = new HttpParams(); 
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
   
    return this.http.get<IVideoFilePagination>(this.baseUrl + '/reading-material/get-VideoFiles', { observe: 'response', params })
    .pipe(
      map(response => {
        this.VideoFiles = [...this.VideoFiles, ...response.body.items];
        this.VideoFilePagination = response.body;
        return this.VideoFilePagination;
      })
    ); 
  }
  getVideoFiles(pageNumber, pageSize,searchText) {

    let params = new HttpParams(); 
    
    params = params.append('searchText', searchText.toString());
    params = params.append('pageNumber', pageNumber.toString());
    params = params.append('pageSize', pageSize.toString());
    //params = params.append('baseSchoolNameId', baseSchoolNameId.toString());
   
    return this.http.get<IVideoFilePagination>(this.baseUrl + '/video-file/get-VideoFiles', { observe: 'response', params })
    .pipe(
      map(response => {
        this.VideoFiles = [...this.VideoFiles, ...response.body.items];
        this.VideoFilePagination = response.body;
        return this.VideoFilePagination;
      })
    ); 
  }
  getSelectedVideoFileByMaterialTitleIdBaseSchoolIdAndCourseNameId(baseSchoolNameId,courseNameId,VideoFileTitleId){
    return this.http.get<VideoFile[]>(this.baseUrl + '/reading-material/get-selectedVideoFileByMaterialTitleIdBaseSchoolIdAndCourseNameId?baseSchoolNameId='+baseSchoolNameId+'&courseNameId='+courseNameId+'&materialTitleId='+VideoFileTitleId+'');
  }
  find(id: number) {
    return this.http.get<VideoFile>(this.baseUrl + '/video-file/get-VideoFileDetail/' + id);
  }
  update(id: number,model: any) {
    return this.http.put(this.baseUrl + '/video-file/update-VideoFile/'+id, model,{
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
  // submit(model: any) {
    
  //   return this.http.post<PostResponse>(this.baseUrl + '/reading-material/save-VideoFile', model).pipe(
  //     map((VideoFile: PostResponse) => {
  //       if (VideoFile) {
  //         console.log(VideoFile);
  //         return VideoFile;
  //       }
  //     })
  //   );
  // } 
  // submit(model: any) {
  //   return this.http.post(this.baseUrl + '/soft-copy-upload/save-SoftCopyUpload', model);
  // }
  submit(model: any) {
    return this.http.post(this.baseUrl + '/video-file/save-VideoFile', model,{
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
  delete(id:number){
    return this.http.delete(this.baseUrl + '/video-file/delete-VideoFile/'+id);
  }
}
