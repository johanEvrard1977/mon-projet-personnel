import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../Services/authentification.service';
import { AlertService } from '../Services/alert.service';
import { first } from 'rxjs/operators';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-pass-init',
  templateUrl: './pass-init.component.html',
  styleUrls: ['./pass-init.component.css']
})
export class PassInitComponent implements OnInit {

  registerForm: FormGroup;
  submitted = false;
  returnUrl: string;
  user:any;
  checkoutForm: any;
  users:any;
  loading = false;

  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private userService: UserService,
    private alertService: AlertService) { 

  }


  ngOnInit(): void {
    this.registerForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
  });
  let name = this.route.snapshot.paramMap.get('name');
        this.GetByUser(name);
  }

  GetByUser(name:string) {
    this.userService.getUserByName(name)
        .pipe(first())
        .subscribe(users => this.users = users);
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

     this.userService.update(this.registerForm.value, this.registerForm.value.username)
         .pipe(first())
         .subscribe(
             data => {
                 this.router.navigate(['./accueil/']);
                 this.loading = false;
             },
             error => {
                 this.alertService.error(error);
             });
 }

}
