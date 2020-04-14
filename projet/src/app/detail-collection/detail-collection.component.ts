import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CollectionService } from '../Services/collection.service';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { AuthenticationService } from '../Services/authentification.service';

@Component({
  selector: 'app-detail-collection',
  templateUrl: './detail-collection.component.html',
  styleUrls: ['./detail-collection.component.css'],
  animations: [
    slideInAnimation,
    // animation triggers go here
  
    trigger('openClose', [
      state('open', style({
        width: '300px',
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
export class DetailCollectionComponent implements OnInit {

  collections:any;
  isOpen = true;
  currentUser: any;

  constructor(private route: ActivatedRoute,private collectionService: CollectionService,
    private authenticationService: AuthenticationService) {
      this.currentUser = this.authenticationService.currentUserValue;
     }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('Id');
     this.collectionService.getcollectionById(id).subscribe(Collection => this.collections = Collection) 
  }

  toggle() {
    this.isOpen = !this.isOpen;
}

deleteCollection(id:number){
  this.collectionService.deleteCollection(id);
}

deleteVaisseau(idV:number, idC:number){
  this.collectionService.deleteVaisseau(idV, idC);
}

deletePilote(idP:number, idC:number){
  this.collectionService.deletePilote(idP, idC);
}

deleteAmelioration(idA:number, idC:number){
  this.collectionService.deleteAmelioration(idA, idC);
}
}
