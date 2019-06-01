import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminComponent } from '../admin/admin.component';
import { UserComponent } from '../user/user.component';
import { UsersComponent } from '../users/users.component';
import { RolesComponent } from '../roles/roles.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { AuthGuard } from 'src/app/_guards/auth.guard';
import { AdminGuard } from 'src/app/_guards/admin.guard';
import { RoleComponent } from '../role/role.component';

const routes: Routes = [
  { path: 'admin', component: AdminComponent,
    canActivate: [AuthGuard, AdminGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard, AdminGuard] },
      { path: 'roles', component: RolesComponent, canActivate: [AuthGuard, AdminGuard]},
      { path: 'role/:id', component: RoleComponent, canActivate: [AuthGuard, AdminGuard]},
      { path: 'users', component: UsersComponent, canActivate: [AuthGuard, AdminGuard]},
      { path: 'user/:id', component: UserComponent, canActivate: [AuthGuard, AdminGuard]},
    ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdministrationRoutingModule { }
