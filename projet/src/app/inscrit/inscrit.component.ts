import { Component, OnInit } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../Models/user';
import { AuthenticationService } from '../Services/authentification.service';
import { UserService } from '../Services/user.service';
@Component({
  selector: 'app-inscrit',
  templateUrl: './inscrit.component.html',
  styleUrls: ['./inscrit.component.css']
})
export class InscritComponent implements OnInit {

  currentUser: User;
    users = [];

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        this.loadAllUsers();
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
}
