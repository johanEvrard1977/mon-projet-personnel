import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { Vaisseau } from '../Models/vaisseau'

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}

@Injectable({
  providedIn: 'root'
})
export class VaisseauService {

  VaisseauUrl = 'http://localhost:60504/api/Vaisseau/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('VaisseauService');
  
  }
   /** GET heroes from the server */
   getVaisseaux (): Observable<Vaisseau[]> {
    
    return this.http.get<Vaisseau[]>(this.VaisseauUrl, httpOptions)
      .pipe(catchError(this.handleError('getVaisseaux', []))
      );
  }

  getVaisseauById(Id:string): Observable<any> {
    let test = this.http.get<Vaisseau>(this.VaisseauUrl +Id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getVaisseauById')));
      console.log(test);
      return test;
  }
}
