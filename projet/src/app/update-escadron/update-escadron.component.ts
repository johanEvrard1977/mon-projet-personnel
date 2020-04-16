import { Component, OnInit } from '@angular/core';
import { Vaisseau } from '../Models/vaisseau';
import { Pilote } from '../Models/pilote';
import { Amelioration } from '../Models/amelioration';
import { Camp } from '../Models/camp';
import { FormGroup, FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AlertService } from '../Services/alert.service';
import { EscadronService } from '../Services/escadron.service';
import { CampService } from '../Services/camp.service';
import { UserService } from '../Services/user.service';
import { AuthenticationService } from '../Services/authentification.service';
import { map, switchMap, first } from 'rxjs/operators';

@Component({
  selector: 'app-update-escadron',
  templateUrl: './update-escadron.component.html',
  styleUrls: ['./update-escadron.component.css']
})
export class UpdateEscadronComponent implements OnInit {

  vaisseaux: Vaisseau[];
  pilotes: Pilote[];
  ameliorations:Amelioration[];
  Camp:Camp[];
  registerForm: FormGroup;
  submitted = false;
  XIDVaisseau:number;
  XIDPilote:number;
  XIDAmelioration:number;
  XIDEscadron:number;
  objetEscadron:any;
  escadrons:any;
  camps:any;
  
  idCamp:any;
  currentUser: any;
  
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,private alertService: AlertService,
    private escadronService: EscadronService, private router:Router,
    private campService:CampService, private userService:UserService,
    private authenticationService: AuthenticationService) {
      this.currentUser = this.authenticationService.currentUserValue;
     }

  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      Vaisseau: [''],
      Pilote: [''],
      Amelioration: [''],
      Camp: [''],
      Escadron: [''],
  });
  
    let id = this.route.snapshot.paramMap.get('Id');
     this.escadronService.getescadronById(id)
     .pipe(map(col =>{ this.escadrons = col; return col.Camp[0].Id}))
     .pipe(switchMap(id => { 
       if(id !== null && id !== undefined){
       return this.campService.getCampById(id);
     }
    })).subscribe(ca =>{ this.camps = ca});
     
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
     this.XIDEscadron = this.registerForm.value.Escadron;
     
     this.objetEscadron = {
       "XIDVaisseau":this.XIDVaisseau,
       "XIDAmelioration":this.XIDAmelioration,"XIDPilote":this.XIDPilote,
       "XIDEscadron":this.XIDEscadron
     };
     console.log(this.objetEscadron);
     this.escadronService.registerIntoEscadron(this.objetEscadron)
         .pipe(first())
         .subscribe(
             data => {
                 this.alertService.success('Update successful', true);
                 this.escadronService.getescadronById(this.XIDEscadron).subscribe(heroes => (this.escadrons = heroes));
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

