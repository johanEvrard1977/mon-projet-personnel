import { Injectable } from '@angular/core';
import { User } from '../Models/user';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleError, HttpErrorHandler } from './http-error-handler.service';
import { Observable, BehaviorSubject } from 'rxjs';
import { catchError, retry, map } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({
    'Authorization': 'Basic '+window.btoa('jojo:jojo'),
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*'
  })
}

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private currentUserSubject: BehaviorSubject<User>;
  public currentUser: Observable<User>;
  UserUrl = 'http://localhost:60504/api/Users/';  // URL to web api
  private handleError: HandleError;

  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('UserService');
    this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
  }
   /** GET heroes from the server */
   getUsers (): Observable<User[]> {
    
    return this.http.get<User[]>(this.UserUrl, httpOptions)
      .pipe(catchError(this.handleError('getUsers', []))
      );
      
  }

  getUserById(id:any): Observable<any> {
    return this.http.get<User>(this.UserUrl +id, httpOptions).pipe(
      retry(3), catchError(this.handleError('getUserById')));
  }

  getUserByName(username:string): Observable<any> {
    return this.http.get<User>(this.UserUrl +"GetByName/"+username, httpOptions).pipe(
      retry(3), catchError(this.handleError('getUserByName')));
  }

  checkUser(username:string, password:string){
    return this.http.get<User>(this.UserUrl+"Check/"+username+"/"+password, httpOptions).pipe(
      retry(3), catchError(this.handleError('checkUser')));
  }

  checkUserForPass(user:User){
    return this.http.post(this.UserUrl+"CheckUserForPass/",user, httpOptions);
  }

  update(user: User, id: number) {
    return this.http.put(this.UserUrl+"PutPass/"+ id,user, httpOptions);
}

  register(user: User) {
    return this.http.post(this.UserUrl, user, httpOptions);
}

delete(id: number) {
    return this.http.delete(this.UserUrl + id, httpOptions);
}
}
