import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap, finalize } from 'rxjs/operators';
import { AuthService } from '../guard/auth.service';
import { AppMessageService } from '../service/app-message.service';


@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private authService: AuthService, private appMessageService: AppMessageService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(request).pipe(
            catchError(err => {
                this.appMessageService.appIdle();
                if (err.status === 401) {
                    // auto logout if 401 response returned from api
                    this.authService.logout();
                    location.reload(true);
                }

                const error = err.error.message || err.statusText;
                return throwError(error);
            }));
    }
}