import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResult } from '../ViewModel/api-result';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CheckService {

  constructor(private http: HttpClient) { }

  GetLeaveInfo():Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Check/GetLeaveInfo");
  }
  GetOvertimeInfo():Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Check/GetOvertime");
  }
  GetCostInfo():Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Check/GetCost");
  }

  CheckInfo(userId:number,status:string,checkType:number):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Check/CheckInfo",{ID:userId,Status:status,Type:checkType});
  }

  GetFile():Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Check/DownFile");
  }
}
