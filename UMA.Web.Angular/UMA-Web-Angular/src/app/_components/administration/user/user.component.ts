import { ActivatedRoute } from '@angular/router';
import { Location } from '@angular/common';
import { Component, OnInit, Input } from '@angular/core';

import { UserService } from 'src/app/_services/_api/user/user.service';
import { RoleViewModel } from 'src/app/_entities/role/reponse/role.viewmodel';
import { RoleService } from 'src/app/_services/_api/role/role.service';
import { IdentityViewModel } from 'src/app/_entities/user/response/identity.viewmodel';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.sass']
})
export class UserComponent implements OnInit {
  @Input() user: IdentityViewModel;
  selectedRoles: RoleViewModel[];
  roles: RoleViewModel[];
  selectedItem: string;
  items: string[];
  ddSettings = {};
  selectionPlacehoder = 'Select a role';

  constructor(
    private route: ActivatedRoute,
    private location: Location,
    private userService: UserService,
    private roleService: RoleService
  ) { }

  ngOnInit() {
    this.getUser();
    this.ddSettings = {
      idField: 'id',
      textField: 'name'
    };
  }

  getUser() {
    const id = this.route.snapshot.paramMap.get('id');
    this.userService.getUser({id})
    .subscribe(response => {
      this.user = response;
      this.getRoles();
    });
  }

  getRoles() {
    this.roleService.getAllRoles({})
    .subscribe(response => {
      this.roles = response.roles;
      this.roleService.getRolesByIdentity({id: this.user.id})
      .subscribe(sResponse => this.selectedRoles = sResponse.roles);
    });
  }

  save(): void {
    this.userService.updateUser({id: this.user.id, login: this.user.login, password: null}).
    subscribe(() =>
      this.userService.setRoles({identity: this.user.id, roles: this.selectedRoles.map(e => e.id)})
      .subscribe(() => this.goBack()));
  }

  goBack(): void {
    this.location.back();
  }
}
