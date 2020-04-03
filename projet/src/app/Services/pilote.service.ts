import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Pilote } from '../Models/pilote';
const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}
@Injectable({
  providedIn: 'root'
})
export class PiloteService {

  PiloteUrl = 'http://localhost:60504/api/Pilote/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('PiloteService');
  
  }
   /** GET heroes from the server */
   getPilotes (): Observable<Pilote[]> {
    
    return this.http.get<Pilote[]>(this.PiloteUrl, httpOptions)
      .pipe(catchError(this.handleError('getPilotes', []))
      );
      
  }

  getPiloteById(id:any): Observable<any> {
    console.log(id);
    return this.http.get<Pilote>(this.PiloteUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getPiloteById')));
  }
}
