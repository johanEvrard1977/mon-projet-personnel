import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable } from 'rxjs';
import { Escadron } from '../Models/escadron';
import { catchError, retry } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo')
  })
}

@Injectable({
  providedIn: 'root'
})
export class EscadronService {

  EscadronUrl = 'http://localhost:60504/api/Escadron/';  // URL to web api
  private handleError: HandleError;
  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('EscadronService');
  
  }
   /** GET heroes from the server */
   getescadrons (): Observable<Escadron[]> {
    
    return this.http.get<Escadron[]>(this.EscadronUrl, httpOptions)
      .pipe(catchError(this.handleError('getescadrons', []))
      );
  }

  getescadronById(id:any): Observable<any> {
    console.log(this.EscadronUrl +id);
    return this.http.get<Escadron>(this.EscadronUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getescadronById')));
  }

  register(escadron: Escadron) {
    return this.http.post(this.EscadronUrl, escadron, httpOptions);
}

registerIntoEscadron(escadron: Escadron) {
  return this.http.post(this.EscadronUrl+"PostElements", escadron, httpOptions);
}

deleteEscadron(id:number){
  return this.http.delete(this.EscadronUrl+id, httpOptions)
}

deleteIntoEscadron(col: Escadron) {
  console.log(col);
  let result = this.http.post(this.EscadronUrl+"DeleteIntoEscadron", col, httpOptions);
  console.log(result);
      return result;
}
}
