import { Component, OnInit, Output } from '@angular/core';
import { User } from '../Models/user';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from '../Services/authentification.service';
import { AlertService } from '../Services/alert.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  providers: [User],
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  user:any;
  checkoutForm: any;
  //@Output(id);
  constructor(private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private authenticationService: AuthenticationService,
    private alertService: AlertService) { 

    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(['/']);
  }
  }


  ngOnInit(): void {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
  });

  // get return url from route parameters or default to '/'
  this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

 // convenience getter for easy access to form fields
 get f() { return this.loginForm.controls; }

 onSubmit() {
     this.submitted = true;

     // reset alerts on submit
     this.alertService.clear();

     // stop here if form is invalid
     if (this.loginForm.invalid) {
         return;
     }

     this.loading = true;
     this.authenticationService.login(this.f.username.value, this.f.password.value)
         .pipe(first())
         .subscribe(
             data => {
              console.log(JSON.parse(sessionStorage.currentUser));
                 this.router.navigate(['./inscrit/'+this.f.username.value]);
                 this.loading = false;
             },
             error => {
                 this.alertService.error(error);
                 this.loading = false;
             });
 }

}
