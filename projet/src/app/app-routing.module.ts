import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ActionComponent } from './action/action.component';
import { AmeliorationComponent } from './amelioration/amelioration.component';
import { PiloteComponent } from './pilote/pilote.component';
import { VaisseauComponent } from './vaisseau/vaisseau.component';
import { LoginComponent } from './login/login.component';
import { InscritComponent } from './inscrit/inscrit.component';
import { RegisterComponent } from './register/register.component';
import { AuthGardService } from './Helpers/auth-gard.service';

const routes: Routes = [
  { path: 'action', component: ActionComponent },
  { path: 'amelioration', component: AmeliorationComponent },
  { path: 'pilote', component: PiloteComponent },
  { path: 'vaisseau', component: VaisseauComponent },
  { path: 'login', component: LoginComponent },
  { path: 'inscrit', component: InscritComponent, canActivate: [AuthGardService] },
  { path: 'register', component: RegisterComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
