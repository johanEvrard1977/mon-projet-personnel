import { Component, OnInit } from '@angular/core';
import { Vaisseau } from '../Models/vaisseau';
import { VaisseauService } from '../Services/vaisseau.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AlertService } from '../Services/alert.service';
import { EscadronService } from '../Services/escadron.service';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-register-escadron',
  templateUrl: './register-escadron.component.html',
  styleUrls: ['./register-escadron.component.css']
})
export class RegisterEscadronComponent implements OnInit {

  vaisseaux: Vaisseau[];
  registerForm: FormGroup;
  submitted = false;

  constructor(private formBuilder: FormBuilder,
    private router: Router,private vaisseauService: VaisseauService,
    private alertService: AlertService, private escadronService: EscadronService) { }

    ngOnInit(): void {
      this.registerForm = this.formBuilder.group({
        Nom: ['', Validators.required],
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
        this.escadronService.register(this.registerForm.value)
            .pipe(first())
            .subscribe(
                data => {
                    this.alertService.success('Registration successful', true);
                    this.router.navigate(['/login']);
                },
                error => {
                    this.alertService.error(error);
                });
    }
  
    getVaisseaux(): void {
      this.vaisseauService.getVaisseaux()
        .subscribe(heroes => (this.vaisseaux = heroes));
    }
  
  }
  