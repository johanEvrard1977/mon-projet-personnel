import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { catchError, retry } from 'rxjs/operators';
import { Action } from '../Models/action';
import { HttpErrorHandler, HandleError } from './http-error-handler.service';
import { Observable } from 'rxjs';


const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}

@Injectable({
  providedIn: 'root'
})
export class ActionService {

  ActionUrl = 'http://localhost:60504/api/Action/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('ActionService');
  
  }
   /** GET heroes from the server */
   getActions (): Observable<Action[]> {
    
    return this.http.get<Action[]>(this.ActionUrl, httpOptions)
      .pipe(catchError(this.handleError('getActions', []))
      );
  }

  getActionById(id:any): Observable<any> {
    console.log(id);
    return this.http.get<Action>(this.ActionUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getActionById')));
  }
}
