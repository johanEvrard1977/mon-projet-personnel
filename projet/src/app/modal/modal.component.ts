import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { Camp } from '../Models/camp';
import { CampService } from '../Services/camp.service';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../Services/user.service';
import { first } from 'rxjs/operators';
import { CollectionService } from '../Services/collection.service';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ModalComponent>,private userService: UserService,
    private route: ActivatedRoute, private campService:CampService,
    private collectionService: CollectionService) { }

  camps: any;
  users:any;
  collections:any;

  ngOnInit(): void {
    let name = this.route.snapshot.paramMap.get('name');
        this.GetByUser(name);
        let id = this.route.snapshot.paramMap.get('Id');
     this.collectionService.getcollectionById(id).subscribe(Collection => this.collections = Collection); 
     this.getCamps();
  }

  GetByUser(name:string) {
    this.userService.getUserByName(name)
        .pipe(first())
        .subscribe(users => this.users = users);
}

  getCamps(): void {
    this.campService.getCamps()
      .subscribe(heroes => (this.camps = heroes));
  }


  getCampById(id: any) {
    this.campService.getCampById(id)
      .subscribe(data => {
        this.camps = data
      });
  }

  // When the user clicks the action button a.k.a. the logout button in the\
  // modal, show an alert and followed by the closing of the modal
  actionFunction() {
    alert("You have logged out.");
    this.closeModal();
  }

  // If the user clicks the cancel button a.k.a. the go back button, then\
  // just close the modal
  closeModal() {
    this.dialogRef.close();
  }

}
