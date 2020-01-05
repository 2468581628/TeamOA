import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ApiResult } from '../ViewModel/api-result';
import { Leave } from '../ViewModel/leave';

@Injectable({
  providedIn: 'root'
})
export class LeaveService {

  constructor(private http: HttpClient) { }

  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' })};

  GetLeaveData() :Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Leave/GetLeaveData");
  }

  AddLeaveData(sd,ed,t,r) :Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Leave/AddLeave",{StartTime:sd,EndTime:ed,Type:t,Remark:r});
  }
}
