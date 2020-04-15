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
import { UpdateCollectionComponent } from './update-collection/update-collection.component';
import { DetailAmeliorationBisComponent } from './detail-amelioration-bis/detail-amelioration-bis.component';
import { RegisterEscadronComponent } from './register-escadron/register-escadron.component';

const routes: Routes = [
  { path: 'action', component: ActionComponent, canActivate: [AuthGardService] },
  { path: 'action:/', component: ActionComponent, canActivate: [AuthGardService] },
  { path: 'amelioration', component: AmeliorationComponent, canActivate: [AuthGardService] },
  { path: 'amelioration/:Id', component: DetailAmeliorationBisComponent, canActivate: [AuthGardService] },
  { path: 'collection/:Id', component: DetailCollectionComponent, canActivate: [AuthGardService] },
  { path: 'collection', component: CollectionComponent, canActivate: [AuthGardService] },
  { path: 'pilote', component: PiloteComponent, canActivate: [AuthGardService] },
  { path: 'pilote/:Id', component: PiloteComponent, canActivate: [AuthGardService] },
  { path: 'vaisseau', component: VaisseauComponent, canActivate: [AuthGardService] },
  { path: 'vaisseau/:Id', component: VaisseauComponent, canActivate: [AuthGardService] },
  { path: 'login', component: LoginComponent, canActivate: [AuthGardService] },
  { path: 'inscrit', component: InscritComponent, canActivate: [AuthGardService] },
  { path: 'inscrit/:name', component: InscritComponent, canActivate: [AuthGardService] },
  { path: 'registerCollection', component: RegisterCollectionComponent, canActivate: [AuthGardService] },
  { path: 'registerCollection/:Id', component: RegisterCollectionComponent, canActivate: [AuthGardService] },
  { path: 'registerEscadron', component: RegisterEscadronComponent, canActivate: [AuthGardService] },
  { path: 'registerEscadron/:Id', component: RegisterEscadronComponent, canActivate: [AuthGardService] },
  { path: 'register', component: RegisterComponent, canActivate: [AuthGardService] },
  { path: 'updateCollection', component: UpdateCollectionComponent , canActivate: [AuthGardService] },
  { path: 'updateCollection/:Id', component: UpdateCollectionComponent, canActivate: [AuthGardService] },
  { path: 'updateCollection/:Id/:Id', component: UpdateCollectionComponent, canActivate: [AuthGardService] },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
