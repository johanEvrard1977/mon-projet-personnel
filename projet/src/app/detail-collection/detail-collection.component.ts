import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CollectionService } from '../Services/collection.service';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { AuthenticationService } from '../Services/authentification.service';
import { Collection } from '../Models/collection';
import { EscadronService } from '../Services/escadron.service';
import { map, switchMap } from 'rxjs/operators';
import { User } from '../Models/user';
import { UserService } from '../Services/user.service';
import { BehaviorSubject } from 'rxjs';

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
  compteur: number;
  compteur2:number;
  compteurp: number;
  compteurp2:number;
  compteura: number;
  compteura2:number;
  compteure: number;
  compteure2:number;
  estCache: boolean;
  lblMessage: string;
  currentUserSubject: any;

  constructor(private route: ActivatedRoute,private collectionService: CollectionService,
    private authenticationService: AuthenticationService, private router:Router,
    private escadronService:EscadronService, private userservice:UserService) {
      this.currentUser = this.authenticationService.currentUserValue;
      this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(sessionStorage.getItem('currentUser')));
    this.currentUser = this.currentUserSubject.asObservable();
     }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('Id');
     this.collectionService.getcollectionById(id).subscribe(Collection => this.collections = Collection);
     this.compteur = 0;
    this.compteur2 = 3; 
    this.compteurp = 0;
    this.compteurp2 = 3; 
    this.compteura = 0;
    this.compteura2 = 3; 
    this.compteure = 0;
    this.compteure2 = 3; 
    sessionStorage.CurrentUser;
  }

  toggle() {
    this.isOpen = !this.isOpen;
}

deleteCollection(id:number){
  this.collectionService.deleteCollection(id).subscribe(
    (data) => {
      this.collectionService.getcollections().subscribe(Collection => this.collections = Collection);
      this.router.navigate(['/inscrit/'+this.userservice.currentUser]);
    }
  );
}

deleteEscadron(id:number){
  this.escadronService.deleteEscadron(id).subscribe();
}

deleteIntoCollection(c:number, c2:number){
  
  this.collections = {
    "XIDVaisseau": [c],
    "XIDCollection": c2
  }
  this.collectionService.deleteIntoCollection(this.collections).subscribe(
    (data) => {
      this.collectionService.getcollectionById(c2).subscribe(Collection => this.collections = Collection);
      this.router.navigate(['/collection/'+c2]);
    });
}

deletePiloteIntoCollection(c:number, c2:number){
  
  this.collections = {
    "XIDPilote": [c],
    "XIDCollection": c2
  }
  this.collectionService.deleteIntoCollection(this.collections).subscribe(
    (data) => {
      this.collectionService.getcollectionById(c2).subscribe(Collection => this.collections = Collection);
      this.router.navigate(['/collection/'+c2]);
    });
}

deleteAmeliorationIntoCollection(c:number, c2:number){
  
  this.collections = {
    "XIDAmelioration": [c],
    "XIDCollection": c2
  }
  this.collectionService.deleteIntoCollection(this.collections).subscribe(
    (data) => {
      this.collectionService.getcollectionById(c2).subscribe(Collection => this.collections = Collection);
      this.router.navigate(['/collection/'+c2]);
    });
  }
next(){
  this.compteur += 3;
  this.compteur2 +=3;
}
before(){
  this.compteur -= 3;
  this.compteur2 -=3;
}
nextP(){
  this.compteurp += 3;
  this.compteurp2 +=3;
}
beforeP(){
  this.compteurp -= 3;
  this.compteurp2 -=3;
}
nextA(){
  this.compteura += 3;
  this.compteura2 +=3;
}
beforeA(){
  this.compteura -= 3;
  this.compteura2 -=3;
}
nextE(){
  this.compteure += 3;
  this.compteure2 +=3;
}
beforeE(){
  this.compteure -= 3;
  this.compteure2 -=3;
}
}
