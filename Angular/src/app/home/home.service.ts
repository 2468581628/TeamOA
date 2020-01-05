import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { tap, delay,map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  // httpOptions = {
  //   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  // };
  constructor(private http: HttpClient) { }

  
  getdata():Observable<any>{
    return this.http.post<any>('http://localhost:50367/api/Leave/AddLeave',JSON.stringify({i:1})).pipe(
      map(data=>{
        console.log(data)
      })
    );
  }
}
