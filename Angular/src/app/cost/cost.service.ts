import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResult } from '../ViewModel/api-result';
import { HttpClient } from '@angular/common/http';
import { CostFileName } from '../ViewModel/cost-file-name';

@Injectable({
  providedIn: 'root'
})
export class CostService {

  constructor(private http: HttpClient) { }

  UpLoadingFile(files:FormData):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Cost/UploaderFile",files);
  }

  AddCostData(costType:string,costCount:number,costFileName:CostFileName):Observable<ApiResult>{
    return this.http.post<ApiResult>("http://localhost:50367/api/Cost/AddCostData",{CostType:costType,CostCount:costCount,CostFileName:{FileName:costFileName.fileName,NewFileName:costFileName.newFileName}});
  }

  GetCostData():Observable<ApiResult>{
    return this.http.get<ApiResult>("http://localhost:50367/api/Cost/GetCostData");
  }
}
