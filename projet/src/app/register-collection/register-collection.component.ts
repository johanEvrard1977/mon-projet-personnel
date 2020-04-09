import { Component, OnInit } from '@angular/core';
import { Vaisseau } from '../Models/vaisseau';
import { VaisseauService } from '../Services/vaisseau.service';
import { CollectionService } from '../Services/collection.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { AlertService } from '../Services/alert.service';
import { PiloteService } from '../Services/pilote.service';
import { Pilote } from '../Models/pilote';
import { Amelioration } from '../Models/amelioration';
import { AmeliorationService } from '../Services/amelioration.service';
import { Camp } from '../Models/camp';
import { CampService } from '../Services/camp.service';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-register-collection',
  templateUrl: './register-collection.component.html',
  styleUrls: ['./register-collection.component.css'],
  
})
export class RegisterCollectionComponent implements OnInit {

  //vaisseaux: Vaisseau[];
  get vaisseaux():Vaisseau[]{ 
    if(this.changeCamps == undefined)
      return [];
    else
      return this.changeCamps.Vaisseau}
  //pilotes: Pilote[];
  get pilotes():Pilote[]{ 
    if(this.changeCamps == undefined)
      return [];
    else
      return this.changeCamps.Pilote}
  changePilote:any;
  ameliorations:Amelioration[];
  camps:Camp[];
  changeCamps:Camp;
  registerForm: FormGroup;
  submitted = false;
  Nom:string;
  XIDVaisseau:number;
  XIDPilote:number;
  XIDAmelioration:number;
  XIDCamp:number;
  UserId:number;
  quantiteV:number;
  quantiteP:number;
  quantiteA:number;
  objetCollection:any;
  collections:any;
  users:any;
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,private vaisseauService: VaisseauService,
    private alertService: AlertService, private collectionService: CollectionService,
    private piloteService: PiloteService, private ameliorationService:AmeliorationService,
    private campService:CampService, private userService:UserService) { }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      Nom: ['', Validators.required],
      Vaisseau: ['', Validators.required],
      Pilote: ['', Validators.required],
      Amelioration: ['', Validators.required],
      Camp: ['', Validators.required],
      UserId: [''],
      quantiteV:['', Validators.required],
      quantiteP:['', Validators.required],
      quantiteA:['', Validators.required],
  });
  this.getCamps();
  this.XIDCamp = 1;
  this.campService.getCampById(this.XIDCamp)
  .subscribe(heroes => (this.changeCamps = heroes));
  let id = this.route.snapshot.paramMap.get('Id');
     this.userService.getUserById(id).subscribe(user => this.users = user); 
  }

  // convenience getter for easy access to form fields
  get f() { return this.registerForm.controls; }

  onSubmit() {
      this.submitted = true;

      // reset alerts on submit
      this.alertService.clear();

      // stop here if form is invalid
      if (this.registerForm.invalid) {
          return;
      }
      
      this.XIDVaisseau = this.registerForm.value.Vaisseau;
      this.Nom = this.registerForm.value.Nom;
      this.XIDAmelioration = this.registerForm.value.Amelioration;
      this.XIDPilote = this.registerForm.value.Pilote;
      this.UserId = this.registerForm.value.UserId;
      this.quantiteV = this.registerForm.value.quantiteV;
      this.quantiteP = this.registerForm.value.quantiteP;
      this.quantiteA = this.registerForm.value.quantiteA;
      
      this.objetCollection = {
        "Nom": this.Nom, "XIDVaisseau":this.XIDVaisseau,
        "XIDAmelioration":this.XIDAmelioration,"XIDPilote":this.XIDPilote,
        "XIDUser":this.UserId, "quantiteVaisseau":this.quantiteV, "quantitePilote":this.quantiteP,
        "quantiteAmelioration":this.quantiteA
      };
     /* this.collectionService.register(this.objetCollection)
          .pipe(first())
          .subscribe(
              data => {
                  this.alertService.success('Registration successful', true);
                  //this.router.navigate(['/login']);
              },
              error => {
                  this.alertService.error(error);
              });*/
  }

  /*getVaisseaux(): void {
    this.vaisseauService.getVaisseaux()
      .subscribe(heroes => (this.vaisseaux = heroes));
  }
  getPilotes(): void{
    this.piloteService.getPilotes()
    .subscribe(heroes => (this.pilotes = heroes));
  }

  getAmeliorations(): void{
    this.ameliorationService.getAmeliorations()
    .subscribe(heroes => (this.ameliorations = heroes));
  }
*/
  getCamps(): void{
    this.campService.getCamps()
    .subscribe(heroes => (this.camps = heroes));
  }

  changement(evenement) {

   this.XIDCamp = evenement.value;
   this.campService.getCampById(this.XIDCamp)
    .subscribe(heroes => (this.changeCamps = heroes));
}

changementPilote(evenement) {

  this.XIDPilote = evenement.value;
  this.piloteService.getPiloteById(this.XIDPilote)
   .subscribe(heroes => (this.changePilote = heroes));
}
}