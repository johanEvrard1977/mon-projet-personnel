import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { HttpClientXsrfModule } from '@angular/common/http';
import { HttpClientModule, HTTP_INTERCEPTORS  } from '@angular/common/http';
import { MessageService } from './Services/message.service';
import { HttpErrorHandler } from './Services/http-error-handler.service';
import { ActionComponent } from './action/action.component';
import { DetailActionComponent } from './detail-action/detail-action.component';
import { ActionService } from './Services/action.service';
import { AmeliorationComponent } from './amelioration/amelioration.component';
import { AmeliorationService } from './Services/amelioration.service';
import { PiloteComponent } from './pilote/pilote.component';
import { PiloteService } from './Services/pilote.service';
import { DetailPiloteComponent } from './detail-pilote/detail-pilote.component';
import { VaisseauComponent } from './vaisseau/vaisseau.component';
import { DetailVaisseauComponent } from './detail-vaisseau/detail-vaisseau.component';
import { VaisseauService } from './Services/vaisseau.service';
import { AccueilComponent } from './accueil/accueil.component';
import { InscritComponent } from './inscrit/inscrit.component';
import { AlertComponent } from './alert/alert.component';
import { AlertService } from './Services/alert.service';
import { RegisterComponent } from './register/register.component';
import { JwtInterceptorService } from './Helpers/jwt-interceptor.service';
import { ErrorInterceptorService } from './Helpers/error-interceptor.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CollectionComponent } from './collection/collection.component';
import { DetailCollectionComponent } from './detail-collection/detail-collection.component';
import { RegisterCollectionComponent } from './register-collection/register-collection.component';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
import { UpdateCollectionComponent } from './update-collection/update-collection.component';
import { RegisterEscadronComponent } from './register-escadron/register-escadron.component';
import { CommonModule } from '@angular/common';
import { AuthGardService } from './Helpers/auth-gard.service';
import { DetailAmeliorationBisComponent } from './detail-amelioration-bis/detail-amelioration-bis.component';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    TopBarComponent,
    LoginComponent,
    ActionComponent,
    DetailActionComponent,
    AmeliorationComponent,
    PiloteComponent,
    DetailPiloteComponent,
    VaisseauComponent,
    DetailVaisseauComponent,
    AccueilComponent,
    InscritComponent,
    AlertComponent,
    RegisterComponent,
    CollectionComponent,
    DetailCollectionComponent,
    RegisterCollectionComponent,
    UpdateCollectionComponent,
    RegisterEscadronComponent,
    DetailAmeliorationBisComponent
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    MatButtonModule,
    MatDialogModule,
    CommonModule,
    // import HttpClientModule after BrowserModule.
    HttpClientModule,
    HttpClientXsrfModule.withOptions({
      cookieName: 'My-Xsrf-Cookie',
      headerName: 'My-Xsrf-Header',
    }),

    
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: AccueilComponent },
      { path: 'action/:Id', component: DetailActionComponent },
      { path: 'action', component: ActionComponent },
      { path: 'amelioration/:Id', component: DetailAmeliorationBisComponent },
      { path: 'amelioration', component: AmeliorationComponent },
      { path: 'collection/:Id', canActivate: [AuthGardService], component: DetailCollectionComponent },
      { path: 'collection', canActivate: [AuthGardService], component: CollectionComponent },
      { path: 'registerCollection', canActivate: [AuthGardService], component: RegisterCollectionComponent },
      { path: 'registerCollection/:Id', canActivate: [AuthGardService], component: RegisterCollectionComponent },
      { path: 'registerEscadron', canActivate: [AuthGardService], component: RegisterEscadronComponent },
      { path: 'registerEscadron/:Id', canActivate: [AuthGardService], component: RegisterEscadronComponent },
      { path: 'pilote/:Id', component: DetailPiloteComponent },
      { path: 'pilote', component: PiloteComponent },
      { path: 'vaisseau/:Id', component: DetailVaisseauComponent },
      { path: 'vaisseau', component: VaisseauComponent },
      { path: 'login', component: LoginComponent },
      { path: 'inscrit', canActivate: [AuthGardService], component: InscritComponent },
      { path: 'inscrit/:name', canActivate: [AuthGardService], component: InscritComponent },
      { path: 'register', canActivate: [AuthGardService], component: RegisterComponent },
      { path: 'updateCollection', canActivate: [AuthGardService], component: UpdateCollectionComponent },
      { path: 'updateCollection/:Id', canActivate: [AuthGardService], component: UpdateCollectionComponent },
    ]),
    BrowserAnimationsModule
  ],
  providers: [
    MessageService,
    HttpErrorHandler,
    ActionService,
    AmeliorationService,
    PiloteService,
    VaisseauService,
    LoginComponent,
    AlertService,
    InscritComponent,
    RegisterCollectionComponent,
    RegisterComponent,
    UpdateCollectionComponent,
    DetailAmeliorationBisComponent,
    RegisterEscadronComponent,
    { 
      provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true
    },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true
    },
  ],
  bootstrap: [AppComponent],
  
})
export class AppModule { }
