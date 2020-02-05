import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ApiResult } from '../ViewModel/api-result';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArticleWagesService {

  constructor(private http: HttpClient) { }

  UpLoadingFile(files:FormData):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Cost/UploaderFile",files);
  }
}
