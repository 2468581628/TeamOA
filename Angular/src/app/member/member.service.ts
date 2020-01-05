import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResult } from '../ViewModel/api-result';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MemberService {

  constructor(private http: HttpClient) { }

  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' })};

  getData() :Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Member/GetMemberData")
  }

  AddMem(name:string,password:string,account:string,tel:string):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Member/InsMemberData",{USERNAME:name,ACCOUNT:account,STATUS:true,TEL:tel,PASSWORD:password},this.httpOptions);
  }

  UpdStatusData(status:boolean,id:number):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Member/UpdStatusData",{ID:id,STATUS:status},this.httpOptions);
  }

  ChangeMemberInfo(id:number,name:string,tel:string):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Member/UpdMemberData",{ID:id,USERNAME:name,TEL:tel},this.httpOptions);
  }

  ChangePassWord(id:number,password:string):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Member/UpdPasswordData",{ID:id,PASSWORD:password},this.httpOptions);
  }
}
