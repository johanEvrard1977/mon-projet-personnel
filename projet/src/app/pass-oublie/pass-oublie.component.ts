import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../Services/authentification.service';
import { UserService } from '../Services/user.service';
import { AlertService } from '../Services/alert.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-pass-oublie',
  templateUrl: './pass-oublie.component.html',
  styleUrls: ['./pass-oublie.component.css']
})
export class PassOublieComponent implements OnInit {

  registerForm: FormGroup;
    loading = false;
    submitted = false;
    currentUser: any;
    

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authenticationService: AuthenticationService,
        private userService: UserService,private route: ActivatedRoute,
        private alertService: AlertService
    ) {
        // redirect to home if already logged in
        if (this.authenticationService.currentUserValue) {
            this.currentUser = this.authenticationService.currentUserValue;
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            Mail: ['', Validators.required],
            username: ['', Validators.required],
        });
        
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

        this.loading = true;
        this.userService.checkUserForPass(this.registerForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Un mail vient de vous être envoyés', true);
                    this.router.navigate(['/accueil/']);
                },
                error => {
                    this.alertService.success('Mote de passe et/ou login incorrect', true);
                    this.alertService.error(error);
                    this.loading = false;
                });
    }
}