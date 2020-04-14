import { Component, OnInit } from '@angular/core';
import { first, switchMap } from 'rxjs/operators';
import { User } from '../Models/user';
import { AuthenticationService } from '../Services/authentification.service';
import { UserService } from '../Services/user.service';
import { ParamMap, ActivatedRoute, Router } from '@angular/router';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';
@Component({
  selector: 'app-inscrit',
  templateUrl: './inscrit.component.html',
  styleUrls: ['./inscrit.component.css'],
  animations: [
    slideInAnimation,
    // animation triggers go here
  
    trigger('openClose', [
      state('open', style({
        width: '250px',
        opacity: 1,
        backgroundColor: 'red'
      })),
      state('closed', style({
        opacity: 0,
        backgroundColor: 'pink'
      })),
      transition('* => *', [
        animate('0.7s')
      ]),
      ]),
  ],
})
export class InscritComponent implements OnInit {

    currentUser: User;
    users:any;
    isOpen = true;
    compteur: number;
    compteur2:number;

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private route: ActivatedRoute
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        let name = this.route.snapshot.paramMap.get('name');
        this.GetByUser(name);
        this.compteur = 0;
        this.compteur2 = 12;
    }

    deleteUser(id: number) {
        this.userService.delete(id)
            .pipe(first())
            .subscribe(() => this.loadAllUsers());
    }

    private loadAllUsers() {
        this.userService.getUsers()
            .pipe(first())
            .subscribe(users => this.users = users);
    }

    GetByUser(name:string) {
        this.userService.getUserByName(name)
            .pipe(first())
            .subscribe(users => this.users = users);
    }

    toggle() {
        this.isOpen = !this.isOpen;
  }

  next(){
    this.compteur += 12;
    this.compteur2 +=12;
  }
  before(){
    this.compteur -= 12;
    this.compteur2 -=12;
  }
}
