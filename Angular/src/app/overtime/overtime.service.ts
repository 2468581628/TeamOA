import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResult } from '../ViewModel/api-result';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OvertimeService {

  constructor(private http: HttpClient) { }

  AddOvertime(starttTime:Date,endTime:Date,inputValue:string):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Overtime/AddOvertime",{StarttTime:starttTime,EndTime:endTime,InputValue:inputValue});
  }

  GetData():Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Overtime/GetOvertime")
  }
}
