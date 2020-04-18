import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../Models/user';
import { AlertService } from './alert.service';

const httpOptions = {
    headers: new HttpHeaders({
      'Authorization': 'Basic '+window.btoa('jojo:jojo')
    })
  }

@Injectable({ providedIn: 'root' })
export class AuthenticationService {

    loading = false;
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;
    UserUrl = 'http://localhost:60504/api/Users/';
    

    constructor(private http: HttpClient,
        private alertService: AlertService) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(username, password) {
        
        return this.http.get<User>(this.UserUrl+"Check/"+username+"/"+password, httpOptions)
            .pipe(map(user => {
                let u = new User();
                if(user){
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                console.log(user);
                u.Username = username;
                sessionStorage.setItem('currentUser', JSON.stringify(u));
                this.currentUserSubject.next(u);
                return u != null;
                }
                else 
                {
                    this.alertService.error('Mot de passe et/ou login incorrect', true);
                    this.loading = false;
                    return u == null;
                }
                
            }));
    }

    logout() {
        // remove user from local storage and set current user to null
        sessionStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
    }
}