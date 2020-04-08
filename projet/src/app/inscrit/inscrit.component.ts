import { Component, OnInit } from '@angular/core';
import { first, switchMap } from 'rxjs/operators';

import { User } from '../Models/user';
import { AuthenticationService } from '../Services/authentification.service';
import { UserService } from '../Services/user.service';
import { ParamMap, ActivatedRoute, Router } from '@angular/router';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { MatDialogConfig, MatDialog } from '@angular/material/dialog';
import { ModalComponent } from '../modal/modal.component';
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

    constructor(
        private authenticationService: AuthenticationService,
        private userService: UserService,
        private route: ActivatedRoute,
        public matDialog: MatDialog
    ) {
        this.currentUser = this.authenticationService.currentUserValue;
    }

    ngOnInit() {
        let name = this.route.snapshot.paramMap.get('name');
        this.GetByUser(name)
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

  openModal() {
    const dialogConfig = new MatDialogConfig();
    // The user can't close the dialog by clicking outside its body
    dialogConfig.disableClose = true;
    dialogConfig.id = "modal-component";
    dialogConfig.height = "350px";
    dialogConfig.width = "600px";
    // https://material.angular.io/components/dialog/overview
    const modalDialog = this.matDialog.open(ModalComponent, dialogConfig);
  }
}
