import { Component, OnInit } from '@angular/core';
import { User } from '../Models/user';
import { Router } from '@angular/router';
import { AuthenticationService } from '../Services/authentification.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  currentUser: any;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
    }


  ngOnInit(): void {
  }

  retour(nom:any){
    this.router.navigate(['/inscrit/'+this.authenticationService.currentUserValue]);
  }
    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/']);
    }

}
