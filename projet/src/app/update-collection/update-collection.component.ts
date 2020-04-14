import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CollectionService } from '../Services/collection.service';
import { Vaisseau } from '../Models/vaisseau';
import { Pilote } from '../Models/pilote';
import { Amelioration } from '../Models/amelioration';
import { Camp } from '../Models/camp';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AlertService } from '../Services/alert.service';
import { CampService } from '../Services/camp.service';
import { UserService } from '../Services/user.service';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../Services/authentification.service';

@Component({
  selector: 'app-update-collection',
  templateUrl: './update-collection.component.html',
  styleUrls: ['./update-collection.component.css']
})
export class UpdateCollectionComponent implements OnInit {

  vaisseaux: Vaisseau[];
  pilotes: Pilote[];
  ameliorations:Amelioration[];
  Camp:Camp[];
  registerForm: FormGroup;
  submitted = false;
  XIDVaisseau:number;
  XIDPilote:number;
  XIDAmelioration:number;
  XIDCamp:number;
  XIDCollection:number;
  objetCollection:any;
  collections:any;
  camps:any;

  idCamp:any;
  currentUser: any;
  
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,private alertService: AlertService,
    private collectionService: CollectionService, private router:Router,
    private campService:CampService, private userService:UserService,
    private authenticationService: AuthenticationService) {
      this.currentUser = this.authenticationService.currentUserValue;
     }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      Nom: ['', Validators.required],
      Vaisseau: [''],
      Pilote: [''],
      Amelioration: [''],
      Camp: [''],
      Collection: [''],
  });
  
    let id = this.route.snapshot.paramMap.get('Id');
     this.collectionService.getcollectionById(id).subscribe(Collection => this.collections = Collection); 
     this.idCamp = 1;
     this.campService.getCampById(this.idCamp).subscribe(camps => this.camps = camps);
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
     this.XIDAmelioration = this.registerForm.value.Amelioration;
     this.XIDPilote = this.registerForm.value.Pilote;
     this.XIDCollection = this.registerForm.value.Collection;
     this.XIDCamp = this.registerForm.value.Camp;
     
     this.objetCollection = {
       "XIDVaisseau":this.XIDVaisseau,
       "XIDAmelioration":this.XIDAmelioration,"XIDPilote":this.XIDPilote,
       "XIDCollection":this.XIDCollection,"XIDCamp":this.XIDCamp
     };
     console.log(this.objetCollection);
     this.collectionService.registerIntoCollection(this.objetCollection)
         .pipe(first())
         .subscribe(
             data => {
                 this.alertService.success('Update successful', true);
                 this.collectionService.getcollectionById(this.collections).subscribe(heroes => (this.collections = heroes));
                // this.router.navigate(['/inscrit/'+this.collections.Nom]);
             },
             error => {
                 this.alertService.error(error);
             });
 }

 getCamps(): void{
   this.campService.getCamps()
   .subscribe(heroes => (this.Camp = heroes));
 }
  
}

