import { Component, OnInit } from '@angular/core';
import { slideInAnimation } from '../Models/slide-in-animation';
import { trigger, state, style, transition, animate } from '@angular/animations';
import { ActivatedRoute, Router } from '@angular/router';
import { CollectionService } from '../Services/collection.service';
import { AuthenticationService } from '../Services/authentification.service';
import { EscadronService } from '../Services/escadron.service';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-detail-escadron',
  templateUrl: './detail-escadron.component.html',
  styleUrls: ['./detail-escadron.component.css'],
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
export class DetailEscadronComponent implements OnInit {

  escadrons:any;
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

  constructor(private route: ActivatedRoute,
    private authenticationService: AuthenticationService, private router:Router,
    private escadronService:EscadronService, private userservice:UserService) {
     }

  ngOnInit(): void {
    let id = this.route.snapshot.paramMap.get('Id');
     this.escadronService.getescadronById(id).subscribe(escadron => this.escadrons = escadron);
     this.compteur = 0;
    this.compteur2 = 3; 
    this.compteurp = 0;
    this.compteurp2 = 3; 
    this.compteura = 0;
    this.compteura2 = 3; 
    this.compteure = 0;
    this.compteure2 = 3; 
    this.authenticationService.currentUser.subscribe(x => this.currentUser = x);
  }

  toggle() {
    this.isOpen = !this.isOpen;
}

retour(nom:any){
  this.router.navigate(['/inscrit/'+JSON.parse(sessionStorage.currentUser).Username]);
}

deleteEscadron(id:number){
  this.escadronService.deleteEscadron(id).subscribe(
    (data) => {
      this.escadronService.getescadrons().subscribe(escadron => this.escadrons = escadron);
      this.router.navigate(['/inscrit/'+this.userservice.currentUser]);
    }
  );
}

deleteIntoEscadron(c:number, c2:number){
  
  this.escadrons = {
    "XIDVaisseau": [c],
    "XIDEscadron": c2
  }
  this.escadronService.deleteIntoEscadron(this.escadrons).subscribe(
    (data) => {
      this.escadronService.getescadronById(c2).subscribe(escadron => this.escadrons = escadron);
      this.router.navigate(['/escadron/'+c2]);
    });
}

deletePiloteIntoEscadron(c:number, c2:number){
  
  this.escadrons = {
    "XIDPilote": [c],
    "XIDEscadron": c2
  }
  this.escadronService.deleteIntoEscadron(this.escadrons).subscribe(
    (data) => {
      this.escadronService.getescadronById(c2).subscribe(escadron => this.escadrons = escadron);
      this.router.navigate(['/escadron/'+c2]);
    });
}

deleteAmeliorationIntoEscadron(c:number, c2:number){
  
  this.escadrons = {
    "XIDAmelioration": [c],
    "XIDEscadron": c2
  }
  this.escadronService.deleteIntoEscadron(this.escadrons).subscribe(
    (data) => {
      this.escadronService.getescadronById(c2).subscribe(escadron => this.escadrons = escadron);
      this.router.navigate(['/escadron/'+c2]);
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
