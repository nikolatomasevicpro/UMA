import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AuthGuard } from '../_guards/auth.guard';

import { HomeComponent } from '../_components/home/home.component';
import { LoginComponent } from '../_components/session/login/login.component';
import { PageNotFoundComponent } from '../_components/session/page-not-found/page-not-found.component';
import { RegisterComponent } from '../_components/session/register/register.component';
import { ProfileComponent } from '../_components/session/profile/profile.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'profile', component: ProfileComponent },
  // { path : '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
