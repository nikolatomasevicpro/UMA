import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { ToastrModule } from 'ngx-toastr';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { JwtInterceptor } from '../_helpers/interceptors/jwt.interceptor';

import { AppComponent } from './app-component/app.component';

import { LoginComponent } from '../_components/session/login/login.component';
import { HomeComponent } from '../_components/home/home.component';
import { PageNotFoundComponent } from '../_components/session/page-not-found/page-not-found.component';
import { AdministrationModule } from '../_components/administration/base/administration.module';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import { RegisterComponent } from '../_components/session/register/register.component';
import { ProfileComponent } from '../_components/session/profile/profile.component';
import { HeaderComponent } from '../_components/session/header/header.component';
import { FooterComponent } from '../_components/session/footer/footer.component';
import { GlobalDirective } from '../_directives/global/global.directive';
import { SharedModule } from '../_components/shared/base/shared.module';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HomeComponent,
    PageNotFoundComponent,
    RegisterComponent,
    ProfileComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    AdministrationModule,
    ToastrModule.forRoot(),
    AngularFontAwesomeModule,
    NgbModule,
    SharedModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
