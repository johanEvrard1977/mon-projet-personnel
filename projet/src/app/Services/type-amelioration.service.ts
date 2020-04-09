import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable } from 'rxjs';
import { type } from '../Models/type';
import { catchError, retry } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}

@Injectable({
  providedIn: 'root'
})
export class TypeAmeliorationService {

  TypeUrl = 'http://localhost:60504/api/TypeAmelioration/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('TypeAmeliorationService');
  
  }
   /** GET heroes from the server */
   getTypes (): Observable<type[]> {
    
    return this.http.get<type[]>(this.TypeUrl, httpOptions)
      .pipe(catchError(this.handleError('getTypes', []))
      );
      
  }

  getTypeById(id:any): Observable<any> {
    console.log(id);
    return this.http.get<type>(this.TypeUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getTypeById')));
  }
}
