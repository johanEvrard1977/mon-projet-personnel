import { Component } from '@angular/core';
import { Router } from '@angular/router';

import { AuthenticationService } from './Services/authentification.service';
import { User } from './Models/user';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'projet';
  
}
