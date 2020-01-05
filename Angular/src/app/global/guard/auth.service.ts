import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { tap, delay,map } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }
  
  isLoggedIn = false;

  // store the URL so we can redirect after logging in
  redirectUrl: string;

  login(username: string, password: string): Observable<boolean> {
    return this.http.post<any>('http://localhost:50367/api/Login/Login', { account:username, password:password })
          .pipe(map(user => {
              // login successful if there's a jwt token in the response
              if (user && user.token) {
                  // store user details and jwt token in local storage to keep user logged in between page refreshes
                  localStorage.setItem('currentUser', JSON.stringify(user));
              }

              return user;
          }));
  }

  logout(): void {
    localStorage.removeItem('currentUser');
  }
}
