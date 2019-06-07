import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdministrationRoutingModule } from './administration-routing.module';
import { AdminComponent } from '../admin/admin.component';
import { DashboardComponent } from '../dashboard/dashboard.component';
import { UsersComponent } from '../users/users.component';
import { UserComponent } from '../user/user.component';
import { RolesComponent } from '../roles/roles.component';
import { FormsModule } from '@angular/forms';
import { RoleComponent } from '../role/role.component';

import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';
import { SharedModule } from '../../shared/base/shared.module';
import { GlobalDirective } from 'src/app/_directives/global/global.directive';

@NgModule({
  declarations: [
    AdminComponent,
    DashboardComponent,
    UsersComponent,
    UserComponent,
    RolesComponent,
    RoleComponent
  ],
  imports: [
    FormsModule,
    CommonModule,
    AdministrationRoutingModule,
    NgMultiSelectDropDownModule.forRoot(),
    SharedModule
  ]
})
export class AdministrationModule { }
