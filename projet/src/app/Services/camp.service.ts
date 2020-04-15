import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Camp } from '../Models/camp';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}

@Injectable({
  providedIn: 'root'
})
export class CampService {

  CampUrl = 'http://localhost:60504/api/Camp/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('CampService');
  
  }
   /** GET heroes from the server */
   getCamps (): Observable<Camp[]> {
    
    return this.http.get<Camp[]>(this.CampUrl, httpOptions)
      .pipe(catchError(this.handleError('getCamps', []))
      );
  }

  getCampById(id:number): Observable<any> {
    return this.http.get<Camp>(this.CampUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getCampById')));
  }
}
