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
import { DetailCollectionComponent } from './detail-collection/detail-collection.component';
import { CollectionComponent } from './collection/collection.component';
import { RegisterCollectionComponent } from './register-collection/register-collection.component';

const routes: Routes = [
  { path: 'action', component: ActionComponent },
  { path: 'action:/', component: ActionComponent },
  { path: 'amelioration', component: AmeliorationComponent },
  { path: 'amelioration/:Id', component: AmeliorationComponent },
  { path: 'collection/:Id', component: DetailCollectionComponent, canActivate: [AuthGardService] },
  { path: 'collection', component: CollectionComponent },
  { path: 'pilote', component: PiloteComponent },
  { path: 'pilote/:Id', component: PiloteComponent },
  { path: 'vaisseau', component: VaisseauComponent },
  { path: 'vaisseau/:Id', component: VaisseauComponent },
  { path: 'login', component: LoginComponent },
  { path: 'inscrit', component: InscritComponent },
  { path: 'inscrit/:name', component: InscritComponent, canActivate: [AuthGardService] },
  { path: 'registerCollection', component: RegisterCollectionComponent },
  { path: 'registerCollection/:Id', component: RegisterCollectionComponent },
  { path: 'register', component: RegisterComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
