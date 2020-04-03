import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule }      from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
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
import { DetailameliorationComponent } from './detail-amelioration/detail-amelioration.component'
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
  ],
  imports: [
    BrowserModule,
    FormsModule,
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
      { path: 'amelioration/:Id', component: DetailameliorationComponent },
      { path: 'amelioration', component: AmeliorationComponent },
      { path: 'pilote/:Id', component: DetailPiloteComponent },
      { path: 'pilote', component: PiloteComponent },
      { path: 'vaisseau/:Id', component: DetailVaisseauComponent },
      { path: 'vaisseau', component: VaisseauComponent },
      { path: 'login', component: LoginComponent },
      { path: 'inscrit', component: InscritComponent },
      { path: 'register', component: RegisterComponent },
    ])
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
    RegisterComponent,
    { 
      provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true
    },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptorService, multi: true
    },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
