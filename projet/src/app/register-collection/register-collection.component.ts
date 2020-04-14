import { Component, OnInit } from '@angular/core';
import { Vaisseau } from '../Models/vaisseau';
import { VaisseauService } from '../Services/vaisseau.service';
import { CollectionService } from '../Services/collection.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../Services/alert.service';
import { PiloteService } from '../Services/pilote.service';
import { Pilote } from '../Models/pilote';
import { Amelioration } from '../Models/amelioration';
import { AmeliorationService } from '../Services/amelioration.service';
import { Camp } from '../Models/camp';
import { CampService } from '../Services/camp.service';
import { UserService } from '../Services/user.service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../Services/authentification.service';

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
      return this.changeCamps.Vaisseau
    }
  //pilotes: Pilote[];
  get pilotes():Pilote[]{ 
    if(this.changeCamps == undefined)
      return [];
    else
      return this.changeCamps.Pilote
    }

  //ameliorations:Amelioration[];
  get ameliorations():Amelioration[]{ 
    if(this.changeCamps == undefined)
      return [];
    else
      return this.changeCamps.Amelioration
    }
    
  currentUser: any;
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
  objetCollection:any;
  collections:any;
  users:any;
  flag:number;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,private alertService: AlertService,
    private collectionService: CollectionService, private router:Router,
    private campService:CampService, private userService:UserService,
    private authenticationService: AuthenticationService) { 
      this.currentUser = this.authenticationService.currentUserValue;
    }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      Nom: ['', Validators.required, Validators.minLength(3)],
      Vaisseau: [''],
      Pilote: [''],
      Amelioration: [''],
      Camp: [''],
      UserId: [''],
  });
  
  this.getCamps();
  this.XIDCamp = 1;
  this.flag = 1;
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
      this.XIDCamp = this.registerForm.value.Camp;
      
      this.objetCollection = {
        "Nom": this.Nom, "XIDVaisseau":this.XIDVaisseau,
        "XIDAmelioration":this.XIDAmelioration,"XIDPilote":this.XIDPilote,
        "XIDUser":this.UserId,"XIDCamp":this.XIDCamp
      };
      console.log(this.objetCollection);
      this.collectionService.register(this.objetCollection)
          .pipe(first())
          .subscribe(
              data => {
                  this.alertService.success('Registration successful', true);
                  this.userService.getUserById(this.UserId).subscribe(heroes => (this.users = heroes));
                  this.router.navigate(['/inscrit/'+this.users.Nom]);
              },
              error => {
                  this.alertService.error(error);
              });
  }

  getCamps(): void{
    this.campService.getCamps()
    .subscribe(heroes => (this.camps = heroes));
  }

  viderChamp(){
    this.registerForm.value.Camp.clear;
    console.log("toto");
  }
  changement(evenement) {

   this.XIDCamp = evenement.value;
   this.campService.getCampById(this.XIDCamp)
    .subscribe(heroes => (this.changeCamps = heroes));
    this.registerForm.value.Camp = evenement.value;
    this.flag = 0;
  }
   
}
