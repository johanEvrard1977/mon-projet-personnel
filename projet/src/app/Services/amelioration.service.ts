import { Injectable } from '@angular/core';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Amelioration } from '../Models/amelioration';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}

@Injectable({
  providedIn: 'root'
})
export class AmeliorationService {

  AmeliorationUrl = 'http://localhost:60504/api/Amelioration/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('AmeliorationService');
  
  }
   /** GET heroes from the server */
   getAmeliorations (): Observable<Amelioration[]> {
    
    return this.http.get<Amelioration[]>(this.AmeliorationUrl, httpOptions)
      .pipe(catchError(this.handleError('getAmeliorations', []))
      );
      
  }

  getAmeliorationById(id:any): Observable<any> {
    console.log(id);
    return this.http.get<Amelioration>(this.AmeliorationUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getAmeliorationById')));
  }
}
