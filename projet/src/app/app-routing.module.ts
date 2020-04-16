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
import { DetailEscadronComponent } from './detail-escadron/detail-escadron.component';
import { UpdateEscadronComponent } from './update-escadron/update-escadron.component';
import { AccueilComponent } from './accueil/accueil.component';
import { DetailPiloteComponent } from './detail-pilote/detail-pilote.component';
import { DetailActionComponent } from './detail-action/detail-action.component';
import { DetailVaisseauComponent } from './detail-vaisseau/detail-vaisseau.component';

const routes: Routes = [
  { path: '', component: AccueilComponent },
  { path: 'accueil', component: AccueilComponent },
  { path: 'action', component: ActionComponent },
  { path: 'action/:Id', component: DetailActionComponent },
  { path: 'amelioration', component: AmeliorationComponent },
  { path: 'amelioration/:Id', component: DetailAmeliorationBisComponent },
  { path: 'collection/:Id', component: DetailCollectionComponent, canActivate: [AuthGardService] },
  { path: 'collection', component: CollectionComponent, canActivate: [AuthGardService] },
  { path: 'escadron/:Id', canActivate: [AuthGardService], component: DetailEscadronComponent },
  { path: 'pilote', component: PiloteComponent },
  { path: 'pilote/:Id', component: DetailPiloteComponent },
  { path: 'vaisseau', component: VaisseauComponent },
  { path: 'vaisseau/:Id', component: DetailVaisseauComponent },
  { path: 'login', component: LoginComponent },
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
  { path: 'updateEscadron', canActivate: [AuthGardService], component: UpdateEscadronComponent },
  { path: 'updateEscadron/:Id', canActivate: [AuthGardService], component: UpdateEscadronComponent },
    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
